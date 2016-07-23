using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
        // public List<DailyScheduleBLL> DailySchedules { get; set; }
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
            //  this.DailySchedules = new List<DailyScheduleBLL>();//used to save xml to DB
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
                _with2.ID = 1;
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
                _with11.ID = 3;
                _with11.address = "rua 23 qd 46 lot 28";
                _with11.city = "Azerbejan";
                _with11.postCode = "88402-445";
                _with11.country = "South Africa";
                _with11.landline = "9047201-02348578";
                _with11.mobile = "234532455465";
                _with11.email = "eoiuejhg@rgu.net";
                _with11.dateCreated = Utils.GetDatetimeNOW();
                _with11.dateUpdated = (DateTime)Utils.GetDateFromString("01/12/2010 10:04:08");

                //employees
                var _with3 = i.Employees;
                EmployeeBLL oi1 = new EmployeeBLL(Person.MRS, "RUTH", "Simpson", "sdijfif@akijhdi.co.uk", (Guid)Utils.GetTestASP_UserID());
                oi1.ID = 1;
                oi1.agenda.ID = 1; //NB AgendaID must be valid to save xml to DB
                DaySchedule newTestDaySchedule = new DaySchedule(isTest: true);
                oi1.agenda.staffCalendar.Add(Utils.GetDatetimeNOW().Date, newTestDaySchedule);
                _with3.Add(oi1);
                //staff 2
                EmployeeBLL oi2 = new EmployeeBLL(Person.MS, "Lorenzo", "Victor", new ContactDetailsBLL(), "34802342-289", "developer", new AgendaBLL(), (Guid)Utils.GetTestASP_UserID());
                oi2.ID = 2;
                oi2.agenda.ID = 2; //NB AgendaID must be valid to save xml to DB
                DaySchedule newTestDaySchedule2 = new DaySchedule(isTest: true);
                oi2.agenda.staffCalendar.Add(Utils.GetDatetimeNOW().Date.AddDays(1), newTestDaySchedule);
                _with3.Add(oi2);
                //staff 3
                EmployeeBLL oi3 = new EmployeeBLL(Person.MR, "Alves", "Thomas", new ContactDetailsBLL(), "34802342-289", "developer", new AgendaBLL(), (Guid)Utils.GetTestASP_UserID());
                oi3.ID = 3;
                oi3.agenda.ID = 3; //NB AgendaID must be valid to save xml to DB
                DaySchedule newTestDaySchedule3 = new DaySchedule(isTest: true);
                oi3.agenda.staffCalendar.Add(Utils.GetDatetimeNOW().Date.AddDays(2), newTestDaySchedule);
                _with3.Add(oi3);

                //services 
                var _with4 = i.Services;
                ServicesBLL a = new ServicesBLL("service 1", "wrap up without a word", 55, 99.3m);
                a.ID = 1;
                ServicesBLL b = new ServicesBLL("service 2", "no no no ", 89, 102236.893m);
                b.ID = 2;
                ServicesBLL c = new ServicesBLL("service 3", "FFS84857 983*33h", byte.MaxValue, decimal.MaxValue);
                c.ID = 3;
                ServicesBLL d = new ServicesBLL("service 4", "wrap up again", byte.MinValue, decimal.MinValue);
                d.ID = 4;

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
        public static Installation PopulateInstalationObjFromDB(ref Installation i, int? companyID) {
            try {
                if (i == null) {
                    i = new Installation();
                    //timestamp
                    i.Timestamp = Utils.GetDatetimeNOW();
                }

                //------  company  ---------
                //get company dataTable
                var company = CompanyBLL.GetCompanyByID(companyID);//.GetAllCompanies();??

                //get ----company contact Details ----- dataTable 
                int coContactDetID = company.Rows[0].Field<int>(8);
                var coContactDet = ContactDetailsBLL.GetContactDetailByID(coContactDetID);
                //populate an instance of contactDetBLL
                var _with11 = coContactDet.Rows[0];
                ContactDetailsBLL coContactBLL = new ContactDetailsBLL(_with11.Field<string>(1), _with11.Field<string>(3), _with11.Field<string>(2), _with11.Field<string>(4), _with11.Field<string>(5), _with11.Field<string>(6), _with11.Field<string>(7));

                //polulate an instance of companyBLL
                var _with1 = company.Rows[0];
                CompanyBLL coBLL = new CompanyBLL(_with1.Field<string>(1), _with1.Field<string>(2), _with1.Field<int>(3), _with1.Field<string>(4), _with1.Field<DateTime>(5), (string)_with1.ItemArray[6], _with1.Field<bool>(9), _with1.Field<string>(10), _with1.Field<string>(11));
                coBLL.ID = _with1.Field<int>(0);//same as companyID               
                //add contact details to coBLL
                coBLL.businessAddress = coContactBLL;
                //foreign keys
                int clientID = _with1.Field<int>(7);

                //------  Client  ---------  
                //get client dataTable
                var client = ClientBLL.GetClientByID(clientID);//GetAllClients();

                //get ---- client contact ------dataTable 
                int cltContactDetID = client.Rows[0].Field<int>(4);
                var cltContactDet = ContactDetailsBLL.GetContactDetailByID(cltContactDetID);
                //populate an instance of contactDetBLL
                var _with21 = cltContactDet.Rows[0];
                ContactDetailsBLL clientContactBLL = new ContactDetailsBLL(_with21.Field<string>(1), _with21.Field<string>(3), _with21.Field<string>(2), _with21.Field<string>(4), _with21.Field<string>(5), _with21.Field<string>(6), _with21.Field<string>(7));

                //Populate clientBLL 
                var _with2 = client.Rows[0];
                ClientBLL clientBLL = new ClientBLL(_with2.Field<string>(1), _with2.Field<string>(2), _with2.Field<string>(3), clientContactBLL, _with2.Field<Guid>(9));
                clientBLL.ID = _with2.Field<int>(0);
                //add client to company
                coBLL.mainClientContact = clientBLL;

                //add to installation
                i.Company = coBLL;
                //-------------------------------------------------------------------------------------------------------------------

                //------  Employees  --------- 
                //get staff dataTable 
                var employees = EmployeeBLL.GetAllEmployees();
                // Loop through all employees
                foreach (DataRow employee in employees.Rows) {
                    //get ---- employee agenda ------dataTable 
                    short staffAgendaID = employee.Field<short>(8);
                    var staffAgenda = AgendaBLL.GetAgendaByID(staffAgendaID);
                    //populate an instance of agendaBLL
                    var _with41 = staffAgenda.Rows[0];
                    System.Diagnostics.Debug.Print("staffAgendaID from employee Table is: " + staffAgendaID.ToString() + "staffAgendaID from AGENDA Table is: " + _with41.Field<short>(0).ToString());
                    AgendaBLL staffAgendaBLL = new AgendaBLL(staffAgendaID,_with41.Field<bool?>(1), _with41.Field<bool?>(2));

                    //get ---- employee contact ------dataTable 
                    int staffContDetID = employee.Field<int>(4);
                    var staffContDet = ContactDetailsBLL.GetContactDetailByID(staffContDetID);
                    //populate an instance of contactDetBLL
                    var _with31 = cltContactDet.Rows[0];
                    ContactDetailsBLL staffContactBLL = new ContactDetailsBLL(_with31.Field<string>(1), _with31.Field<string>(3), _with31.Field<string>(2), _with31.Field<string>(4), _with31.Field<string>(5), _with31.Field<string>(6), _with31.Field<string>(7));

                    //Populate staffBLL 
                    var _with3 = employee;
                    EmployeeBLL staffBLL = new EmployeeBLL(_with3.Field<string>(1), _with3.Field<string>(2), _with3.Field<string>(3), staffContactBLL, _with3.Field<string>(6), _with3.Field<string>(7), staffAgendaBLL, _with3.Field<Guid>(9));
                    clientBLL.ID = _with3.Field<int>(0);
                    //add contact detail to staff
                    staffBLL.contactDetail = staffContactBLL;


                    //get ---- DailyShedules foreach  agenda ------dataTable 
                    var curStaffCalendar = staffBLL.agenda.staffCalendar;
                    List<int> bookingTimes = new List<int>();
                    //get data stored on db
                    var staffAgendaDailyShedules = DailySchedule.GetDailySchedulesByAgendaID(staffAgendaID);
                    // Loop through each dailySchedule on staff's agenda
                    foreach (DataRow dailySchedule in staffAgendaDailyShedules.Rows) {
                        //create a new DayScheduleBLL
                        DaySchedule daySchedBLL = new DaySchedule();
                        DateTime date = dailySchedule.Field<DateTime>(2);
                        XDocument xDoc = XDocument.Parse(dailySchedule.Field<System.String>(3));

                        //loopthrough db xml and get a list of "busy times"
                        bookingTimes = DayScheduleXML.GetTimesFromDayScheduleXML(xDoc);

                        //add appts to daySchedBLL
                        foreach (int time in bookingTimes) { 
                            //add appts to daySchedBLL
                            bool added = AgendaBLL.AddBooking(ref curStaffCalendar, date, time);
                            System.Diagnostics.Debug.Print("ADDED?\t " + added.ToString());
                        }//                      
                    }//end loop daySchedule

                    //add employee to installation
                    i.Employees.Add(staffBLL);
                }//// endLoop through all employees


                return i;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }
        #endregion








    }//class
}//namespace
