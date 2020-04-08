using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTaS_APPendix
{
    public partial class frmAbout : Form
    {

        private static string m_sStatus;

        public frmAbout(bool xClose)
        {
            InitializeComponent();

            UpdateTimer.Start();
            UpdateTimer.Interval = 50;

            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            lblHelp.Text = "Please report any errors to the IT Service Desk quoting the details below.";
            lblBDAppNumber.Text = "BDApp Reference Number: 110705";
            lblBDAppName.Text = "BDApp Name: DTaS APPendix";
            lblResolver.Text = "Resolver Group: HMRC B Local Compliance";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = m_sStatus;
        }

        static public void SetStatus(string newStatus)
        {
            //if (frmAbout == null)
            //    return;
            m_sStatus = newStatus;
        }

        private void frmAbout_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateTimer.Stop();
        }


        private void frmAbout_MouseEnter(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
        }

        private void frmAbout_MouseLeave(object sender, EventArgs e)
        {

        }

        private void frmAbout_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            this.Close();
        }

        private void frmAbout_Activated(object sender, EventArgs e)
        {
            // where a 'proper' form, not 'splash', e.g. from menu
            // show appropriate controls, colours ...
            if (this.FormBorderStyle == FormBorderStyle.FixedToolWindow)
            {
                this.Text = "About " + lblApplicationName.Text;
                Color backcolour = Color.White;
                Color forecolour = Color.Black;

                foreach (Label lb in this.Controls.OfType<Label>())
                {
                    lb.Visible = true;
                    lb.BackColor = backcolour;
                    lb.ForeColor = forecolour;
                }
                lblStatus.Visible = false;
                BackColor = backcolour;
                ForeColor = forecolour;

            }
        }

        private void frmAbout_Deactivate(object sender, EventArgs e)
        {
            // where a 'proper' form, not 'splash', e.g. from menu
            // restore frmMain
            if (this.FormBorderStyle == FormBorderStyle.FixedToolWindow)
            {

                frmMain frm = new frmMain();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.TopLevel = true;
                frm.TopMost = true;
                frm.Show();
                frm.WindowState = FormWindowState.Normal;

            }


        }

        private void picDTaS_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will initiate the reinstall process.  Click Ok to proceed", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.OK)
            {
                Global.updateApplication();
                Environment.Exit(1);
            }
        }

        public void frmAbout_Close()
        {
            this.Close();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
