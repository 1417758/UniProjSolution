﻿using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Error_TestError : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void Submit_Click(object sender, EventArgs e) {
        //try {

        string arg = ((Button)sender).CommandArgument;

        switch (arg) {
            case "1": {
                    // Exception handled on the Generic Error Page
                    throw new InvalidOperationException("Button 1 was clicked");
                    break;
                }
            case "2": {
                    // Exception handled on the current page
                    throw new ArgumentOutOfRangeException("Button 2 was clicked");
                    break;
                }
            case "3": {
                    // Exception handled by Application_Error
                    throw new Exception("Button 3 was clicked");
                    break;
                }
            case "4": {
                    // Exception handled on the Http 404 Error Page
                    Response.Redirect("NonexistentPage.aspx");
                    break;
                }
            case "5": {
                    // Exception handled on the Http Error Page
                    Response.Redirect("NonexistentPage-NoCatch.aspx");
                    break;
                }
            case "6": {
                    // Exception handled on the Generic Http Error Page
                    Response.Redirect("NonexistentPage-NoCatch.aspx/" + new string('x', 500));
                    break;
                }
        }
        //}
        //catch (Exception ex) {
        //    System.Diagnostics.Debug.Print("<h2>TestError.aspx, Submit_Click Method</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
        //    // Log the exception and notify system operators
        //    ExceptionUtility.LogException(ex, "TestError.aspx, Submit_Click Method");
        //    ExceptionUtility.NotifySystemOps(ex);
        //}
    }

    private void Page_Error(object sender, EventArgs e) {
        // Get last error from the server
        Exception exc = Server.GetLastError();

        // Handle exceptions generated by Button 1
        if (exc is InvalidOperationException) {
            // Pass the error on to the Generic Error page
            Server.Transfer("GenericError.aspx", true);
        }

        // Handle exceptions generated by Button 2
        else if (exc is ArgumentOutOfRangeException) {
            // Give the user some information, but
            // stay on the default page
            System.Diagnostics.Debug.Print("<h2>Default Page Error</h2>\n");
            System.Diagnostics.Debug.Print("<p>Provide as much information here as is " +
              "appropriate to show to the client.</p>\n");
            System.Diagnostics.Debug.Print("Return to the <a href='TestError.aspx'>" + "Test Error Page</a>\n");
            Response.Write("Return to <a href=\"TestError.aspx\">Error Test Default Page</a>");

            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "TestError.aspx, Page_Error");
            ExceptionUtility.NotifySystemOps(exc);

            // Clear the error from the server
            Server.ClearError();
        }
        else {
            // Pass the error on to the default global handler
        }
    }
}
