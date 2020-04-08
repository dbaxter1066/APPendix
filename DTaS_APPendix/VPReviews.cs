using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace DTaS_APPendix
{
    //class VPReviews
    //{
    //    public IList<VPRew> VPRewList { get { return this._vprews; } }
    //    private List<VPRew> _vprews = new List<VPRew>();

    //    // Public methods.  
    //    public void Add(VPRew c)
    //    {
    //        _vprews.Add(c);
    //    }

    //    public IEnumerator GetEnumerator()
    //    {
    //        foreach (VPRew _vprew in _vprews)
    //        {
    //            yield return _vprew;
    //        }
    //    }

    //    public void GetBDAppReviews(int intBDAppID)
    //    {
    //        VPRew _vprew = null;
    //        try
    //        {
    //            SqlConnection con = new SqlConnection(Global.ConnectionString);
    //            SqlCommand cmd = new SqlCommand("qryVPGetBDAppReviews", con);
    //            cmd.CommandTimeout = Global.TimeOut;
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.Clear();
    //            SqlParameter prmBDAppID = cmd.Parameters.Add("@BDAppID", SqlDbType.Int);
    //            prmBDAppID.Value = intBDAppID;

    //            con.Open();

    //            //OleDbDataReader dr = cmd.ExecuteReader();
    //            SqlDataReader dr = cmd.ExecuteReader();

    //            if (dr != null)
    //            {
    //                // Call Read before accessing data.
    //                while (dr.Read())
    //                {
    //                    _vprew = new VPRew();
    //                    _vprew.BDApp_ID = Convert.ToInt32(dr["BDApp_ID"].ToString());
    //                    _vprew.BDApp_Number = Convert.ToInt32(dr["BDApp_Number"].ToString());
    //                    try
    //                    {
    //                        _vprew.RDate = Convert.ToDateTime(dr["Review_Date"].ToString());
    //                    }
    //                    catch
    //                    {
    //                        _vprew.RDate = Convert.ToDateTime("01/01/1900 00:00:00");
    //                    }
    //                    _vprew.RDescription = Convert.ToString(dr["Review_Description"]);
    //                    _vprew.RNotes = Convert.ToString(dr["Notes"]);
    //                    _vprews.Add(_vprew);
    //                }
    //            }
    //        }
    //        catch (SqlException ex)
    //        {
    //            if (ex.Number == -2) // connection time-out
    //            {
    //                System.Windows.Forms.MessageBox.Show("The application could not connect to the database, and will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
    //                // Close the application
    //                Environment.Exit(1);
    //            }
    //        }
    //    }
    //}

    public class VPRew
    {

        private Int32 _rewId;
        private Int32 _bdappId;
        private Int32 _bdappNumber;
        private DateTime _rDate;
        private string _rRag;
        private string _rDescription;
        private string _rNotes;
        private DateTime _rActioned;


        public VPRew()
        {

        }

        public VPRew(int _rewid, int _bdappid, int _bdappnumber, DateTime _rdate, string _rrag, string _rdescription, string _rnotes, DateTime _ractioned)
        {
            this._rewId = _rewid;
            this._bdappId = _bdappid;
            this._bdappNumber = _bdappnumber;
            this._rDate = _rdate;
            this._rRag = _rrag;
            this._rDescription = _rdescription;
            this._rNotes = _rnotes;
            this._rActioned = _ractioned;
        }

        public Boolean UpdateAddReview(int intReviewID, int intBDAppID, int intBDAppNo, string dtReviewDate, string strDescription, string strNotes, string dtActioned)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPAddReview", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                SqlParameter prmReviewID = cmd.Parameters.Add("@nReviewID", SqlDbType.Int);
                prmReviewID.Value = intReviewID;
                SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDAppID", SqlDbType.Int);
                prmBDAppID.Value = intBDAppID;
                SqlParameter prmBDAppNo = cmd.Parameters.Add("@nBDAppNo", SqlDbType.Int);
                prmBDAppNo.Value = intBDAppNo;
                SqlParameter prmReviewDate = cmd.Parameters.Add("@nReviewDate", SqlDbType.Date);
                if (dtReviewDate == "")
                {
                    prmReviewDate.Value = DBNull.Value;
                }
                else
                {
                    prmReviewDate.Value = dtReviewDate;
                }
                SqlParameter prmDescription = cmd.Parameters.Add("@nDescription", SqlDbType.NVarChar);
                prmDescription.Value = strDescription;
                SqlParameter prmNotes = cmd.Parameters.Add("@nNotes", SqlDbType.NVarChar);
                prmNotes.Value = strNotes;
                SqlParameter prmActioned = cmd.Parameters.Add("@nActioned", SqlDbType.Date);
                if (dtActioned == "")
                {
                    prmActioned.Value = DBNull.Value;
                }
                else
                {
                    prmActioned.Value = dtActioned;
                }
                var returnParameter = cmd.Parameters.Add("@nReviewID", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                Global.gblResult = Convert.ToInt16(returnParameter.Value);
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();

                MessageBox.Show("Review data successfully saved.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to add Review.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public Boolean DeleteReview(int intReviewID)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPDeleteReview", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                SqlParameter prmReviewID = cmd.Parameters.Add("@nReviewID", SqlDbType.Int);
                prmReviewID.Value = intReviewID;
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();

                MessageBox.Show("Review data successfully deleted.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to delete Review.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false; ;
            }
        }

        public Int32 Review_ID
        {
            get
            {
                return _rewId;
            }
            set
            {
                _rewId = value;
            }
        }

        public Int32 BDApp_ID
        {
            get
            {
                return _bdappId;
            }
            set
            {
                _bdappId = value;
            }
        }

        public Int32 BDApp_Number
        {
            get
            {
                return _bdappNumber;
            }
            set
            {
                _bdappNumber = value;
            }
        }

        public DateTime RDate
        {
            get
            {
                return _rDate;
            }
            set
            {
                _rDate = value;
            }
        }

        public String RRag
        {
            get
            {
                return _rRag;
            }
            set
            {
                _rRag = value;
            }
        }

        public String RDescription
        {
            get
            {
                return _rDescription;
            }
            set
            {
                _rDescription = value;
            }
        }

        public String RNotes
        {
            get
            {
                return _rNotes;
            }
            set
            {
                _rNotes = value;
            }
        }

        public DateTime RActioned
        {
            get
            {
                return _rActioned;
            }
            set
            {
                _rActioned = value;
            }
        }
    }

    public class VPWOH
    {

        private DateTime _wohStart;
        private string _wohDescription;
        private DateTime _wohTarget;


        public VPWOH()
        {

        }

        public VPWOH( DateTime _wohstart, string _wohdescription, DateTime _wohtarget)
        {
            this._wohStart = _wohstart;
            this._wohDescription = _wohdescription;
            this._wohTarget = _wohtarget;
        }

        public DateTime WOHStart
        {
            get
            {
                return _wohStart;
            }
            set
            {
                _wohStart = value;
            }
        }

        public String WOHDescription
        {
            get
            {
                return _wohDescription;
            }
            set
            {
                _wohDescription = value;
            }
        }

        public DateTime WOHTarget
        {
            get
            {
                return _wohTarget;
            }
            set
            {
                _wohTarget = value;
            }
        }
    }

    public class VPAssyst
    {

        private Int32 _assRef;
        private Int32 _bdappID;
        private string _assDescription;
        private DateTime _assStart;
        private string _assRag;
        private Int32 _assDev;
        private DateTime _assSla;
        private DateTime _assSent;
        private DateTime _assChased;
        private DateTime _assClosed;
        private string _assNotes;
        private DateTime _assNad;
        private string _assNa;
        private string _assFix;

        public VPAssyst()
        {

        }

        public VPAssyst(int _assref, int _bdappid, string _assdescription, DateTime _assstart, string _assrag, int _assdev, DateTime _asssla, DateTime _asssent, DateTime _asschased, DateTime _assclosed, string _assnotes, DateTime _assnad, string _assna, string _assfix)
        {
            this._assRef = _assref;
            this._bdappID = _bdappid;
            this._assDescription = _assdescription;
            this._assStart = _assstart;
            this._assRag = _assrag;
            this._assDev = _assdev;
            this._assSla = _asssla;
            this._assSent = _asssent;
            this._assChased = _asschased;
            this._assClosed = _assclosed;
            this._assNotes = _assnotes;
            this._assNad = _assnad;
            this._assNa = _assna;
            this._assFix = _assfix;
        }

        public Int32 ASSRef
        {
            get
            {
                return _assRef;
            }
            set
            {
                _assRef = value;
            }
        }

        public Int32 BDApp_ID
        {
            get
            {
                return _bdappID;
            }
            set
            {
                _bdappID = value;
            }
        }

        public String ASSDescription
        {
            get
            {
                return _assDescription;
            }
            set
            {
                _assDescription = value;
            }
        }

        public DateTime ASSStart
        {
            get
            {
                return _assStart;
            }
            set
            {
                _assStart = value;
            }
        }

        public String ASSRag
        {
            get
            {
                return _assRag;
            }
            set
            {
                _assRag = value;
            }
        }

        public Int32 ASSDev
        {
            get
            {
                return _assDev;
            }
            set
            {
                _assDev = value;
            }
        }


        public DateTime ASSSla
        {
            get
            {
                return _assSla;
            }
            set
            {
                _assSla = value;
            }
        }

        public DateTime ASSSent
        {
            get
            {
                return _assSent;
            }
            set
            {
                _assSent = value;
            }
        }

        public DateTime ASSChased
        {
            get
            {
                return _assChased;
            }
            set
            {
                _assChased = value;
            }
        }

        public DateTime ASSClosed
        {
            get
            {
                return _assClosed;
            }
            set
            {
                _assClosed = value;
            }
        }

        public String ASSNotes
        {
            get
            {
                return _assNotes;
            }
            set
            {
                _assNotes = value;
            }
        }
        public DateTime ASSNad
        {
            get
            {
                return _assNad;
            }
            set
            {
                _assNad = value;
            }
        }

        public String ASSNa
        {
            get
            {
                return _assNa;
            }
            set
            {
                _assNa = value;
            }
        }

        public String ASSFix
        {
            get
            {
                return _assFix;
            }
            set
            {
                _assFix = value;
            }
        }

        public Boolean DeleteAss(int intAssID)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPDeleteAssystCase", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                SqlParameter prmAssID = cmd.Parameters.Add("@nAssID", SqlDbType.Int);
                prmAssID.Value = intAssID;
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();

                MessageBox.Show("Assyst Case successfully deleted.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to delete Assyst Case.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false; ;
            }
        }

        public Boolean UpdateAddAss(int intAssRef, int intBDAppID, string dtDateOpened, string dtSLATarget, string strDescription,  int intAssDev, string dtEmailSent, string dtEmailChased, string strNotes, string dtNAD, string strNA, string dtResolved, string strFix)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPAddAss", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                SqlParameter prmAssRef = cmd.Parameters.Add("@nAssRef", SqlDbType.Int);
                prmAssRef.Value = intAssRef;
                SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDAppID", SqlDbType.Int);
                prmBDAppID.Value = intBDAppID;
                SqlParameter prmDateOpened = cmd.Parameters.Add("@nDateOpened", SqlDbType.Date);
                if (dtDateOpened == "")
                {
                    prmDateOpened.Value = DBNull.Value;
                }
                else
                {
                    prmDateOpened.Value = dtDateOpened;
                }
                SqlParameter prmSLATarget = cmd.Parameters.Add("@nSLATarget", SqlDbType.Date);
                if (dtSLATarget == "")
                {
                    prmSLATarget.Value =  DBNull.Value;
                }
                else
                {
                    prmSLATarget.Value = dtSLATarget;
                }                
                SqlParameter prmDescription = cmd.Parameters.Add("@nDescription", SqlDbType.NVarChar);
                prmDescription.Value = strDescription;                
                SqlParameter prmAssDev = cmd.Parameters.Add("@nAssDev", SqlDbType.Int);
                prmAssDev.Value = intAssDev;
                SqlParameter prmEmailSent = cmd.Parameters.Add("@nEmailSent", SqlDbType.Date);
                if (dtEmailSent == "")
                {
                    prmEmailSent.Value = DBNull.Value;
                }
                else
                {
                    prmEmailSent.Value = dtEmailSent;
                }                
                SqlParameter prmEmailChased = cmd.Parameters.Add("@nEmailChased", SqlDbType.Date);
                if (dtEmailChased == "")
                {
                    prmEmailChased.Value = DBNull.Value;
                }
                else
                {
                    prmEmailChased.Value = dtEmailChased;
                }
                SqlParameter prmNotes = cmd.Parameters.Add("@nNotes", SqlDbType.NVarChar);
                prmNotes.Value = strNotes;
                SqlParameter prmNAD = cmd.Parameters.Add("@nNAD", SqlDbType.Date);
                if (dtNAD == "")
                {
                    prmNAD.Value = DBNull.Value;
                }
                else
                {
                    prmNAD.Value = dtNAD;
                }
                SqlParameter prmNA = cmd.Parameters.Add("@nNA", SqlDbType.NVarChar);
                prmNA.Value = strNA;
                SqlParameter prmResolved = cmd.Parameters.Add("@nResolved", SqlDbType.Date);
                if (dtResolved == "")
                {
                    prmResolved.Value = DBNull.Value;
                }
                else
                {
                    prmResolved.Value = dtResolved;
                }
                SqlParameter prmFix = cmd.Parameters.Add("@nFix", SqlDbType.NVarChar);
                prmFix.Value = strFix;
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();

                MessageBox.Show("Assyst Case data successfully saved.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to add Assyst Case data.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }

    public class VPOthDev
    {
        private bool _devCheck;
        private string _devFullName;
        private Int32 _devPID;
               
        public VPOthDev()
        {

        }

        public VPOthDev(bool _devcheck, string _devfullname, int _devpid)
        {
            this._devCheck = _devcheck;
            this._devPID = _devpid;
            this._devFullName = _devfullname;
        }

        public bool DevCheck
        {
            get
            {
                return _devCheck;
            }
            set
            {
                _devCheck = value;
            }
        }

        public Int32 DEVPID
        {
            get
            {
                return _devPID;
            }
            set
            {
                _devPID = value;
            }
        }

        public String Full_Name
        {
            get
            {
                return _devFullName;
            }
            set
            {
                _devFullName = value;
            }
        }
    }

    public class VPKPI
    {
        private string _kpiDescription;
        private string _kpiLink;

        public VPKPI()
        {

        }

        public VPKPI(string _kpidescription, string _kpilink)
        {
            this._kpiDescription = _kpidescription;
            this._kpiLink = _kpilink;
        }

        public string KPI_Description
        {
            get
            {
                return _kpiDescription;
            }
            set
            {
                _kpiDescription = value;
            }
        }

        public String KPI_Link
        {
            get
            {
                return _kpiLink;
            }
            set
            {
                _kpiLink = value;
            }
        }
    }
}
