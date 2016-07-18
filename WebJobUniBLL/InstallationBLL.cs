using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;
using WebJobUniUtils;

namespace WebJobUniBLL {
    public class InstallationBLL {

        #region "Methods"
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
                    tempStaffID = EmployeeBLL.AddEmployee(staff.title, staff.firstName, staff.lastName, (int)tempStaffContDetID, staff.aspnetUserID, null, null, (short)tempStaffAgendaID);
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
                System.Diagnostics.Debug.Print("<h2>BLL.InstallationBLL.SaveInstallationToDB(ref i)</h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
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
                System.Diagnostics.Debug.Print("<h2>BLL.InstallationBLL.GetStaffNames()</h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
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
                System.Diagnostics.Debug.Print("<h2>BLL.InstallationBLL.GetServiceNames()</h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
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
                    temp =service.name.PadRight(35) + (service.duration.ToString()+" mins").PadRight(15) + "£ " +service.price.ToString();
                    System.Diagnostics.Debug.Print(temp);
                    liServNames.Add(temp);
                    
                }

                return liServNames;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>BLL.InstallationBLL.GetServiceNames()</h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

    }//class
}//namespace

