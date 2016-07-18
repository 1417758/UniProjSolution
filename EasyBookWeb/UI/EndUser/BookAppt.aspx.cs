using AjaxControlToolkit;
using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniBLL;

public partial class UI_EndUser_BookAppt : System.Web.UI.Page {

    #region "Event Handlers"

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            PopulateUserControlsFromSession();
    }

    protected void Button_Click(object sender, EventArgs e) {
        try {
            //cast so can get tellesense
            Button selectedBt = (Button)sender;
            string btID = selectedBt.ID;
            //ie: buttonID = ButtonUserInfo
            int idNumb = (int)WebJobUniUtils.Utils.GetNumberInt(btID.Substring(6, 1));
            //get panel
            //R AccordionPane curPanel = (AccordionPane)Master.FindControl("MainContent").FindControl("AccordionPane" + idNumb);
            //get ajax accordion panel
            Accordion accordion1 = (Accordion)this.Master.FindControl("MainContent").FindControl("Accordion1");

            //check validation
            int userSevSelected = -1;
            bool isUserDetVal = false, isValid = false;
            string userSel1, userSel2;
            switch (idNumb) {
                case 1://services
                    //check service is selected
                    userSevSelected = this.ServiceSelectionUserControl.GetSelectedServiceIndex();
                    if (userSevSelected > 0)
                        isValid = true;
                    break;
                case 2://staff
                    userSel1 = this.StaffSelectionUserControl.GetStaffelected();
                    if (!String.IsNullOrEmpty(userSel1))
                        isValid = true;
                    break;
                case 3://date & time
                    userSel1 = this.DateSelectionUserControl.GetSelectedDateStrg();
                    userSel2 = this.DateSelectionUserControl.GetSelectedTimeStrg();
                    if (!String.IsNullOrEmpty(userSel1) && !String.IsNullOrEmpty(userSel2))
                        isValid = true;
                    break;
                case 4://user info
                    isUserDetVal = this.UserInfoUserControl.IsValidFields();
                    if (isUserDetVal)
                        isValid = true;
                    break;
                case 5://payment
                    PolulateInstallation(isPayment: true);
                    break;
                case 6://confirmation
                    PolulateInstallation(isConfirmation: true);
                    break;
            }

            //if current usercontrol validation passes (is valid)
            if (isValid) {
                //move on to next accordion step
                accordion1.SelectedIndex = idNumb;
                //save to session
                goto save2InstSess;
            }
            else {
                //remain on same usercontrol till validation is corrected
                accordion1.SelectedIndex = idNumb - 1;
                goto Outer;
            }
            save2InstSess://goto1
            //save to session accordingly, AND popupate staff agenda to date&time
            switch (idNumb) {
                case 1://services                 
                    PolulateInstallation(isService: true);
                    break;
                case 2://staff
                    PolulateInstallation(isStaff: true);
                    break;
                case 3://date & time
                    PolulateInstallation(isDateAndTime: true);
                    break;
                case 4://user info
                    PolulateInstallation(isUserInfo: true);
                    break;
                case 5://payment
                    PolulateInstallation(isPayment: true);
                    break;
                case 6://confirmation
                    PolulateInstallation(isConfirmation: true);
                    break;
            }//end switch2

            Outer://goto2
            System.Diagnostics.Debug.Print("BookAppt.aspx Button_Click() \t Do Nothing and exit");
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, Button_Click()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, Button_Click()");
            ExceptionUtility.NotifySystemOps(ex);
        }//end catch
    }//end Button_Click

    #endregion

    #region "Methods"
    public void PopulateUserControlsFromSession() {
        try {
            //Get installation from session             
            Installation i = WebUtils.GetInstallationObjectFromSession();

            //services
            List<string> servNames = InstallationBLL.GetServiceDetailsFull(i);
            this.ServiceSelectionUserControl.PopulateServices(servNames);
            //Staff
            List<string> staffNames = InstallationBLL.GetStaff1stNameWithTitle(i);
            this.StaffSelectionUserControl.PopulateStaff(staffNames);

            //date&time

            //End-user Details

            //Payment

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, PopulateUserControlsFromSession Method</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, PopulateUserControlsFromSession Method");
            ExceptionUtility.NotifySystemOps(ex);
        }//end catch
    }//end void

    private void PolulateInstallation(bool isService = false, bool isStaff = false, bool isDateAndTime = false, bool isUserInfo = false, bool isPayment = false, bool isConfirmation = false) {
        try {
            //get isntallation from session
            Installation i = WebUtils.GetInstallationObjectFromSession();
            ApptBLL appt = new ApptBLL();

            //R SaveInstallationToDB (test installation isnt save to DB)

            //udpate Company details
            if (isService) {
                int servSel = this.ServiceSelectionUserControl.GetSelectedServiceIndex();
                // string servName = this.ServiceSelectionUserControl.GetServiceSelected();//gets service name duration and price as per interface
                string servName2 = i.Services[servSel].name;
                int? servID = ServicesBLL.GetServiceIDByServName_Int(servName2);//more than one
            }

            //update client details (main company contact CLIENT)
            if (isStaff) {
                int staffSel_index = this.StaffSelectionUserControl.GetSelectedServiceIndex();
                string staffSel_name = this.StaffSelectionUserControl.GetStaffelected();
                //NB: (index - 1) because of "No Preference"
                string staff1stName = i.Employees[staffSel_index - 1].firstName;
                int? staffID = EmployeeBLL.GetPersonIDByASPuserID(i.Employees[staffSel_index - 1].aspnetUserID);//more than one
                //
            }

            //client ASP.NET USER ID
            if (isDateAndTime) {
                //
            }

            if (isUserInfo) {
                //
            }

            if (isPayment) {
                //

            }

            if (isConfirmation) {
                //


            }

            //if (!isComplete)
            //    //add installation back to session
            //    WebUtils.PutInstallationObjectinSession(i);

            //if (isComplete)
            //    //process data and save to database
            //    InstallationBLL.SaveInstallationToDB(i);
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, PolulateInstallation(x6)</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, PolulateInstallation(x6)");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }//end PolulateInstallation(x6)



    #endregion



}//class