using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DTaS_APPendix
{
    public partial class frmMain : Form
    {
        int PID = 0;
        ToolTip tooltip1 = new ToolTip();

        public frmMain()
        {
            Cursor.Current = Cursors.WaitCursor;

            InitializeComponent();

            // Populate global variables
            LoadAppVarables gen = new LoadAppVarables();
            gen.LoadApplication();

            // Check if access is granted and/or message to be displayed
            frmAbout.SetStatus("Checking Broadcast messages");
            Global.CheckBroadcast();

            // Check version numbers
            frmAbout.SetStatus("Checking version numbers");
            System.Threading.Thread.Sleep(900);
            Global.CheckVersions();

            //event that handles mouse clicks made only on Column Headers
            dgvBDApps.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(dgvBDApps_ColumnHeaderMouseClick);

            // Check if db is online
            #region DB Online
            if (!Global.IsServerConnected(Global.ConnectionString))
            {
                MessageBox.Show(Application.ProductName + " is not available.  Please try again later.  If the problem persists, please report the error to the IT Helpdesk", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                 System.Threading.Thread.CurrentThread.Abort();
                Application.Exit();
                Environment.Exit(1);
            }
            #endregion DB Online

            // Get user details
            frmAbout.SetStatus("Checking User");
            System.Threading.Thread.Sleep(900);
            User user = new User();
            Global.FullName = user.FullName;
            Global.PID = user.PID;
            if (user.VP_Admin == true) ;
            {
                Global.VP_Admin = true;
            }
            if (user.BA_Admin != "") ;
            {
                Global.BA_Admin = true;
            }

            this.tssPID.Text = "PID : " + user.PID;
            this.tssName.Text = "Name : " + user.FullName;

            //this.toolStripStatusPID.Text = "PID : " + user.PID;
            //this.toolStripStatusName.Text = "Name : " + user.FullName;
            frmAbout.SetStatus("Loading Application data");
            System.Threading.Thread.Sleep(400);

            Cursor.Current = Cursors.Default;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.TopMost = false;

            // size form 
            int objwidth = Screen.FromControl(this).Bounds.Width;
            this.Width = objwidth / 2;
            int objheight = Screen.FromControl(this).Bounds.Height;
            this.Height = objheight;
            this.pnlMain.Height = objheight;
            this.grpBDApps.Width = (objwidth / 2) - this.dgvBDApps.Location.X;
            this.grpInformation.Width = (objwidth / 2) - this.dgvBDApps.Location.X;
            this.grpCompliance.Left = (objwidth / 2) + 15;
            this.grpCompliance.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 50;
            this.grpDetails.Left = (objwidth / 2) + 15;
            this.grpDetails.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 50;
            this.grpBDApps.Height = this.grpDetails.Top + this.grpDetails.Height - this.grpCompliance.Top;
            this.grpInformation.Top = this.grpBDApps.Top + grpBDApps.Height;
            //this.grpWOH.Left = (objwidth / 2) + 15;
            //this.grpWOH.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 25;
            int objRemainder = grpInformation.Height;
            this.grpAssyst.Left = this.grpDetails.Left;
            this.grpAssyst.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 50;
            this.grpAssyst.Top = grpDetails.Top + grpDetails.Height;
            this.grpAssyst.Height = objRemainder / 2;
            this.grpReviews.Top = grpAssyst.Top + grpAssyst.Height;
            this.grpReviews.Left = (objwidth / 2) + 15;
            this.grpReviews.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 50;
            this.grpReviews.Height = objRemainder / 2;
            this.grpSpacer.Top = grpInformation.Top + grpInformation.Height;

            populateBDApps(true);

            populateCompliance(0);
            populateDetails(0);
            //populateReviews(Convert.ToInt32(dgvBDApps.Rows[0].Cells[0].Value));

            populateDGVs(Convert.ToInt32(dgvBDApps.Rows[0].Cells[0].Value), true);

            this.tssApplicationCount.Text = "Application Count : " + this.dgvBDApps.Rows.Count;

            this.TopMost = false;
        }

        private void populateDGVs(int intBDAppID, bool blnSetCol)
        {

            if (blnSetCol == true)
            {
                #region SetColWidths 
                // for dgvAssyst
                int cols = dgvAssyst.Columns.Count > 0 ? dgvAssyst.Columns.Count : 1;
                int onepc = (dgvAssyst.Width - dgvAssyst.Columns[0].Width) / 100; /* one percent of grid width minus 'select' column */

                // create colwidth array, initialising all elements to zero 
                int[] colwidth = new int[cols];
                int i;

                for (i = 0; i < cols; i++)
                {
                    colwidth[i] = 0;
                }

                // specific columns
                colwidth[0] = 20 * onepc; /*Assyst Ref*/
                colwidth[2] = 36 * onepc; /*Summary*/
                colwidth[3] = 17 * onepc; /*Start Date*/
                colwidth[4] = 10 * onepc; /*RAG*/
                colwidth[6] = 17 * onepc; /*Target Date*/
                

                // apply widths values
                for (i = 0; i < cols; i++)
                {
                    if (colwidth[i] > 0)
                    {
                        dgvAssyst.Columns[i].Width = colwidth[i];
                    }
                    else
                    {
                        dgvAssyst.Columns[i].Visible = false; /* hide zero width columns */
                    }

                }

                // for dgvReviews
                int rcols = dgvReviews.Columns.Count > 0 ? dgvReviews.Columns.Count : 1;
                int ronepc = (dgvReviews.Width - dgvReviews.Columns[0].Width) / 100; /* one percent of grid width minus 'select' column */

                // create colwidth array, initialising all elements to zero 
                int[] rcolwidth = new int[rcols];
               
                for (i = 0; i < rcols; i++)
                {
                    rcolwidth[i] = 0;
                }

                // specific columns
                rcolwidth[3] = 15 * ronepc; /*Review Date*/
                rcolwidth[4] = 10 * ronepc; /*RAG*/
                rcolwidth[5] = 40 * ronepc; /*Description*/
                rcolwidth[6] = 35 * ronepc; /*Notes*/


                // apply widths values
                for (i = 0; i < rcols; i++)
                {
                    if (rcolwidth[i] > 0)
                    {
                        dgvReviews.Columns[i].Width = rcolwidth[i];
                    }
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
                        cmd.CommandText = "qryVPGetBDAppDGVs";
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

                        //this.dgvReviews.DataSource = ds.Tables[0];                        
                        //this.dgvAssyst.DataSource = ds.Tables[1];
                        //this.dgvOtherDevs.DataSource = ds.Tables[2];

                        this.bDAppReviewBindingSource.DataSource = ds.Tables[0];
                        this.bDAppAssystBindingSource.DataSource = ds.Tables[1];
                        this.bDAppOtherDevsBindingSource.DataSource = ds.Tables[2];

                        this.dgvReviews.DataSource = this.bDAppReviewBindingSource.DataSource;
                        this.dgvAssyst.DataSource = this.bDAppAssystBindingSource.DataSource;
                        this.dgvOtherDevs.DataSource = this.bDAppOtherDevsBindingSource.DataSource;

                        //this.bDAppReviewBindingSource.Sort = "RDescription Desc";

                    }
                }
            }
            catch
            {

            }
        }

        private void populateDetails(int intRow)
        {
            try
            {
                DataGridViewRow selectedRow = dgvBDApps.Rows[intRow];
                {
                    this.txtBDAppName.Text = Convert.ToString(selectedRow.Cells["bDAppName"].Value);
                    this.txtDirectorate.Text = Convert.ToString(selectedRow.Cells["directorate"].Value);
                    this.txtGroup.Text = Convert.ToString(selectedRow.Cells["cGroup"].Value);
                    this.txtBusinessCriticality.Text = Convert.ToString(selectedRow.Cells["busCrit"].Value);
                    if (Convert.ToBoolean(selectedRow.Cells["bDAppReg"].Value) == true)
                    {
                        this.chkBDAppReg.Checked = true;
                    }
                    else
                    {
                        this.chkBDAppReg.Checked = false;
                    }
                    this.txtProductOwner.Text = Convert.ToString(selectedRow.Cells["productOwner"].Value);
                    this.txtBusSME.Text = Convert.ToString(selectedRow.Cells["busSME"].Value);
                    this.txtBusContact.Text = Convert.ToString(selectedRow.Cells["busContact"].Value);
                    this.txtLeadDev.Text = Convert.ToString(selectedRow.Cells["leadDev"].Value);
                    this.txtDataGaurdian.Text = Convert.ToString(selectedRow.Cells["dataGuardian"].Value);
                    this.txtDescription.Text = Convert.ToString(selectedRow.Cells["bDAppDescription"].Value);
                    this.txtNotes.Text = Convert.ToString(selectedRow.Cells["bDAppNotes"].Value);
                }
            }
            catch
            {

            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout(true);

            // set relative position
                  frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.Location = new Point(
            //    (this.Location.X + (this.Width / 2)),
            //    (this.Location.Y + (this.Height / 2)));
            //frm.StartPosition = FormStartPosition.Manual;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;  /*add Close button*/

            frm.TopLevel = true;
            frm.TopMost = true;

            this.WindowState = FormWindowState.Minimized; /*minimise launcher*/
            this.Hide();
            frm.picDTaS.Enabled = true;
            frm.picDTaS.Visible = true;
            frm.ShowDialog();
            RefreshForm();
        }

        private void populateBDApps(Boolean blnSetCol)
        {
            VPApps vpapps = new VPApps();

            vpapps.GetAllBDApps();

            if (blnSetCol == true)
            {
                #region SetColWidths
                int cols = dgvBDApps.Columns.Count > 0 ? dgvBDApps.Columns.Count : 1;
                int onepc = (dgvBDApps.Width - dgvBDApps.Columns[0].Width) / 100; /* one percent of grid width minus 'select' column */

                // create colwidth array, initialising all elements to zero 
                int[] colwidth = new int[cols];
                int i;

                for (i = 0; i < cols; i++)
                {
                    colwidth[i] = 0;
                }

                // specific columns
                colwidth[dgvBDApps.Columns["bDAppNumber"].DisplayIndex] = 6 * onepc; /*BDApp name*/
                colwidth[dgvBDApps.Columns["bDAppName"].DisplayIndex] = 10 * onepc; /*BDApp name*/
                colwidth[dgvBDApps.Columns["availableLauncher"].DisplayIndex] = 6 * onepc; /*Available Via LaunchPad*/
                colwidth[dgvBDApps.Columns["rankBart"].DisplayIndex] = 4 * onepc; /*BART Rank*/
                                                                          //colwidth[5] = 6 * onepc; /*GDPR*/
                                                                          //colwidth[6] = 5 * onepc; /*DPIA*/
                                                                          //colwidth[7] = 5 * onepc; /*SLA*/
                colwidth[dgvBDApps.Columns["status"].DisplayIndex] = 3 * onepc; /*Status_Icon*/
                //colwidth[dgvBDApps.Columns["statusDescription"].DisplayIndex] = 12 * onepc; /*Status Description*/
                colwidth[dgvBDApps.Columns["dateReview"].DisplayIndex] = 8 * onepc; /*Next Review Date*/
                colwidth[dgvBDApps.Columns["dateLastUpdated"].DisplayIndex] = 8 * onepc; /*Date Last Updated*/
                colwidth[dgvBDApps.Columns["reviewRAG"].DisplayIndex] = 7 * onepc; /*Next Review Date RAG*/

                // apply widths values
                for (i = 0; i < cols; i++)
                {
                    if (colwidth[i] > 0)
                    {
                        dgvBDApps.Columns[i].Visible = true;
                    }
                    else
                    {
                        dgvBDApps.Columns[i].Visible = false; /* hide zero width columns */
                    }
                }
                #endregion
            }

            // Convert List to DataTable so we can sort datagridview
            DataTable table = ToDataTables(vpapps.VPBDAppList);
            bDAppBindingSource.DataSource = table;
            dgvBDApps.DataSource = bDAppBindingSource.DataSource;

            // highlight user apps
            int rows = dgvBDApps.Rows.Count;
        }

        public DataTable ToDataTables<T>(IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prp = props[i];
                table.Columns.Add(prp.Name, prp.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private void standardReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStndReports frmReports = new frmStndReports() { TopMost = true };

            frmReports.ShowDialog();
            RefreshForm();
        }

        private void adhocReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will open a form to allow the user to run user defined reports", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvBDApps_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dgvBDApps.Columns[e.ColumnIndex].Name == "status")
                {
                    if (dgvBDApps.SortOrder.ToString() == "Ascending") // Check if sorting is Ascending
                    {
                        dgvBDApps.Sort(dgvBDApps.Columns["statusDescription"], ListSortDirection.Descending);
                    }
                    else
                    {
                        dgvBDApps.Sort(dgvBDApps.Columns["statusDescription"], ListSortDirection.Ascending);
                    }
            }
        }

        private void addApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("This will open a form to allow the user to add a new application", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmDTaSApp frmDTaS = new frmDTaSApp() { TopMost = true };

            Cursor.Current = Cursors.WaitCursor;

            frmDTaS.Text = "DTaS APPendix - Add Application Details";
            frmDTaS.cboBDAppNo.Enabled = false;
            frmDTaS.cboBDAppNo.Visible = false;
            frmDTaS.btnAmendNumber.Enabled = false;
            frmDTaS.btnAmendNumber.Visible = false;
            frmDTaS.txtBDAppNo.Left = frmDTaS.cboBDAppNo.Left;
            frmDTaS.btnReviews.Enabled = false;

            Cursor.Current = Cursors.Default;

            frmDTaS.ShowDialog();
            RefreshForm();
        }

        private void updateApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This will open a form to allow the user to select a BDApp No. and/or BDApp Name then update the Application Details", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmDTaSApp frmDTaS = new frmDTaSApp() { TopMost = true };

            Cursor.Current = Cursors.WaitCursor;

            frmDTaS.Text = "DTaS APPendix - Amend Application Details";
            frmDTaS.txtBDAppNo.Enabled = false;
            //frmDTaS.txtBDAppNo.Visible = false;

            Cursor.Current = Cursors.Default;

            frmDTaS.ShowDialog();
            RefreshForm();
        }

        private void bARTImportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string dbTable = "";
            string exFilepath = "";
            string exInstruction = "";

            //Populate rest of form based upon BDAppNo Selected
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPBARTImportInstructions", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;               

                con.Open();

                //OleDbDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    // Call Read before accessing data.
                    while (dr.Read())
                    {
                        dbTable = dr["dbTable"].ToString();
                        exFilepath = dr["exFileName"].ToString();
                        exInstruction = dr["exImportInstruction"].ToString();
                    }
                }
                con.Close();

            }
            catch (SqlException ex)
            {
          
                
                    System.Windows.Forms.MessageBox.Show("The application could not connect to the database for the BART Import Instructions.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                
            }

            FileImport fi = new FileImport();

            //fi.InsertFilesToDatabase(dbTable, dbTableColumns, excsvFile, exSheetName, excsvColumnNames, blnExcel);
            fi.ImportDatafromExcel(dbTable, exFilepath, exInstruction);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDTaSApp frmDTaS = new frmDTaSApp() { TopMost = true };

            Cursor.Current = Cursors.WaitCursor;

            frmDTaS.Text = "DTaS APPendix - Delete Application Details";
            frmDTaS.txtBDAppNo.Enabled = false;
            frmDTaS.txtBDAppNo.Visible = false;
            frmDTaS.txtBDAppID.Enabled = false;
            frmDTaS.txtBDAppID.Visible = false;
            frmDTaS.btnAmendNumber.Enabled = false;
            frmDTaS.btnAmendNumber.Visible = false;
            frmDTaS.btnSave.Text = "Delete";
            frmDTaS.btnSaveClose.Text = "Delete && Close";

            Cursor.Current = Cursors.Default;

            frmDTaS.ShowDialog();
            RefreshForm();
        }

        private void populateCompliance(int intRow)
        {
                try
                {
                    DataGridViewRow selectedRow = dgvBDApps.Rows[intRow];
                    {
                        if (Convert.ToBoolean(selectedRow.Cells["gDPR"].Value) == true)
                        {
                            this.chkGDPR.Checked = true;
                        }
                        else
                        {
                            this.chkGDPR.Checked = false;
                        }
                    if (Convert.ToBoolean(selectedRow.Cells["dPI"].Value) == true)
                    {
                        this.chkDPIA.Checked = true;
                    }
                    else
                    {
                        this.chkDPIA.Checked = false;
                    }
                    if (Convert.ToBoolean(selectedRow.Cells["sLA"].Value) == true)
                    {
                        this.chkSLA.Checked = true;
                    }
                    else
                    {
                        this.chkSLA.Checked = false;
                    }

                }
                }
                catch
                {

                }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void RefreshForm()
        {
            int selectedBDAppID = 0;
            int intRow = dgvBDApps.CurrentCell.RowIndex;

            if (dgvBDApps.RowCount > 0)
            {
                selectedBDAppID = Convert.ToInt32(dgvBDApps.Rows[intRow].Cells[0].Value);
                clsGridUtility.SaveSorting(dgvBDApps);
            }
            // size form 
            int objwidth = Screen.FromControl(this).Bounds.Width;
            this.Width = objwidth / 2;
            int objheight = Screen.FromControl(this).Bounds.Height;
            this.Height = objheight;
            this.pnlMain.Height = objheight - 25;
            this.grpBDApps.Width = (objwidth / 2) - this.dgvBDApps.Location.X;
            this.grpCompliance.Left = (objwidth / 2) + 15;
            this.grpCompliance.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 25;
            this.grpDetails.Left = (objwidth / 2) + 15;
            this.grpDetails.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 25;
            this.grpBDApps.Height = this.grpDetails.Top + this.grpDetails.Height - this.grpCompliance.Top;
            this.grpReviews.Width = (objwidth / 2) - this.dgvBDApps.Location.X;
            //this.grpWOH.Left = (objwidth / 2) + 15;
            //this.grpWOH.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 25;
            this.grpAssyst.Left = this.grpDetails.Left;
            this.grpAssyst.Width = (objwidth / 2) - this.dgvBDApps.Location.X - 25;

            populateBDApps(false);

            //populateReviews(Convert.ToInt32(dgvBDApps.Rows[0].Cells[0].Value));

            if (dgvBDApps.RowCount > 0)
            {
                clsGridUtility.RestoreSorting(dgvBDApps);
                if (selectedBDAppID != 0)
                {
                    bool blnBDApp = false;
                    foreach (DataGridViewRow row in dgvBDApps.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value.ToString()) == selectedBDAppID)
                        {
                            dgvBDApps.CurrentCell = dgvBDApps.Rows[row.Index].Cells[1];
                            populateCompliance(row.Index);
                            populateDetails(row.Index);
                            populateDGVs(Convert.ToInt32(dgvBDApps.Rows[row.Index].Cells[0].Value), false);
                            blnBDApp = true;
                            break;
                        }
                    }
                    if (blnBDApp == false)
                    {
                        populateCompliance(0);
                        populateDetails(0);
                        populateDGVs(Convert.ToInt32(dgvBDApps.Rows[0].Cells[0].Value), false);
                    }
                }
            }
            else
            {
                populateCompliance(0);
                populateDetails(0);
                populateDGVs(Convert.ToInt32(dgvBDApps.Rows[0].Cells[0].Value), false);
            }

            this.tssApplicationCount.Text = "Application Count : " + this.dgvBDApps.Rows.Count;
        }

        private void dgvBDApps_ColumnHeaderDoubleMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //    if (dgvBDApps.SortOrder.ToString() == "Ascending") // Check if sorting is Ascending
            //    {
            //        dgvBDApps.Sort(dgvBDApps.Columns[dgvBDApps.SortedColumn.Name], ListSortDirection.Descending);
            //    }
            //    else
            //    {
            //        dgvBDApps.Sort(dgvBDApps.Columns[dgvBDApps.SortedColumn.Name], ListSortDirection.Ascending);
            //    }
        }

    private void dgvBDApps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int intRow = dgvBDApps.CurrentCell.RowIndex;

            //MessageBox.Show("'" + Convert.ToString(dgvBDApps.Rows[thisrow].Cells[2].Value + "'"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //MessageBox.Show("Double Click will open a form to display/update Application Details", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmDTaSApp frmDTaS = new frmDTaSApp() { TopMost = true };

            Cursor.Current = Cursors.WaitCursor;

            frmDTaS.Text = "DTaS APPendix - Amend Application Details";
            frmDTaS.txtBDAppNo.Enabled = false;
            //frmDTaS.txtBDAppNo.Visible = false;
            frmDTaS.txtBDAppID.Enabled = false;
            frmDTaS.txtBDAppID.Visible = false;
            frmDTaS.cboBDAppNo.Text = Convert.ToString(dgvBDApps.Rows[intRow].Cells[1].Value);

            Cursor.Current = Cursors.Default;

            frmDTaS.ShowDialog();
            RefreshForm();
        }

        private void dgvBDApps_SelectionChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int intRow = dgvBDApps.CurrentCell.RowIndex;

                populateCompliance(intRow);
                populateDetails(intRow);
                //populateReviews(Convert.ToInt32(dgvBDApps.Rows[intRow].Cells[0].Value));
                populateDGVs(Convert.ToInt32(dgvBDApps.Rows[intRow].Cells[0].Value), false);
            }
            catch
            {

            }

            Cursor.Current = Cursors.Default;
        }

        private void dgvBDApps_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvBDApps.Rows)
                if (row.Cells["reviewRAG"].Value.ToString() == "R")  //Date has past
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (row.Cells["reviewRAG"].Value.ToString() == "A") //Date is within next 14 days
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (row.Cells["reviewRAG"].Value.ToString() == "G") //Date is within next 28 days
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else //Date is over 28 days away
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
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

        private void dgvAssyst_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvAssyst.Rows)
                if (row.Cells["aSSRagDataGridViewTextBoxColumn"].Value.ToString() == "R")  //14 days have past
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (row.Cells["aSSRagDataGridViewTextBoxColumn"].Value.ToString() == "A") //7 days have past
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (row.Cells["aSSRagDataGridViewTextBoxColumn"].Value.ToString() == "G") //less than 7 days have past
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else //??
                {
                    row.DefaultCellStyle.BackColor = Color.Empty;
                }
        }

        private void addAssystToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmAssyst frmAssyst = new frmAssyst() { TopMost = true };
                   
            frmAssyst.Text = "DTaS APPendix - Add Assyst Case";
            frmAssyst.cboAssRef.Enabled = false;
            frmAssyst.cboAssRef.Visible = false;

            Cursor.Current = Cursors.Default;

            frmAssyst.ShowDialog();
            RefreshForm();
        }

        private void amendAssystToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmAssyst frmAssyst = new frmAssyst() { TopMost = true };

            frmAssyst.Text = "DTaS APPendix - Amend Assyst Case";
            frmAssyst.txtAssRef.Enabled = false;
            frmAssyst.txtAssRef.Visible = false;

            Cursor.Current = Cursors.Default;

            frmAssyst.ShowDialog();
            RefreshForm();
        }

        private void deleteAssystToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssyst frmAssyst = new frmAssyst() { TopMost = true };

            frmAssyst.Text = "DTaS APPendix - Delete Assyst Case";
            frmAssyst.txtAssRef.Enabled = false;
            frmAssyst.txtAssRef.Visible = false;
            frmAssyst.cboBDAppNo.Enabled = false;
            frmAssyst.btnSave.Text = "Delete";
            frmAssyst.btnSaveClose.Text = "Delete && Close";
            frmAssyst.ShowDialog();
            RefreshForm();
        }

        private void dgvAssyst_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            int intRow = dgvAssyst.CurrentCell.RowIndex;
            int intBRow = dgvBDApps.CurrentCell.RowIndex;

            frmAssyst frmAssyst = new frmAssyst() { TopMost = true };

            frmAssyst.Text = "DTaS APPendix - Amend Assyst Case";
            frmAssyst.cboAssRef.Enabled = false;
            frmAssyst.txtAssRef.Visible = false;
            frmAssyst.cboBDAppNo.Enabled = false;
            frmAssyst.cboAssRef.SelectedIndex = frmAssyst.cboAssRef.FindStringExact(Convert.ToString(dgvAssyst.Rows[intRow].Cells[0].Value)); // Assyst reference

            Cursor.Current = Cursors.Default;

            frmAssyst.ShowDialog();
            RefreshForm();
        }

        private void dBTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmAdmin frmAdmin = new frmAdmin() { TopMost = true };

            Cursor.Current = Cursors.Default;

            frmAdmin.ShowDialog();
        }

        private void searchAssystCasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch frmsearch = new frmSearch() { TopMost = true };

            frmsearch.Text = "Search Assyst Cases";
            frmsearch.ShowDialog();
        }

        private void searchApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearch frmsearch = new frmSearch() { TopMost = true };

            frmsearch.Text = "Search Applications";
            frmsearch.ShowDialog();
        }

        private void dgvBDApps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

    }
}
