namespace PrinterSwitcher
{
    partial class frmAddMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddMapping));
            this.lvProcessWindows = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripLVProcesses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.assignPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefreshList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSaveNClose = new System.Windows.Forms.ToolStripButton();
            this.setProcessDefaultPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeProcessDefaultPrinterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripLVProcesses.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvProcessWindows
            // 
            this.lvProcessWindows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.lvProcessWindows.ContextMenuStrip = this.contextMenuStripLVProcesses;
            this.lvProcessWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcessWindows.FullRowSelect = true;
            this.lvProcessWindows.Location = new System.Drawing.Point(0, 25);
            this.lvProcessWindows.MultiSelect = false;
            this.lvProcessWindows.Name = "lvProcessWindows";
            this.lvProcessWindows.Size = new System.Drawing.Size(564, 242);
            this.lvProcessWindows.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvProcessWindows.TabIndex = 1;
            this.lvProcessWindows.UseCompatibleStateImageBehavior = false;
            this.lvProcessWindows.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Process & windows";
            this.columnHeader1.Width = 318;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "MDI";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mapped to printer";
            this.columnHeader2.Width = 193;
            // 
            // contextMenuStripLVProcesses
            // 
            this.contextMenuStripLVProcesses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignPrinterToolStripMenuItem,
            this.removeMappingToolStripMenuItem,
            this.toolStripSeparator2,
            this.setProcessDefaultPrinterToolStripMenuItem,
            this.removeProcessDefaultPrinterToolStripMenuItem});
            this.contextMenuStripLVProcesses.Name = "contextMenuStripLVProcesses";
            this.contextMenuStripLVProcesses.Size = new System.Drawing.Size(239, 120);
            // 
            // assignPrinterToolStripMenuItem
            // 
            this.assignPrinterToolStripMenuItem.Name = "assignPrinterToolStripMenuItem";
            this.assignPrinterToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.assignPrinterToolStripMenuItem.Text = "Assign printer";
            this.assignPrinterToolStripMenuItem.Click += new System.EventHandler(this.assignPrinterToolStripMenuItem_Click);
            // 
            // removeMappingToolStripMenuItem
            // 
            this.removeMappingToolStripMenuItem.Name = "removeMappingToolStripMenuItem";
            this.removeMappingToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.removeMappingToolStripMenuItem.Text = "Remove mapping";
            this.removeMappingToolStripMenuItem.Click += new System.EventHandler(this.removeMappingToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefreshList,
            this.toolStripSeparator1,
            this.toolStripButtonSaveNClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(564, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRefreshList
            // 
            this.toolStripButtonRefreshList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRefreshList.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefreshList.Image")));
            this.toolStripButtonRefreshList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefreshList.Name = "toolStripButtonRefreshList";
            this.toolStripButtonRefreshList.Size = new System.Drawing.Size(50, 22);
            this.toolStripButtonRefreshList.Text = "Refresh";
            this.toolStripButtonRefreshList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonRefreshList.Click += new System.EventHandler(this.toolStripButtonRefreshList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSaveNClose
            // 
            this.toolStripButtonSaveNClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSaveNClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveNClose.Image")));
            this.toolStripButtonSaveNClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveNClose.Name = "toolStripButtonSaveNClose";
            this.toolStripButtonSaveNClose.Size = new System.Drawing.Size(80, 22);
            this.toolStripButtonSaveNClose.Text = "Save && Close";
            this.toolStripButtonSaveNClose.Click += new System.EventHandler(this.toolStripButtonSaveNClose_Click);
            // 
            // setProcessDefaultPrinterToolStripMenuItem
            // 
            this.setProcessDefaultPrinterToolStripMenuItem.Name = "setProcessDefaultPrinterToolStripMenuItem";
            this.setProcessDefaultPrinterToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.setProcessDefaultPrinterToolStripMenuItem.Text = "Set process default printer";
            this.setProcessDefaultPrinterToolStripMenuItem.Click += new System.EventHandler(this.setProcessDefaultPrinterToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(235, 6);
            // 
            // removeProcessDefaultPrinterToolStripMenuItem
            // 
            this.removeProcessDefaultPrinterToolStripMenuItem.Name = "removeProcessDefaultPrinterToolStripMenuItem";
            this.removeProcessDefaultPrinterToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.removeProcessDefaultPrinterToolStripMenuItem.Text = "Remove process default printer";
            this.removeProcessDefaultPrinterToolStripMenuItem.Click += new System.EventHandler(this.removeProcessDefaultPrinterToolStripMenuItem_Click);
            // 
            // frmAddMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 267);
            this.Controls.Add(this.lvProcessWindows);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmAddMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Mapping";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAddMapping_Load);
            this.contextMenuStripLVProcesses.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvProcessWindows;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefreshList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveNClose;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLVProcesses;
        private System.Windows.Forms.ToolStripMenuItem assignPrinterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMappingToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem setProcessDefaultPrinterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeProcessDefaultPrinterToolStripMenuItem;
    }
}