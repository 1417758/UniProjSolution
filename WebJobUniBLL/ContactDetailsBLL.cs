using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {

    public class ContactDetailsBLL : ContactDetails {

        #region "Variables"
        public int? ID { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postCode { get; set; }
        public string country { get; set; }
        public string landline { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string notes { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateUpdated { get; set; }

        #endregion

        //default constructor
        public ContactDetailsBLL() {
        }

        public ContactDetailsBLL(string _address, string _city, string _postCode, string _country, string _landline, string _mobile, string _email, string _notes, DateTime _dateCreated, DateTime _dateUpdated ) {
            this.address = _address;
            this.city = _city;
            this.postCode = _postCode;
            this.country = _country;
            this.dateCreated = _dateCreated;
            this.landline = _landline;
            this.mobile = _mobile;
            this.email = _email;
            this.notes = _notes;
            this.dateCreated = _dateCreated;
            this.dateUpdated = _dateUpdated;
        }

    }//class
}//namespace
