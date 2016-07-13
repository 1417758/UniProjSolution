using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniBLL;


public partial class UI_Register : System.Web.UI.Page {

    //private ASP.usercontrols_personaldetailsusercontrol_ascx personalDetails;
    // Installation i = WebUtils.GetInstallationObjectFromSession();
    private string userName, email;
    private Guid aspUserID;
    private List<string> personalDetails;//title,firstName, lastName,
    private List<string> businessDetails;//businessDomain, industry, natOfBuss, landLine,
    private List<int> openHrs;//Mon-Sun
    private List<int> closeHrs;//Mon-Sun
    private List<bool> openDays;//Mon-Sun
    ///employess
    private List<string> staffTitles;//title,
    private List<string> staff1stName;//firstName, 
    private List<string> staffLastName;//lastName,
    private List<string> staffEmail;//emails
    ///services
    private List<string> serviceName;
    private List<string> serviceDuration;
    private List<string> servicePrice;
    private List<string> serviceStaff;
    /* //usercontrols
     ASP.usercontrols_personaldetailsusercontrol_ascx personalDetControl;
     ASP.usercontrols_indandnatbususercontrol_ascx businessDetControl;
     ASP.usercontrols_openinghrsweek_ascx businessHrsControl;
     ASP.usercontrols_addstaffusercontrol_ascx staffControl;
     ASP.usercontrols_addservicesusercontrol_ascx servicesControl;
     */


    #region "Event Handlers"
    protected void Page_Load(object sender, EventArgs e) {
        //resets warning label at Add Staff and Add Service
        ResetWarning();

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e) {
        try {
            MembershipCreateStatus p = MembershipCreateStatus.Success;
            Membership.CreateUser(CreateUserWizard1.UserName, CreateUserWizard1.Password, CreateUserWizard1.Email, CreateUserWizard1.Question, CreateUserWizard1.Answer, true, out p);

            //retrieve data entered by client
            this.userName = CreateUserWizard1.UserName;
            this.aspUserID = (Guid)AppSettings.GetUserIDByUserName(CreateUserWizard1.UserName);
            this.email = CreateUserWizard1.Email;
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, CreatedUser()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, CreatedUser()");
            ExceptionUtility.NotifySystemOps(ex);
        }//endtry-catch
    }//end CreatedUser

    protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e) {
        //add to installation obj and session
        PolulateInstallation();
        //redirect
        Response.Redirect("MyLogin.aspx");
    }

    protected void CreateUserWizard1_OnActiveStepChanged(object sender, EventArgs e) {
        try {
 
            //step1 - Personal Details
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep2))
                //get personal details
                personalDetails = PersonalDetailsUserControl1.GetPersonalDetails();
            //step2
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep3))
                //get company details
                businessDetails = IndAndNatBusUserControl1.GetBusinessDetails();
            //step3
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep4)) {
                //get business hours
                openHrs = OpeningHrsWeek1.GetOpeningHourInt();
                closeHrs = OpeningHrsWeek1.GetClosingHourInt();
                openDays = OpeningHrsWeek1.GetOpeningDays();
            }
            //step4
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep5)) {
                //get Employees added
                staffTitles = AddStaffUserControl1.GetStaffDetails(isTitles: true);//title,
                staff1stName = AddStaffUserControl1.GetStaffDetails();//firstName, 
                staffLastName = AddStaffUserControl1.GetStaffDetails(isLastNames: true);//lastName,
                staffEmail = AddStaffUserControl1.GetStaffDetails(isEmails: true);//emails
                //populate next slide staff dropdown
                AddServicesUserControl1.PopulateStaff(staff1stName);
            }
            //step5
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(CompleteWizardStep1)) {
                //get services added
                serviceName = AddServicesUserControl1.GetServiceDetails();
                serviceDuration = AddServicesUserControl1.GetServiceDetails(isServDuration: true);
                servicePrice = AddServicesUserControl1.GetServiceDetails(isServPrice: true);
                serviceStaff = AddServicesUserControl1.GetServiceDetails(isServStaff: true);
            }
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, OnActiveStepChanged()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, OnActiveStepChanged()");
            ExceptionUtility.NotifySystemOps(ex);
        }//endtry-catch
    }//end OnActiveStepChanged

    protected void CreateUserWizard1_NextButtonClick(object sender, WizardNavigationEventArgs e) {
        try {
            bool isUserControlValid = true;

            //get userControl validation
            switch (CreateUserWizard1.ActiveStepIndex) {
                case 0://create aspUser
                    System.Diagnostics.Debug.Print("CreateUserWizard1_NextButtonClick, ActiveStepIndex: " + CreateUserWizard1.ActiveStepIndex.ToString() + "\t Created aspUser!");
                    break;
                case 1://personal Details
                    isUserControlValid = PersonalDetailsUserControl1.IsValidFields();
                    break;
                case 2://Business Details
                    isUserControlValid = IndAndNatBusUserControl1.IsValidFields();
                    break;
                case 3://business working hrs and days
                    System.Diagnostics.Debug.Print("CreateUserWizard1_NextButtonClick, ActiveStepIndex: " + CreateUserWizard1.ActiveStepIndex.ToString() + "\t Business Hrs!");
                    break;
                case 4://add staff
                    isUserControlValid = AddStaffUserControl1.IsValidFields();
                    break;
                case 5://add service
                    isUserControlValid = AddServicesUserControl1.IsValidFields();
                    break;
                case 6: //complete
                    System.Diagnostics.Debug.Print("CreateUserWizard1_NextButtonClick, ActiveStepIndex: " + CreateUserWizard1.ActiveStepIndex.ToString() + "\t Finished Registration!");
                    break;
                default:
                    System.Diagnostics.Debug.Print("CreateUserWizard1_NextButtonClick, ActiveStepIndex: " + CreateUserWizard1.ActiveStepIndex.ToString() + "\t Unknown wizard step!");
                    break;
            }
            //stop CreateUserWizard1 going to nextStep is usercontrol isnt valid
            if (!isUserControlValid)
                e.Cancel = true;

            //check staff has been added
            if (CreateUserWizard1.ActiveStepIndex == 4)
                ShowWarning(isUserControlValid, CreateUserWizard1.ActiveStepIndex, e);
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, PolulateInstallation()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, PolulateInstallation()");
            ExceptionUtility.NotifySystemOps(ex);
        }//endtry-catch
    }//end NextButtonClick

    protected void CreateUserWizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e) {
        try {
            bool isUserControlValid = true;
            System.Diagnostics.Debug.Print(e.CurrentStepIndex.ToString());
            //get userControl validation
            switch (CreateUserWizard1.ActiveStepIndex) {
                case 5://add service
                    isUserControlValid = AddServicesUserControl1.IsValidFields();
                    break;
                default:
                    System.Diagnostics.Debug.Print("CreateUserWizard1_NextButtonClick, ActiveStepIndex: " + CreateUserWizard1.ActiveStepIndex.ToString() + "\t Unknown wizard step!");
                    break;
            }
            //stop CreateUserWizard1 going to nextStep is usercontrol isnt valid
            if (!isUserControlValid)
                e.Cancel = true;
            //check service has been added
            ShowWarning(isUserControlValid, CreateUserWizard1.ActiveStepIndex, e);
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, PolulateInstallation()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, PolulateInstallation()");
            ExceptionUtility.NotifySystemOps(ex);
        }//endtry-catch
    }//end FinishButtonClick
    #endregion

    #region "Methods"
    private void PolulateInstallation() {
        try {
            //get isntallation from session
            Installation i = WebUtils.GetInstallationObjectFromSession();

            //add isntallation back to session
            //WebUtils.PutInstallationObjectinSession(i);
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, PolulateInstallation()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, PolulateInstallation()");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }
    #endregion

    
   


    protected void ShowWarning(bool isUserControlValid, int curStepIndex, WizardNavigationEventArgs e) {
        try {         
            int itemAdded = 0;
            Label warning = new Label();

            //get userControl validation
            switch (curStepIndex) {
                case 4://check staff
                    itemAdded = AddStaffUserControl1.GetStaffDetails().Count();                    
                    break;
                case 5://check service
                    itemAdded = AddServicesUserControl1.GetServiceDetails().Count();                    
                    break;
                default:
                    System.Diagnostics.Debug.Print("ShowWarning, ActiveStepIndex: " + CreateUserWizard1.ActiveStepIndex.ToString() + "\t Unknown wizard step!");
                    break;
            }
            //check service or staff has been added
           if (isUserControlValid && itemAdded == 0) {
                switch (curStepIndex) {
                    case 4://staff warning msg
                        //find warning label
                        warning = (Label)CreateUserWizard1.FindControl("lblWarningStaff");
                        warning.Text = "Please click on add to include at least one member of staff.";
                        break;
                    case 5://service warning msg 
                        //find warning label
                        warning = (Label)CreateUserWizard1.FindControl("lblWarningService");
                        warning.Text = "Please click on add to include at least one service.";
                        break;
                    default:
                        System.Diagnostics.Debug.Print("ShowWarning, ActiveStepIndex: " + CreateUserWizard1.ActiveStepIndex.ToString() + "\t Unknown wizard step!");
                        break;
                }//inner switch
                //dont allow wizard to move to next slide
                e.Cancel = true;

            }//endif           
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, PolulateInstallation()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, PolulateInstallation()");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }

    protected void ResetWarning() {
        try {
            Label warning = new Label();
            //check staff
            if (CreateUserWizard1.ActiveStepIndex == 4)
                warning = (Label)CreateUserWizard1.FindControl("lblWarningStaff");
            //check service
            else if (CreateUserWizard1.ActiveStepIndex == 5)
                warning = (Label)CreateUserWizard1.FindControl("lblWarningService");
         //reset warning label
            warning.Text = "";

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, PolulateInstallation()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, PolulateInstallation()");
            ExceptionUtility.NotifySystemOps(ex);
        }//end try-catch
    }//end ResetWarning






}//class