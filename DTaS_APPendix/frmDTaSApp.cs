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
using System.IO;

namespace DTaS_APPendix
{
    public partial class frmDTaSApp : Form
    {
        public DataTable dtStatus = new DataTable();
        public DataTable dtGDL = new DataTable();
        public DataTable dtBDApp = new DataTable();
        public DataTable dtGroup = new DataTable();
        public bool blnLoad;

        public frmDTaSApp()
        {
            blnLoad = true;

            InitializeComponent();

            //Populate Combos
            //cboRestBDApp
            this.cboRestBDApp.Items.Add("No");
            this.cboRestBDApp.Items.Add("Yes");

            //cboGoverningDL
            //refreshGoverningDLCombo();

            //cboStatus
            //refreshStatusCombo();

            //cboBDAppNo
            //refreshBDAppNoCombo();

            refreshDTaSAdminCombos();

            blnLoad = false;
        }

        private void refreshDTaSAdminCombos()
        {
            //reset cboBDAppNo Combo
            if (cboBDAppNo.Items.Count > 0)
            {
                cboBDAppNo.DataSource = null;
                cboBDAppNo.DataBindings.Clear();
                cboBDAppNo.Items.Clear();
                dtBDApp.Clear();
            }

            //reset cboGoverningDL Combo
            if (cboGoverningDL.Items.Count > 0)
            {
                cboGoverningDL.DataSource = null;
                cboGoverningDL.DataBindings.Clear();
                cboGoverningDL.Items.Clear();
            }

            //reset cboStatus Combo
            if (cboStatus.Items.Count > 0)
            {
                cboStatus.DataSource = null;
                cboStatus.DataBindings.Clear();
                cboStatus.Items.Clear();
            }

            //reset cboDirectorate Combo
            if (cboDirectorate.Items.Count > 0)
            {
                cboDirectorate.DataSource = null;
                cboDirectorate.DataBindings.Clear();
                cboDirectorate.Items.Clear();
            }

            //reset cboGroup Combo
            if (cboGroup.Items.Count > 0)
            {
                cboGroup.DataSource = null;
                cboGroup.DataBindings.Clear();
                cboGroup.Items.Clear();
                dtGroup.Clear();
            }

            //reset cboLeadDev Combo
            if (cboLeadDev.Items.Count > 0)
            {
                cboLeadDev.DataSource = null;
                cboLeadDev.DataBindings.Clear();
                cboLeadDev.Items.Clear();
            }

            //reset cboFrontEnd Combo
            if (cboFrontEnd.Items.Count > 0)
            {
                cboFrontEnd.DataSource = null;
                cboFrontEnd.DataBindings.Clear();
                cboFrontEnd.Items.Clear();
            }

            //reset cboBackEnd Combo
            if (cboBackEnd.Items.Count > 0)
            {
                cboBackEnd.DataSource = null;
                cboBackEnd.DataBindings.Clear();
                cboBackEnd.Items.Clear();
            }

            try
            {
                using (SqlConnection con = new SqlConnection(Global.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "qryVPGetAppFormCombos";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        con.Close();

                        cboBDAppNo.DataSource = ds.Tables[0];
                        cboBDAppNo.DisplayMember = "BDApp_Number";
                        cboBDAppNo.ValueMember = "BDApp_ID";
                        cboBDAppNo.Enabled = true;
                        cboBDAppNo.SelectedIndex = -1;

                        cboGoverningDL.DataSource = ds.Tables[1];
                        cboGoverningDL.DisplayMember = "Governing_DL";
                        cboGoverningDL.ValueMember = "GDL_ID";
                        cboGoverningDL.Enabled = true;
                        cboGoverningDL.SelectedIndex = -1;

                        cboStatus.DataSource = ds.Tables[2];
                        cboStatus.DisplayMember = "Status_Description";
                        cboStatus.ValueMember = "Status_ID";
                        cboStatus.Enabled = true;
                        cboStatus.SelectedIndex = -1;

                        cboDirectorate.DataSource = ds.Tables[3];
                        cboDirectorate.DisplayMember = "Directorate";
                        cboDirectorate.ValueMember = "Directorate";
                        cboDirectorate.Enabled = true;
                        cboDirectorate.SelectedIndex = -1;

                        dtGroup = ds.Tables[4];
                        DataView dvGroup = new DataView(dtGroup);
                        cboGroup.DataSource = dvGroup;
                        cboGroup.DisplayMember = "CGroup";
                        cboGroup.ValueMember = "CGroup";
                        cboGroup.Enabled = true;
                        cboGroup.SelectedIndex = -1;

                        cboLeadDev.DataSource = ds.Tables[5];
                        cboLeadDev.DisplayMember = "Full_Name";
                        cboLeadDev.ValueMember = "PID";
                        cboLeadDev.Enabled = true;
                        cboLeadDev.SelectedIndex = -1;

                        cboFrontEnd.DataSource = ds.Tables[6];
                        cboFrontEnd.DisplayMember = "ProgLanguage";
                        cboFrontEnd.ValueMember = "ProgLanguage";
                        cboFrontEnd.Enabled = true;
                        cboFrontEnd.SelectedIndex = -1;

                        cboBackEnd.DataSource = ds.Tables[7];
                        cboBackEnd.DisplayMember = "ProgLanguage";
                        cboBackEnd.ValueMember = "ProgLanguage";
                        cboBackEnd.Enabled = true;
                        cboBackEnd.SelectedIndex = -1;

                        cboCriticality.DataSource = ds.Tables[8];
                        cboCriticality.DisplayMember = "Criticality";
                        cboCriticality.ValueMember = "Criticality_ID";
                        cboCriticality.Enabled = true;
                        cboCriticality.SelectedIndex = -1;
                    }
                }
            }
            catch
            {

            }
        }

        private void refreshDTaSAdminForm()
        {
            cboBDAppNo.SelectedIndex = -1;
            txtBDAppNo.Text = "";
            txtBDAppID.Text = "";
            txtBDAppNo.Text = "";
            txtBDAppName.Text = "";
            txtFriendlyName.Text = "";
            cboRestBDApp.SelectedIndex = -1;
            cboGoverningDL.SelectedIndex = -1;
            txtAdminContact.Text = "";
            txtVersionNo.Text = "";
            txtBDAppFolder.Text = "";
            txtSourceFolder.Text = "";
            cboStatus.SelectedIndex = -1;
            txtUserInstallLocation.Text = "";
            txtUpdateProcess.Text = "";
            txtCommand.Text = "";
            txtCommandArgs.Text = "";
            cbAvailable_LaunchPad.Checked = false;
            chkGDPR.Checked = false;
            chkDPIA.Checked = false;
            chkSLA.Checked = false;
            txtDPIARef.Text = "";
            txtDPIALink.Text = "";
            txtSLALink.Text = "";
            txtBARTRank.Text = "";
            cboDirectorate.SelectedIndex = -1;
            cboGroup.SelectedIndex = -1;
            cboCriticality.SelectedIndex = -1;
            chkBDAppReg.Checked = false;
            txtProductOwner.Text = "";
            txtBusSME.Text = "";
            txtBusContact.Text = "";
            cboLeadDev.SelectedIndex = -1;
            txtDataGaurdian.Text = "";
            txtDescription.Text = "";
            txtNotes.Text = "";
            txtSQLPreProd.Text = "";
            txtSQLLive.Text = "";
            cboFrontEnd.SelectedIndex = -1;
            cboBackEnd.SelectedIndex = -1;
        }

        //private void refreshStatusCombo()
        //{
        //    if (cboStatus.Items.Count > 0)
        //    {
        //        cboStatus.DataSource = null;
        //        cboStatus.DataBindings.Clear();
        //        cboStatus.Items.Clear();
        //    }

        //    SqlConnection con = new SqlConnection(Global.ConnectionString);
        //    SqlCommand cmd = new SqlCommand("qryGetStatuses", con);
        //    cmd.CommandTimeout = Global.TimeOut;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;

        //    da.Fill(dtStatus);
        //    cboStatus.DataSource = dtStatus;
        //    cboStatus.DisplayMember = "Status_Description";
        //    cboStatus.ValueMember = "Status_ID";
        //    cboStatus.Enabled = true;
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    cboStatus.SelectedIndex = -1;            
        //}

        //private void refreshGoverningDLCombo()
        //{
        //    if (cboGoverningDL.Items.Count > 0)
        //    {
        //        cboGoverningDL.DataSource = null;
        //        cboGoverningDL.DataBindings.Clear();
        //        cboGoverningDL.Items.Clear();
        //    }

        //    SqlConnection con = new SqlConnection(Global.ConnectionString);
        //    SqlCommand cmd = new SqlCommand("qryGetGoverningDLs", con);
        //    cmd.CommandTimeout = Global.TimeOut;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;

        //    da.Fill(dtGDL);
        //    cboGoverningDL.DataSource = dtGDL;
        //    cboGoverningDL.DisplayMember = "Governing_DL";
        //    cboGoverningDL.ValueMember = "GDL_ID";
        //    cboGoverningDL.Enabled = true;
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    cboGoverningDL.SelectedIndex = -1;
        //}

        //private void refreshBDAppNoCombo()
        //{
        //    if (cboBDAppNo.Items.Count > 0)
        //    {
        //        cboBDAppNo.DataSource = null;
        //        cboBDAppNo.DataBindings.Clear();
        //        cboBDAppNo.Items.Clear();
        //        dtBDApp.Clear();
        //    }

        //    SqlConnection con = new SqlConnection(Global.ConnectionString);
        //    SqlCommand cmd = new SqlCommand("qryVPGetAllApps", con);
        //    cmd.CommandTimeout = Global.TimeOut;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    da.SelectCommand = cmd;

        //    da.Fill(dtBDApp);
        //    cboBDAppNo.DataSource = dtBDApp;
        //    cboBDAppNo.DisplayMember = "BDApp_Number";
        //    cboBDAppNo.ValueMember = "BDApp_Number";
        //    cboBDAppNo.Enabled = true;
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    cboBDAppNo.SelectedIndex = -1;
        //}

        private void refreshVPBDAppNoCombo()
        {
            if (cboBDAppNo.Items.Count > 0)
            {
                cboBDAppNo.DataSource = null;
                cboBDAppNo.DataBindings.Clear();
                cboBDAppNo.Items.Clear();
                dtBDApp.Clear();
            }

            using (SqlConnection con = new SqlConnection(Global.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "qryVPGetAllAppNos";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    con.Close();

                    cboBDAppNo.DataSource = ds.Tables[0];
                    cboBDAppNo.DisplayMember = "BDApp_Number";
                    cboBDAppNo.ValueMember = "BDApp_ID";
                    cboBDAppNo.Enabled = true;
                    cboBDAppNo.SelectedIndex = -1;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            bool blnRestBDapp = false;
            string strBDAppID = "";
            string strBDAppNo = "";
            string strCriticality = "";

            if (this.cboRestBDApp.Text == "Yes")
            {
                blnRestBDapp = true;
            }
            if (this.Text == "DTaS APPendix - Add Application Details")
            {
                strBDAppNo = this.txtBDAppNo.Text; //Textbox BDApp Number
                strBDAppID = this.txtBDAppID.Text; //Textbox BDApp Number
                if (strBDAppID == "")
                {
                    strBDAppID = "0";
                }
            }
            else
            {
                if (cboBDAppNo.Text  == "")
                {
                    MessageBox.Show("Please select a BDApp Number.", "DTaS APPendix", MessageBoxButtons.OK);
                    return;
                }

                strBDAppID = this.cboBDAppNo.SelectedValue.ToString(); //Combobox ID Number
                if (this.txtBDAppNo.Enabled == true) // amend Application but user has chosen to amend BDApp Number
                {
                    strBDAppNo = this.txtBDAppNo.Text; //Textbox BDApp Number
                    if(strBDAppNo.Trim() == "")
                    {
                        strBDAppNo = this.cboBDAppNo.Text; //Combobox BDApp Number
                    }
                }
                else
                {
                    strBDAppNo = this.cboBDAppNo.Text; //Combobox BDApp Number
                }
            }
            if (cboCriticality.SelectedValue == null)
            {
                strCriticality = "6";
            }
            else
            {
                strCriticality = this.cboCriticality.SelectedValue.ToString(); //Business Criticality ID Number
            }

            if (strBDAppNo == "")
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please select a BDApp Number.", "Application Details", MessageBoxButtons.OK);
                return;
            }

            if (this.Text == "DTaS APPendix - Delete Application Details") // if Delete run Delete instruction
            {
                Cursor.Current = Cursors.Default;
                DialogResult dialogResult = MessageBox.Show("Please confirm you wish to delete the Application data - Yes/No", "Delete Application", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Apps apps = new Apps();
                    if (apps.DeleteBDApp(Convert.ToInt32(strBDAppNo)) == true)
                    {
                        blnLoad = true;
                        refreshVPBDAppNoCombo();
                        refreshDTaSAdminForm();
                        blnLoad = false;
                        this.cboBDAppNo.Focus();
                    }
                }
            }
            else // run update/add proceedure
            {
                // Save Proccedure for qryAddBDAppApplication - Updates or Saves dependant upon if the BDAppNo already exists
                Apps apps = new Apps();
                if (apps.UpdateAddBDApp(Convert.ToInt32(strBDAppID), Convert.ToInt32(strBDAppNo), txtBDAppName.Text, txtFriendlyName.Text, blnRestBDapp, Convert.ToInt16(cboGoverningDL.SelectedValue), txtAdminContact.Text, txtVersionNo.Text, txtBDAppFolder.Text, txtSourceFolder.Text, Convert.ToInt16(cboStatus.SelectedValue), txtUserInstallLocation.Text, Convert.ToInt32(Global.PID), txtUpdateProcess.Text, txtCommand.Text, txtCommandArgs.Text, cbAvailable_LaunchPad.Checked, chkGDPR.Checked, chkDPIA.Checked, chkSLA.Checked, txtDPIARef.Text, txtDPIALink.Text, txtSLALink.Text, cboDirectorate.Text, cboGroup.Text, Convert.ToInt32(strCriticality), chkBDAppReg.Checked, txtProductOwner.Text, txtBusSME.Text, txtBusContact.Text, Convert.ToInt32(cboLeadDev.SelectedValue), txtDataGaurdian.Text, txtDescription.Text, txtNotes.Text, txtSQLPreProd.Text, txtSQLLive.Text, cboFrontEnd.Text, cboBackEnd.Text) == true)
                {
                    blnLoad = true;
                    //refreshVPBDAppNoCombo();
                    //refreshDTaSAdminForm();
                    blnLoad = false;
                    if (this.cboBDAppNo.Enabled == false) // add Application
                    {
                        this.btnReviews.Enabled = true;
                        this.txtBDAppID.Text = Convert.ToString(Global.gblResult);
                        this.txtBDAppNo.Text = strBDAppNo;
                        this.txtBDAppNo.Focus();
                    }
                    else // amend Application
                    {
                        cboCriticality.SelectedValue = Convert.ToInt32(strCriticality);
                        cboBDAppNo.SelectedIndex = cboBDAppNo.FindStringExact(strBDAppNo);
                        this.txtBDAppNo.Enabled = false;
                        this.txtBDAppNo.Text = "";
                        this.btnAmendNumber.Image = DTaS_APPendix.Properties.Resources.lock_closed;
                        this.cboBDAppNo.Focus();
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void txtBDAppNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboBDAppNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad == false)
            {
                Cursor.Current = Cursors.WaitCursor;

                string strBDAppNo = cboBDAppNo.Text;
                txtBDAppID.Text = cboBDAppNo.SelectedValue.ToString();

                //Populate rest of form based upon BDAppNo Selected
                try
                {
                    SqlConnection con = new SqlConnection(Global.ConnectionString);
                    SqlCommand cmd = new SqlCommand("qryVPGetFullBDAppDetail", con);
                    cmd.CommandTimeout = Global.TimeOut;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDApp_ID", SqlDbType.Int);

                    prmBDAppID.Value = Convert.ToInt32(txtBDAppID.Text);

                    con.Open();

                    //OleDbDataReader dr = cmd.ExecuteReader();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr != null)
                    {
                        // Call Read before accessing data.
                        while (dr.Read())
                        {
                            txtBDAppName.Text = dr["BDApp_Name"].ToString();
                            txtFriendlyName.Text = dr["BDApp_Friendly_Name"].ToString();
                            if (string.IsNullOrEmpty(dr["Restricted_BDApp"].ToString()))
                            {
                                cboGoverningDL.SelectedIndex = -1;
                            }
                            else
                            {
                                if (dr["Restricted_BDApp"].ToString() == "True")
                                {
                                    cboRestBDApp.SelectedIndex = cboRestBDApp.FindStringExact("Yes");
                                }
                                else
                                {
                                    cboRestBDApp.SelectedIndex = cboRestBDApp.FindStringExact("No");
                                }
                            }
                            if (string.IsNullOrEmpty(dr["Governing_DL"].ToString()))
                            {
                                cboGoverningDL.SelectedIndex = -1;
                            }
                            else
                            {
                                cboGoverningDL.SelectedIndex = cboGoverningDL.FindStringExact(dr["Governing_DL"].ToString());
                            }
                            txtAdminContact.Text = dr["BDApp_Admin_Contact"].ToString();
                            txtVersionNo.Text = dr["BDApp_Version_Number"].ToString();
                            txtSourceFolder.Text = dr["BDApp_Source_Folder"].ToString();
                            txtBDAppFolder.Text = dr["BDAppFolder"].ToString();
                            if (string.IsNullOrEmpty(dr["Status_Description"].ToString()))
                            {
                                cboStatus.SelectedIndex = -1;
                            }
                            else
                            {
                                cboStatus.SelectedIndex = cboStatus.FindStringExact(dr["Status_Description"].ToString());
                            }
                            txtUserInstallLocation.Text = dr["User_Install_Location"].ToString();
                            txtUpdateProcess.Text = dr["Update_Process"].ToString();
                            txtCommand.Text = dr["BDApp_Command"].ToString();
                            txtCommandArgs.Text = dr["BDApp_Command_Args"].ToString();
                            if (string.IsNullOrEmpty(dr["Available_Via_Launcher"].ToString()))
                            {
                                cbAvailable_LaunchPad.Checked = false;
                            }
                            else
                            {
                                cbAvailable_LaunchPad.Checked = Convert.ToBoolean(dr["Available_Via_Launcher"]);
                            }
                            if (dr["GDPR"] != System.DBNull.Value)
                            {
                                chkGDPR.Checked = Convert.ToBoolean(dr["GDPR"]);
                            }
                            else
                            {
                                chkGDPR.Checked = false;
                            }
                            if (dr["DPIA"] != System.DBNull.Value)
                            {
                                chkDPIA.Checked = Convert.ToBoolean(dr["DPIA"]);
                            }
                            else
                            {
                                chkDPIA.Checked = false;
                            }                            
                            if (dr["SLA"] != System.DBNull.Value)
                            {
                                chkSLA.Checked = Convert.ToBoolean(dr["SLA"]);
                            }
                            else
                            {
                                chkSLA.Checked = false;
                            }                            
                            txtDPIARef.Text = dr["DPIA_Ref"].ToString();
                            txtDPIALink.Text = dr["DPIA_Link"].ToString();
                            txtSLALink.Text = dr["SLA_Link"].ToString();
                            txtBARTRank.Text = dr["BARTRank"].ToString();
                            cboDirectorate.SelectedIndex = cboDirectorate.FindStringExact(dr["Directorate"].ToString());
                            cboGroup.SelectedIndex = cboGroup.FindStringExact(dr["CGroup"].ToString());
                            cboCriticality.SelectedValue = dr["BusinessCriticality"];
                            if (dr["BDAppReg"] != System.DBNull.Value)
                            {
                                chkBDAppReg.Checked = Convert.ToBoolean(dr["BDAppReg"]);
                            }
                            else
                            {
                                chkBDAppReg.Checked = false;
                            }                            
                            txtProductOwner.Text = dr["ProductOwner"].ToString();
                            txtBusSME.Text = dr["BusinessSME"].ToString();
                            txtBusContact.Text = dr["BusinessContact"].ToString();
                            cboLeadDev.SelectedIndex = cboLeadDev.FindStringExact(dr["Full_Name"].ToString());
                            txtDataGaurdian.Text = dr["DataGuardian"].ToString();
                            txtDescription.Text = dr["BDAppDescription"].ToString();
                            txtNotes.Text = dr["BDAppNotes"].ToString();
                            txtSQLPreProd.Text = dr["SQLPreProd"].ToString();
                            txtSQLLive.Text = dr["SQLLive"].ToString();
                            cboFrontEnd.SelectedIndex = cboFrontEnd.FindStringExact(dr["FrontEnd"].ToString());
                            cboBackEnd.SelectedIndex = cboBackEnd.FindStringExact(dr["BackEnd"].ToString());
                        }
                        con.Close();
                    }

                }
                catch (SqlException ex)
                {
                    if (ex.Number == -2) // connection time-out
                    {
                        Cursor.Current = Cursors.Default;
                        System.Windows.Forms.MessageBox.Show("The application could not connect to the database, and will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        // Close the application
                        Environment.Exit(1);
                    }
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDTaSAdmin_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void cboGoverningDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDirectorate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad == false)
            {
                if (cboDirectorate.SelectedValue != null)
                {
                    DataView dv = cboGroup.DataSource as DataView;

                    //foreach (DataColumn col in dv.Table.Rows[0].Table.Columns)
                    //{
                    //    string name = col.ColumnName;
                    //}
                    try
                    {
                        dv.RowFilter = ("Directorate = '" + cboDirectorate.SelectedValue.ToString() + "'");
                    }
                    catch
                    {

                    }
                }
            }
        }
        

        private void btnReviews_Click(object sender, EventArgs e)
        {
            
            frmReviews frmReviews = new frmReviews() { TopMost = true };

            Cursor.Current = Cursors.WaitCursor;
            try
            {
            frmReviews.Text = "DTaS APPendix - Reviews";
            frmReviews.txtBDAppNo.Text = cboBDAppNo.Text;
            frmReviews.txtBDAppID.Text = cboBDAppNo.SelectedValue.ToString();
            }
            catch (Exception )
            {
                MessageBox.Show("Please select a BDApp Number.", "DTaS APPendix", MessageBoxButtons.OK);
                return;
            }


            Cursor.Current = Cursors.Default;

            frmReviews.ShowDialog();
        }

        private void btnBDAppFolder_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (txtBDAppFolder.Text !="")
            {
            if (IsUnc(txtBDAppFolder.Text.ToString()) == true)
            {
                this.TopMost = false;
                System.Diagnostics.Process.Start("explorer.exe", txtBDAppFolder.Text.ToString());
            }
            else
            {
                this.TopMost = false;
                System.Diagnostics.Process.Start(txtBDAppFolder.Text.ToString(), "chrome.exe");
            }
            }

            Cursor.Current = Cursors.Default;
        }

        private void bltnInstallFolder_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (txtSourceFolder.Text != "")
            {
                if (IsUnc(txtSourceFolder.Text.ToString()) == true)
                {
                    this.TopMost = false;
                    System.Diagnostics.Process.Start("explorer.exe", txtSourceFolder.Text.ToString());
                }
                else
                {
                    this.TopMost = false;
                    System.Diagnostics.Process.Start(txtSourceFolder.Text.ToString(), "chrome.exe");
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnDPIAFolder_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (txtDPIALink.Text != "")
            {
            if (IsUnc(txtDPIALink.Text.ToString()) == true)
            {
                this.TopMost = false;
                System.Diagnostics.Process.Start("explorer.exe", txtDPIALink.Text.ToString());
            }
            else
            {
                this.TopMost = false;
                System.Diagnostics.Process.Start(txtDPIALink.Text.ToString(), "chrome.exe");
            }
            }



            Cursor.Current = Cursors.Default;
        }

        private void btnSLAFolder_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (txtSLALink.Text != "")
            {
            if (IsUnc(txtSLALink.Text.ToString()) == true)
            {
                this.TopMost = false;
                System.Diagnostics.Process.Start("explorer.exe", txtSLALink.Text.ToString());
            }
            else
            {
                this.TopMost = false;
                System.Diagnostics.Process.Start(txtSLALink.Text.ToString(), "chrome.exe");
            }
            }


            Cursor.Current = Cursors.Default;
        }

        public static bool IsUnc(string path)
        {

            string root = Path.GetPathRoot(path);
            if (root == "")
                return false;

            // Check if root starts with "\\", clearly an UNC
            if (root.StartsWith(@"\\"))
                return true;

            // Check if the drive is a network drive
            DriveInfo drive = new DriveInfo(root);
            if (drive.DriveType == DriveType.Network)
                return true;

            return false;
        }

        private void btnOtherDev_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            frmOtherDevs frmotherdevs = new frmOtherDevs() { TopMost = true };

            frmotherdevs.txtBDAppID.Text = this.txtBDAppID.Text;

            frmotherdevs.ShowDialog();

            populateOtherDevDGVs(Convert.ToInt32(txtBDAppID.Text));

            Cursor.Current = Cursors.Default;
        }

        private void txtBDAppID_TextChanged(object sender, EventArgs e)
        {
            if (txtBDAppID.Text != "")
            {
                btnOtherDev.Enabled = true;
                populateOtherDevDGVs(Convert.ToInt32(txtBDAppID.Text));
            }            
        }

        private void populateOtherDevDGVs(int intBDAppID)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (SqlConnection con = new SqlConnection(Global.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "qryVPGetOtherDevsDGVs";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter prmBDAppID = cmd.Parameters.Add("@BDAppID", SqlDbType.Int);

                        prmBDAppID.Value = intBDAppID;

                        con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        con.Close();

                        this.OtherDevBindingSource.DataSource = ds.Tables[0];

                        this.dgvOtherDevs.DataSource = this.OtherDevBindingSource.DataSource;

                        //this.bDAppReviewBindingSource.Sort = "RDescription Desc";

                    }
                }
            }
            catch
            {

            }

            Cursor.Current = Cursors.Default;
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            bool blnRestBDapp = false;
            string strBDAppID = "";
            string strBDAppNo = "";
            string strCriticality = "";

            if (this.cboRestBDApp.Text == "Yes")
            {
                blnRestBDapp = true;
            }
            if (this.Text == "DTaS APPendix - Add Application Details")
            {
                strBDAppNo = this.txtBDAppNo.Text; //Textbox BDApp Number
                strBDAppID = this.txtBDAppID.Text; //Textbox BDApp Number
                if (strBDAppID == "")
                {
                    strBDAppID = "0";
                }
            }
            else
            {
                if (cboBDAppNo.Text == "")
                {
                    MessageBox.Show("Please select a BDApp Number.", "DTaS APPendix", MessageBoxButtons.OK);
                    return;
                }
                strBDAppID = this.cboBDAppNo.SelectedValue.ToString(); //Combobox ID Number
                if (this.txtBDAppNo.Enabled == true) // amend Application but user has chosen to amend BDApp Number
                {
                    strBDAppNo = this.txtBDAppNo.Text; //Textbox BDApp Number
                    if (strBDAppNo.Trim() == "")
                    {
                        strBDAppNo = this.cboBDAppNo.Text; //Combobox BDApp Number
                    }
                }
                else
                {
                    strBDAppNo = this.cboBDAppNo.Text; //Combobox BDApp Number
                }
            }
            if (cboCriticality.SelectedValue == null)
            {
                strCriticality = "6";
            }
            else
            {
                strCriticality = this.cboCriticality.SelectedValue.ToString(); //Business Criticality ID Number
            }

            if (strBDAppNo == "")
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please select a BDApp Number.", "Application Details", MessageBoxButtons.OK);
                return;
            }

            if (this.Text == "DTaS APPendix - Delete Application Details") // if Delete run Delete instruction
            {
                Cursor.Current = Cursors.Default;
                DialogResult dialogResult = MessageBox.Show("Please confirm you wish to delete the Application data - Yes/No", "Delete Application", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Apps apps = new Apps();
                    if (apps.DeleteBDApp(Convert.ToInt32(strBDAppNo)) == true)
                    {
                        blnLoad = true;
                        refreshVPBDAppNoCombo();
                        refreshDTaSAdminForm();
                        blnLoad = false;
                        this.cboBDAppNo.Focus();

                        Cursor.Current = Cursors.Default;

                        this.Close();
                    }
                }
            }
            else // run update/add proceedure
            {
                // Save Proccedure for qryAddBDAppApplication - Updates or Saves dependant upon if the BDAppNo already exists
                Apps apps = new Apps();
                if (apps.UpdateAddBDApp(Convert.ToInt32(strBDAppID), Convert.ToInt32(strBDAppNo), txtBDAppName.Text, txtFriendlyName.Text, blnRestBDapp, Convert.ToInt16(cboGoverningDL.SelectedValue), txtAdminContact.Text, txtVersionNo.Text, txtBDAppFolder.Text, txtSourceFolder.Text, Convert.ToInt16(cboStatus.SelectedValue), txtUserInstallLocation.Text, Convert.ToInt32(Global.PID), txtUpdateProcess.Text, txtCommand.Text, txtCommandArgs.Text, cbAvailable_LaunchPad.Checked, chkGDPR.Checked, chkDPIA.Checked, chkSLA.Checked, txtDPIARef.Text, txtDPIALink.Text, txtSLALink.Text, cboDirectorate.Text, cboGroup.Text, Convert.ToInt32(strCriticality), chkBDAppReg.Checked, txtProductOwner.Text, txtBusSME.Text, txtBusContact.Text, Convert.ToInt32(cboLeadDev.SelectedValue), txtDataGaurdian.Text, txtDescription.Text, txtNotes.Text, txtSQLPreProd.Text, txtSQLLive.Text, cboFrontEnd.Text, cboBackEnd.Text) == true)
                {
                    blnLoad = true;
                    //refreshVPBDAppNoCombo();
                    //refreshDTaSAdminForm();
                    blnLoad = false;
                    if (this.cboBDAppNo.Enabled == false)  // add Application

                    {
                        this.btnReviews.Enabled = true;
                        this.txtBDAppID.Text = Convert.ToString(Global.gblResult);
                        this.txtBDAppNo.Text = strBDAppNo;
                        this.txtBDAppNo.Focus();
                    }
                    else // amend Application
                    {
                        cboCriticality.SelectedValue = Convert.ToInt32(strCriticality);
                        cboBDAppNo.SelectedIndex = cboBDAppNo.FindStringExact(strBDAppNo);
                        this.txtBDAppNo.Enabled = false;
                        this.txtBDAppNo.Text = "";
                        this.btnAmendNumber.Image = DTaS_APPendix.Properties.Resources.lock_closed;
                        this.cboBDAppNo.Focus();
                    }

                    Cursor.Current = Cursors.Default;

                    this.Close();
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnAmendNumber_Click(object sender, EventArgs e)
        {
            if((cboBDAppNo.Enabled == true) && (this.txtBDAppNo.Enabled == false))
            {
                btnAmendNumber.Image = DTaS_APPendix.Properties.Resources.lock_open;
                this.txtBDAppNo.Enabled = true;
            }
            else if ((cboBDAppNo.Enabled = true) && (this.txtBDAppNo.Enabled = true))
            {
                btnAmendNumber.Image = DTaS_APPendix.Properties.Resources.lock_closed;
                this.txtBDAppNo.Text = "";
                this.txtBDAppNo.Enabled = false;
            }
        }

        private void btnDescription_Click(object sender, EventArgs e)
        {
            btnDescription.Image = DTaS_APPendix.Properties.Resources.lock_open;

            //open text form
            frmText frmtext = new frmText() { TopMost = true };

            frmtext.txtPrevious.Text = this.txtDescription.Text;
            frmtext.Text = "Description";

            frmtext.ShowDialog();

            if (frmText.rtnText == "Closed")
            {

            }
            else
            {
                this.txtDescription.Text = frmText.rtnText;
            }
            btnDescription.Image = DTaS_APPendix.Properties.Resources.lock_closed;

        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            btnNotes.Image = DTaS_APPendix.Properties.Resources.lock_open;

            //open text form
            frmText frmtext = new frmText() { TopMost = true };

            frmtext.txtPrevious.Text = this.txtNotes.Text;
            frmtext.Text = "Notes";

            frmtext.ShowDialog();

            if (frmText.rtnText == "Closed")
            {

            }
            else
            { 
                this.txtNotes.Text = frmText.rtnText;
            }

            btnNotes.Image = DTaS_APPendix.Properties.Resources.lock_closed;

        }
    }
}
