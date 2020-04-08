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
    class VPDetails
    {


        public IList<VPDetail> VPDetailsList { get { return this._vpdetails; } }
        private List<VPDetail> _vpdetails = new List<VPDetail>();

        // Public methods.  
        public void Add(VPDetail c)
        {
            _vpdetails.Add(c);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (VPDetail _vpdetail in _vpdetails)
            {
                yield return _vpdetail;
            }
        }

        public void GetBDAppDetail(int intBDAppID)
        {
            VPDetail _vpdetail = null;
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPGetBDAppDetail", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                SqlParameter prmBDAppID = cmd.Parameters.Add("@BDAppID", SqlDbType.Int);
                prmBDAppID.Value = intBDAppID;

                con.Open();

                //OleDbDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    // Call Read before accessing data.
                    while (dr.Read())
                    {
                        _vpdetail = new VPDetail();
                        _vpdetail.Directorate = dr["Directorate"].ToString();
                        _vpdetail.CGroup = dr["CGroup"].ToString();
                        _vpdetail.BDAppReg = Convert.ToBoolean(dr["BDAppReg"]);
                        _vpdetail.ProductOwner = dr["ProductOwner"].ToString();
                        _vpdetail.BusSME = dr["BusinessSME"].ToString();
                        _vpdetail.BusContact = dr["BusinessContact"].ToString();
                        _vpdetail.LeadDev = dr["FullName"].ToString();
                        _vpdetail.DataGuardian = dr["DataGuardian"].ToString();
                        _vpdetails.Add(_vpdetail);
                    }
                }
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
    }

    public class VPDetail
    {

        private string _dIrectorate;
        private string _cGroup;
        private bool _bdappReg;
        private string _productOwner;
        private string _busSme;
        private string _busContact;
        private string _leadDev;
        private string _dataGuardian;

        public VPDetail()
        {

        }

        public VPDetail(string _directorate, string _cgroup, bool _bdappreg, string _productowner, string _bussme, string _buscontact, string _leaddev, string _dataguardian)
        {
            this._dIrectorate = _directorate;
            this._cGroup = _cgroup;
            this._bdappReg = _bdappreg;
            this._productOwner = _productowner;
            this._busSme = _bussme;
            this._busContact = _buscontact;
            this._leadDev = _leaddev;
            this._dataGuardian = _dataguardian;
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
    }
}
