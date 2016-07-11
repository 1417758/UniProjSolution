using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_Register : System.Web.UI.Page {



    #region "Event Handlers"
    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e) {
        try {
            MembershipCreateStatus p = MembershipCreateStatus.Success;
            Membership.CreateUser(CreateUserWizard1.UserName, CreateUserWizard1.Password, CreateUserWizard1.Email, CreateUserWizard1.Question, CreateUserWizard1.Answer, true, out p);
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
            title = (Label)labT;

            //step2
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep2))
                title.Text = this.WizardStep2.Title;
                title.Text = "RACHELS";
            //step3
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep3))
                title.Text = this.WizardStep3.Title;
            //step4
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep4))
                title.Text = this.WizardStep4.Title;
            //step5
            if (CreateUserWizard1.ActiveStepIndex == CreateUserWizard1.WizardSteps.IndexOf(this.WizardStep5))
                title.Text = this.WizardStep5.Title;
                */
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