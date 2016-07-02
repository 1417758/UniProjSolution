using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error_HttpError : System.Web.UI.Page {

    protected HttpException ex = null;
    protected void Page_Load(object sender, EventArgs e) {

        try {
            ex = (HttpException)Server.GetLastError();
            int httpCode = ex.GetHttpCode();

            // Filter for Error Codes and set text
            if (httpCode >= 400 && httpCode < 500)
                ex = new HttpException
                    (httpCode, "Safe message for 4xx HTTP codes.", ex);
            else if (httpCode > 499)
                ex = new HttpException
                    (ex.ErrorCode, "Safe message for 5xx HTTP codes.", ex);
            else
                ex = new HttpException
                    (httpCode, "Safe message for unexpected HTTP codes.", ex);

            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "HttpError Page, Page_Load Event");
            ExceptionUtility.NotifySystemOps(ex);

            // Fill the page fields
            lblExMessage.Text = ex.Message;
            lblExTrace.Text = ex.StackTrace;

            // Show Inner Exception fields for local access
            if (ex.InnerException != null) {
                lblInnerTrace.Text = ex.InnerException.StackTrace;
                //InnerErrorPanel.Visible = Request.IsLocal;
                lblInnerMessage.Text = string.Format("HTTP {0}: {1}",
                  httpCode, ex.InnerException.Message);
            }
            // Show Trace for local access
            lblExTrace.Visible = Request.IsLocal;

            // Clear the error from the server
            Server.ClearError();
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>HttpError.aspx, Page_Load Event</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "HttpError.aspx, Page_Load Event");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }
}