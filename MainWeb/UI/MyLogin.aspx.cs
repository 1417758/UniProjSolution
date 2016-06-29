using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_MyLogin : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
    }



    //protected void Login1_LoggedIn(object sender, System.EventArgs e) {

    //    try {
    //        string ipaddress = Request.UserHostAddress;

    //        string user = Strings.UCase(Strings.Trim(this.Login1.UserName));

    //        //adds a record to logins table 
    //        Logins.AddLogin(DateTime.Now, user, this.Login1.Password, true, getDetails, ipaddress, user);


    //        //create user directory and temp folder if it doesn't exist
    //        string s = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/" + user + "/upload/");

    //        if (!Directory.Exists(s)) {
    //            Directory.CreateDirectory(s);
    //        }

    //        DropDownList mode = this.Login1.FindControl("modeDropDownList");

    //        if (mode.SelectedIndex == 0) {
    //            // Me.Login1.DestinationPageUrl = "~/UI/Overview.aspx"
    //            Response.Redirect("~/UI/Overview.aspx");
    //        }
    //        else if (mode.SelectedIndex == 1) {
    //            Session(SessionConstants.UserConfig_Instalation) = new Installation();
    //            //  Me.Login1.DestinationPageUrl = "~/UI/UserConfig/Welcome.aspx"
    //            Response.Redirect("~/UI/UserConfig/Welcome.aspx", true);
    //            //PS: this needs set here in order to hide controls on master page if user selects user config mode
    //            Session(SessionConstants.UserHasVisitedUserConfig) = true;
    //        }
    //    }
    //    catch (System.Threading.ThreadAbortException ex) {
    //        //do nothing - happens every time (due response redirect it seems)
    //        System.Diagnostics.Debug.Print(ex.ToString);
    //    }
    //    catch (Exception ex) {
    //        UtilsShared.LogException(ex, User.Identity.Name);
    //    }

    //}







}