using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTaS_APPendix
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strString;

            if (this.txtKeyword.Text != "")
            {
                strString = this.txtKeyword.Text;

                try
                {
                    using (SqlConnection con = new SqlConnection(Global.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            if (this.Text == "Search Assyst Cases")
                            {
                                cmd.CommandText = "qryVPSearchAssystCases";
                            }
                            else
                            {
                                cmd.CommandText = "qryVPSearchApplications";
                            }
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter prmString = cmd.Parameters.Add("@String", SqlDbType.NVarChar);

                            prmString.Value = strString;

                            con.Open();

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                            DataSet ds = new DataSet();
                            adapter.Fill(ds);

                            con.Close();

                            dgvResults.Columns[0].Visible = false; //Results_ID


                            this.ResultsbindingSource.DataSource = ds.Tables[0];

                            this.dgvResults.DataSource = this.ResultsbindingSource.DataSource;

                            //this.bDAppReviewBindingSource.Sort = "RDescription Desc";

                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void dgvResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            {
                int intRow = dgvResults.CurrentCell.RowIndex;

                if (this.Text == "Search Assyst Cases") 
                {
                    Cursor.Current = Cursors.WaitCursor;

                    frmAssyst frmassyst = new frmAssyst() { TopMost = true };

                    frmassyst.Text = "DTaS APPendix - Amend Assyst Case";
                    frmassyst.cboAssRef.Enabled = false;
                    frmassyst.txtAssRef.Visible = false;
                    frmassyst.cboBDAppNo.Enabled = false;
                    frmassyst.cboAssRef.SelectedIndex = frmassyst.cboAssRef.FindStringExact(Convert.ToString(dgvResults.Rows[intRow].Cells[1].Value)); // Assyst reference

                    Cursor.Current = Cursors.Default;

                    frmassyst.ShowDialog();
                }
                else
                {
                    frmDTaSApp frmDTaS = new frmDTaSApp() { TopMost = true };

                    Cursor.Current = Cursors.WaitCursor;

                    frmDTaS.Text = "DTaS APPendix - Amend Application Details";
                    frmDTaS.txtBDAppNo.Enabled = false;
                    //frmDTaS.txtBDAppNo.Visible = false;
                    frmDTaS.txtBDAppID.Enabled = false;
                    frmDTaS.txtBDAppID.Visible = false;
                    frmDTaS.cboBDAppNo.Text = Convert.ToString(dgvResults.Rows[intRow].Cells[1].Value);

                    Cursor.Current = Cursors.Default;

                    frmDTaS.ShowDialog();
                }

            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
