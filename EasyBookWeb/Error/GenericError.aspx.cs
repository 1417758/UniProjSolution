using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error_GenericError : System.Web.UI.Page {

    protected Exception ex = null;
    protected void Page_Load(object sender, EventArgs e) {

        try {
            // Get the last error from the server
            Exception ex = Server.GetLastError();

            // Create a safe message
            string safeMsg = "A problem has occurred in the web site. ";

            // Show Inner Exception fields for local access
            if (ex != null && ex.InnerException != null) {
                lblInnerTrace.Text = ex.InnerException.StackTrace;
                // InnerErrorPanel.Visible = Request.IsLocal;
                lblInnerMessage.Text = ex.InnerException.Message;
            }
            // Show Trace for local access
            if (Request.IsLocal)
                lblExTrace.Visible = true;
            else
                ex = new Exception(safeMsg, ex);

            // Fill the page fields
            if (ex != null && ex.Message != null)
                lblExMessage.Text = ex.Message;
            if (ex != null && ex.StackTrace != null)
                lblExTrace.Text = ex.StackTrace;

            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "GenericError Page, Page_Load Event");
            ExceptionUtility.NotifySystemOps(ex);

            // Clear the error from the server
            Server.ClearError();
        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>GenericError.aspx, Page_Load Event</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "GenericError.aspx, Page_Load Event");
            ExceptionUtility.NotifySystemOps(exc);
        }

    }
}