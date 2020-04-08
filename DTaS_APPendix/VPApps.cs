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
    class VPApps : IEnumerable
    {
        public IList<VPBDApp> VPBDAppList { get { return this._vpapps; } }
        private List<VPBDApp> _vpapps = new List<VPBDApp>();

        // Public methods.  
        public void Add(VPBDApp c)
        {
            _vpapps.Add(c);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (VPBDApp _vpapp in _vpapps)
            {
                yield return _vpapp;
            }
        }

        public void GetAllBDApps()
        {
            VPBDApp _vpapp = null;
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPGetAllBDApps", con);
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
                        _vpapp = new VPBDApp();
                        _vpapp.BDApp_ID = Convert.ToInt32(dr["BDApp_ID"].ToString());
                        _vpapp.BDApp_Number = Convert.ToInt32(dr["BDApp_Number"].ToString());
                        _vpapp.BDApp_Name = dr["BDApp_Name"].ToString();
                        _vpapp.Available_Launcher = Convert.ToBoolean(dr["Available_Via_Launcher"].ToString());
                        _vpapp.Rank_Bart = Convert.ToInt32(dr["BART_Ranking"].ToString());
                        _vpapp.GDPR = Convert.ToBoolean(dr["GDPR"]);
                        _vpapp.DPI = Convert.ToBoolean(dr["DPIA"]);
                        _vpapp.SLA = Convert.ToBoolean(dr["SLA"]);
                        _vpapp.BDApp_Status = Convert.ToInt16(dr["BDApp_Status"].ToString());
                        byte[] statusimg = (byte[])dr["Status_Image"]; /*read image*/
                        MemoryStream statusms = new MemoryStream(statusimg); /*set as MemoryStream e*/
                        _vpapp.Status = new Bitmap(statusms);  /*assign as bitmap*/
                        _vpapp.Status_Description = dr["Status_Description"].ToString();
                        try
                        {
                            _vpapp.Date_Review = Convert.ToDateTime(dr["Next_Review_Date"].ToString());
                        }
                        catch
                        {
                            _vpapp.Date_Review = Convert.ToDateTime("01/01/2050 00:00:00");
                        }
                        try
                        {
                            _vpapp.Date_LastUpdated = Convert.ToDateTime(dr["Date_Updated"].ToString());
                        }
                        catch
                        {
                            _vpapp.Date_LastUpdated = Convert.ToDateTime("01/01/2050 00:00:00");
                        }
                        _vpapp.Directorate = dr["Directorate"].ToString();
                        _vpapp.CGroup = dr["CGroup"].ToString();
                        _vpapp.BusCrit = dr["BusCrit"].ToString();
                        _vpapp.BDAppReg = Convert.ToBoolean(dr["BDAppReg"]);
                        _vpapp.ProductOwner = dr["ProductOwner"].ToString();
                        _vpapp.BusSME = dr["BusinessSME"].ToString();
                        _vpapp.BusContact = dr["BusinessContact"].ToString();
                        _vpapp.LeadDev = dr["Full_Name"].ToString();
                        _vpapp.DataGuardian = dr["DataGuardian"].ToString();
                        _vpapp.BDAppDescription = dr["BDAppDescription"].ToString();
                        _vpapp.BDAppNotes = dr["BDAppNotes"].ToString();
                        _vpapp.ReviewRAG = dr["RAG"].ToString();
                        _vpapps.Add(_vpapp);
                    }
                }

                con.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == -2) // connection time-out
                {
                    System.Windows.Forms.MessageBox.Show("The application could not connect to the database, and will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // Close the application
                    Environment.Exit(1);
                }
            }
        }

        public Boolean DeleteBDApp(int intBDAppNo)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryDeleteBDAppApplication", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                SqlParameter prmBDAppNo = cmd.Parameters.Add("@nBDAppNo", SqlDbType.Int);
                prmBDAppNo.Value = intBDAppNo;
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();

                MessageBox.Show("Application data successfully deleted.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to delete Application.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }

    public class VPBDApp
    {

        private Int32 _bdappId;
        private Int32 _bdappNumber;
        private string _bdappName;
        private bool _availableLauncher;
        private Int32 _rankBART;
        private bool _gDpr;
        private bool _dPi;
        private bool _sLa;
        private Int16 _bdappStatus;
        private Bitmap _statusImg;
        private string _statusDescription;
        private DateTime _dateReview;
        private DateTime _dateLastUpdated;
        private string _dIrectorate;
        private string _cGroup;
        private string _busCrit;
        private bool _bdappReg;
        private string _productOwner;
        private string _busSme;
        private string _busContact;
        private string _leadDev;
        private string _dataGuardian;
        private string _bdappDescription;
        private string _bdappNotes;
        private string _reviewRAG;

        public VPBDApp()
        {

        }

        public VPBDApp(int _bdappid, int _bdappnumber, string _bdappname, bool _availablelauncher, int _rankbart,
            bool _gdpr, bool _dpi, bool _sla, short _bdappstatus, Bitmap _statusimg, string _statusdescription, 
            DateTime _datereview, DateTime _datelastupdated, string _directorate, string _cgroup, string _buscrit, bool _bdappreg, string _productowner, string _bussme, string _buscontact, string _leaddev, string _dataguardian, string _bdappdescription, string _bdappnotes, string _reviewrag) //, string _descriptionreview, string _notesreview)
        {
            this._bdappId = _bdappid;
            this._bdappNumber = _bdappnumber;
            this._bdappName = _bdappname;
            this._availableLauncher = _availablelauncher;
            this._rankBART = _rankbart;
            this._gDpr = _gdpr;
            this._dPi = _dpi;
            this._sLa = _sla;
            this._bdappStatus = _bdappstatus;
            this._statusImg = _statusimg;
            this._statusDescription = _statusdescription;
            this._dateReview = _datereview;
            this._dateLastUpdated = _datelastupdated;
            this._dIrectorate = _directorate;
            this._cGroup = _cgroup;
            this._busCrit = _buscrit;
            this._bdappReg = _bdappreg;
            this._productOwner = _productowner;
            this._busSme = _bussme;
            this._busContact = _buscontact;
            this._leadDev = _leaddev;
            this._dataGuardian = _dataguardian;
            this._bdappDescription = _bdappdescription;
            this._bdappNotes = _bdappnotes;
            this._reviewRAG = _reviewrag;
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

        public string BDApp_Name
        {
            get
            {
                return _bdappName;
            }
            set
            {
                _bdappName = value;
            }
        }


        public bool Available_Launcher
        {
            get
            {
                return _availableLauncher;
            }
            set
            {
                _availableLauncher = value;
            }
        }

        public Int32 Rank_Bart
        {
            get
            {
                return _rankBART;
            }
            set
            {
                _rankBART = value;
            }
        }

        public bool GDPR
        {
            get
            {
                return _gDpr;
            }
            set
            {
                _gDpr = value;
            }
        }

        public bool DPI
        {
            get
            {
                return _dPi;
            }
            set
            {
                _dPi = value;
            }
        }

        public bool SLA
        {
            get
            {
                return _sLa;
            }
            set
            {
                _sLa = value;
            }
        }

        public Int16 BDApp_Status
        {
            get
            {
                return _bdappStatus;
            }
            set
            {
                _bdappStatus = value;
            }
        }

        public Bitmap Status
        {
            get
            {
                return _statusImg;
            }
            set
            {
                _statusImg = value;
            }
        }

        public string Status_Description
        {
            get
            {
                return _statusDescription;
            }
            set
            {
                _statusDescription = value;
            }
        }

        public DateTime Date_Review
        {
            get
            {
                return _dateReview;
            }
            set
            {
                _dateReview = value;
            }
        }

        public DateTime Date_LastUpdated
        {
            get
            {
                return _dateLastUpdated;
            }
            set
            {
                _dateLastUpdated = value;
            }
        }

        public String Directorate
        {
            get
            {
                return _dIrectorate;
            }
            set
            {
                _dIrectorate = value;
            }
        }

        public String CGroup
        {
            get
            {
                return _cGroup;
            }
            set
            {
                _cGroup = value;
            }
        }

        public String BusCrit
        {
            get
            {
                return _busCrit;
            }
            set
            {
                _busCrit = value;
            }
        }


        public bool BDAppReg
        {
            get
            {
                return _bdappReg;
            }
            set
            {
                _bdappReg = value;
            }
        }

        public String ProductOwner
        {
            get
            {
                return _productOwner;
            }
            set
            {
                _productOwner = value;
            }
        }

        public String BusSME
        {
            get
            {
                return _busSme;
            }
            set
            {
                _busSme = value;
            }
        }

        public String BusContact
        {
            get
            {
                return _busContact;
            }
            set
            {
                _busContact = value;
            }
        }

        public String LeadDev
        {
            get
            {
                return _leadDev;
            }
            set
            {
                _leadDev = value;
            }
        }

        public String DataGuardian
        {
            get
            {
                return _dataGuardian;
            }
            set
            {
                _dataGuardian = value;
            }
        }

        public String BDAppDescription
        {
            get
            {
                return _bdappDescription;
            }
            set
            {
                _bdappDescription = value;
            }
        }

        public String BDAppNotes
        {
            get
            {
                return _bdappNotes;
            }
            set
            {
                _bdappNotes = value;
            }
        }

        public String ReviewRAG
        {
            get
            {
                return _reviewRAG;
            }
            set
            {
                _reviewRAG = value;
            }
        }
    }
}
