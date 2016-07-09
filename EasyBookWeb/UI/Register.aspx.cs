using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_Register : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e) {
        try {
            MembershipCreateStatus p = MembershipCreateStatus.Success;
            Membership.CreateUser(CreateUserWizard1.UserName, CreateUserWizard1.Password, CreateUserWizard1.Email, CreateUserWizard1.Question, CreateUserWizard1.Answer, true, out p);
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>MyLogin.aspx, LoggedIn Method</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "MyLogin.aspx, LoggedIn Method");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }

    protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e) {
        Response.Redirect("MyLogin.aspx");
    }



}