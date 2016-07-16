using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniBLL;
using WebJobUniDAL;
using WebJobUniUtils;

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

    /// <summary>
    /// 1. CreateUserWizardStep Create ASP.Net User
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e) {
        try {
            MembershipCreateStatus p = MembershipCreateStatus.Success;
            Membership.CreateUser(CreateUserWizard1.UserName, CreateUserWizard1.Password, CreateUserWizard1.Email, CreateUserWizard1.Question, CreateUserWizard1.Answer, true, out p);

            //retrieve data entered by client
            this.userName = CreateUserWizard1.UserName;
            this.aspUserID = (Guid)AppSettings.GetUserIDByUserName(CreateUserWizard1.UserName);
            this.email = CreateUserWizard1.Email;
            // PolulateInstallation();

            //hide RegisterHyperLink
            this.RegisterHyperLink.Visible = false;

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, CreatedUser()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, CreatedUser()");
            ExceptionUtility.NotifySystemOps(ex);
        }//endtry-catch
    }//end CreatedUser

    /// <summary>
    /// 2. Stops Wizard going to nextStep is usercontrol validation isnt valid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
                case 5://add service (NB: NEVER RUN AS BUTTON FINISH IS PRESSED INSTEAD) goTo finish_buttonClick
                    isUserControlValid = AddServicesUserControl1.IsValidFields();
                    break;
                case 6: //complete (NB: NEVER RUN AS BUTTON CONTINUE IS PRESSED INSTEAD) goTo ContinueButtonClick
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
            System.Diagnostics.Debug.Print("<h2>Register.aspx, CreateUserWizard1_NextButtonClick()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, CreateUserWizard1_NextButtonClick()");
            ExceptionUtility.NotifySystemOps(ex);
        }//endtry-catch
    }//end NextButtonClick

    /// <summary>
    /// 3. Get Data from userControls entered by the web-User and save it to session
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

            //updated session installation
            PolulateInstallation(CreateUserWizard1.ActiveStepIndex - 1);


        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, OnActiveStepChanged()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, OnActiveStepChanged()");
            ExceptionUtility.NotifySystemOps(ex);
        }//endtry-catch
    }//end OnActiveStepChanged

    /// <summary>
    /// 4. Event Handlers Evoked on last wizardStep (ADD Services) 
    /// it still triggers ActiveStepChange after this (it works as the last-next click)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
                    System.Diagnostics.Debug.Print("CreateUserWizard1_FinishButtonClick, ActiveStepIndex: " + CreateUserWizard1.ActiveStepIndex.ToString() + "\t Unknown wizard step!");
                    break;
            }
            //stop CreateUserWizard1 going to nextStep is usercontrol isnt valid
            if (!isUserControlValid)
                e.Cancel = true;
            //check service has been added
            ShowWarning(isUserControlValid, CreateUserWizard1.ActiveStepIndex, e);

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, CreateUserWizard1_FinishButtonClick()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, CreateUserWizard1_FinishButtonClick()");
            ExceptionUtility.NotifySystemOps(ex);
        }//endtry-catch
    }//end FinishButtonClick

    /// <summary>
    /// 5. Event Handlers Evoked upon completion of CreateUserWizard (confirmation)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e) {
        //process installation obj in BLL
        PolulateInstallation(CreateUserWizard1.ActiveStepIndex);
        //redirect
        Response.Redirect("MyLogin.aspx");
    }

    #endregion

    #region "Methods"
    private void ShowWarning(bool isUserControlValid, int curStepIndex, WizardNavigationEventArgs e) {
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

    private void ResetWarning() {
        Label warning = new Label();
        //check staff
        if (CreateUserWizard1.ActiveStepIndex == 4)
            warning = (Label)CreateUserWizard1.FindControl("lblWarningStaff");
        //check service
        else if (CreateUserWizard1.ActiveStepIndex == 5)
            warning = (Label)CreateUserWizard1.FindControl("lblWarningService");
        //reset warning label
        warning.Text = "";
    }//end ResetWarning

    private void PolulateInstallation(bool isAspNetDet = false, bool isPersDet = false, bool isBusDet = false, bool isBusHrs = false, bool isEmployee = false, bool isService = false, bool isComplete = false) {
        try {
            //get isntallation from session
            Installation i = WebUtils.GetInstallationObjectFromSession();

            //udpate Company details
            if (isBusDet) {
                var _with2 = i.Company;
                _with2.domain = this.businessDetails[0];
                _with2.industry = this.businessDetails[1];
                _with2.natureOfBusiness = (int)Utils.GetNumberInt(this.businessDetails[2]);
                _with2.businessAddress.landline = this.businessDetails[3];
            }

            //update client details (main company contact CLIENT)
            if (isPersDet) {
                var _with1 = i.Company.mainClientContact;
                _with1.title = this.personalDetails[0];
                _with1.firstName = this.personalDetails[1];
                _with1.lastName = this.personalDetails[2];
                _with1.role = (byte)RolesEnum.CLIENT;
            }

            //client ASP.NET USER ID
            if (isAspNetDet) {
                var _with21 = i.Company.mainClientContact;
                _with21.aspnetUserID = this.aspUserID;
                //client Contact Details
                var _with11 = _with21.contactDetail;
                _with11.email = this.email;
                _with11.dateCreated = i.Timestamp;
                _with11.dateUpdated = i.Timestamp;
            }

            if (isBusHrs) {
                var _with22 = i.Company;
                _with22.OpeningTime = this.openHrs;
                _with22.ClosingTime = this.closeHrs;
                _with22.OpeningDays = this.openDays;
            }

            if (isEmployee) {
                //Employees
                Guid tempStaffASPUserID = new Guid();
                var _with3 = i.Employees;
                //loop through all employees added 
                for (int j = 0; j < this.staff1stName.Count; j++) {
                    //add ASP.NET USER and get ASP.NET USER ID
                    tempStaffASPUserID = WebUtils.AddASPNETUser(this.staffLastName[j], this.staff1stName[j], this.staffEmail[j]);
                    //add to installation Employee
                    _with3.Add(new EmployeeBLL(this.staffTitles[j], this.staff1stName[j], this.staffLastName[j], this.staffEmail[j], tempStaffASPUserID));
                }
                //add Staff email to Installation ProviderBLL
                i.ServicesProvidedByStaff.staffEmails = this.staffEmail;
            }//endif isEmployees

            if (isService) {
                //services 
                var _with4 = i.Services;
                //loop through all employees added 
                for (int k = 0; k < this.serviceName.Count; k++) {
                    //create new service
                    ServicesBLL serv = new ServicesBLL();
                    serv.name = this.serviceName[k];
                    serv.duration = this.serviceDuration[k];
                    serv.price = this.servicePrice[k];
                    //add to installation service
                    _with4.Add(serv);
                }

                //services Provided By Staff    
                var _with5 = i.ServicesProvidedByStaff;
                _with5.serviceNames = this.serviceName;
                _with5.staffPerfServiceNames = this.serviceStaff;
            }

            if (!isComplete)
                //add installation back to session
                WebUtils.PutInstallationObjectinSession(i);

            if (isComplete)
                //process data and save to database
                InstallationBLL.SaveInstallationToDB(i);
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, PolulateInstallation(x6)</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, PolulateInstallation(x6)");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }//end PolulateInstallation(x6)


    private void PolulateInstallation(int createUserWizard1_ActiveStepIndex) {
        //Decide which section to update

        switch (createUserWizard1_ActiveStepIndex) {
            case 0://ASP.net Details
                PolulateInstallation(isAspNetDet: true);
                break;
            case 1://Client Details
                PolulateInstallation(isPersDet: true);
                break;
            case 2://Company Details
                PolulateInstallation(isBusDet: true);
                break;
            case 3://Company Working Hrs
                PolulateInstallation(isBusHrs: true);
                break;
            case 4://Employess
                PolulateInstallation(isEmployee: true);
                break;
            case 5://Services
                PolulateInstallation(isService: true);
                break;
            case 6://Complete Confirmation
                System.Diagnostics.Debug.Print("Register.aspx, PolulateInstallation(int):\t Registration Complete!");
                PolulateInstallation(isComplete: true);
                break;
            default: //unknown
                System.Diagnostics.Debug.Print("Register.aspx, PolulateInstallation(int): " + createUserWizard1_ActiveStepIndex.ToString() + "\t Unknown wizard step!");
                break;
        }//end switch
    }//end PolulateInstallation(int)


    #endregion




}//class