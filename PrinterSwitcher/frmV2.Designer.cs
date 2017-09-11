namespace PrinterSwitcher
{
    partial class frmV2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmV2));
            this.menuStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDefaultPrinter = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.lvProcessesName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvProcessesPrinter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvProcessesType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cntxtMnuProcesses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxtMnuWindows = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editMappingWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMappingWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cntxtMnuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.specialOfferContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tmrWindowCheck = new System.Windows.Forms.Timer(this.components);
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cntxtMnuProcesses.SuspendLayout();
            this.cntxtMnuWindows.SuspendLayout();
            this.cntxtMnuNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            toolStripStatusLabel1.IsLink = true;
            toolStripStatusLabel1.LinkColor = System.Drawing.Color.Red;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(862, 17);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "Please give feedback at https://github.com/faisalthaheem/automatic-printer-switch" +
    "er";
            toolStripStatusLabel1.ToolTipText = "Your feedback will make APS better.";
            toolStripStatusLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.toolStripSeparator4,
            this.tsbDefaultPrinter});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(104, 22);
            this.tsbRefresh.Text = "Refresh processes";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDefaultPrinter
            // 
            this.tsbDefaultPrinter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDefaultPrinter.Image = ((System.Drawing.Image)(resources.GetObject("tsbDefaultPrinter.Image")));
            this.tsbDefaultPrinter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDefaultPrinter.Name = "tsbDefaultPrinter";
            this.tsbDefaultPrinter.Size = new System.Drawing.Size(131, 22);
            this.tsbDefaultPrinter.Text = "Change Default printer";
            this.tsbDefaultPrinter.Click += new System.EventHandler(this.tsbDefaultPrinter_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 225);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(908, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lvProcesses
            // 
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvProcessesName,
            this.lvProcessesPrinter,
            this.lvProcessesType});
            this.lvProcesses.ContextMenuStrip = this.cntxtMnuProcesses;
            this.lvProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcesses.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.Location = new System.Drawing.Point(0, 25);
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(908, 200);
            this.lvProcesses.TabIndex = 0;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            this.lvProcesses.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProcesses_ColumnClick);
            this.lvProcesses.SelectedIndexChanged += new System.EventHandler(this.lvProcesses_SelectedIndexChanged);
            // 
            // lvProcessesName
            // 
            this.lvProcessesName.Text = "Program";
            this.lvProcessesName.Width = 227;
            // 
            // lvProcessesPrinter
            // 
            this.lvProcessesPrinter.Text = "Prints to";
            this.lvProcessesPrinter.Width = 192;
            // 
            // lvProcessesType
            // 
            this.lvProcessesType.Text = "Type";
            this.lvProcessesType.Width = 101;
            // 
            // cntxtMnuProcesses
            // 
            this.cntxtMnuProcesses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMappingToolStripMenuItem,
            this.removeMappingToolStripMenuItem});
            this.cntxtMnuProcesses.Name = "cntxtMnuProcesses";
            this.cntxtMnuProcesses.Size = new System.Drawing.Size(169, 48);
            this.cntxtMnuProcesses.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMnuProcesses_Opening);
            // 
            // editMappingToolStripMenuItem
            // 
            this.editMappingToolStripMenuItem.Name = "editMappingToolStripMenuItem";
            this.editMappingToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.editMappingToolStripMenuItem.Text = "Edit Mapping";
            this.editMappingToolStripMenuItem.Click += new System.EventHandler(this.editMappingToolStripMenuItem_Click);
            // 
            // removeMappingToolStripMenuItem
            // 
            this.removeMappingToolStripMenuItem.Name = "removeMappingToolStripMenuItem";
            this.removeMappingToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.removeMappingToolStripMenuItem.Text = "Remove Mapping";
            this.removeMappingToolStripMenuItem.Click += new System.EventHandler(this.removeMappingToolStripMenuItem_Click);
            // 
            // cntxtMnuWindows
            // 
            this.cntxtMnuWindows.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMappingWindow,
            this.removeMappingWindow});
            this.cntxtMnuWindows.Name = "cntxtMnuWindows";
            this.cntxtMnuWindows.Size = new System.Drawing.Size(169, 48);
            this.cntxtMnuWindows.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMnuWindows_Opening);
            // 
            // editMappingWindow
            // 
            this.editMappingWindow.Name = "editMappingWindow";
            this.editMappingWindow.Size = new System.Drawing.Size(168, 22);
            this.editMappingWindow.Text = "Edit mapping";
            this.editMappingWindow.Click += new System.EventHandler(this.editMappingWindow_Click);
            // 
            // removeMappingWindow
            // 
            this.removeMappingWindow.Name = "removeMappingWindow";
            this.removeMappingWindow.Size = new System.Drawing.Size(168, 22);
            this.removeMappingWindow.Text = "Remove mapping";
            this.removeMappingWindow.Click += new System.EventHandler(this.removeMappingWindow_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cntxtMnuNotifyIcon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Automatic Printer Switcher";
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
            this.cntxtMnuNotifyIcon.Size = new System.Drawing.Size(222, 204);
            this.cntxtMnuNotifyIcon.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMnuNotifyIcon_Opening);
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
            // tmrWindowCheck
            // 
            this.tmrWindowCheck.Interval = 2000;
            this.tmrWindowCheck.Tick += new System.EventHandler(this.tmrWindowCheck_Tick);
            // 
            // frmV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 247);
            this.Controls.Add(this.lvProcesses);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmV2_FormClosing);
            this.Load += new System.EventHandler(this.frmV2_Load);
            this.Resize += new System.EventHandler(this.frmV2_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cntxtMnuProcesses.ResumeLayout(false);
            this.cntxtMnuWindows.ResumeLayout(false);
            this.cntxtMnuNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lvProcesses;
        private System.Windows.Forms.ColumnHeader lvProcessesName;
        private System.Windows.Forms.ColumnHeader lvProcessesPrinter;
        private System.Windows.Forms.ColumnHeader lvProcessesType;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cntxtMnuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem specialOfferContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkingForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactComputedSynergyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem restoreAPSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem startupOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticallyStartWhenILogOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysMinimizeToTrayOnStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cntxtMnuProcesses;
        private System.Windows.Forms.ContextMenuStrip cntxtMnuWindows;
        private System.Windows.Forms.ToolStripMenuItem editMappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMappingWindow;
        private System.Windows.Forms.ToolStripMenuItem removeMappingWindow;
        private System.Windows.Forms.Timer tmrWindowCheck;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbDefaultPrinter;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}