using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;
using WebJobUniUtils;

namespace WebJobUniBLL {
    public class ContactDetailsBLL : ContactDetails {

        #region "Variables"
        //DB table has 10 columns
        public int? ID { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postCode { get; set; }
        public string country { get; set; }
        public string landline { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public DateTime? dateCreated { get; set; }
        public DateTime? dateUpdated { get; set; }

        #endregion

        //default constructor
        public ContactDetailsBLL() {
        }

        public ContactDetailsBLL(string _address, string _city, string _postCode, string _country, string _landline, string _mobile, string _email) {
            this.address = _address;
            this.city = _city;
            this.postCode = _postCode;
            this.country = _country;
            this.landline = _landline;
            this.mobile = _mobile;
            this.email = _email;
            this.dateCreated = Utils.GetDatetimeNOW();
            this.dateUpdated = Utils.GetDatetimeNOW();
        }

    }//class
}//namespace
