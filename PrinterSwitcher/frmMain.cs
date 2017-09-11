using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Xml;
using System.Threading;
using Microsoft.Win32;
using System.Reflection;
using AdvancedDataGridView;
using AdvancedDataGridView.Properties;

namespace PrinterSwitcher
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		[ DllImport("user32.dll") ]
		static extern int GetForegroundWindow();

		[ DllImport("user32.dll") ]
		static extern int GetWindowText(int hWnd, StringBuilder text, int count);

		[ DllImport("user32.dll") ]
		static extern int GetWindowModuleFileName(int hWnd, StringBuilder text, int count);

		[ DllImport("user32.dll") ]
		static extern int GetWindowThreadProcessId(int hWnd, ref int processID);
		
		[DllImport("winspool.drv", CharSet=CharSet.Auto, SetLastError=true)]
		static extern bool SetDefaultPrinter(string Name);
		
		private string m_currForegroundProcess = string.Empty;
        //private string m_defaultPrinterName = string.Empty;
        private System.Windows.Forms.Timer tmrWindowCheck;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip cntxtMnuNotifyIcon;
        private ToolStripMenuItem restoreAPSToolStripMenuItem;
        private ToolStripMenuItem contactComputedSynergyToolStripMenuItem;
        private ToolStripMenuItem reportBugToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolTip tipHelp;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem checkingForUpdatesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem startupOptionsToolStripMenuItem;
        private ToolStripMenuItem automaticallyStartWhenILogOnToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem alwaysMinimizeToTrayOnStartupToolStripMenuItem;
        private ContextMenuStrip cntxtMnuLVMappings;
        private ToolStripMenuItem editMappingToolStripMenuItem;


        private string mMapFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                    + "\\APS\\processPrinterMap.xml";
        private AdvancedDataGridView.TreeGridView gvMapping;
        private ToolStrip tsTop;
        private ImageList ilGV;
        private TreeGridColumn processWindowCol;
        private DataGridViewLinkColumn mappedPrinterCol;

        private PSProcessCollection mProcesses = new PSProcessCollection();
        private ToolStripMenuItem removeMappingToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsbChangeDefaultPrinter;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblLastAction;
        private ToolStripStatusLabel lblDefaultPrinter;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private PSWindows mProcessSnapshot = new PSWindows();
        private ToolStripMenuItem specialOfferContextMenuItem;

        private bool mShutdown = false;

		public frmMain()
		{

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            notifyIcon1.Visible = true;
 
            //check to see if /tray was passed
            if (Environment.CommandLine.Contains("/tray"))
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(this.oneShot));
            }


		}

        public void oneShot(object o)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cntxtMnuLVMappings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrWindowCheck = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cntxtMnuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkingForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactComputedSynergyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreAPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startupOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticallyStartWhenILogOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysMinimizeToTrayOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.gvMapping = new AdvancedDataGridView.TreeGridView();
            this.processWindowCol = new AdvancedDataGridView.TreeGridColumn();
            this.mappedPrinterCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ilGV = new System.Windows.Forms.ImageList(this.components);
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbChangeDefaultPrinter = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDefaultPrinter = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.specialOfferContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtMnuLVMappings.SuspendLayout();
            this.cntxtMnuNotifyIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMapping)).BeginInit();
            this.tsTop.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cntxtMnuLVMappings
            // 
            this.cntxtMnuLVMappings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMappingToolStripMenuItem,
            this.removeMappingToolStripMenuItem});
            this.cntxtMnuLVMappings.Name = "cntxtMnuLVMappings";
            this.cntxtMnuLVMappings.Size = new System.Drawing.Size(169, 48);
            this.cntxtMnuLVMappings.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMnuLVMappings_Opening);
            // 
            // editMappingToolStripMenuItem
            // 
            this.editMappingToolStripMenuItem.Name = "editMappingToolStripMenuItem";
            this.editMappingToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.editMappingToolStripMenuItem.Text = "Edit mapping";
            this.editMappingToolStripMenuItem.Click += new System.EventHandler(this.editMappingToolStripMenuItem_Click);
            // 
            // removeMappingToolStripMenuItem
            // 
            this.removeMappingToolStripMenuItem.Name = "removeMappingToolStripMenuItem";
            this.removeMappingToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.removeMappingToolStripMenuItem.Text = "Remove mapping";
            this.removeMappingToolStripMenuItem.Click += new System.EventHandler(this.removeMappingToolStripMenuItem_Click);
            // 
            // tmrWindowCheck
            // 
            this.tmrWindowCheck.Tick += new System.EventHandler(this.tmrWindowCheck_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Right click to show options, double click to restore.";
            this.notifyIcon1.BalloonTipTitle = "Automatic Printer Switcher";
            this.notifyIcon1.ContextMenuStrip = this.cntxtMnuNotifyIcon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Automatic Printer Switcher v1.0";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // cntxtMnuNotifyIcon
            // 
            this.cntxtMnuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.specialOfferContextMenuItem,
            this.checkingForUpdatesToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem,
            this.contactComputedSynergyToolStripMenuItem,
            this.reportBugToolStripMenuItem,
            this.toolStripSeparator3,
            this.restoreAPSToolStripMenuItem,
            this.toolStripSeparator1,
            this.startupOptionsToolStripMenuItem,
            this.toolStripSeparator5,
            this.quitToolStripMenuItem});
            this.cntxtMnuNotifyIcon.Name = "cntxtMnuNotifyIcon";
            this.cntxtMnuNotifyIcon.Size = new System.Drawing.Size(222, 226);
            this.cntxtMnuNotifyIcon.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMnuNotifyIcon_Opening);
            // 
            // checkingForUpdatesToolStripMenuItem
            // 
            this.checkingForUpdatesToolStripMenuItem.Enabled = false;
            this.checkingForUpdatesToolStripMenuItem.Name = "checkingForUpdatesToolStripMenuItem";
            this.checkingForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.checkingForUpdatesToolStripMenuItem.Text = "Checking for updates";
            this.checkingForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkingForUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // contactComputedSynergyToolStripMenuItem
            // 
            this.contactComputedSynergyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contactComputedSynergyToolStripMenuItem.Image")));
            this.contactComputedSynergyToolStripMenuItem.Name = "contactComputedSynergyToolStripMenuItem";
            this.contactComputedSynergyToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.contactComputedSynergyToolStripMenuItem.Text = "Contact Computed Synergy";
            this.contactComputedSynergyToolStripMenuItem.Click += new System.EventHandler(this.contactComputedSynergyToolStripMenuItem_Click);
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.reportBugToolStripMenuItem.Text = "Report bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(218, 6);
            // 
            // restoreAPSToolStripMenuItem
            // 
            this.restoreAPSToolStripMenuItem.Name = "restoreAPSToolStripMenuItem";
            this.restoreAPSToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.restoreAPSToolStripMenuItem.Text = "Restore APS";
            this.restoreAPSToolStripMenuItem.Click += new System.EventHandler(this.restoreAPSToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // startupOptionsToolStripMenuItem
            // 
            this.startupOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticallyStartWhenILogOnToolStripMenuItem,
            this.alwaysMinimizeToTrayOnStartupToolStripMenuItem});
            this.startupOptionsToolStripMenuItem.Name = "startupOptionsToolStripMenuItem";
            this.startupOptionsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.startupOptionsToolStripMenuItem.Text = "Startup Options";
            // 
            // automaticallyStartWhenILogOnToolStripMenuItem
            // 
            this.automaticallyStartWhenILogOnToolStripMenuItem.Name = "automaticallyStartWhenILogOnToolStripMenuItem";
            this.automaticallyStartWhenILogOnToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.automaticallyStartWhenILogOnToolStripMenuItem.Text = "Automatically start when I log on";
            this.automaticallyStartWhenILogOnToolStripMenuItem.Click += new System.EventHandler(this.automaticallyStartWhenILogOnToolStripMenuItem_Click);
            // 
            // alwaysMinimizeToTrayOnStartupToolStripMenuItem
            // 
            this.alwaysMinimizeToTrayOnStartupToolStripMenuItem.Name = "alwaysMinimizeToTrayOnStartupToolStripMenuItem";
            this.alwaysMinimizeToTrayOnStartupToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.alwaysMinimizeToTrayOnStartupToolStripMenuItem.Text = "Always minimize to tray on startup";
            this.alwaysMinimizeToTrayOnStartupToolStripMenuItem.Visible = false;
            this.alwaysMinimizeToTrayOnStartupToolStripMenuItem.Click += new System.EventHandler(this.alwaysMinimizeToTrayOnStartupToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(218, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // tipHelp
            // 
            this.tipHelp.AutomaticDelay = 250;
            this.tipHelp.IsBalloon = true;
            this.tipHelp.ShowAlways = true;
            this.tipHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipHelp.ToolTipTitle = "Help";
            // 
            // gvMapping
            // 
            this.gvMapping.AllowUserToAddRows = false;
            this.gvMapping.AllowUserToDeleteRows = false;
            this.gvMapping.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.gvMapping.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvMapping.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.processWindowCol,
            this.mappedPrinterCol});
            this.gvMapping.ContextMenuStrip = this.cntxtMnuLVMappings;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvMapping.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMapping.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvMapping.ImageList = this.ilGV;
            this.gvMapping.Location = new System.Drawing.Point(0, 25);
            this.gvMapping.MultiSelect = false;
            this.gvMapping.Name = "gvMapping";
            this.gvMapping.RowHeadersVisible = false;
            this.gvMapping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMapping.ShowLines = false;
            this.gvMapping.Size = new System.Drawing.Size(683, 330);
            this.gvMapping.TabIndex = 2;
            this.gvMapping.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMapping_CellContentClick);
            // 
            // processWindowCol
            // 
            this.processWindowCol.DefaultNodeImage = null;
            this.processWindowCol.HeaderText = "Process/Window";
            this.processWindowCol.Name = "processWindowCol";
            this.processWindowCol.ReadOnly = true;
            this.processWindowCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mappedPrinterCol
            // 
            this.mappedPrinterCol.HeaderText = "Mapped Printer";
            this.mappedPrinterCol.Name = "mappedPrinterCol";
            this.mappedPrinterCol.ReadOnly = true;
            // 
            // ilGV
            // 
            this.ilGV.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilGV.ImageStream")));
            this.ilGV.TransparentColor = System.Drawing.Color.Transparent;
            this.ilGV.Images.SetKeyName(0, "Process.ico");
            this.ilGV.Images.SetKeyName(1, "small.ico");
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.tsbChangeDefaultPrinter});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(683, 25);
            this.tsTop.TabIndex = 3;
            this.tsTop.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton1.Text = "Refresh list";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbChangeDefaultPrinter
            // 
            this.tsbChangeDefaultPrinter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbChangeDefaultPrinter.Image = ((System.Drawing.Image)(resources.GetObject("tsbChangeDefaultPrinter.Image")));
            this.tsbChangeDefaultPrinter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbChangeDefaultPrinter.Name = "tsbChangeDefaultPrinter";
            this.tsbChangeDefaultPrinter.Size = new System.Drawing.Size(130, 22);
            this.tsbChangeDefaultPrinter.Text = "Change default printer";
            this.tsbChangeDefaultPrinter.Click += new System.EventHandler(this.tsbChangeDefaultPrinter_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblDefaultPrinter,
            this.lblLastAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 355);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(683, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel1.Text = "Default printer: ";
            // 
            // lblDefaultPrinter
            // 
            this.lblDefaultPrinter.Name = "lblDefaultPrinter";
            this.lblDefaultPrinter.Size = new System.Drawing.Size(0, 17);
            // 
            // lblLastAction
            // 
            this.lblLastAction.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblLastAction.Name = "lblLastAction";
            this.lblLastAction.Size = new System.Drawing.Size(4, 17);
            // 
            // specialOfferContextMenuItem
            // 
            this.specialOfferContextMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.specialOfferContextMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialOfferContextMenuItem.ForeColor = System.Drawing.Color.Red;
            this.specialOfferContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("specialOfferContextMenuItem.Image")));
            this.specialOfferContextMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.specialOfferContextMenuItem.Name = "specialOfferContextMenuItem";
            this.specialOfferContextMenuItem.Size = new System.Drawing.Size(221, 22);
            this.specialOfferContextMenuItem.Visible = false;
            this.specialOfferContextMenuItem.Click += new System.EventHandler(this.specialOfferContextMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(683, 377);
            this.Controls.Add(this.gvMapping);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APS ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.cntxtMnuLVMappings.ResumeLayout(false);
            this.cntxtMnuNotifyIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMapping)).EndInit();
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion




		private void frmMain_Load(object sender, System.EventArgs e)
		{
            loadMappings();
            if (gvMapping.Nodes.Count == 0)
            {
                refreshMappings();
            }
            tmrWindowCheck.Start();

            selfinfo selfi = new selfinfo();
            this.Text += " v" + selfi.AssemblyVersion;

            try
            {
                Thread updateCheck = new Thread(new ThreadStart(checkForUpdates));
                updateCheck.Start();
            }
            catch (Exception ex)
            {
            }

            try
            {
                Thread offerCheck = new Thread(new ThreadStart(checkForOffer));
                offerCheck.Start();
            }
            catch (Exception ex)
            {
            }

		}

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0011)
            {
                mShutdown = true;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Loads all processes currently running and mapped into the view
        /// 
        /// </summary>
		private void loadMappings()
        {



            PSDB db = new PSDB();
            PSProcessCollection loadedData = db.loadProcesses();
            if (null == loadedData)
            {
                if (System.IO.File.Exists(db.mMapFilePath))
                {
                    MessageBox.Show(
                        "An error occured while loading the saved mapping",
                        "Loading mapping",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                mProcesses = loadedData;
                refreshMappings();
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


		private void tmrWindowCheck_Tick(object sender, System.EventArgs e)
		{
            tmrWindowCheck.Enabled = false;

			try
			{
				//get the foreground window
				int fgWindow = GetForegroundWindow();

				//get the process for this window
				int processID =0;
				GetWindowThreadProcessId(fgWindow, ref processID);

                bool checkChange = false;
				Process process = Process.GetProcessById(processID);

                //If the active window is an MDI container then we have to check everytime
                if (mProcesses.ContainsKey(process.ProcessName)
                    && mProcesses[process.ProcessName].ISMDIContainer == true)
                {
                    checkChange = true;
                }
                else if (mProcesses.ContainsKey(process.ProcessName) &&
                    m_currForegroundProcess != process.ProcessName)
                {
                    //else we check if active window has changed
                    m_currForegroundProcess = process.ProcessName;
                    checkChange = true;
                }
                else
                {
                    //set system default printer
                    SetDefaultPrinter(mProcesses.mSysDefPrinter);

                    m_currForegroundProcess = process.ProcessName;
                }
                
				//do we need to change the printer?
				if(checkChange)
				{
                    if (mProcesses[process.ProcessName].ISMDIContainer)
                    {
                        PSWindows cWindows = new PSWindows();
                        string title = cWindows.getActiveMDIChildTitle(process.MainWindowHandle);
                        if (title != string.Empty)
                        {
                            if (mProcesses[process.ProcessName].WindowMapping.ContainsKey(title))
                            {
                                SetDefaultPrinter(mProcesses[process.ProcessName].WindowMapping[title]);
                            }
                            else if (mProcesses[process.ProcessName].MappedPrinter.Length > 0)
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
                        else if (mProcesses[process.ProcessName].MappedPrinter.Length > 0)
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
                    else
                    {
                        StringBuilder wndTitle = new StringBuilder(2048);
                        GetWindowText(fgWindow, wndTitle, 2048);

                        //Do we have a specific window mapping for this process?
                        if (wndTitle.ToString().Length > 0 &&
                            mProcesses[process.ProcessName].WindowMapping.ContainsKey(wndTitle.ToString()))
                        {
                            SetDefaultPrinter(mProcesses[process.ProcessName].WindowMapping[wndTitle.ToString()]);
                        }
                        else if (mProcesses[process.ProcessName].MappedPrinter.Length > 0)
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
			}
			catch(Exception ex)
			{
				//exceptions can occur
			}

            tmrWindowCheck.Enabled = true;
		}

        private void restoreAPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                this.Visible = false;
                //notifyIcon1.ShowBalloonTip(300, "Automatic Printer Switcher", "Automatic Printer Switcher is running.\nRigh click this icon for options", ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            restoreAPSToolStripMenuItem_Click(null, null);
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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shutdownAPS();
        }

        private void shutdownAPS()
        {
            notifyIcon1.Visible = false;

            tmrWindowCheck.Stop();
            saveMappings();

            Application.Exit();
            Process.GetCurrentProcess().Kill();

        }

        public void checkForOffer()
        {
            try
            {
                System.Net.WebClient client = new System.Net.WebClient();
                string downloadedString = client.DownloadString("http://www.computedsynergy.com/aps/meta/offer.txt");

                string[] offerInfo = downloadedString.Split(new char[] { '|' });
                specialOfferContextMenuItem.Text = offerInfo[0];
                specialOfferContextMenuItem.Tag = offerInfo[1];
                specialOfferContextMenuItem.Visible = true;

            }
            catch (Exception ex)
            {
                checkingForUpdatesToolStripMenuItem.Text = "No updates available.";
            }
        }

        public void checkForUpdates()
        {
            try
            {
                selfinfo asm = new selfinfo();

                System.Net.WebClient verFile = new System.Net.WebClient();
                string sAvailableVer = verFile.DownloadString("http://www.computedsynergy.com/aps/meta/version.txt");

                int availableVersion = Convert.ToInt32(sAvailableVer.Replace(".",""));
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
                this.Invoke(upa, new object[] {version});
            }
            else
            {
                checkingForUpdatesToolStripMenuItem.Text = "Download new version " + version;
                checkingForUpdatesToolStripMenuItem.ForeColor = Color.Green;
                checkingForUpdatesToolStripMenuItem.Enabled = true;
            }
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
        private void cntxtMnuNotifyIcon_Opening(object sender, CancelEventArgs e)
        {
            //Check key in run to see if this program is set to run
            try
            {
                RegistryKey run = Registry.CurrentUser.OpenSubKey(
                    "Software\\Microsoft\\Windows\\CurrentVersion\\run", true);
                if (null != run)
                {
                    string val = (string)run.GetValue("Automatic Printer Switcher");
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
                        run.SetValue("Automatic Printer Switcher", assembly, RegistryValueKind.String);
                        automaticallyStartWhenILogOnToolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        run.DeleteValue("Automatic Printer Switcher");
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

        private void editMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvMapping.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a program from the list first",
                    "Change printer",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Font boldFont = new Font(gvMapping.DefaultCellStyle.Font, FontStyle.Bold);

            
            string processName = string.Empty;
            string windowName = string.Empty;
            bool isProcess = gvMapping.CurrentNode.HasChildren;

            if (isProcess)
            {
                processName = (string)gvMapping.CurrentNode.Cells[0].Value;
            }
            else
            {
                processName = (string)gvMapping.CurrentNode.Parent.Cells[0].Value;
                windowName = (string)gvMapping.CurrentNode.Cells[0].Value;
            }
            

            frmPrinters printers = new frmPrinters(processName);
            if (printers.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            tmrWindowCheck.Stop();

            if (isProcess)
            {
                if (!mProcesses.ContainsKey(processName))
                {
                    mProcesses[processName] = new PSProcess(
                        processName, mProcessSnapshot.mProcesses[processName].ISMDIContainer);
                }

                mProcesses[processName].MappedPrinter = printers.SelectedPrinter;
                gvMapping.CurrentNode.Cells[1].Value = printers.SelectedPrinter;
                lblLastAction.Text = string.Format("Mapped [{0}] to process [{1}]",
                    printers.SelectedPrinter, processName);
            }
            else
            {
                if (!mProcesses.ContainsKey(processName))
                {
                    mProcesses[processName] = new PSProcess(
                        processName, mProcessSnapshot.mProcesses[processName].ISMDIContainer);
                    mProcesses[processName].MappedPrinter = "";
                }
                mProcesses[processName].WindowMapping[windowName] = printers.SelectedPrinter;
                gvMapping.CurrentNode.Cells[1].Value = printers.SelectedPrinter;
                lblLastAction.Text = string.Format("Mapped [{0}] to [{1}]'s window [{2}]",
                    printers.SelectedPrinter, processName, windowName);
            }

            gvMapping.CurrentNode.DefaultCellStyle.Font = boldFont;


            saveMappings();
            tmrWindowCheck.Start();

        }

        
        //private void setDefaultPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmPrinters printers = new frmPrinters();

        //    if (printers.ShowDialog() != DialogResult.OK)
        //        return;

        //    mProcesses.mSysDefPrinter = printers.cmbPrinters.Text;

        //}


        private void mergeMappings(PSProcessCollection collection)
        {
            foreach (string key in collection.Keys)
            {
                if (mProcesses.ContainsKey(key))
                {
                    //merge windows
                    foreach (string window in collection[key].WindowMapping.Keys)
                    {
                        if (!mProcesses[key].WindowMapping.ContainsKey(window))
                        {
                            mProcesses[key].WindowMapping[window] =
                                collection[key].WindowMapping[window];
                        }
                    }
                }
                else
                {
                    mProcesses[key] = collection[key];
                }
            }
        }

        /// <summary>
        /// Clears the list view and updates with the latest mappings
        /// </summary>
        private void refreshMappings()
        {
            

            try
            {
                gvMapping.Enabled = false;
                gvMapping.Nodes.Clear();

                Font boldFont = new Font(gvMapping.DefaultCellStyle.Font, FontStyle.Bold);

                //get list of running processes and their windows
                mProcessSnapshot.scan();
                foreach (string processName in mProcessSnapshot.mProcesses.Keys)
                {
                    TreeGridNode node = gvMapping.Nodes.Add(processName, "");
                    node.ImageIndex = 0;

                    if (mProcesses.ContainsKey(processName))
                    {
                        node.DefaultCellStyle.Font = boldFont;
                        node.Cells[1].Value = mProcesses[processName].MappedPrinter;
                    }

                    foreach (string window in mProcessSnapshot.mProcesses[processName].WindowMapping.Keys)
                    {
                        TreeGridNode child = node.Nodes.Add(window, "");
                        child.ImageIndex = 1;

                        if (mProcesses.ContainsKey(processName))
                        {
                            if (mProcesses[processName].WindowMapping.ContainsKey(window))
                            {
                                child.DefaultCellStyle.Font = boldFont;
                                child.Cells[1].Value = mProcesses[processName].WindowMapping[window];
                            }
                        }

                    }
                }

                //Add all programs in our loaded list that were not actively running
                foreach (string processName in mProcesses.Keys)
                {
                    if (!mProcessSnapshot.mProcesses.ContainsKey(processName))
                    {
                        TreeGridNode node = gvMapping.Nodes.Add(processName, mProcesses[processName].MappedPrinter);
                        node.ImageIndex = 0;
                        node.DefaultCellStyle.Font = boldFont;

                        foreach (string window in mProcesses[processName].WindowMapping.Keys)
                        {
                            TreeGridNode child = node.Nodes.Add(window, mProcesses[processName].WindowMapping[window]);
                            child.ImageIndex = 1;
                            child.DefaultCellStyle.Font = boldFont;

                        }
                    }
                    else
                    {
                        //Check if all windows are contained as well?
                        foreach (string window in mProcesses[processName].WindowMapping.Keys)
                        {
                            if (!mProcessSnapshot.mProcesses[processName].WindowMapping.ContainsKey(window))
                            {
                                //find the node and add child
                                foreach (TreeGridNode node in gvMapping.Nodes)
                                {
                                    if (node.Cells[0].Value.ToString() == processName)
                                    {
                                        TreeGridNode child = node.Nodes.Add(window, mProcesses[processName].WindowMapping[window]);
                                        child.ImageIndex = 1;
                                        child.DefaultCellStyle.Font = boldFont;
                                        break;
                                    }
                                }
                            }

                        }                        
                    }
                }
                gvMapping.Enabled = true;


                lblDefaultPrinter.Text = mProcesses.mSysDefPrinter;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while refreshing the mappings",
                    "Refresh mappings",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mShutdown)
            {
                //todo: Handle windows os shutdown here
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void removeMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvMapping.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please choose a process/window from the list",
                    "Remove mapping",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Font regularFont = new Font(gvMapping.DefaultCellStyle.Font, FontStyle.Regular);


            string processName = string.Empty;
            string windowName = string.Empty;
            bool isProcess = gvMapping.CurrentNode.HasChildren;

            if (isProcess)
            {
                processName = (string)gvMapping.CurrentNode.Cells[0].Value;
            }
            else
            {
                processName = (string)gvMapping.CurrentNode.Parent.Cells[0].Value;
                windowName = (string)gvMapping.CurrentNode.Cells[0].Value;
            }


            tmrWindowCheck.Stop();

            if (isProcess)
            {
                if (mProcesses.ContainsKey(processName))
                {
                    mProcesses.Remove(processName);
                    lblLastAction.Text = "Removed process " + processName;
                }
            }
            else
            {
                if (mProcesses.ContainsKey(processName))
                {
                    if (mProcesses[processName].WindowMapping.ContainsKey(windowName))
                    {
                        mProcesses[processName].WindowMapping.Remove(windowName);
                        lblLastAction.Text = string.Format("Remove [{0}] for process [{1}]",
                            windowName, processName);
                    }
                }
                
            }

            gvMapping.CurrentNode.Cells[1].Value = string.Empty;
            gvMapping.CurrentNode.DefaultCellStyle.Font = regularFont;


            saveMappings();
            tmrWindowCheck.Start();

        }

        private void cntxtMnuLVMappings_Opening(object sender, CancelEventArgs e)
        {
            if (gvMapping.SelectedCells.Count > 0)
            {
                if (null != gvMapping.CurrentNode.DefaultCellStyle.Font &&
                    gvMapping.CurrentNode.DefaultCellStyle.Font.Bold == true)
                {
                    removeMappingToolStripMenuItem.Enabled = true;
                }
                else
                {
                    removeMappingToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void gvMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                editMappingToolStripMenuItem_Click(this, null);
            }
        }

 
        private void tsbChangeDefaultPrinter_Click(object sender, EventArgs e)
        {
            frmPrinters printers = new frmPrinters(string.Empty);

            if (printers.ShowDialog() != DialogResult.OK)
                return;

            mProcesses.mSysDefPrinter = printers.SelectedPrinter;

            lblLastAction.Text = "Changed default printer to: " + printers.SelectedPrinter;
            lblDefaultPrinter.Text = printers.SelectedPrinter;

            saveMappings();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            refreshMappings();
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

	}
}
