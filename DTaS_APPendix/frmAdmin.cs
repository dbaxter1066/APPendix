using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DTaS_APPendix
{
    public partial class frmAdmin : Form
    {

        SqlDataAdapter adap = new SqlDataAdapter();

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public frmAdmin()
        {
            InitializeComponent();
            refreshVPTableCombo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool blnPassed = true;

            int intColumns = dgvTable.ColumnCount;
            int intRows = dgvTable.RowCount;

            Cursor.Current = Cursors.WaitCursor;

            foreach (DataGridViewRow row in dgvTable.Rows)
            {
                if (row.Index + 1 != intRows)
                {
                    try
                    {

                        SqlConnection con = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd = new SqlCommand(dgvTables.SelectedRows[0].Cells[2].Value.ToString(), con);
                        cmd.CommandTimeout = Global.TimeOut;
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Clear();

                        if (intColumns > 0)
                        {
                            if (dgvTable.Columns[0].ValueType == typeof(String))
                            {
                                SqlParameter prmOne = cmd.Parameters.Add("@nPrmOne", SqlDbType.NVarChar);
                                prmOne.Value = row.Cells[0].Value.ToString();
                            }
                            if (dgvTable.Columns[0].ValueType == typeof(int))
                            {
                                SqlParameter prmOne = cmd.Parameters.Add("@nPrmOne", SqlDbType.Int);
                                prmOne.Value = Convert.ToInt16(row.Cells[0].Value.ToString());
                            }
                        }
                        if (intColumns > 1)
                        {
                            if (dgvTable.Columns[1].ValueType == typeof(String))
                            {
                                SqlParameter prmTwo = cmd.Parameters.Add("@nPrmTwo", SqlDbType.NVarChar);
                                prmTwo.Value = row.Cells[1].Value.ToString();
                            }
                            if (dgvTable.Columns[1].ValueType == typeof(bool))
                            {
                                SqlParameter prmTwo = cmd.Parameters.Add("@nPrmTwo", SqlDbType.Bit);
                                prmTwo.Value = Convert.ToBoolean(row.Cells[1].Value.ToString());
                            }
                            if (dgvTable.Columns[1].ValueType == typeof(int))
                            {
                                SqlParameter prmTwo = cmd.Parameters.Add("@nPrmTwo", SqlDbType.Int);
                                prmTwo.Value = Convert.ToInt32(row.Cells[1].Value.ToString());
                            }
                        }
                        if (intColumns > 2)
                        {
                            if (dgvTable.Columns[2].ValueType == typeof(String))
                            {
                                SqlParameter prmThree = cmd.Parameters.Add("@nPrmThree", SqlDbType.NVarChar);
                                prmThree.Value = row.Cells[2].Value.ToString();
                            }
                            if (dgvTable.Columns[2].ValueType == typeof(bool))
                            {
                                SqlParameter prmThree = cmd.Parameters.Add("@nPrmThree", SqlDbType.Bit);
                                prmThree.Value = Convert.ToBoolean(row.Cells[2].Value.ToString());
                            }
                            if (dgvTable.Columns[2].ValueType == typeof(int))
                            {
                                SqlParameter prmThree = cmd.Parameters.Add("@nPrmThree", SqlDbType.Int);
                                prmThree.Value = Convert.ToInt16(row.Cells[2].Value.ToString());
                            }
                        }
                        if (intColumns > 3)
                        {
                            if (dgvTable.Columns[3].ValueType == typeof(String))
                            {
                                SqlParameter prmFour = cmd.Parameters.Add("@nPrmFour", SqlDbType.NVarChar);
                                prmFour.Value = row.Cells[3].Value.ToString();
                            }
                            if (dgvTable.Columns[3].ValueType == typeof(bool))
                            {
                                SqlParameter prmFour = cmd.Parameters.Add("@nPrmFour", SqlDbType.Bit);
                                prmFour.Value = Convert.ToBoolean(row.Cells[3].Value.ToString());
                            }
                            if (dgvTable.Columns[3].ValueType == typeof(int))
                            {
                                SqlParameter prmFour = cmd.Parameters.Add("@nPrmFour", SqlDbType.Int);
                                prmFour.Value = Convert.ToInt16(row.Cells[3].Value.ToString());
                            }
                        }
                        if (intColumns > 4)
                        {
                            if (dgvTable.Columns[4].ValueType == typeof(String))
                            {
                                SqlParameter prmFive = cmd.Parameters.Add("@nPrmFive", SqlDbType.NVarChar);
                                prmFive.Value = row.Cells[4].Value.ToString();
                            }
                            if (dgvTable.Columns[4].ValueType == typeof(bool))
                            {
                                SqlParameter prmFive = cmd.Parameters.Add("@nPrmFive", SqlDbType.Bit);
                                prmFive.Value = Convert.ToBoolean(row.Cells[4].Value.ToString());
                            }
                            if (dgvTable.Columns[4].ValueType == typeof(int))
                            {
                                SqlParameter prmFive = cmd.Parameters.Add("@nPrmFive", SqlDbType.Int);
                                prmFive.Value = Convert.ToInt16(row.Cells[4].Value.ToString());
                            }
                        }
                        if (intColumns > 5)
                        {
                            if (dgvTable.Columns[5].ValueType == typeof(String))
                            {
                                SqlParameter prmSix = cmd.Parameters.Add("@nPrmSix", SqlDbType.NVarChar);
                                prmSix.Value = row.Cells[5].Value.ToString();
                            }
                            if (dgvTable.Columns[5].ValueType == typeof(bool))
                            {
                                SqlParameter prmSix = cmd.Parameters.Add("@nPrmSix", SqlDbType.Bit);
                                prmSix.Value = Convert.ToBoolean(row.Cells[5].Value.ToString());
                            }
                            if (dgvTable.Columns[5].ValueType == typeof(int))
                            {
                                SqlParameter prmSix = cmd.Parameters.Add("@nPrmSix", SqlDbType.Int);
                                prmSix.Value = Convert.ToInt16(row.Cells[5].Value.ToString());
                            }
                        }
                        if (intColumns > 6)
                        {
                            if (dgvTable.Columns[6].ValueType == typeof(String))
                            {
                                SqlParameter prmSeven = cmd.Parameters.Add("@nPrmSeven", SqlDbType.NVarChar);
                                prmSeven.Value = row.Cells[6].Value.ToString();
                            }
                            if (dgvTable.Columns[6].ValueType == typeof(bool))
                            {
                                SqlParameter prmSeven = cmd.Parameters.Add("@nPrmSeven", SqlDbType.Bit);
                                prmSeven.Value = Convert.ToBoolean(row.Cells[6].Value.ToString());
                            }
                            if (dgvTable.Columns[6].ValueType == typeof(int))
                            {
                                SqlParameter prmSeven = cmd.Parameters.Add("@nPrmSeven", SqlDbType.Int);
                                prmSeven.Value = Convert.ToInt16(row.Cells[6].Value.ToString());
                            }
                        }
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
                MessageBox.Show("Application failed to add Admin data.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Admin data successfully saved.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshVPTableCombo()
        {
            //if (cboTable.Items.Count > 0)
            //{
            //    cboTable.DataSource = null;
            //    cboTable.DataBindings.Clear();
            //    cboTable.Items.Clear();
            //    dt.Clear();
            //}            

            using (SqlConnection con = new SqlConnection(Global.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "qryVPGetAdminTables";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    con.Close();

                    //cboTable.DataSource = ds.Tables[0];
                    //cboTable.DisplayMember = "TableName";
                    //cboTable.ValueMember = "tblSQL";
                    //cboTable.Enabled = true;
                    //cboTable.SelectedIndex = -1;

                    dgvTables.DataSource = ds.Tables[0];

                    //cboAddUpdate.DataSource = ds.Tables[1];
                    //cboAddUpdate.DisplayMember = "TableName";
                    //cboAddUpdate.ValueMember = "AddUpdateSP";
                    //cboAddUpdate.Enabled = true;
                    // cboAddUpdate.SelectedIndex = -1;
                    dgvTables.Columns[1].Visible = false;
                    dgvTables.Columns[2].Visible = false;
                    dgvTables.Columns[3].Visible = false;
                }
            }
        }

        private void dgvTables_SelectionChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //SqlDataAdapter adap = new SqlDataAdapter();
                dgvTable.DataSource = null;
                //BindingSource bs = new BindingSource();
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlDataAdapter adap = new SqlDataAdapter(dgvTables.SelectedRows[0].Cells[1].Value.ToString(), con);
                con.Open();
                DataSet ds = new DataSet("Bound");
                adap.FillSchema(ds, SchemaType.Source, "Data");
                adap.Fill(ds, "Data");
                //con.Close();
                dgvTable.DataSource = ds;
                dgvTable.DataMember = "Data";

                if (dgvTables.SelectedRows[0].Cells[3].Value.ToString() != "")
                {
                    string strFull = dgvTables.SelectedRows[0].Cells[3].Value.ToString();
                    string[] strHide = Regex.Split(strFull, @",");

                    foreach (string strcol in strHide)
                    {
                        dgvTable.Columns[Convert.ToInt16(strcol)].Visible = false;
                    }
                }
                con.Close();
            }

            catch (Exception ex)
            {

            }

            Cursor.Current = Cursors.Default;
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
