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
        public static void SaveInstallationToDB(Installation i) {
            try {
                //  System.Diagnostics.Debug.Print(i.ToString());

                //save CLient contact Details
                var _with1 = i.Company.mainClientContact.contactDetail;
                int contDetID = (int)ContactDetailsBLL.AddContactDetails(_with1.email);

                //save CLient
                var _with2 = i.Company.mainClientContact;
                int clientID = (int)ClientBLL.AddClient(_with2.title, _with2.firstName, _with2.lastName, contDetID, _with2.aspnetUserID);

                //save Company address/phone numb
                var _with3 = i.Company.businessAddress;
                int compContDetID = (int)ContactDetailsBLL.AddContactDetails(null, null, null, null, _with3.landline, null, null);

                //save Company 
                var _with4 = i.Company;
                int compID = (int)CompanyBLL.AddCompany(_with4.domain, _with4.industry, _with4.natureOfBusiness, clientID, compContDetID);

                //save Employees 
                int tempStaffContDetID, tempStaffID;
                short tempStaffAgendaID;
                foreach (EmployeeBLL staff in i.Employees) {
                    //save staff contact details
                    tempStaffContDetID = (int)ContactDetailsBLL.AddContactDetails(staff.contactDetail.email);
                    //save staff agenda
                    tempStaffAgendaID = (short)AgendaBLL.AddAgenda(false, false);
                    //save employee
                    tempStaffID = (int)EmployeeBLL.AddEmployee(staff.title, staff.firstName, staff.lastName, tempStaffContDetID, staff.aspnetUserID, null, null, tempStaffAgendaID);
                }

                //save services 
                int tempServID;
                foreach (ServicesBLL service in i.Services) {
                    //save service
                    //     tempServID = (int)ServicesBLL.AddService(service.name, service.duration, service.price);
                }


            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>BLL.InstallationBLL.SaveInstallationToDB()</h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
            }
        }
        #endregion

        #region "Functions"
        public static List<string> GetStaffNames(Installation i, bool is1stName = true, bool isLastName = false) {
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

