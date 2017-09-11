using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PrinterSwitcher
{
	/// <summary>
	/// Summary description for frmPrinters.
	/// </summary>
	public class frmPrinters : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
        private ListView lvPrinters;
        private IContainer components;
        private ImageList imageList1;


        private string mChosenPrinter = string.Empty;

        public string SelectedPrinter{
            get
            {
                return mChosenPrinter;
            }
        }


		public frmPrinters(string processName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            if (processName != string.Empty)
            {
                this.Text = "Map printer for [" + processName + "]";
            }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrinters));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvPrinters = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(350, 155);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Okay";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(436, 155);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvPrinters
            // 
            this.lvPrinters.LargeImageList = this.imageList1;
            this.lvPrinters.Location = new System.Drawing.Point(12, 12);
            this.lvPrinters.Name = "lvPrinters";
            this.lvPrinters.Size = new System.Drawing.Size(504, 137);
            this.lvPrinters.TabIndex = 4;
            this.lvPrinters.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "printerlarge.png");
            // 
            // frmPrinters
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(528, 190);
            this.ControlBox = false;
            this.Controls.Add(this.lvPrinters);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPrinters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Available Printers";
            this.Load += new System.EventHandler(this.frmPrinters_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
            if (lvPrinters.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please choose a printer", "Choose printer", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            mChosenPrinter = lvPrinters.SelectedItems[0].Text;
			this.DialogResult = DialogResult.OK;
		}


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void frmPrinters_Load(object sender, System.EventArgs e)
		{
            this.lvPrinters.Items.Clear();

			foreach(string printer in PrinterSettings.InstalledPrinters)
			{
                this.lvPrinters.Items.Add(printer).ImageIndex = 0;
			}
			
		}

	}
}
