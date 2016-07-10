using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error_DefaultRedirectError : System.Web.UI.Page {
    protected HttpException ex = null;

    protected void Page_Load(object sender, EventArgs e) {
        try {
     // Log the exception and notify system operators
        ex = new HttpException("Default Redirect Error");
        ExceptionUtility.LogException(ex, "Caught in Default Redirect Error Page");
        ExceptionUtility.NotifySystemOps(ex);
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>DefaultRedirectError.aspx, Page_Load Event</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "DefaultRedirectError.aspx, Page_Load Event");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }
}