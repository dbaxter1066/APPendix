using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTaS_APPendix
{
    public class VPSearch
    {
        private Int32 _searchId;
        private Int32 _searchReference;
        private string _searchName;
        private string _searchLocation;

        public VPSearch()
        {

        }

        public VPSearch(int _searchid, int _searchreference, string _searchname, string _searchlocation)
        {
            this._searchId = _searchid;
            this._searchReference = _searchreference;
            this._searchName = _searchname;
            this._searchLocation = _searchlocation;
        }

        public Int32 Search_ID
        {
            get
            {
                return _searchId;
            }
            set
            {
                _searchId = value;
            }
        }

        public Int32 Search_Reference
        {
            get
            {
                return _searchReference;
            }
            set
            {
                _searchReference = value;
            }
        }

        public string Search_Name
        {
            get
            {
                return _searchName;
            }
            set
            {
                _searchName = value;
            }
        }

        public string Search_Location
        {
            get
            {
                return _searchLocation;
            }
            set
            {
                _searchLocation = value;
            }
        }
    }
}
