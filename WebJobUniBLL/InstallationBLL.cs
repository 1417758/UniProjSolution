using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebJobUniDAL;
using WebJobUniUtils;

namespace WebJobUniBLL {
    public class InstallationBLL {

        #region "Methods"
        public static void SaveInstallationToDB2(ref Installation i, ref ApptBLL appt, string selectedStaff1stName, string staffFilePhath) {
            try {
                //------ save End-user --------- only 1 always!? 
                int? endUser_ContDetID;
                //check user exists on DB
                //   int userIndex = i.Customers.FindIndex(endUser => endUser.aspnetUserID.ToString().Equals(endUserASPUserID.ToString(), StringComparison.Ordinal));
                int endUserIndex = i.Customers.Count - 1; //endUser added is always the last one?? use IndexFinder INSTEAD?? 22/7/16
                int? endUser_ID = EndUserBLL.GetPersonIDByASPuserID(i.Customers[endUserIndex].aspnetUserID);

                //only add if it doesnt exist 
                if (endUser_ID == null) {
                    //save endUser contact details to --- DB ----
                    var _with1 = i.Customers[endUserIndex].contactDetail;
                    endUser_ContDetID = ContactDetailsBLL.AddContactDetails(_with1.address, _with1.postCode, _with1.city, _with1.country, _with1.landline, _with1.mobile, _with1.email);
                    //save endUser contact details ID to session
                    _with1.ID = endUser_ContDetID;

                    //save End-user to DB
                    var _with2 = i.Customers[endUserIndex];
                    endUser_ID = EndUserBLL.AddEndUser(_with2.title, _with2.firstName, _with2.lastName, endUser_ContDetID, _with2.aspnetUserID);
                    //save endUser ID to ---- session -----
                    _with2.ID = endUser_ID;

                }
                appt.endUserID = (int)endUser_ID;

                //------ save appointment ------------
                //save appt to ---- DB ---- 
                int? newApptID = ApptBLL.AddAppointment(appt.date, appt.time, appt.endUserID, appt.serviceID, appt.provider, appt.notes);
                //save apptID to session
                //source http://stackoverflow.com/questions/1710301/what-is-a-predicate-in-c   
                Predicate<ApptBLL> oscarFinder = (ApptBLL p) => { return p.endUserID == endUser_ID; };
                int apptIndex = i.Appointments.FindLastIndex(oscarFinder);
                i.Appointments[apptIndex].ID = newApptID;


                //------- save staff daily schedule to ---- session ------------  
                string minutes = "";
                if (appt.time.Minutes == 0)
                    minutes = "00";
                else
                    minutes = appt.time.Minutes.ToString();
                int timeINT = (int)Utils.GetNumberInt(appt.time.Hours.ToString() + minutes);
                //get staff agenda 
                //source: http://stackoverflow.com/questions/1568593/how-to-use-indexof-method-of-listobject  
                //ie: list1.FindIndex(x => x==5);  // should return 3, as list1[3] == 5;  // given list1 {3, 4, 6, 5, 7, 8}http://www.dotnetperls.com/list-find
                int empIndex = i.Employees.FindIndex(employee => employee.firstName.Equals(selectedStaff1stName, StringComparison.Ordinal));
                var curSelStaffCalendar = i.Employees[empIndex].agenda.staffCalendar;

                //add booking --- IMPORTANT --> this updates staff's agenda (as BY REF is used) 
                bool addedBooking = AgendaBLL.AddBooking(ref curSelStaffCalendar, appt.date, timeINT);
                //R    if (!addedBooking)
                //R     throw new Exception("<H2>ERROR ADDING BOOKING!</H2>");//throw exc here?it doesnt allow DB save 20/7/16

                //------- save staff daily schedule to ---- DB ------------ 
                //get xml from staff daySchedule 
                XmlDocument staffDayScheXML = DayScheduleXML.CreateXMLFromDaySchedule(i.Employees[empIndex], staffFilePhath, appt.date);
                //add dailySchedule to db
                int? newDailySchedID = DailySchedule.AddDailySchedule(i.Employees[empIndex].agenda.ID, appt.date, staffDayScheXML);
                //add ID back to xml
                DayScheduleXML.Add_ID_2DayScheduleXML(DayScheduleXML.STAFF_DAYSCHEDULEXML_FILENAME, newDailySchedID.ToString());
                //i.DailySchedules.Add(newDailySched);

            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
            }
        }//end SaveInstallationToDB2

        public static void SaveInstallationToDB(ref Installation i) {
            try {
                //  System.Diagnostics.Debug.Print(i.ToString());

                //save CLient contact Details
                var _with1 = i.Company.mainClientContact.contactDetail;
                int? contDetID = ContactDetailsBLL.AddContactDetails(_with1.email);
                _with1.ID = contDetID;

                //save CLient
                var _with2 = i.Company.mainClientContact;
                int? clientID = ClientBLL.AddClient(_with2.title, _with2.firstName, _with2.lastName, (int)contDetID, _with2.aspnetUserID);
                _with2.ID = clientID;

                //save Company address/phone numb
                var _with3 = i.Company.businessAddress;
                int? compContDetID = ContactDetailsBLL.AddContactDetails(null, null, null, null, _with3.landline, null, null);
                _with3.ID = compContDetID;

                //save Company 
                var _with4 = i.Company;
                int? compID = CompanyBLL.AddCompany(_with4.domain, _with4.industry, _with4.natureOfBusiness, (int)clientID, (int)compContDetID);
                _with4.ID = compID;

                //save Employees 
                int? tempStaffContDetID, tempStaffID;
                short? tempStaffAgendaID;
                foreach (EmployeeBLL staff in i.Employees) {
                    //save staff contact details
                    tempStaffContDetID = ContactDetailsBLL.AddContactDetails(staff.contactDetail.email);
                    //save ID to Installation
                    staff.contactDetail.ID = tempStaffContDetID;
                    //save staff agenda
                    tempStaffAgendaID = AgendaBLL.AddAgenda(false, false);
                    staff.agenda.ID = tempStaffAgendaID;
                    //save employee
                    tempStaffID = EmployeeBLL.AddEmployee(staff.title, staff.firstName, staff.lastName, (int)tempStaffContDetID, staff.aspnetUserID, null, null, tempStaffAgendaID);
                    staff.ID = tempStaffID;
                }

                //save services 
                int? tempServID;
                foreach (ServicesBLL service in i.Services) {
                    //save service
                    tempServID = ServicesBLL.AddService(service.name, service.isCertifReq, service.isInsuranceReq, service.description, service.duration, service.durationUnit, service.price);
                    service.ID = tempServID;
                }

                //save Provide
                //FINK!! FINK18/7//16 

                //return i //?? Installation if IDs not added byRef
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
            }
        }

        public static void SaveAppoitmentToDB(ref Installation i) {
            try {
                //save appointments
                int? tempServID;
                foreach (ServicesBLL service in i.Services) {
                    //save service
                    tempServID = ServicesBLL.AddService(service.name, service.isCertifReq, service.isInsuranceReq, service.description, service.duration, service.durationUnit, service.price);
                    service.ID = tempServID;
                }
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
            }
        }

        #endregion

        #region "Functions"
        public static List<string> GetStaff1stNameWithTitle(Installation i, bool is1stName = true, bool isLastName = false) {
            try {
                //create list to save services items             
                List<string> liStaffNames = new List<string>();

                //loop through services
                foreach (EmployeeBLL staff in i.Employees) {
                    //select appropriate detail
                    if (is1stName)
                        //save service name  to new list of string
                        liStaffNames.Add(staff.title + " " + staff.firstName);
                    if (isLastName)
                        //save service name  to new list of string
                        liStaffNames.Add(staff.title + " " + staff.lastName);
                }

                return liStaffNames;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }
        public static List<string> GetServiceDetails(Installation i, bool isNames = true, bool isDesc = false, bool isDuration = false, bool isPrice = false) {
            try {
                //create list to save services items             
                List<string> liServNames = new List<string>();

                //loop through services
                foreach (ServicesBLL service in i.Services) {
                    //select appropriate detail
                    if (isNames)
                        //save service name  to new list of string
                        liServNames.Add(service.name);
                    if (isDesc)
                        //save service name  to new list of string
                        liServNames.Add(service.description);
                    if (isDuration)
                        //save service name  to new list of string
                        liServNames.Add(service.duration.ToString());
                    if (isPrice)
                        //save service name  to new list of string
                        liServNames.Add(service.price.ToString());
                }

                return liServNames;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }
        public static List<string> GetServiceDetailsFull(Installation i) {
            try {
                //create list to save services items             
                List<string> liServNames = new List<string>();
                string temp = "";

                //loop through services
                foreach (ServicesBLL service in i.Services) {
                    //select appropriate detail
                    //save service name  to new list of string
                    temp = String.Format("{0, 177}, {1, 87} mins £ {2,500}", service.name, service.duration.ToString(), service.price.ToString());
                    System.Diagnostics.Debug.Print(temp);
                    temp = service.name.PadRight(35) + (service.duration.ToString() + " mins").PadRight(15) + "£ " + service.price.ToString();
                    System.Diagnostics.Debug.Print(temp);
                    liServNames.Add(temp);

                }

                return liServNames;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }
        #endregion

    }//class
}//namespace

