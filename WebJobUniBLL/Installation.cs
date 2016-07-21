using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;
using WebJobUniUtils;

namespace WebJobUniBLL {
    [Serializable()]
    public class Installation {

        #region "Instances"
        public DateTime Timestamp { get; set; }
        public CompanyBLL Company { get; set; }
        public List<EmployeeBLL> Employees { get; set; }
        public List<ServicesBLL> Services { get; set; }
        public ProvideBLL ServicesProvidedByStaff { get; set; }
        public List<EndUserBLL> Customers { get; set; }
        public List<ApptBLL> Appointments { get; set; }
        public List<OrderBLL> Invoices { get; set; }
        #endregion

        #region "Constructors"
        //default constructor
        public Installation() {
            this.Company = new CompanyBLL();
            this.Timestamp = Utils.GetDatetimeNOW();
            this.Employees = new List<EmployeeBLL>();
            this.Services = new List<ServicesBLL>();
            this.ServicesProvidedByStaff = new ProvideBLL();
            this.Customers = new List<EndUserBLL>();
            this.Appointments = new List<ApptBLL>();
            this.Invoices = new List<OrderBLL>();
        }
        #endregion


        #region "Functions"
        /// <summary>
        /// Get test installation object.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Installation GetTestInstallation() {
            try {
                Installation i = new Installation();

                //Company
                var _with2 = i.Company;
                _with2.ID = 2;
                _with2.domain = "TESTING Ltd";
                _with2.industry = "Net Business";
                _with2.natureOfBusiness = 99999;
                _with2.regNumb = "9372370-2";
                _with2.dateIncorporated = (DateTime)Utils.GetDateFromString2("04/08/2016 07:00:00");
                _with2.url = "www.RachieHolding.com";
                _with2.isVATreg = true;
                _with2.VATnumb = "9234902-0";
                _with2.notes = "all in order";
                _with2.businessAddress = new ContactDetailsBLL();

                //client (main company contact)
                var _with1 = _with2.mainClientContact;
                _with1.ID = 1;
                _with1.title = Person.MRS;
                _with1.firstName = "ME";
                _with1.lastName = "McSantos";
                _with1.role = (byte)RolesEnum.CLIENT;
                _with1.aspnetUserID = (Guid)Utils.GetTestASP_UserID();

                //client Contact Details
                var _with11 = _with1.contactDetail;
                _with11.ID = 11;
                _with11.address = "rua 23 qd 46 lot 28";
                _with11.city = "Azerbejan";
                _with11.postCode = "88402-445";
                _with11.country = "South Africa";
                _with11.landline = "9047201-02348578";
                _with11.mobile = "234532455465";
                _with11.email = "eoiuejhg@rgu.net";
                _with11.notes = "nothing to declare";
                _with11.dateCreated = Utils.GetDatetimeNOW();
                _with11.dateUpdated = (DateTime)Utils.GetDateFromString("01/12/2010 10:04:08");

                //employees
                var _with3 = i.Employees;
                EmployeeBLL oi1 = new EmployeeBLL(Person.MRS, "RUTH", "Simpson", "sdijfif@akijhdi.co.uk", (Guid)Utils.GetTestASP_UserID());
                DaySchedule newTestDaySchedule = new DaySchedule(isTest: true);
                oi1.agenda.staffCalendar.Add(Utils.GetDatetimeNOW().Date, newTestDaySchedule);
                oi1.ID = 2;
                _with3.Add(oi1);
                //staff 2
                EmployeeBLL oi2 = new EmployeeBLL(Person.MS, "Lorenzo", "Victor", new ContactDetailsBLL(), "34802342-289", "developer", new AgendaBLL(), (Guid)Utils.GetTestASP_UserID());
                DaySchedule newTestDaySchedule2 = new DaySchedule(isTest: true);
                oi2.agenda.staffCalendar.Add(Utils.GetDatetimeNOW().Date.AddDays(1), newTestDaySchedule);
                oi2.ID = 10;
                _with3.Add(oi2);
                //staff 3
                EmployeeBLL oi3 = new EmployeeBLL(Person.MR, "Alves", "Thomas", new ContactDetailsBLL(), "34802342-289", "developer", new AgendaBLL(), (Guid)Utils.GetTestASP_UserID());
                oi3.ID = 9;
                DaySchedule newTestDaySchedule3 = new DaySchedule(isTest: true);
                oi3.agenda.staffCalendar.Add(Utils.GetDatetimeNOW().Date.AddDays(2), newTestDaySchedule);
                _with3.Add(oi3);

                //services 
                var _with4 = i.Services;
                ServicesBLL a = new ServicesBLL("service 1", "wrap up without a word", 55, 99.3m);
                a.ID = 5;
                ServicesBLL b = new ServicesBLL("service 2", "no no no ", 89, 102236.893m);
                b.ID = 8;
                ServicesBLL c = new ServicesBLL("service 3", "FFS84857 983*33h", byte.MaxValue, decimal.MaxValue);
                c.ID = 13;
                ServicesBLL d = new ServicesBLL("service 4", "wrap up again", byte.MinValue, decimal.MinValue);
                d.ID = 89;

                _with4.Add(a);
                _with4.Add(b);
                _with4.Add(c);
                _with4.Add(d);

                //services Provided By Staff
                var _with5 = i.ServicesProvidedByStaff;
                _with5 = null;

                return i;
            }
           catch (Exception ex) {
                ExceptionHandling.LogException(ref ex); return null;
            }
        }
        #endregion

        #region "Methods"
        public override string ToString() {
            try {
                //if (i == null)
                //    i = new Installation();
                StringBuilder x = new StringBuilder();
                var _with1 = x;
                _with1.Append("Installation:\n");

                //company
                _with1.Append("Company:\t" + this.Company.ToString() + "\n");

                //client (company main contact)
                _with1.Append("Client (company main contact):\t" + this.Company.mainClientContact.ToString() + "\n");

                //company contact details
                _with1.Append("Company Contact Details:\t" + this.Company.businessAddress.ToString() + "\n");

                //Services Provided by Staff
                _with1.Append("Services Provided by Staff:\t" + this.ServicesProvidedByStaff.ToString() + "\n");

                //Employees
                foreach (EmployeeBLL employee in this.Employees) {
                    _with1.Append("Employee:\t" + employee.ToString() + "\n");
                    _with1.Append("Employee Contact Detail:\t" + employee.contactDetail.ToString() + "\n");
                }

                //Services
                foreach (ServicesBLL service in this.Services) {
                    _with1.Append("Service:\t" + service.ToString() + "\n");

                }

                return _with1.ToString();
            }
           catch (Exception ex) {
                ExceptionHandling.LogException(ref ex); 
                return "<h2>Error in Installation.cs ToString Function  </h2> \n" + ex.Message;
            }
        }

        /// <summary>
        /// MUST review 11/7/16
        /// </summary>
        /// <param name="i"></param>
        /// <param name="company"></param>
        public static void PopulateInstalation(ref Installation i, CompanyBLL company) {
            try {
                //
                /*    if (i == null)
                        i = new Installation();

                    //Get data from parameter company
                    var _with1 = company;
                    CompanyBLL co = new CompanyBLL(_with1.domain, _with1.industry, _with1.natureOfBusiness, _with1.regNumb, _with1.dateIncorporated, _with1.url, _with1.isVATreg, _with1.VATnumb, _with1.notes);

                    var _with2 = company.mainClientContact;
                    ClientBLL client = new ClientBLL(_with2.title, _with2.firstName, _with2.lastName, _with2.contactDetail, _with2.role, _with2.aspnetUserID);

                    var _with3 = company.mainClientContact.contactDetail;
                    ContactDetailsBLL clientContact = new ContactDetailsBLL(_with3.address, _with3.city, _with3.postCode, _with3.country, _with3.landline, _with3.mobile, _with3.email, _with3.notes, _with3.dateCreated, _with3.dateUpdated);

                    var _with4 = company.businessAddress;
                    ContactDetailsBLL businessAddress = new ContactDetailsBLL(_with4.address, _with4.city, _with4.postCode, _with4.country, _with4.landline, _with4.mobile, _with4.email, _with4.notes, _with4.dateCreated, _with4.dateUpdated);

                    //update Installation with date extracted
                    i.Company = company;
                    */
            }
           catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
            }
        }
        #endregion








    }//class
}//namespace
