using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;

namespace PrinterSwitcher
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class frmNewMapping : System.Windows.Forms.Form
	{

		public string processName = string.Empty;
		public string windowTitle = string.Empty;
        public string printerName = string.Empty;
		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.ColumnHeader colProcessName;
		private System.Windows.Forms.ColumnHeader colWindowTitle;
		private System.Windows.Forms.ListView lvProcesses;
        private Label label1;
        private Label label3;
        private ComboBox cmbPrinters;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		private System.ComponentModel.Container components = null;

		public frmNewMapping()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.colProcessName = new System.Windows.Forms.ColumnHeader();
            this.colWindowTitle = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPrinters = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(561, 226);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(69, 30);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(16, 226);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(93, 30);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "Add mapping";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lvProcesses
            // 
            this.lvProcesses.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProcessName,
            this.colWindowTitle});
            this.lvProcesses.FullRowSelect = true;
            this.lvProcesses.GridLines = true;
            this.lvProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvProcesses.HideSelection = false;
            this.lvProcesses.HotTracking = true;
            this.lvProcesses.HoverSelection = true;
            this.lvProcesses.Location = new System.Drawing.Point(8, 28);
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(624, 124);
            this.lvProcesses.TabIndex = 8;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            // 
            // colProcessName
            // 
            this.colProcessName.Text = "Program name";
            this.colProcessName.Width = 200;
            // 
            // colWindowTitle
            // 
            this.colWindowTitle.Text = "";
            this.colWindowTitle.Width = 600;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Step 1: Choose a program from the following list";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Step 2: Choose a printer";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Location = new System.Drawing.Point(19, 181);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(611, 21);
            this.cmbPrinters.TabIndex = 3;
            // 
            // frmNewMapping
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(642, 268);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvProcesses);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmbPrinters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmNewMapping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Printer mapping";
            this.Load += new System.EventHandler(this.frmNewMapping_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			
			this.Hide();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			if(lvProcesses.SelectedItems.Count == 0) return;

			processName = lvProcesses.SelectedItems[0].Text;
			windowTitle = lvProcesses.SelectedItems[0].SubItems[0].Text;
			printerName = cmbPrinters.Text;
			
			this.Hide();

		}

		private void frmNewMapping_Load(object sender, System.EventArgs e)
		{
			refreshProcessList();
			refreshPrintersList();
		}

		private void refreshProcessList()
		{
			this.lvProcesses.Items.Clear();

			Process[] processes = Process.GetProcesses();
			foreach(Process process in processes)
			{
				if(process.ProcessName.Length ==0 || process.MainWindowTitle.Length ==0) continue;
                ListViewGroup grpProcessWindows = lvProcesses.Groups.Add(process.ProcessName, process.ProcessName);
                

                //ListViewItem lvItem = lvProcesses.Items.Add(process.ProcessName);
                //lvItem.SubItems.Add(process.MainWindowTitle);
			}
		}

        private void addProcessWindows(ListViewGroup group)
        {
            
        }

		private void refreshPrintersList()
		{
			this.cmbPrinters.Items.Clear();

			foreach(string sPrinterName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
			{
				this.cmbPrinters.Items.Add(sPrinterName);
			}

            if(this.cmbPrinters.Items.Count > 0)
				this.cmbPrinters.SelectedIndex =0;
		}
	}
}


