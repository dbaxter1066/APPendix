using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTaS_APPendix
{
    class VPReports
    {
        private Int32 _repId;
        private string _repName;
        private string _repTemp;
        private string _repSp;
        private string _repAddSp;
        private bool _repFrom;
        private bool _repTo;



        public VPReports()
        {

        }

        public VPReports(int _repid, string _repname, string _reptemp, string _repsp, string _repaddsp, bool _repfrom, bool _repto)
        {
            this._repId = _repid;
            this._repName = _repname;
            this._repTemp = _reptemp;
            this._repSp = _repsp;
            this._repAddSp = _repaddsp;
            this._repFrom = _repfrom;
            this._repTo = _repto;
        }

        public Int32 Rep_ID
        {
            get
            {
                return _repId;
            }
            set
            {
                _repId = value;
            }
        }

        
        public String RName
        {
            get
            {
                return _repName;
            }
            set
            {
                _repName = value;
            }
        }

        public String RTemp
        {
            get
            {
                return _repTemp;
            }
            set
            {
                _repTemp = value;
            }
        }

        public String RSP
        {
            get
            {
                return _repSp;
            }
            set
            {
                _repSp = value;
            }
        }

        public String RADDSP
        {
            get
            {
                return _repAddSp;
            }
            set
            {
                _repAddSp = value;
            }
        }

        public bool RFROM
        {
            get
            {
                return _repFrom;
            }
            set
            {
                _repFrom = value;
            }
        }

        public bool RTO
        {
            get
            {
                return _repTo;
            }
            set
            {
                _repTo = value;
            }
        }
    }
}
