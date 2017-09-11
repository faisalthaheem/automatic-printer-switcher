using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrinterSwitcher
{
    public partial class frmAddMapping : Form
    {
        public Dictionary<string, Dictionary<string, string>> mMapped =
            new Dictionary<string, Dictionary<string, string>>();

        public PSProcessCollection mProcesses = new PSProcessCollection();

        private PSProcessCollection mExistingProcesses = null; 

        public frmAddMapping(PSProcessCollection existingProcesses)
        {
            InitializeComponent();
            mExistingProcesses = existingProcesses;
        }

        private void frmAddMapping_Load(object sender, EventArgs e)
        {
            rescan();
        }

        private void toolStripButtonRefreshList_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All mappings will be lost, continue?",
                "Warning!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            rescan();
        }

        private void rescan()
        {
            PSWindows ps = new PSWindows();
            if (!ps.scan())
            {
                MessageBox.Show("There was an error scanning the processes.",
                    "Scan processes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                lvProcessWindows.Groups.Clear();
                lvProcessWindows.BeginUpdate();

                foreach (string key in ps.mProcesses.Keys)
                {
                    if (mExistingProcesses.ContainsKey(key))
                    {
                        continue;
                    }

                    ListViewGroup grp = lvProcessWindows.Groups.Add(key, key);
                    grp.Tag = ps.mProcesses[key];
                }

                lvProcessWindows.EndUpdate();
            }
        }

        private void toolStripButtonSaveNClose_Click(object sender, EventArgs e)
        {
            lvProcessWindows.Enabled = false;

            foreach (ListViewGroup process in lvProcessWindows.Groups)
            {
                foreach (ListViewItem window in process.Items)
                {
                    if (window.SubItems.Count > 2)
                    {
                        PSProcess psprocess = (PSProcess)process.Tag;
                        if (!mProcesses.ContainsKey(psprocess.ProcessName))
                        {
                            mProcesses.Add(psprocess.ProcessName,psprocess);
                            
                        }
                    }                    
                }
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void assignPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (lvProcessWindows.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show(
            //        "Please choose a window first",
            //        "Map printer",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //    return;
            //}
            //frmPrinters printer = new frmPrinters();
            //if (printer.ShowDialog() == DialogResult.OK)
            //{
            //    lvProcessWindows.SelectedItems[0].SubItems.Add(printer.cmbPrinters.Text);
            //}
        }

        private void removeMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (lvProcessWindows.SelectedItems.Count == 0) return;
            //if (lvProcessWindows.SelectedItems[0].SubItems.Count > 2)
            //{
            //    lvProcessWindows.SelectedItems[0].SubItems.RemoveAt(2);
            //}
        }

        private void setProcessDefaultPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (lvProcessWindows.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show(
            //        "Please choose a window first",
            //        "Map printer",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //    return;
            //}
            //frmPrinters printer = new frmPrinters();
            //if (printer.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            //PSProcess process = (PSProcess)lvProcessWindows.SelectedItems[0].Group.Tag;

            //process.MappedPrinter = printer.cmbPrinters.Text;

            //lvProcessWindows.SelectedItems[0].Group.Header =
            //    string.Format("{0} [{1}]", process.ProcessName, process.MappedPrinter);

        }

        private void removeProcessDefaultPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProcessWindows.SelectedItems.Count == 0) return;
            lvProcessWindows.SelectedItems[0].Group.Header =
                ((PSProcess)lvProcessWindows.SelectedItems[0].Group.Tag).ProcessName;

            ((PSProcess)lvProcessWindows.SelectedItems[0].Group.Tag).MappedPrinter = string.Empty;

        }
    }
}
