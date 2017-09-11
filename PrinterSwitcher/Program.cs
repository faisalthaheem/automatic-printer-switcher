using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrinterSwitcher
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmV2());
        }

    }
}
