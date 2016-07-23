using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniBLL;
using WebJobUniUtils;

public partial class UI_EndUser_WelcomeUser : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            //get current installation from session
            Installation i = WebUtils.GetInstallationObjectFromSession();
            int compID;

            //get url variables
            string clientURL1 = this.Request.RawUrl;
         //   var clientURL2 = HttpContext.Current.Server.UrlDecode.compID_url(); .compID_url; //.UrlDecode.compID_url;
            string compID_url = Request.QueryString[XMLConstants.URLVar1];
            string test_url = Request.QueryString[XMLConstants.URLVar2];
            System.Diagnostics.Debug.Print("<h1>COMPANY_ID FROM URL_VAR IS:\t</h1> " + compID_url + ", test url var is:\t" + test_url);

            //load session Installtion accordinly
            if (String.IsNullOrEmpty(compID_url))
                //load test installation
                i = Installation.GetTestInstallation();
            else {
                compID = (int)Utils.GetNumberInt(compID_url);
                i = Installation.PopulateInstalationObjFromDB(ref i, compID);
            }

            //update session variable
            SessionVariables.CompanyID = WebUtils.GetInstallationObjectFromSession().Company.ID; //i.Company.ID;
            //update welcome page text label
            this.LabelCompanyName.Text = WebUtils.GetInstallationObjectFromSession().Company.domain;
        }
    }
}