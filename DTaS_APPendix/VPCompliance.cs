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
    class VPCompliance : IEnumerable
    {
        public IList<VPComp> VPCompList { get { return this._vpcomps; } }
        private List<VPComp> _vpcomps = new List<VPComp>();

        // Public methods.  
        public void Add(VPComp c)
        {
            _vpcomps.Add(c);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (VPComp _vpcomp in _vpcomps)
            {
                yield return _vpcomp;
            }
        }

        public void GetBDAppComp(int intBDAppID)
        {
            VPComp _vpcomp = null;
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPGetBDAppComp", con);
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
                        _vpcomp = new VPComp();
                        _vpcomp.BDApp_ID = Convert.ToInt32(dr["BDApp_ID"].ToString());
                        _vpcomp.BDApp_Number = Convert.ToInt32(dr["BDApp_Number"].ToString());
                        _vpcomp.GDPR = Convert.ToBoolean(dr["GDPR"]);
                        _vpcomp.DPI = Convert.ToBoolean(dr["DPIA"]);
                        _vpcomp.SLA = Convert.ToBoolean(dr["SLA"]);
                        _vpcomps.Add(_vpcomp);
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


        public Boolean UpdateAddVPComp(int intBDAppNo, string strBDAppName, bool blnGDPR, bool blnDPI, bool blnSLA)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPAddBDAppCompliance", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                SqlParameter prmBDAppNo = cmd.Parameters.Add("@nBDAppNo", SqlDbType.Int);
                prmBDAppNo.Value = intBDAppNo;
                SqlParameter prmBDAppName = cmd.Parameters.Add("@nBDAppName", SqlDbType.NVarChar);
                prmBDAppName.Value = strBDAppName;
                SqlParameter prmGDPR = cmd.Parameters.Add("@nGDPR", SqlDbType.Bit);
                prmGDPR.Value = blnGDPR;
                SqlParameter prmDPI = cmd.Parameters.Add("@nDPI", SqlDbType.Bit);
                prmDPI.Value = blnDPI;
                SqlParameter prmSLA = cmd.Parameters.Add("@nSLA", SqlDbType.Bit);
                prmSLA.Value = blnSLA;
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();

                MessageBox.Show("Application Compliance data successfully saved.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to add Application Compliance data.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }

    public class VPComp
    {

        private Int32 _bdappId;
        private Int32 _bdappNumber;
        private bool _gDpr;
        private bool _dPi;
        private bool _sLa;


        public VPComp()
        {

        }

        public VPComp(int _bdappid, int _bdappnumber, bool _gdpr, bool _dpi, bool _sla)
        {
            this._bdappId = _bdappid;
            this._bdappNumber = _bdappnumber;
            this._gDpr = _gdpr;
            this._dPi = _dpi;
            this._sLa = _sla;
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

    }
}
