using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
     public class  EmployeeBLL : Employee{

        #region "Variables"
        public int? ID { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public ContactDetailsBLL contactDetail { get; set; }
        public byte role { get; set; }
        public string natInsNumb { get; set; }
        public string jobTitle { get; set; }
        public AgendaBLL agenda { get; set; }
        public Guid aspnetUserID { get; set; }

        #endregion

        #region "Constructors"

        public EmployeeBLL() {
            this.contactDetail = new ContactDetailsBLL();
            this.agenda = new AgendaBLL();
        }
        public EmployeeBLL(string _title, string _firstName, string _lastName, ContactDetailsBLL _contactDet, string _natInsNumb, string _jobTitle, AgendaBLL _agenda, Guid _aspUserID) {
            this.contactDetail = _contactDet;
            this.agenda = new AgendaBLL();
            this.title = _title;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.role = (byte)RolesEnum.EMPLOYEE;
            this.natInsNumb = _natInsNumb;
            this.jobTitle = _jobTitle;
            this.aspnetUserID = _aspUserID;
            this.agenda = _agenda;
        }
        public EmployeeBLL(string _title, string _firstName, string _lastName, string email, Guid _aspUserID) {            
            this.contactDetail = new ContactDetailsBLL();
            this.agenda = new AgendaBLL();
            this.title = _title;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.contactDetail.email = email;
            this.aspnetUserID = _aspUserID;
        }
        
        #endregion


        #region "Functions"
        public static List<string> GetAllStaff1stNames() {
            try { 
            List<string> staffNames = new List<string>();
            //get all employees dataTable
            var allStaff = GetAllEmployees();

            // ... Loop over all rows.
            foreach (DataRow row in allStaff.Rows) {
                // ... Write value of 3rd field as integer.
                System.Diagnostics.Debug.Print(row.Field<string>(2));
                //add name to list
                staffNames.Add(row.Field<string>(2));
            }

            return staffNames;
            }
           catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);     return null;
            }
        }
        #endregion

    }//class
}//namespace
