using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTaS_APPendix
{
    public partial class frmText : Form
    {
        public static string rtnText;
        
        public frmText()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // save back to parent form
            if (this.txtPrevious.Text == "")
            {
                if (this.txtNew.Text == "")
                {
                    rtnText = "";
                }
                else
                {
                    rtnText = DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine + this.txtNew.Text + Environment.NewLine + Environment.NewLine;
                }

            }
            else
            {
                rtnText = DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine + this.txtNew.Text + Environment.NewLine + Environment.NewLine + this.txtPrevious.Text + Environment.NewLine;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // close and return to parent form
            rtnText = "Closed";
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // delete text from txtPrevious
            this.txtPrevious.Text = "";
        }

        private void frmText_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
