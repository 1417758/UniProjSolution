using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;
using WebJobUniUtils;

namespace WebJobUniBLL {
    public class InstallationBLL {

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






    }//class
}//namespace

