using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain theForm = new frmMain();
                        theForm.textBoxOut.Text = "oooooo";
            Application.Run(theForm);
            var mb = MessageBox.Show("hi");

        }
    }
}
