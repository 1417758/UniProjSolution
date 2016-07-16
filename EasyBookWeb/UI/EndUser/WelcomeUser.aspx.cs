using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_EndUser_WelcomeUser : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            this.LabelCompanyName.Text = WebUtils.GetInstallationObjectFromSession().Company.domain;
    }
}