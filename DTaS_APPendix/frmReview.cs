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
using System.Diagnostics;


namespace DTaS_APPendix
{
    public partial class frmReview : Form
    {

        public DataTable dtDes = new DataTable();
        public DataTable dtRD = new DataTable();
        public DataSet ds = new DataSet();
        public bool blnLoad;
        public bool blnDes;

        public frmReview()
        {
            InitializeComponent();
            blnLoad = true;
            blnDes = true;
        }

        public void refreshReviewCombos(int intBDAppID)
        {
            //reset cboReviewDate Combo
            if (cboReviewDate.Items.Count > 0)
            {
                cboReviewDate.DataSource = null;
                cboReviewDate.DataBindings.Clear();
                cboReviewDate.Items.Clear();
                dtRD.Clear();
            }

            try
            {
                using (SqlConnection con = new SqlConnection(Global.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "qryVPGetReviewFormCombos";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDAppID", SqlDbType.Int);

                        prmBDAppID.Value = intBDAppID;

                        //con.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //DataSet ds = new DataSet();
                        ds.Clear();
                        adapter.Fill(ds);

                        con.Close();

                        cboReviewDate.DataSource = ds.Tables[1];
                        cboReviewDate.DisplayMember = "Review_Date";
                        cboReviewDate.ValueMember = "Review_ID";
                        cboReviewDate.Enabled = true;
                        cboReviewDate.SelectedIndex = -1;

                        if (blnDes == true)
                        {
                            //reset cboDescription Combo
                            if (cboDescription.Items.Count > 0)
                            {
                                cboDescription.DataSource = null;
                                cboDescription.DataBindings.Clear();
                                cboDescription.Items.Clear();
                            }

                            cboDescription.DataSource = ds.Tables[0];
                            cboDescription.DisplayMember = "RDescription";
                            cboDescription.ValueMember = "RSOP";
                            cboDescription.Enabled = true;
                            cboDescription.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtReviewID_TextChanged(object sender, EventArgs e)
        {
            refreshReviewCombos(Convert.ToInt32(txtBDAppID.Text));
        }

        private void cboReviewDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blnLoad != true)
            {

                try
                {
                    int intReviewID = Convert.ToInt32(cboReviewDate.SelectedValue);

                    {
                        using (SqlConnection con = new SqlConnection(Global.ConnectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "qryVPGetReviewDetails";
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlParameter prmReviewID = cmd.Parameters.Add("@nReviewID", SqlDbType.Int);

                                prmReviewID.Value = intReviewID;

                                con.Open();

                                //OleDbDataReader dr = cmd.ExecuteReader();
                                SqlDataReader dr = cmd.ExecuteReader();

                                if (dr != null)
                                {
                                    // Call Read before accessing data.
                                    while (dr.Read())
                                    {
                                        if (string.IsNullOrEmpty(dr["Review_Description"].ToString()))
                                        {
                                            cboDescription.SelectedIndex = -1;
                                        }
                                        else
                                        {
                                            cboDescription.SelectedIndex = cboDescription.FindStringExact(dr["Review_Description"].ToString());
                                        }
                                        if (string.IsNullOrEmpty(dr["Notes"].ToString()))
                                        {
                                            txtNotes.Text = "";
                                        }
                                        else
                                        {
                                            txtNotes.Text = dr["Notes"].ToString();
                                        }
                                        if (string.IsNullOrEmpty(dr["Actioned"].ToString()))
                                        {
                                            txtActionedDate.Text = "";
                                        }
                                        else
                                        {
                                            txtActionedDate.Text = Convert.ToDateTime(dr["Actioned"]).ToString("dd/MM/yyyy");
                                        }
                                        txtReviewDate.Text = Convert.ToDateTime(dr["Review_Date"]).ToString("dd/MM/yyyy");
                                    }
                                }
                                con.Close();
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string strReviewID = "";
            string strReviewDate = "";
            string strBDAppNo = "";
            string strBDAppID = "";

            if (this.Text == "DTaS APPendix - Add Review")
            {
                strBDAppNo = this.txtBDAppNo.Text; //Textbox BDApp Number
                strBDAppID = this.txtBDAppID.Text; //textbox BDApp Number
                strReviewID = this.txtReviewID.Text; //Textbox Review Number
                strReviewDate = this.txtReviewDate.Text; // Review Date
                if (strReviewID == "")
                {
                    strReviewID = "0";
                }
            }
            else
            {
                strReviewID = this.cboReviewDate.SelectedValue.ToString(); //Combobox Review ID
                strBDAppNo = this.txtBDAppNo.Text; //textbox BDApp Number
                strBDAppID = this.txtBDAppID.Text; //textbox BDApp Number
                strReviewDate = this.txtReviewDate.Text; //Combobox Review Date Number
            }

            if (strBDAppNo == "")
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please select a BDApp Number.", "Review Details", MessageBoxButtons.OK);
                return;
            }

            if (strReviewDate == "")
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please enter a Review Date.", "Review Details", MessageBoxButtons.OK);
                return;
            }

            if (CheckDate(strReviewDate) != true)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Please enter a valid Review Date.", "Review Details", MessageBoxButtons.OK);
                return;
            }

            if (this.Text == "DTaS APPendix - Delete Review") // if Delete run Delete instruction
            {
                Cursor.Current = Cursors.Default;
                DialogResult dialogResult = MessageBox.Show("Please confirm you wish to delete the Review - Yes/No", "Delete Review", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    VPRew reviews = new VPRew();
                    if (reviews.DeleteReview(Convert.ToInt32(strReviewID)) == true)
                    {
                        blnLoad = true;
                        blnDes = false;
                        refreshReviewCombos(Convert.ToInt32(strBDAppID));
                        blnLoad = false;
                        this.cboReviewDate.Focus();
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            else // run update/add proceedure
            {
                Cursor.Current = Cursors.WaitCursor;

                if (txtActionedDate.Text != "")
                {
                    if (CheckDate(txtActionedDate.Text) != true)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please enter a valid Actioned Date.", "Review Details", MessageBoxButtons.OK);
                        return;
                    }
                }

                // Save Proccedure for qryAddBDAppApplication - Updates or Saves dependant upon if the BDAppNo already exists
                VPRew reviews = new VPRew();
                if (reviews.UpdateAddReview(Convert.ToInt32(strReviewID), Convert.ToInt32(strBDAppID), Convert.ToInt32(strBDAppNo), strReviewDate, cboDescription.Text.ToString(), txtNotes.Text, txtActionedDate.Text) == true)
                {
                    blnLoad = true;
                    blnDes = false;
                    refreshReviewCombos(Convert.ToInt32(strBDAppID));
                    //refreshDTaSAdminForm();
                    blnLoad = false;
                    if (this.txtBDAppNo.Visible == true) //Add Review

                    {
                        this.txtReviewID.Text = "";
                        this.txtBDAppNo.Text = strBDAppNo;
                        this.txtBDAppID.Text = strBDAppID;
                        this.txtReviewDate.Text = "";
                        this.cboReviewDate.SelectedIndex = -1;
                        this.cboDescription.SelectedIndex = -1;
                        this.txtNotes.Text = "";
                        this.txtActionedDate.Text = "";
                    }
                    else  // Update Review
                    {
                        cboReviewDate.SelectedIndex = cboReviewDate.FindStringExact(strReviewID);
                        this.cboReviewDate.Focus();
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

        private void btnSOP_Click(object sender, EventArgs e)
        {
            if (this.cboDescription.SelectedValue.ToString() != "")
                try
                {
                    Process fileopener = new Process();
                    fileopener.StartInfo.FileName = "explorer";
                    fileopener.StartInfo.Arguments = "\"" + this.cboDescription.SelectedValue.ToString() + "\"";
                    this.TopMost = false;
                    fileopener.Start();
                }
                catch
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Invalid SOP filepath.", "Review SOP", MessageBoxButtons.OK);
                    return;
                }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("No SOP for this Review Description.", "Review SOP", MessageBoxButtons.OK);
                return;
            }
        }

        private void frmReview_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
