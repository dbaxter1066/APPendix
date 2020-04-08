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
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;

namespace DTaS_APPendix
{
    using Word = Microsoft.Office.Interop.Word;

    public partial class frmAssyst : Form
    {
        public DataTable dtAssRef = new DataTable();
        public DataTable dtBDApp = new DataTable();
        public DataTable dtDevs = new DataTable();
        public bool blnLoad;
        public bool blnNotAssRef;

        public frmAssyst()
        {
            blnLoad = true;
            blnNotAssRef = false;

            InitializeComponent();

            refreshAssystCombos();

            blnLoad = false;
            blnNotAssRef = true;
        }

        private void refreshAssystCombos()
        {
            //reset cboAssRef Combo
            if (cboAssRef.Items.Count > 0)
            {
                cboAssRef.DataSource = null;
                cboAssRef.DataBindings.Clear();
                cboAssRef.Items.Clear();
            }

            //reset cboBDAppNo Combo
            if (cboBDAppNo.Items.Count > 0)
            {
                cboBDAppNo.DataSource = null;
                cboBDAppNo.DataBindings.Clear();
                cboBDAppNo.Items.Clear();
                dtBDApp.Clear();
            }


            //reset cboAssignDev Combo
            if (cboAssignDev.Items.Count > 0)
            {
                cboAssignDev.DataSource = null;
                cboAssignDev.DataBindings.Clear();
                cboAssignDev.Items.Clear();
            }

            //reset cboAssFix Combo
            if (cboFix.Items.Count > 0)
            {
                cboFix.DataSource = null;
                cboFix.DataBindings.Clear();
                cboFix.Items.Clear();
            }

            try
            {
                using (SqlConnection con = new SqlConnection(Global.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "qryVPGetAssFormCombos";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        con.Close();

                        cboAssRef.DataSource = ds.Tables[0];
                        cboAssRef.DisplayMember = "Assyst_Reference";
                        cboAssRef.ValueMember = "Assyst_Reference";
                        cboAssRef.Enabled = true;
                        cboAssRef.SelectedIndex = -1;

                        cboBDAppNo.DataSource = ds.Tables[1];
                        cboBDAppNo.DisplayMember = "BDApp_Number";
                        cboBDAppNo.ValueMember = "BDApp_ID";
                        cboBDAppNo.Enabled = true;
                        cboBDAppNo.SelectedIndex = -1;

                        cboAssignDev.DataSource = ds.Tables[2];
                        cboAssignDev.DisplayMember = "Full_Name";
                        cboAssignDev.ValueMember = "PID";
                        cboAssignDev.Enabled = true;
                        cboAssignDev.SelectedIndex = -1;

                        cboFix.DataSource = ds.Tables[3];
                        cboFix.DisplayMember = "Assyst_Fix";
                        cboFix.ValueMember = "Assyst_Fix";
                        cboFix.Enabled = true;
                        cboFix.SelectedIndex = -1;
                    }
                }
            }
            catch
            {

            }
        }

        private void txtDateOpened_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtDateOpened_LostFocus(object sender, EventArgs e)
        {
            //add two weeks to date from txtDateOpened and populate date in txtSLATarget
            int addDays = 14;
            if ((txtDateOpened.Text != "") && (CheckDate(txtDateOpened.Text) != true))
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please enter a valid Date Resolved.", "Review Details", MessageBoxButtons.OK);
                return;
            }
            else if ((txtDateOpened.Text != "") && (CheckDate(txtDateOpened.Text) == true))
            {
                DateTime dateOpened = Convert.ToDateTime(this.txtDateOpened.Text.Trim());
                this.txtSLATarget.Text = dateOpened.AddDays(addDays).ToString("dd/MM/yyyy");
                this.txtDateOpened.Text = dateOpened.ToString("dd/MM/yyyy");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAssystCase();
            /*Cursor.Current = Cursors.WaitCursor;

            string strAssRef = "";
            string strBDAppID = "";

            if (this.Text == "DTaS APPendix - Add Assyst Case")
            {
                strAssRef = this.txtAssRef.Text; //Textbox Assyst Ref
                strBDAppID = this.cboBDAppNo.SelectedValue.ToString(); //Combobox BDApp ID
                if (strBDAppID == "")
                {
                    strBDAppID = "0";
                }
            }
            else
            {
                strAssRef = this.cboAssRef.SelectedValue.ToString(); //Combobox Ass Ref
                strBDAppID = this.cboBDAppNo.SelectedValue.ToString(); //Combobox ID Number
            }

            if (strAssRef == "")
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please select a Assyst Reference.", "Assyst Case", MessageBoxButtons.OK);
                return;
            }

            if (this.Text == "DTaS APPendix - Delete Assyst Case") // if Delete run Delete instruction
            {
                DialogResult dialogResult = MessageBox.Show("Please confirm you wish to delete the Assyst data - Yes/No", "Delete Assyst Case", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    VPAssyst vpassyst = new VPAssyst();
                    if (vpassyst.DeleteAss(Convert.ToInt32(strAssRef)) == true)
                    {
                        blnLoad = true;
                        blnNotAssRef = false;
                        refreshAssystCombos();
                        refreshAssystForm();
                        blnLoad = false;
                        blnNotAssRef = true;
                        this.cboAssRef.Focus();
                    }
                }
            }
            else // run update/add proceedure
            {
                if (txtDateOpened.Text == "")
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Please enter a valid Date Opened.", "Review Details", MessageBoxButtons.OK);
                    return;
                }

                if (CheckDate(txtDateOpened.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Date Opened.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }

                if (txtEmailSent.Text != "")
                {
                    if (CheckDate(txtEmailSent.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Email Sent Date.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (txtEmailChased.Text != "")
                {
                    if (CheckDate(txtEmailChased.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Email Chased Date.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (txtNAD.Text != "")
                {
                    if (CheckDate(txtNAD.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Next Action Date.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (txtDateResolved.Text != "")
                {
                    if (CheckDate(txtDateResolved.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Date Resolved.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }
                // Save Proccedure for qryAddBDAppApplication - Updates or Saves dependant upon if the BDAppNo already exists
                VPAssyst vpassyst = new VPAssyst();
                if (vpassyst.UpdateAddAss(Convert.ToInt32(strAssRef), Convert.ToInt32(strBDAppID), txtDateOpened.Text, txtSLATarget.Text, txtSummary.Text, Convert.ToInt32(cboAssignDev.SelectedValue), txtEmailSent.Text, txtEmailChased.Text, txtNotes.Text, txtNAD.Text, txtNA.Text, txtDateResolved.Text, cboFix.Text) == true)
                {
                    if (this.txtAssRef.Enabled == true)
                    {
                        this.txtAssRef.Text = strAssRef;
                        this.txtAssRef.Focus();
                    }
                    else
                    {
                        blnLoad = true;
                        blnNotAssRef = false;                        
                        cboAssRef.SelectedIndex = cboAssRef.FindStringExact(strAssRef);
                        this.cboAssRef.Focus();
                        blnNotAssRef = true;
                        blnLoad = false;
                    }
                }
            }

            Cursor.Current = Cursors.Default;*/
        }

        private void refreshAssystForm()
        {
            txtAssRef.Text = "";
            cboAssRef.SelectedIndex = -1;
            cboBDAppNo.SelectedIndex = -1;
            txtBDAppName.Text = "";
            txtDateOpened.Text = "";
            txtEmailSent.Text = "";
            txtEmailChased.Text = "";
            txtDateResolved.Text = "";
            txtNA.Text = "";
            txtNAD.Text = "";
            txtNotes.Text = "";
            txtSLATarget.Text = "";
            txtSummary.Text = "";
            cboAssignDev.SelectedIndex = -1;
            cboFix.SelectedIndex = -1;
        }

        private void cboAssRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad == false)
            {
                Cursor.Current = Cursors.WaitCursor;

                blnNotAssRef = false;

                string strAssRef = cboAssRef.Text;

                //Populate rest of form based upon BDAppNo Selected
                try
                {
                    SqlConnection con = new SqlConnection(Global.ConnectionString);
                    SqlCommand cmd = new SqlCommand("qryVPGetFullAssystDetail", con);
                    cmd.CommandTimeout = Global.TimeOut;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter prmAssRef = cmd.Parameters.Add("@nAssRef", SqlDbType.Int);

                    prmAssRef.Value = Convert.ToInt32(strAssRef);

                    con.Open();

                    //OleDbDataReader dr = cmd.ExecuteReader();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr != null)
                    {
                        // Call Read before accessing data.
                        while (dr.Read())
                        {
                            cboBDAppNo.SelectedIndex = cboBDAppNo.FindStringExact(dr["BDApp_Number"].ToString());
                            txtBDAppName.Text = dr["BDApp_Name"].ToString();
                            txtDateOpened.Text = Convert.ToDateTime(dr["Assyst_Open"].ToString()).ToShortDateString();
                            txtSLATarget.Text =Convert.ToDateTime(dr["SLA_Target"].ToString()).ToShortDateString();
                            txtSummary.Text = dr["Assyst_Description"].ToString();
                            cboAssignDev.SelectedIndex = cboAssignDev.FindStringExact(dr["Full_Name"].ToString());
                            if (Convert.ToString(dr["Email_Sent"].ToString()) == "")
                            {
                                txtEmailSent.Text = Convert.ToString("");
                            }
                            else
                            {
                                txtEmailSent.Text = Convert.ToDateTime(dr["Email_Sent"].ToString()).ToShortDateString(); // Email Sent
                            }
                            if (Convert.ToString(dr["Email_Chased"].ToString()) == "")
                            {
                                txtEmailChased.Text = Convert.ToString("");
                            }
                            else
                            {
                                txtEmailChased.Text = Convert.ToDateTime(dr["Email_Chased"].ToString()).ToShortDateString(); // Email Chased
                            }
                            txtNotes.Text = dr["Notes"].ToString(); //Notes
                            if (Convert.ToString(dr["Next_Action_Date"].ToString()) == "")
                            {
                                txtNAD.Text = Convert.ToString("");
                            }
                            else
                            {
                                txtNAD.Text = Convert.ToDateTime(dr["Next_Action_Date"].ToString()).ToShortDateString(); // Next Action Date
                            }                            
                            txtNA.Text = dr["Next_Action"].ToString();
                            cboFix.SelectedIndex = cboFix.FindStringExact(dr["Assyst_Fix"].ToString());
                            if (Convert.ToString(dr["Assyst_Close"].ToString()) == "")
                            {
                                txtDateResolved.Text = Convert.ToString("");
                            }
                            else
                            {
                                txtDateResolved.Text = Convert.ToDateTime(dr["Assyst_Close"].ToString()).ToShortDateString(); // Closed Date
                            }
                        }                                            
                    }

                    blnNotAssRef = true;
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

                    blnNotAssRef = true;
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void cboBDAppNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(blnNotAssRef ==true)
            {
                Cursor.Current = Cursors.WaitCursor;

                //BDApp No has changed and not because the Ass Ref has updated so we need to find corresponding BDApp Name
                string strBDAppID = this.cboBDAppNo.SelectedValue.ToString();

                //Populate rest of form based upon BDAppNo Selected
                try
                {
                    SqlConnection con = new SqlConnection(Global.ConnectionString);
                    SqlCommand cmd = new SqlCommand("qryVPGetBDAppName", con);
                    cmd.CommandTimeout = Global.TimeOut;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDAppID", SqlDbType.Int);

                    prmBDAppID.Value = Convert.ToInt32(strBDAppID);

                    con.Open();

                    //OleDbDataReader dr = cmd.ExecuteReader();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr != null)
                    {
                        // Call Read before accessing data.
                        while (dr.Read())
                        {
                            txtBDAppName.Text = dr["BDApp_Name"].ToString();                    
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == -2) // connection time-out
                    {
                        Cursor.Current = Cursors.Default;
                        System.Windows.Forms.MessageBox.Show("The application could not connect to the database, please try again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                //Populate KPI Details of form based upon BDAppNo Selected
                if (this.cboBDAppNo.Text != "")
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(Global.ConnectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "qryVPGetBDAppKPIs";
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDAppNo", SqlDbType.Int);

                                prmBDAppID.Value = Convert.ToInt32(this.cboBDAppNo.Text);

                                con.Open();

                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                                DataSet ds = new DataSet();
                                adapter.Fill(ds);

                                con.Close();

                                this.KPIbindingSource.DataSource = ds.Tables[0];

                                this.dgvKPIs.DataSource = this.KPIbindingSource.DataSource;

                            }
                        }
                
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == -2) // connection time-out
                        {
                            Cursor.Current = Cursors.Default;
                            System.Windows.Forms.MessageBox.Show("The application could not connect to the database, please try again.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }

                Cursor.Current = Cursors.Default;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CreateDocument();
            Cursor.Current = Cursors.Default;
        }

        
        private void CreateDocument()
        {
            if (cboAssRef.SelectedItem == null)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please select an Assyst Reference.", "Assyst Case", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string strAssRef = "";

            if (this.Text == "DTaS APPendix - Add Assyst Case")
            {
                strAssRef = this.txtAssRef.Text; //Textbox Assyst Ref
            }
            else
            {
                strAssRef = this.cboAssRef.SelectedValue.ToString(); //Combobox Ass Ref
            }

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            try
            {
//Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "Assyst Reference: " + strAssRef;
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 6;    //6 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();

            Word.Range wrdRng = oDoc.Range(0);
            wrdRng.Font.Bold = 0;
            wrdRng.ParagraphFormat.SpaceAfter = 6;
            if (cboBDAppNo.SelectedItem == null)
            {
                wrdRng.InsertAfter("BDApp Number: ");
            }
            else
            {
                wrdRng.InsertAfter("BDApp Number: " + cboBDAppNo.Text);
            }            
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("BDApp Name: " + txtBDAppName.Text);
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("Date Opened: " + txtDateOpened.Text);
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("SLA Target: " + txtSLATarget.Text);
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("Summary: " + txtSummary.Text);
            wrdRng.InsertParagraphAfter();
            if (cboAssignDev.SelectedItem == null)
            {
                wrdRng.InsertAfter("Assigned to Developer: ");
            }
            else
            {
                wrdRng.InsertAfter("Assigned to Developer: " + cboAssignDev.Text);
            }
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("Acknowledgement Email Sent: " + txtEmailSent.Text);
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("Email Chased: " + txtEmailChased.Text);
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("Notes: " + txtNotes.Text);
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("Next Action Date: " + txtNAD.Text);
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("Next Action: " + txtNA.Text);
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("Date Resolved: " + txtDateResolved.Text);
            wrdRng.InsertParagraphAfter();
            if (cboFix.SelectedItem == null)
            {
                wrdRng.InsertAfter("Fix Applied: ");
            }
            else
            {
                wrdRng.InsertAfter("Fix Applied: " + cboFix.Text);
            }            
            wrdRng.InsertParagraphAfter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgvKPIs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int intRow = dgvKPIs.CurrentCell.RowIndex;

            try
            {
                Process fileopener = new Process();
                fileopener.StartInfo.FileName = "explorer";
                fileopener.StartInfo.Arguments = "\"" + Convert.ToString(dgvKPIs.Rows[intRow].Cells[1].Value) + "\"";
                this.TopMost = false;
                fileopener.Start();
            }
            catch
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Invalid KPI filepath.", "Assyst KPI", MessageBoxButtons.OK);
                return;
            }
            
            Cursor.Current = Cursors.Default;

        }

        private void frmAssyst_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveAssystCase();
            this.Close();
        }

        private void SaveAssystCase()
        {
            Cursor.Current = Cursors.WaitCursor;

            string strAssRef = "";
            string strBDAppID = "";

            if (this.Text == "DTaS APPendix - Add Assyst Case")
            {
                strAssRef = this.txtAssRef.Text; //Textbox Assyst Ref
                //strBDAppID = this.cboBDAppNo.SelectedValue.ToString(); //Combobox BDApp ID
                if (strBDAppID == "")
                {
                    strBDAppID = "0";
                }
            }
            else
            {
                strAssRef = this.cboAssRef.SelectedValue.ToString(); //Combobox Ass Ref
                strBDAppID = this.cboBDAppNo.SelectedValue.ToString(); //Combobox ID Number

                if (strAssRef == "")
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Please select a Assyst Reference.", "Assyst Case", MessageBoxButtons.OK);
                    return;
                }

            }

            if (strAssRef == "")
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please select a Assyst Reference.", "Assyst Case", MessageBoxButtons.OK);
                return;
            }

            if (this.Text == "DTaS APPendix - Delete Assyst Case") // if Delete run Delete instruction
            {
                DialogResult dialogResult = MessageBox.Show("Please confirm you wish to delete the Assyst data - Yes/No", "Delete Assyst Case", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    VPAssyst vpassyst = new VPAssyst();
                    if (vpassyst.DeleteAss(Convert.ToInt32(strAssRef)) == true)
                    {
                        blnLoad = true;
                        blnNotAssRef = false;
                        refreshAssystCombos();
                        refreshAssystForm();
                        blnLoad = false;
                        blnNotAssRef = true;
                        this.cboAssRef.Focus();
                    }
                }
            }
            else // run update/add proceedure
            {
                if (txtDateOpened.Text == "")
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Please enter a valid Date Opened.", "Review Details", MessageBoxButtons.OK);
                    return;
                }

                if (CheckDate(txtDateOpened.Text) != true)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Please enter a valid Date Opened.", "Review Details", MessageBoxButtons.OK);
                    return;
                }

                if (txtEmailSent.Text != "")
                {
                    if (CheckDate(txtEmailSent.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Email Sent Date.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (txtEmailChased.Text != "")
                {
                    if (CheckDate(txtEmailChased.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Email Chased Date.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (txtNAD.Text != "")
                {
                    if (CheckDate(txtNAD.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Next Action Date.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (txtDateResolved.Text != "")
                {
                    if (CheckDate(txtDateResolved.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Date Resolved.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }
                // Save Proccedure for qryAddBDAppApplication - Updates or Saves dependant upon if the BDAppNo already exists
                VPAssyst vpassyst = new VPAssyst();
                if (vpassyst.UpdateAddAss(Convert.ToInt32(strAssRef), Convert.ToInt32(strBDAppID), txtDateOpened.Text, txtSLATarget.Text, txtSummary.Text, Convert.ToInt32(cboAssignDev.SelectedValue), txtEmailSent.Text, txtEmailChased.Text, txtNotes.Text, txtNAD.Text, txtNA.Text, txtDateResolved.Text, cboFix.Text) == true)
                {
                    if (this.txtAssRef.Enabled == true)
                    {
                        this.txtAssRef.Text = strAssRef;
                        this.txtAssRef.Focus();
                    }
                    else
                    {
                        blnLoad = true;
                        blnNotAssRef = false;
                        cboAssRef.SelectedIndex = cboAssRef.FindStringExact(strAssRef);
                        this.cboAssRef.Focus();
                        blnNotAssRef = true;
                        blnLoad = false;
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

    }
}
