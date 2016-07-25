using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class ClientBLL : Client {

        #region "Variables"
        public int? ID { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public ContactDetailsBLL contactDetail { get; set; }
        public byte role { get; set; }
        public Guid? aspnetUserID { get; set; }

        #endregion

        //default constructor
        public ClientBLL() {
            this.contactDetail = new ContactDetailsBLL();
        }

        public ClientBLL(string _title, string _firstName, string _lastName, ContactDetailsBLL _contactDet, Guid? _aspUserID) {
            this.title = _title;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.contactDetail = _contactDet;
            this.role = (byte)RolesEnum.CLIENT;
            this.aspnetUserID = _aspUserID;
        }



    }//class
}//nameSpace
