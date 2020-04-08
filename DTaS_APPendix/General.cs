using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;

namespace DTaS_APPendix
{

    public static class General
    {

        // Need to move this to a separate class
        public static void setRadios(RadioButton rdoYes, RadioButton rdoNo, int val)
        {
            switch (val)
            {
                case 1: // True-Yes
                    rdoYes.Checked = true;
                    break;
                case 0: // False-No
                    rdoNo.Checked = true;
                    break;
                case -1: // neither
                    rdoYes.Checked = false;
                    rdoNo.Checked = false;
                    break;
                default:
                    rdoYes.Checked = false;
                    rdoNo.Checked = false;
                    break;
            }
        }

        public static void setRadios(CheckBox rdoYes, CheckBox rdoNo, int val)
        {
            switch (val)
            {
                case 1: // True-Yes
                    rdoYes.Checked = true;
                    break;
                case 0: // False-No
                    rdoNo.Checked = false;
                    break;
                case -1: // neither
                    rdoYes.Checked = false;
                    break;
                default:
                    rdoYes.Checked = false;
                    break;
            }
        }
    }

    public class StringSplitters
    {
        public string[] SplitCamelCase(string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }
    }

    public class Title
    {
        public string Description { get; set; }
        public int ID { get; set; }
    }

    // Define a class to receive parsed values
    public static class Options
    {

        public static bool Debug
        {
            get; set;

        }

        public static string PID
        {
            get; set;

        }

        public static bool IsInVisualStudio
        {
            get
            {
                bool inIDE = false;
                string[] args = System.Environment.GetCommandLineArgs();
                if (args != null && args.Length > 0)
                {
                    string prgName = args[0].ToUpper();
                    inIDE = prgName.EndsWith("VSHOST.EXE");
                }
                return inIDE;
            }
        }

    }   

    class Global
    {

        private static string _connectionstring;
        private static string _applicationnamestring;
        private static string _broadcastMessage;
        private static string _access;
        private static string _currentVersion;
        private static string _installPath;
        private static int _timeOut;
        private static string _pid;
        private static string _fullname;
        private static Boolean _aladmin;
        private static Boolean _baadmin;
        private static int _gblresult;

        public static string PID
        {
            get
            {
                return _pid;
            }
            set
            {
                _pid = value;
            }
        }

        public static string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                _fullname = value;
            }
        }

        public static int gblResult
        {
            get
            {
                return _gblresult;
            }
            set
            {
                _gblresult = value;
            }
        }

        public static Boolean VP_Admin
        {
            get
            {
                return _aladmin;
            }
            set
            {
                _aladmin = value;
            }
        }

        public static Boolean BA_Admin
        {
            get
            {
                return _baadmin;
            }
            set
            {
                _baadmin = value;
            }
        }

        public static int TimeOut
        {
            get
            {
                // Reads are usually simple
                return _timeOut;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _timeOut = value;
            }
        }


        public static string ConnectionString
        {
            get
            {
                // Reads are usually simple
                return _connectionstring;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _connectionstring = value;
            }
        }

        public static string BroadcastMessage
        {
            get
            {
                return _broadcastMessage;
            }
            set
            {
                _broadcastMessage = value;
            }
        }

        public static string Access
        {
            get
            {
                return _access;
            }
            set
            {
                _access = value;
            }
        }

        public static string CurrentVersion
        {
            get
            {
                return _currentVersion;
            }
            set
            {
                _currentVersion = value;
            }
        }

        public static string InstallPath
        {
            get
            {
                return _installPath;
            }
            set
            {
                _installPath = value;
            }
        }

        public static String ApplicationName
        {
            get
            {
                // Reads are usually simple
                return _applicationnamestring;
            }
            set
            {
                // You can add logic here for race conditions,
                // or other measurements
                _applicationnamestring = value;
            }
        }

        public static void CheckBroadcast()
        {
            if (Global.BroadcastMessage != "#EmptyString")
            {
                MessageBox.Show(Global.BroadcastMessage.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // If Access is denied Quit application
            if (Global.Access == "0")
            {
                // Display Unavailable message if set
                if (Global.BroadcastMessage == "#EmptyString")
                {
                    MessageBox.Show("The system is currently unavailable", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //Application.Exit();
                Environment.Exit(1);
            }

        }

        public static void CheckVersions()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            int _currentVersion = Convert.ToInt16(CurrentVersion);
            int _userVersion = Convert.ToInt16(fvi.FileMajorPart.ToString() + fvi.FileMinorPart.ToString() + fvi.FileBuildPart.ToString() + fvi.FilePrivatePart.ToString());

            if (_currentVersion > _userVersion)
            {
                DialogResult result = MessageBox.Show("There is a new version available.  You will need to update the application", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.OK)
                {
                    updateApplication();
                }
                else
                {
                    MessageBox.Show("The application will now exit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                // We need to close the application whether the user updated or not
                Environment.Exit(1);

            }
        }

        public static void updateApplication()
        {
            // Update applicaton
            try
            {
                Process.Start(Global.InstallPath);
                Environment.Exit(1);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(1);
            }
        }

        public static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public static DialogResult ShowInputDialog(ref string txtmessage, string header)
        {
            System.Drawing.Size size = new System.Drawing.Size(380, 75);
            Form inputBox = new Form  { TopMost = true };

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.MaximizeBox = false;
            inputBox.MinimizeBox = false;
            inputBox.StartPosition = FormStartPosition.CenterParent;
            inputBox.ClientSize = size;
            inputBox.Text = header;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = txtmessage;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            txtmessage = textBox.Text;
            return result;
        }
    }

        public static class SplashForm
    {

        //Delegate for cross thread call to close
        private delegate void CloseDelegate();

        //The type of form to be displayed as the splash screen.
        private static frmAbout splashForm;

        static public void ShowSplashScreen()
        {

            // Make sure it is only launched once.
            if (splashForm != null)
                return;
            Thread thread = new Thread(new ThreadStart(SplashForm.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            splashForm = new frmAbout(false);
            Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            splashForm.Invoke(new CloseDelegate(SplashForm.CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            splashForm.Close();
        }

    }
}
