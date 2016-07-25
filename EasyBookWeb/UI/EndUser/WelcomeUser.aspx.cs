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
          
            //get url variables
            string clientCurrentURL = this.Request.RawUrl;

            //update session installation accordingly
            WebUtils.LoadInstallation2Sesssion(clientCurrentURL);

            //update welcome page text label
            this.LabelCompanyName.Text = WebUtils.GetInstallationObjectFromSession().Company.domain;
        }
    }
}