using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DTaS_APPendix
{
    public partial class frmReviews : Form
    {
        public frmReviews()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReview frmReview = new frmReview() { TopMost = true };

            frmReview.Text = "DTaS APPendix - Add Review";
            frmReview.txtBDAppNo.Text = this.txtBDAppNo.Text;
            frmReview.txtBDAppID.Text = this.txtBDAppID.Text;
            frmReview.refreshReviewCombos(0);
            frmReview.btnSave.Text = "Add";
            frmReview.lblUpdateTo.Visible = false;
            frmReview.cboReviewDate.Enabled = false;
            frmReview.cboReviewDate.Visible = false;
            frmReview.txtReviewDate.Location = frmReview.cboReviewDate.Location;
            frmReview.blnLoad = false;

            Cursor.Current = Cursors.Default;

            frmReview.ShowDialog();
            RefreshForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReview frmReview = new frmReview() { TopMost = true };

            frmReview.Text = "DTaS APPendix - Update Review";
            frmReview.txtBDAppNo.Text = this.txtBDAppNo.Text;
            frmReview.txtBDAppID.Text = this.txtBDAppID.Text;
            frmReview.refreshReviewCombos(Convert.ToInt32(this.txtBDAppID.Text));
            frmReview.btnSave.Text = "Update";
            frmReview.blnLoad = false;

            Cursor.Current = Cursors.Default;

            frmReview.ShowDialog();
            RefreshForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmReview frmReview = new frmReview() { TopMost = true };

            frmReview.Text = "DTaS APPendix - Delete Review";
            frmReview.txtBDAppNo.Text = this.txtBDAppNo.Text;
            frmReview.txtBDAppID.Text = this.txtBDAppID.Text;
            frmReview.refreshReviewCombos(Convert.ToInt32(this.txtBDAppID.Text));
            frmReview.lblUpdateTo.Visible = false;
            frmReview.txtReviewDate.Enabled = false;
            frmReview.txtReviewDate.Visible = false;
            frmReview.btnSave.Text = "Delete";
            frmReview.blnLoad = false;

            Cursor.Current = Cursors.Default;

            frmReview.ShowDialog();
            RefreshForm();
        }

        private void populateDGVs(int intBDAppID, bool blnSetCol)
        {

            if (blnSetCol == true)
            {
                #region SetColWidths 
                // for dgvAssyst
                int cols = dgvReviews.Columns.Count > 0 ? dgvReviews.Columns.Count : 1;
                float onepc = (dgvReviews.Width - dgvReviews.Columns[0].Width) / 100; /* one percent of grid width minus 'select' column */

                // create colwidth array, initialising all elements to zero 
                int[] colwidth = new int[cols];
                int i;

                for (i = 0; i < cols; i++)
                {
                    colwidth[i] = 0;
                }

                // specific columns
                colwidth[3] = Convert.ToInt16(12 * onepc); /*Review Date*/
                colwidth[4] = Convert.ToInt16(8 * onepc); /*RAG*/
                colwidth[5] = Convert.ToInt16(34 * onepc); /*Description*/
                colwidth[6] = Convert.ToInt16(34 * onepc); /*Notes*/
                colwidth[7] = Convert.ToInt16(12 * onepc); /*Actioned*/

                // apply widths values
                for (i = 0; i < cols; i++)
                {
                    if (colwidth[i] > 0)
                    {
                        dgvReviews.Columns[i].Width = colwidth[i];                    }
                    else
                    {
                        dgvReviews.Columns[i].Visible = false; /* hide zero width columns */
                    }                                   
                }
                #endregion
            }
            try
            {
                using (SqlConnection con = new SqlConnection(Global.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "qryVPGetReviewDGVs";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter prmBDAppID = cmd.Parameters.Add("@BDAppID", SqlDbType.Int);

                        prmBDAppID.Value = intBDAppID;

                        con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        con.Close();

                        dgvReviews.Columns[0].Visible = false; //Review_ID
                        dgvReviews.Columns[1].Visible = false; //BDApp_ID
                        dgvReviews.Columns[2].Visible = false; //BDApp_Number

                        this.rEviewsBindingSource.DataSource = ds.Tables[0];

                        this.dgvReviews.DataSource = this.rEviewsBindingSource.DataSource;

                    }
                }
            }
            catch
            {

            }
        }

        private void dgvReviews_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvReviews.Rows)
                if (row.Cells["rRagDataGridViewTextBoxColumn"].Value.ToString() == "R")  //Date has past
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (row.Cells["rRagDataGridViewTextBoxColumn"].Value.ToString() == "A") //Date is within next 14 days
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (row.Cells["rRagDataGridViewTextBoxColumn"].Value.ToString() == "G") //Date is within next 28 days
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else //Date is over 28 days away
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }
        }

        private void txtBDAppID_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int intBDAppID = Convert.ToInt32(txtBDAppID.Text);

                populateDGVs(intBDAppID, true);
            }
            catch
            {

            }

            Cursor.Current = Cursors.Default;
        }

        public void RefreshForm()
        {
            int intBDAppID = Convert.ToInt32(txtBDAppID.Text);

            populateDGVs(intBDAppID, false);
        }

        private void dgvReviews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int intRow = dgvReviews.CurrentCell.RowIndex;

            frmReview frmReview = new frmReview() { TopMost = true };
            
            frmReview.Text = "DTaS APPendix - Update Review";
            frmReview.txtBDAppNo.Text = this.txtBDAppNo.Text;
            frmReview.refreshReviewCombos(Convert.ToInt32(this.txtBDAppID.Text));
            frmReview.blnLoad = false;
            frmReview.cboReviewDate.SelectedValue = dgvReviews.Rows[intRow].Cells[0].Value;
            frmReview.btnSave.Text = "Update";

            Cursor.Current = Cursors.Default;

            frmReview.ShowDialog();
            RefreshForm();
        }

        private void frmReviews_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
