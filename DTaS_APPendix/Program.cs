using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTaS_APPendix
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

            // New code
            SplashForm.ShowSplashScreen();
            frmMain mainForm = new frmMain() { TopMost = true };
            SplashForm.CloseForm();
            // end new code

            mainForm.Activate();

            Application.Run(mainForm);            
        }
    }
}
