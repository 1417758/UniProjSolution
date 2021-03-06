﻿using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniBLL;

public partial class SiteMaster : MasterPage {
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e) {
        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue)) {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey) {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection) {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e) {
       /*07/07 if (!IsPostBack) {
            //disable cache
            //R Response.Cache.SetCacheability(HttpCacheability.NoCache);
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty)) {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }*/
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            MembershipUser currentUser = Membership.GetUser();
            if (currentUser != null) {
                var c = currentUser.UserName;
            }
             dynamic b = Context.User.Identity.Name;
            string username = HttpContext.Current.User.Identity.Name;
            string usernameP = Page.User.Identity.Name;


        }

    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e) {
        //MainWeb Context.GetOwinContext().Authentication.SignOut();
        FormsAuthentication.SignOut();
    }

    protected void btnId_Click(object sender, EventArgs e) {
        //load TEST installation  16/7/16             
        Installation i = WebUtils.GetInstallationObjectFromSession();
        i = Installation.GetTestInstallation();
        //save back to session
        WebUtils.PutInstallationObjectinSession(i);
    }
}