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
    public partial class frmOtherDevs : Form
    {
        public frmOtherDevs()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            bool blnPassed = true;

            int intColumns = dgvOtherDevs.ColumnCount;
            int intRows = dgvOtherDevs.RowCount;
            string strSQLStoredProcedure = "";

            foreach (DataGridViewRow row in dgvOtherDevs.Rows)
            {
                if (row.Index + 1 != intRows)
                {
                    try
                    {
                        if(Convert.ToBoolean(row.Cells[0].Value) == false)
                        {
                            strSQLStoredProcedure = "qryVPDeleteOtherDev";
                        }
                        else
                        {
                            strSQLStoredProcedure = "qryVPAddOtherDev";
                        }

                        SqlConnection con = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd = new SqlCommand(strSQLStoredProcedure, con);
                        cmd.CommandTimeout = Global.TimeOut;
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Clear();

                        SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDAppID", SqlDbType.Int);
                        prmBDAppID.Value = Convert.ToInt32(txtBDAppID.Text);

                        SqlParameter prmPID = cmd.Parameters.Add("@nPID", SqlDbType.Int);
                        prmPID.Value = Convert.ToInt32(row.Cells[1].Value.ToString());

                        cmd.ExecuteNonQuery();
                        con.Close();
                        cmd.Dispose();
                        cmd.Parameters.Clear();

                    }
                    catch
                    {
                        blnPassed = false;
                    }
                }
            }
            if (blnPassed == false)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Application failed to add All Other Developer data.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("All Other Developer data successfully saved.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
        }

        private void frmOtherDevs_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void populateDGVs(bool blnSetCol)
        {

            if (blnSetCol == true)
            {
                #region SetColWidths 
                // for dgvAssyst
                int cols = dgvOtherDevs.Columns.Count > 0 ? dgvOtherDevs.Columns.Count : 1;
                float onepc = (dgvOtherDevs.Width - dgvOtherDevs.Columns[0].Width) / 100; /* one percent of grid width minus 'select' column */

                // create colwidth array, initialising all elements to zero 
                int[] colwidth = new int[cols];
                int i;

                for (i = 0; i < cols; i++)
                {
                    colwidth[i] = 0;
                }

                // specific columns
                colwidth[0] = Convert.ToInt16(20 * onepc); /*Select*/
                colwidth[2] = Convert.ToInt16(80 * onepc); /*FullName*/

                // apply widths values
                for (i = 0; i < cols; i++)
                {
                    if (colwidth[i] > 0)
                    {
                        dgvOtherDevs.Columns[i].Width = colwidth[i];
                    }
                    else
                    {
                        dgvOtherDevs.Columns[i].Visible = false; /* hide zero width columns */
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
                        cmd.CommandText = "qryVPGetBDAppOthDevs";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDAppID", SqlDbType.Int);

                        prmBDAppID.Value = Convert.ToInt32(txtBDAppID.Text);

                        con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        con.Close();

                        this.DevsBindingSource.DataSource = ds.Tables[0];

                        this.dgvOtherDevs.DataSource = this.DevsBindingSource.DataSource;

                    }
                }
            }
            catch
            {

            }
        }

        private void txtBDAppID_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (txtBDAppID.Text != "")
            {
                populateDGVs(true);
            }

            Cursor.Current = Cursors.Default;
        }
    }
}