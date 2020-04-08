using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ini;

namespace DTaS_APPendix
{
    class LoadAppVarables
    {
        public string GlobalFile;
        public void LoadApplication()
        {

            // get path to local file
            #region Local FIle
            IniFile iniLocal = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "lclDTASBMS.ini");
            GlobalFile = iniLocal.IniReadValue("Paths", "GlobalFile");
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "lclDTASBMS.ini"))
            {
                // Do nothing;
            }
            else
            {
                MessageBox.Show("Unable to find the Local settings file.  The application will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                Environment.Exit(1);
            }
            #endregion

            // Check global file exists
            #region Global File
            if (File.Exists(GlobalFile))
            {
                // Do nothing;
            }
            else
            {
                MessageBox.Show("Unable to find the Global settings file.  The application will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                Environment.Exit(1);
            }
            #endregion

            IniFile iniGlobal = new IniFile(GlobalFile);
            int iTimeOut;

            // read info from Global file
            Global.ConnectionString = iniGlobal.IniReadValue("System", "ConnectString");
            Global.CurrentVersion = iniGlobal.IniReadValue("Version", "CurrentVersion");
            Global.InstallPath = iniGlobal.IniReadValue("Version", "InstallPath");

            // Application Name, default to Assembly Name
            Global.ApplicationName = iniGlobal.IniReadValue("Version", "ApplicationName");
            Global.ApplicationName = Global.ApplicationName == "" ? System.Reflection.Assembly.GetCallingAssembly().GetName().Name : Global.ApplicationName;

            // Access / messages
            Global.BroadcastMessage = iniGlobal.IniReadValue("SystemSettings", "Broadcast");
            Global.Access = iniGlobal.IniReadValue("SystemSettings", "Access");

            // External option to adjust connection timeout.
            try
            {
                iTimeOut = int.Parse(iniGlobal.IniReadValue("System", "TimeOut"));
            }
            catch
            {
                iTimeOut = 30;  // default
            }
            Global.TimeOut = iTimeOut < 30 ? 30 : iTimeOut; // avoid any possibility of zero by setting minimum at 10

        }


        public string getAppVersion(string strLocalIniFile)
        {
            IniFile iniLocal = new IniFile(strLocalIniFile);
            string strLocalVersionNo = iniLocal.IniReadValue("Version", "CurrentVersion");

            return strLocalVersionNo;
        }

    }     
}
