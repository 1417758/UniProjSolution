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
    private List<string> serviceName;//title,
    private List<string> serviceDuration;//firstName, 
    private List<string> servicePrice;//lastName,
    private List<string> serviceStaff;//emails


    #region "Event Handlers"
    protected void Page_Load(object sender, EventArgs e) {


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
        }
    }

    protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e) {
        Response.Redirect("MyLogin.aspx");
    }

    protected void CreateUserWizard1_OnActiveStepChanged(object sender, EventArgs e) {
        try {
            /*  // If the ActiveStep is changing to Step2, check to see whether the 
              Label title = new Label();
              dynamic wizCont = this.CreateUserWizard1.FindControl("lblStepTitle");
              title = (Label)wizCont;
              //10/7/16 CANT FIND CONTROL(LABEL) IT ALWAYS RETURNS NULL
              //dynamic labT = Repeater.Controls[0].Controls[0].FindControl("lblControl");
              dynamic labT = CreateUserWizard1.FindControl("HeaderTemplate").FindControl("lblHeader");
              title = (Label)labT;*/


            //get Installation from session
           // Installation i = WebUtils.GetInstallationObjectFromSession();
            ASP.usercontrols_personaldetailsusercontrol_ascx personal;
            string title;
            ASP.usercontrols_personaldetailsusercontrol_ascx personalControl = (ASP.usercontrols_personaldetailsusercontrol_ascx)this.FindControl("PersonalDetailsUserControl1");
            personal = (ASP.usercontrols_personaldetailsusercontrol_ascx)CreateUserWizard1.FindControl("PersonalDetailsUserControl1");

            //step1 - Personal Details
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep2)) {
                personalControl = (ASP.usercontrols_personaldetailsusercontrol_ascx)this.CreateUserWizard1.Controls[0].FindControl("PersonalDetailsUserControl1");
                title = personal.GetTitle();
                title = personalControl.GetTitle();
                personalDetails = personalControl.GetPersonalDetails();

            }
            /*
                        //step2
                        if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep3))
                            title.Text = this.WizardStep2.Title;
                        title.Text = "RACHELS";
                        //step3
                        if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep4))
                            title.Text = this.WizardStep3.Title;
                        //step4
                        if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep5))
                            title.Text = this.WizardStep4.Title;
                        //step5
                        if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(CompleteWizardStep1))
                            title.Text = this.WizardStep5.Title;
            */
            //add isntallation back to session
            //WebUtils.PutInstallationObjectinSession(i);

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>Register.aspx, OnActiveStepChanged()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Register.aspx, OnActiveStepChanged()");
            ExceptionUtility.NotifySystemOps(ex);
        }

    }
    #endregion

    #region "Methods"
    #endregion





    //protected void CreateUserWizard1_DataBinding(object sender, EventArgs e) {
    //    RepeaterItem item = (RepeaterItem)e.Item;
    //    if (item.ItemType == ListItemType.Header) {
    //        item.FindControl("control"); //goes here
    //    }
    //}



    protected void CreateUserWizard1_NextButtonClick(object sender, WizardNavigationEventArgs e) {

    }

    protected void WizardStep3_Unload(object sender, EventArgs e) {

    }
}