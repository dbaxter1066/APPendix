using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DTaS_APPendix
{
    public partial class frmStndReports : Form
    {
        public frmStndReports()
        {
            InitializeComponent();
            populateDGVs(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string StartDate;
            string EndDate;
            string strFileName;

            Cursor.Current = Cursors.WaitCursor;

            foreach (DataGridViewRow row in dgvStndReports.Rows) // check all dates enter for selected records are valid
            {
                if (row.Cells[0].Value != null) // report is not null
                {
                    if ((bool)row.Cells[0].Value == true) // report has been selected
                    {
                        if ((bool)row.Cells[6].Value != false) // Date From
                        {
                            if (CheckDate(row.Cells[7].Value.ToString()) != true)
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Not all required dates are valid.", row.Cells[2].Value.ToString() + "- Date From", MessageBoxButtons.OK);
                                return;
                            }
                        }

                        if ((bool)row.Cells[8].Value != false) // Date To
                        {
                            if (CheckDate(row.Cells[9].Value.ToString()) != true)
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Not all required dates are valid.", row.Cells[2].Value.ToString() + "- Date To", MessageBoxButtons.OK);
                                return;
                            }
                        }
                    }                       
                }
            }

            foreach (DataGridViewRow row in dgvStndReports.Rows) //run selected reports
            {
                if (row.Cells[0].Value != null) // report is not null
                {
                    if ((bool)row.Cells[0].Value == true) // report has been selected

                    {
                        strFileName = "";

                        if ((bool)row.Cells[6].Value != false) // Date From
                        {
                            StartDate = row.Cells[7].Value.ToString();
                        }
                        else
                        {
                            StartDate = "";
                        }

                        if ((bool)row.Cells[8].Value != false) // Date To
                        {
                            EndDate = row.Cells[9].Value.ToString();
                        }
                        else
                        {
                            EndDate = "";
                        }

                        if (row.Cells[3].Value != null)
                        {
                            strFileName = row.Cells[3].Value.ToString();
                        }

                        try
                        {
                            string StoredProcedureName = row.Cells[4].Value.ToString(); //Main SQL Stored Procedure

                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = Global.ConnectionString;

                            //Load Data into DataTable from by executing Stored Procedure
                            string queryString =
                              "EXEC  " + StoredProcedureName + " @nFromdate ='" + StartDate+ "',@nTodate ='" + EndDate + "'";


                            SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            System.Data.DataTable DtValue = new System.Data.DataTable();
                            DtValue = ds.Tables[0];

                            /*Set up work book, work sheets, and excel application*/
                            Microsoft.Office.Interop.Excel.Application oexcel = new Microsoft.Office.Interop.Excel.Application();
                            Microsoft.Office.Interop.Excel._Workbook obook = null;
                            Microsoft.Office.Interop.Excel._Worksheet osheet = null;
                            try
                            {
                                string path = AppDomain.CurrentDomain.BaseDirectory;
                                object misValue = System.Reflection.Missing.Value;
                                if (strFileName == "")
                                {
                                    // Template hasn't been specified so use a new blank workbook
                                    obook = oexcel.Workbooks.Add(misValue);
                                    osheet = (Microsoft.Office.Interop.Excel.Worksheet)obook.Sheets["Sheet1"];
                                }
                                else
                                {
                                    // Template was specified so open the specified template
                                    strFileName = path + strFileName;
                                    obook = oexcel.Workbooks.Open(strFileName);
                                    osheet = (Microsoft.Office.Interop.Excel.Worksheet)obook.Sheets["Data"];
                                    osheet.UsedRange.ClearContents();
                                }

                                int colIndex = 0;
                                int rowIndex = 1;

                                foreach (DataColumn dc in DtValue.Columns)
                                {
                                    colIndex++;
                                    osheet.Cells[1, colIndex] = dc.ColumnName;
                                }
                                foreach (DataRow dr in DtValue.Rows)
                                {
                                    rowIndex++;
                                    colIndex = 0;

                                    foreach (DataColumn dc in DtValue.Columns)
                                    {
                                        colIndex++;
                                        osheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                                    }
                                }

                                osheet.Columns.AutoFit();

                                {
                                    if (row.Cells[5].Value.ToString() != "")
                                    {
                                        StoredProcedureName = row.Cells[5].Value.ToString(); // Additional SQL Stored Procedure

                                        con.ConnectionString = Global.ConnectionString;

                                        //Load Data into DataTable from by executing Stored Procedure
                                        queryString =
                                        "EXEC  " + StoredProcedureName + " @nFromdate ='" + StartDate + "',@nTodate ='" + EndDate + "'";


                                        adapter = new SqlDataAdapter(queryString, con);
                                        ds = new DataSet();
                                        adapter.Fill(ds);
                                        DtValue = new System.Data.DataTable();
                                        DtValue = ds.Tables[0];

                                        osheet = new Microsoft.Office.Interop.Excel.Worksheet();

                                        if (strFileName == "") 
                                        {
                                            // Template hasn't been specified so use above blank workbook
                                            obook.Worksheets.Add(misValue);
                                            osheet = (Microsoft.Office.Interop.Excel.Worksheet)obook.Sheets["Sheet2"];
                                        }
                                        else
                                        {
                                            // Template was specified so use Additional Data worksheet
                                            osheet = (Microsoft.Office.Interop.Excel.Worksheet)obook.Sheets["Additional Data"];
                                            osheet.UsedRange.ClearContents();
                                        }

                                        colIndex = 0;
                                        rowIndex = 1;

                                        foreach (DataColumn dc in DtValue.Columns)
                                        {
                                            colIndex++;
                                            osheet.Cells[1, colIndex] = dc.ColumnName;
                                        }
                                        foreach (DataRow dr in DtValue.Rows)
                                        {
                                            rowIndex++;
                                            colIndex = 0;

                                            foreach (DataColumn dc in DtValue.Columns)
                                            {
                                                colIndex++;
                                                osheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                                            }
                                        }

                                        osheet.Columns.AutoFit();
                                    }
                                }

                                //Release and terminate excel

                                //obook.SaveAs(filepath);
                                //obook.Close();
                                //oexcel.Quit();

                                this.TopMost = false;

                                oexcel.Visible = true;

                                releaseObject(osheet);

                                releaseObject(obook);

                                releaseObject(oexcel);

                                GC.Collect();
                            }
                            catch (Exception ex)
                            {
                                oexcel.Quit();
                            }
                        }

                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            MessageBox.Show( "Report(s) have finished running.", "Standard Reports", MessageBoxButtons.OK);

            Cursor.Current = Cursors.Default;
        }
        private void releaseObject(object o)
        {
            try { while (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0) { } }
            catch { }
            finally
            {
                o = null;
            }
        }


        private void populateDGVs(bool blnSetCol)
        {

            if (blnSetCol == true)
            {
                #region SetColWidths 
                // for dgvAssyst
                int cols = dgvStndReports.Columns.Count > 0 ? dgvStndReports.Columns.Count : 1;
                float onepc = (dgvStndReports.Width - dgvStndReports.Columns[0].Width) / 100; /* one percent of grid width minus 'select' column */

                // create colwidth array, initialising all elements to zero 
                int[] colwidth = new int[cols];
                int i;

                for (i = 0; i < cols; i++)
                {
                    colwidth[i] = 0;
                }

                // specific columns
                colwidth[0] = Convert.ToInt16(6 * onepc); /*Select*/
                colwidth[2] = Convert.ToInt16(54 * onepc); /*Report Name*/
                colwidth[7] = Convert.ToInt16(20 * onepc); /*Date To*/
                colwidth[9] = Convert.ToInt16(20 * onepc); /*Date From*/

                // apply widths values
                for (i = 0; i < cols; i++)
                {
                    if (colwidth[i] > 0)
                    {
                        dgvStndReports.Columns[i].Width = colwidth[i];
                    }
                    else
                    {
                        dgvStndReports.Columns[i].Visible = false; /* hide zero width columns */
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
                        cmd.CommandText = "qryVPGetStandardReports";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        con.Close();

                        this.ReportsBindingSource.DataSource = ds.Tables[0];

                        this.dgvStndReports.DataSource = this.ReportsBindingSource.DataSource;

                    }
                }
            }
            catch
            {

            }
        }

        private void dgvStndReports_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvStndReports.Rows)
            {
                if (row.Cells["rTODataGridViewCheckBoxColumn"].Value.ToString() == "True")  //Date To Required
                {
                    row.Cells["DateTo"].Style.BackColor = Color.Aquamarine;
                    row.Cells["DateTo"].Value = "dd/mm/yyyy";
                }
                else
                {
                    row.Cells["DateTo"].Style.BackColor = Color.Empty;
                    row.Cells["DateTo"].Value = "";
                }

                if (row.Cells["rFROMDataGridViewCheckBoxColumn"].Value.ToString() == "True") //Date From Required
                {
                    row.Cells["DateFrom"].Style.BackColor = Color.Aquamarine;
                    row.Cells["DateFrom"].Value = "dd/mm/yyyy";
                }
                else
                {
                    row.Cells["DateFrom"].Style.BackColor = Color.Empty;
                    row.Cells["DateFrom"].Value = "";
                }
            }
        }

        private void dgvStndReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.Compare(dgvStndReports.CurrentCell.OwningColumn.Name, "RepChk") == 0)
            {
                bool checkBoxStatus = Convert.ToBoolean(dgvStndReports.CurrentCell.EditedFormattedValue);
                //checkBoxStatus gives you whether checkbox cell value of selected row for the
                //"CheckBoxColumn" column value is checked or not. 
                if (checkBoxStatus)
                {
                    //get Date To if required
                    if (dgvStndReports.Rows[e.RowIndex].Cells["rTODataGridViewCheckBoxColumn"].Value.ToString() == "True")  //Date To Required
                    {
                        dgvStndReports.Rows[e.RowIndex].Cells["DateTo"].Style.BackColor = Color.Aquamarine;
                        dgvStndReports.CurrentCell =  dgvStndReports.Rows[e.RowIndex].Cells["DateTo"];
                    }
                    else
                    {
                        dgvStndReports.Rows[e.RowIndex].Cells["DateTo"].Style.BackColor = Color.Empty;
                        dgvStndReports.Rows[e.RowIndex].Cells["DateTo"].Value = "";
                    }

                    //get Date From if required
                    if (dgvStndReports.Rows[e.RowIndex].Cells["rFROMDataGridViewCheckBoxColumn"].Value.ToString() == "True") //Date From Required
                    {
                        dgvStndReports.Rows[e.RowIndex].Cells["DateFrom"].Style.BackColor = Color.Aquamarine;
                        dgvStndReports.CurrentCell = dgvStndReports.Rows[e.RowIndex].Cells["DateFrom"];
                    }
                    else
                    {
                        dgvStndReports.Rows[e.RowIndex].Cells["DateFrom"].Style.BackColor = Color.Empty;
                        dgvStndReports.Rows[e.RowIndex].Cells["DateFrom"].Value = "";
                    }

                }
                else
                {
                    // clear Date From if required

                    //clear Date To if required

                    if (dgvStndReports.Rows[e.RowIndex].Cells["rTODataGridViewCheckBoxColumn"].Value.ToString() == "True")  //Date To Required
                    {
                        dgvStndReports.Rows[e.RowIndex].Cells["DateTo"].Style.BackColor = Color.Aquamarine;
                        dgvStndReports.Rows[e.RowIndex].Cells["DateTo"].Value = "dd/mm/yyyy";
                    }
                    else
                    {
                        dgvStndReports.Rows[e.RowIndex].Cells["DateTo"].Style.BackColor = Color.Empty;
                        dgvStndReports.Rows[e.RowIndex].Cells["DateTo"].Value = "";
                    }

                    if (dgvStndReports.Rows[e.RowIndex].Cells["rFROMDataGridViewCheckBoxColumn"].Value.ToString() == "True") //Date From Required
                    {
                        dgvStndReports.Rows[e.RowIndex].Cells["DateFrom"].Style.BackColor = Color.Aquamarine;
                        dgvStndReports.Rows[e.RowIndex].Cells["DateFrom"].Value = "dd/mm/yyyy";
                    }
                    else
                    {
                        dgvStndReports.Rows[e.RowIndex].Cells["DateFrom"].Style.BackColor = Color.Empty;
                        dgvStndReports.Rows[e.RowIndex].Cells["DateFrom"].Value = "";
                    }
                }
            }                
        }

        protected bool CheckDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void frmStndReports_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
