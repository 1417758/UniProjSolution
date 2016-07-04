<%@ Application Language="C#" %>
<%@ Import Namespace="EasyBookWeb" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Web.Profile" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e) {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    void Application_End(object sender, EventArgs e) {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e) {
        try {
            // Code that runs when an unhandled error occurs
            //source https://msdn.microsoft.com/en-us/library/bb397417(v=vs.100).aspx

            // Get the exception object.
            Exception exc = Server.GetLastError();

            //R

            // Handle HTTP errors
            if (exc.GetType() == typeof(HttpException)) {
                // The Complete Error Handling Example generates
                // some errors using URLs with "NoCatch" in them;
                // ignore these here to simulate what would happen
                // if a global.asax handler were not implemented.
                if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength"))
                    return;

                //Redirect HTTP errors to HttpError page
                Server.Transfer("HttpError.aspx");
                //same/alternative of above// HttpContext.Current.RewritePath("~/Error/HttpErrorPage.aspx");
            }

            // For other kinds of errors give the user some information
            // but stay on the default page
            System.Diagnostics.Debug.Print("<h2>Global.asax Page, Application_Error Method, Error</h2>\n");
            System.Diagnostics.Debug.Print("<p>" + exc.Message + "</p>\n");
            System.Diagnostics.Debug.Print("<p>" + exc.InnerException + "</p>\n");

            //NB REVIEW THIS 03/7/16
            //ORIG Response.Write("Return to the <a href='Default.aspx'>" + "Default Page</a>\n"); /note here Default=testError.aspx
            Response.Write("Return to <a href=\"GenericError.aspx\">Generic</a>");
      //WORKING VS    Response.Write("Return to <a href=\"TestError.aspx\">Error Test Default Page</a>");

            // Log the exception and notify system operators        
            ExceptionUtility.LogException(exc, "Global.asax, Application_Error Method");
            ExceptionUtility.NotifySystemOps(exc);

            //R test
            //R  Server.Transfer("GenericError.aspx", true);

            // Clear the error from the server
            Server.ClearError();
        }
        catch (Exception ex) {
            //  UtilsShared.LogException(ex, User.Identity.Name);
            System.Diagnostics.Debug.Print("<h2>Global.asax, Application_Error Method</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "Global.asax, Application_Error Method");
            ExceptionUtility.NotifySystemOps(ex);
        }

    }

    void Session_Start(object sender, EventArgs e) {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Profile_MigrateAnonymous(Object sender, ProfileMigrateEventArgs pe) {

        //ProfileCommon anonProfile = Profile.GetProfile(pe.AnonymousID);

        // if (anonProfile.UserInfo.Name != null || anonProfile.UserInfo.Name != "") {
        //     Profile.UserInfo = anonProfile.UserInfo;
        // }

        System.Web.Profile.ProfileManager.DeleteProfile(pe.AnonymousID);

        AnonymousIdentificationModule.ClearAnonymousIdentifier();
    }

</script>
