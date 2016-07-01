using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_MyLogin : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        System.Diagnostics.Debug.Print("somehting is happening");
    }

    protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e) {
        if (Membership.ValidateUser(Login1.UserName, Login1.Password) == true) {
            Login1.Visible = true;
            Session["user"] = HttpContext.Current.User.Identity.Name;
            Session["user1"] = Login1.UserName;

            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
        }
        else {
            Response.Write("Invalid Login");
        }
    }


    protected void Login1_LoggedIn(object sender, System.EventArgs e) {

        try {
            string ipaddress = Request.UserHostAddress;

            string endUser = this.Login1.UserName.Trim().ToUpper();

            //adds a record to logins table 
            // Logins.AddLogin(DateTime.Now, user, this.Login1.Password, true, getDetails, ipaddress, user);

            //create user directory and temp folder if it doesn't exist
            string s = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + endUser + "/upload/");

            if (!Directory.Exists(s)) {
                Directory.CreateDirectory(s);
            }


            //start session here
            Session["curUser"] = endUser;

            if(Session["curUser"] != null)
                ///this.Master.




            //redirect 
            Response.Redirect("~/Contact.aspx");

        }
        catch (System.Threading.ThreadAbortException ex) {
            //do nothing - happens every time (due response redirect it seems)
            System.Diagnostics.Debug.Print(ex.ToString());
        }
        catch (Exception ex) {
            // UtilsShared.LogException(ex, User.Identity.Name);
            System.Diagnostics.Debug.Print(ex.ToString());
        }

    }

    /// <summary>
    /// Record failed login and send email exception.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks></remarks>
    protected void Login1_LoginError(object sender, System.EventArgs e) {

        try {

            dynamic a = User.Identity.Name;
            string endUser = this.Login1.UserName.Trim().ToUpper();
            dynamic pass = this.Login1.Password;
            dynamic ipaddress = Request.UserHostAddress;
            //adds a record to logins table 
            //Ra Logins.AddLogin(DateTime.Now, user, pass, false, getDetails, ipaddress, user);


            //R           If ExceptionHandling.ExceptionHandlingSettings.EmailNotificationsOn Then
            //R           Dim toMail As New MailAddress(ExceptionHandling.ExceptionHandlingSettings.ExceptionRecipient)
            //R           Dim fromMail As New MailAddress("errors@pi-e2-software.com")
            //R           Dim msg As String = "Attempted login failed for : " & user & vbCrLf & "Password entered: " & pass
            //R           SendMail.Send(msg, "EMISSIONS COMPILER - Failed Login Attempt", Net.Mail.DeliveryNotificationOptions.None, Net.Mail.MailPriority.High, toMail, fromMail, Nothing, Nothing, Nothing)
            //R           End If
        }
        catch (Exception ex) {
            //  UtilsShared.LogException(ex, User.Identity.Name);
            System.Diagnostics.Debug.Print(ex.ToString());
        }

    }

    /// <summary>
    /// Return details of user browser etc. for storing to database.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public string GetDetails() {
        try {
            string details = "DETAILS:\n";
            details += "Session ID      :" + HttpContext.Current.Session.SessionID + "\n"; //\r\n or Environment.NewLine
            details += "Browser Type    :" + HttpContext.Current.Request.Browser.Type + "\n";
            details += "Browser Version: " + HttpContext.Current.Request.Browser.Version + "\n";
            return details;
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print(ex.ToString());
            return "Error in creating login Details!";
        }
    }

    

}