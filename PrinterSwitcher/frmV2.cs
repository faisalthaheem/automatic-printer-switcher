using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Xml;
using System.Threading;
using Microsoft.Win32;
using System.Reflection;

namespace PrinterSwitcher
{
    public partial class frmV2 : Form
    {

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        static extern int GetWindowModuleFileName(int hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, ref int processID);

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SetDefaultPrinter(string Name);

        private string m_currForegroundProcess = string.Empty;
        private string mMapFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                    + "\\APS\\processPrinterMap.xml";

        private PSProcessCollection mProcesses = new PSProcessCollection();
        private PSWindows mProcessSnapshot = new PSWindows();
        private bool mShutdown = false;

        Font mBoldFont = new Font("Arial", 12.0f,FontStyle.Bold);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0011)
            {
                mShutdown = true;
            }
            base.WndProc(ref m);
        }

        public frmV2()
        {
            InitializeComponent();

        }


        private void frmV2_Load(object sender, EventArgs e)
        {

            //assign sort to list views
            lvProcesses.ListViewItemSorter = new ListViewColumnSorter();
            

            try
            {
                Thread updateCheck = new Thread(new ThreadStart(checkForUpdates));
                updateCheck.Start();
            }
            catch (Exception ex)
            {
            }
            
            //check to see if /tray was passed
            if (Environment.CommandLine.Contains("/tray"))
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(this.oneShot));
            }

            //load saved mapping
            loadMappings();

            //load processes
            refreshMapping();


            selfinfo selfi = new selfinfo();
            this.Text += " v" + selfi.AssemblyVersion;


        }

        public void oneShot(object o)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }

        private void loadMappings()
        {



            PSDB db = new PSDB();
            PSProcessCollection loadedData = db.loadProcesses();
            if (null == loadedData)
            {
                if (System.IO.File.Exists(db.mMapFilePath))
                {
                    MessageBox.Show(
                        "An error occured trying to load the saved mappings; this usually means corruption.",
                        "Loading saved mapping",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                mProcesses = loadedData;
            }

        }

        private void saveMappings()
        {
            PSDB db = new PSDB();
            if (!db.saveProcesses(mProcesses))
            {
                MessageBox.Show(
                    "An error occured while saving the mapping",
                    "Save mapping",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void shutdownAPS()
        {
            notifyIcon1.Visible = false;

            //tmrWindowCheck.Stop();
            saveMappings();

            Application.Exit();
            Process.GetCurrentProcess().Kill();

        }

        public void checkForUpdates()
        {
            try
            {
                selfinfo asm = new selfinfo();

                System.Net.WebClient verFile = new System.Net.WebClient();
                string sAvailableVer = verFile.DownloadString("http://www.computedsynergy.com/aps/meta/version.txt");

                int availableVersion = Convert.ToInt32(sAvailableVer.Replace(".", ""));
                int currentVersion = Convert.ToInt32(asm.AssemblyVersion.Replace(".", ""));

                if (availableVersion > currentVersion)
                {
                    setUpdatesAvailable(sAvailableVer);
                }
                else
                {
                    checkingForUpdatesToolStripMenuItem.Text = "No updates available.";
                }
            }
            catch (Exception ex)
            {
                checkingForUpdatesToolStripMenuItem.Text = "No updates available.";
            }
        }

        delegate void SetUpdatesAavailable(string version);

        private void setUpdatesAvailable(string version)
        {
            if (this.InvokeRequired)
            {
                SetUpdatesAavailable upa = new SetUpdatesAavailable(setUpdatesAvailable);
                this.Invoke(upa, new object[] { version });
            }
            else
            {
                checkingForUpdatesToolStripMenuItem.Text = "Download new version " + version;
                checkingForUpdatesToolStripMenuItem.ForeColor = Color.Green;
                checkingForUpdatesToolStripMenuItem.Enabled = true;
            }
        }

        private void frmV2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mShutdown)
            {
                //todo: Handle windows os shutdown here
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void frmV2_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                this.Visible = false;
            }
        }

        private void cntxtMnuNotifyIcon_Opening(object sender, CancelEventArgs e)
        {
            //Check key in run to see if this program is set to run
            try
            {
                RegistryKey run = Registry.CurrentUser.OpenSubKey(
                    "Software\\Microsoft\\Windows\\CurrentVersion\\run", true);
                if (null != run)
                {
                    string val = (string)run.GetValue("AutomaticPrinterSwitcher");
                    if (null != val)
                    {
                        automaticallyStartWhenILogOnToolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        automaticallyStartWhenILogOnToolStripMenuItem.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Automatic start configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (ShouldMinimizeOnStartup())
            {
                alwaysMinimizeToTrayOnStartupToolStripMenuItem.Checked = true;
            }
            else
            {
                alwaysMinimizeToTrayOnStartupToolStripMenuItem.Checked = false;
            }

        }

        private bool ShouldMinimizeOnStartup()
        {
            bool bRet = false;
            try
            {
                RegistryKey aps = Registry.CurrentUser.OpenSubKey(
                    "Software\\Computed Synergy\\APS", true);
                if (null != aps)
                {
                    string val = (string)aps.GetValue("MinimizeOnStartup");
                    if (null != val)
                    {
                        bRet = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Automatic start configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bRet;

        }

        private void SetMinimizeOnStartup(bool delete)
        {
            try
            {
                RegistryKey aps = Registry.CurrentUser.OpenSubKey(
                    "Software\\Computed Synergy\\APS", true);
                if (null != aps)
                {
                    if (delete)
                    {
                        aps.DeleteValue("MinimizeOnStartup");
                    }
                    else
                    {
                        aps.SetValue("MinimizeOnStartup", "true");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Automatic start configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void automaticallyStartWhenILogOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey run = Registry.CurrentUser.OpenSubKey(
                    "Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (null != run)
                {
                    if (!automaticallyStartWhenILogOnToolStripMenuItem.Checked)
                    {
                        string assembly = string.Format("\"{0}\" /tray", Assembly.GetExecutingAssembly().Location);
                        run.SetValue("AutomaticPrinterSwitcher", assembly, RegistryValueKind.String);
                        automaticallyStartWhenILogOnToolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        run.DeleteValue("AutomaticPrinterSwitcher");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Automatic start configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void alwaysMinimizeToTrayOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (alwaysMinimizeToTrayOnStartupToolStripMenuItem.Checked)
            {
                SetMinimizeOnStartup(true);
                alwaysMinimizeToTrayOnStartupToolStripMenuItem.Checked = false;
            }
            else
            {
                SetMinimizeOnStartup(false);
                alwaysMinimizeToTrayOnStartupToolStripMenuItem.Checked = true;
            }
        }

        private void contactComputedSynergyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:info@computedsynergy.com");
        }

        private void reportBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:support@computedsynergy.com");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frmAbt = new AboutBox();
            frmAbt.ShowDialog(this);
        }

        private void restoreAPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }

        private void checkingForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.computedsynergy.com/aps/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("We could not start automatic download of new version.\nPlease visit http://www.computedsynergy.com/aps to download it manually");
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shutdownAPS();
        }

        private void specialOfferContextMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start((string)specialOfferContextMenuItem.Tag);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.. please use the contact us option to notify us of this problem.",
                    "Ooops",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        
        }


        private void refreshMapping()
        {
            stopTimers();

            //populate currently running processes
            mProcessSnapshot.scan();

            //populate currently running processes
            refreshProcessList();

            //highlight those which are mapped
            mapProcessList();

            //sort
            ListViewColumnSorter sorter = (ListViewColumnSorter)lvProcesses.ListViewItemSorter;
            sorter.SortColumn = 0;
            sorter.Order = SortOrder.Ascending;
            lvProcesses.Sort();

            startTimers();
        }

        /// <summary>
        /// Updates the process list to reflect the result of recent process scan
        /// 
        /// </summary>
        private void refreshProcessList()
        {
            int selectedIndex = 0;
            if (lvProcesses.SelectedItems.Count > 0)
            {
                selectedIndex= lvProcesses.SelectedItems[0].Index;
            }

            lvProcesses.Enabled = false;
            lvProcesses.BeginUpdate();

            lvProcesses.Items.Clear();

            foreach (string process in mProcessSnapshot.mProcesses.Keys)
            {
                ListViewItem lvi = lvProcesses.Items.Add(process,process,0);
                lvi.SubItems.Add("");
                lvi.SubItems.Add("");
            }

            lvProcesses.EndUpdate();
            lvProcesses.Enabled = true;

            if (selectedIndex < lvProcesses.Items.Count)
            {
                lvProcesses.SelectedIndices.Add(selectedIndex);
                lvProcesses.SelectedItems[0].EnsureVisible();
            }
        }

        /// <summary>
        /// Updates the columns to reflect if any printers have been selected as default for the processes
        /// </summary>
        private void mapProcessList()
        {
            foreach (string mappedProcess in mProcesses.Keys)
            {
                ListViewItem[] lvis = lvProcesses.Items.Find(mappedProcess, false);
                if (lvis.Length > 0)
                {
                    lvis[0].Font = mBoldFont;
                    lvis[0].SubItems[1].Text = mProcesses[mappedProcess].MappedPrinter;
                }
            }
        }


        /// <summary>
        /// Called when a user clicks on a process in the process list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lvProcesses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewColumnSorter sorter = (ListViewColumnSorter)lvProcesses.ListViewItemSorter;
            if (e.Column == sorter.SortColumn)
            {
                switch (sorter.Order)
                {
                    case SortOrder.Ascending:
                        sorter.Order = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        sorter.Order = SortOrder.Ascending;
                        break;
                    default:
                        sorter.Order = SortOrder.Ascending;
                        break;
                }
            }
            else
            {
                sorter.SortColumn = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            lvProcesses.Sort();
        }

        private void cntxtMnuProcesses_Opening(object sender, CancelEventArgs e)
        {
            if (lvProcesses.SelectedItems.Count == 0) return;
            if (lvProcesses.SelectedItems[0].Font.Bold)
            {
                removeMappingToolStripMenuItem.Enabled = true;
            }
            else
            {
                removeMappingToolStripMenuItem.Enabled = false;
            }
        }

        private void editMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvProcesses.SelectedItems.Count == 0) return;

            string processName = lvProcesses.SelectedItems[0].Text;
            frmPrinters printers = new frmPrinters(processName) ;
            if (printers.ShowDialog() != DialogResult.OK) return;

            stopTimers();

            //update listview
            lvProcesses.BeginUpdate();
            lvProcesses.SelectedItems[0].SubItems[1].Text = printers.SelectedPrinter;
            lvProcesses.SelectedItems[0].Font = mBoldFont;
            lvProcesses.EndUpdate();

            //update process map
            if (!mProcesses.Keys.Contains(processName))
            {
                mProcesses[processName] = mProcessSnapshot.mProcesses[processName];
            }

            mProcesses[processName].MappedPrinter = printers.SelectedPrinter;

            saveMappings();

            startTimers();
        }

        private void removeMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProcesses.SelectedItems.Count == 0) return;
            string processName = lvProcesses.SelectedItems[0].Text;

            if (MessageBox.Show("Are you sure you want to remove the mapping for process: " + processName + "?",
                "Remove mapping", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            stopTimers();

            //update listview
            lvProcesses.BeginUpdate();

            lvProcesses.SelectedItems[0].Font = lvProcesses.Font;
            lvProcesses.SelectedItems[0].SubItems.RemoveAt(1);

            lvProcesses.EndUpdate();


            //update printers mapping
            if (mProcesses.Keys.Contains(processName))
            {
                mProcesses.Remove(processName);
            }

            saveMappings();

            startTimers();

        }

        private void stopTimers()
        {
            tmrWindowCheck.Stop();
        }

        private void startTimers()
        {
            tmrWindowCheck.Start();
        }

        private void cntxtMnuWindows_Opening(object sender, CancelEventArgs e)
        {
            if (lvProcesses.SelectedItems.Count == 0) return;
        }

        private void editMappingWindow_Click(object sender, EventArgs e)
        {
            if (lvProcesses.SelectedItems.Count == 0) return;

            string processName = lvProcesses.SelectedItems[0].Text;

            frmPrinters printers = new frmPrinters(processName);
            if (printers.ShowDialog() != DialogResult.OK) return;

            stopTimers();

            //update process map
            if (!mProcesses.Keys.Contains(processName))
            {
                mProcesses[processName] = mProcessSnapshot.mProcesses[processName];
            }
            
            saveMappings();

            startTimers();

        }

        private void removeMappingWindow_Click(object sender, EventArgs e)
        {
            if (lvProcesses.SelectedItems.Count == 0) return;

            string processName = lvProcesses.SelectedItems[0].Text;

            if (MessageBox.Show("Are you sure you want to remove the mapping for window: " + processName + "?",
                "Remove mapping", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            stopTimers();

            saveMappings();

            startTimers();
        }

        private void tmrWindowCheck_Tick(object sender, EventArgs e)
        {
            tmrWindowCheck.Enabled = false;

            try
            {
                //get the foreground window
                int fgWindow = GetForegroundWindow();

                //get the process for this window
                int processID = 0;
                GetWindowThreadProcessId(fgWindow, ref processID);

                bool checkChange = false;
                Process process = Process.GetProcessById(processID);
                Console.Write("[{0}] ", process.ProcessName);

                if (mProcesses.ContainsKey(process.ProcessName) &&
                    m_currForegroundProcess != process.ProcessName)
                {
                    
                    checkChange = true;
                    Console.WriteLine("FG WINDOW: Check change");
                }
                //set to default printer only if current foreground process is not the one with the focus, in which case we have
                //a program that is not mapped
                if(!checkChange && m_currForegroundProcess != process.ProcessName)
                {
                    //set system default printer
                    SetDefaultPrinter(mProcesses.mSysDefPrinter);
                }
                
                m_currForegroundProcess = process.ProcessName;

                //do we need to change the printer?
                if (checkChange)
                {
                    if (mProcesses[process.ProcessName].MappedPrinter.Length > 0)
                    {
                        //Do we have a general printer mapped for this process?
                        SetDefaultPrinter(mProcesses[process.ProcessName].MappedPrinter);
                    }
                    else
                    {
                        //Use the system default
                        SetDefaultPrinter(mProcesses.mSysDefPrinter);
                    }
                }
            }
            catch (Exception ex)
            {
                //exceptions can occur
            }

            tmrWindowCheck.Enabled = true;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            refreshMapping();
        }

        private void tsbDefaultPrinter_Click(object sender, EventArgs e)
        {
            frmPrinters printers = new frmPrinters("Default printer");
            if (printers.ShowDialog() != DialogResult.OK) return;

            mProcesses.mSysDefPrinter = printers.SelectedPrinter;

            lblStatus.Text = "Changed default printer to " + printers.SelectedPrinter;

            saveMappings();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/faisalthaheem/automatic-printer-switcher");
            }
            catch (Exception eX)
            {
            }
        }
    }
}
