using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniUtils;

public partial class UI_ConfigPanel_Dashboard : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            //NB -- Upon client login SessionVariables.CompanyID is poputalted according to client details ont the DB
            //ref to Login1_Authenticate1 lines 24-36
            //R        int compID = (int)SessionVariables.CompanyID;
            //testing use compId 1
            int compID = SessionVariables.CompanyID ?? 1;

            var find = HttpContext.Current.Request.Url;  //HttpContext.Current.Server.MapPath.ResolveUrl;
            string var1 = "?" + XMLConstants.URLVar1 + "=" + compID; //SessionVariables.CompanyID.ToString();
            string var2 = "&" + XMLConstants.URLVar2 + "=" + "meTestingYou";

            string test = find.ToString().Replace("UI/ConfigPanel/Dashboard", SessionVariables.EndUserURL + var1 + var2);
            this.clientLink.InnerText = test;
            this.clientLink.HRef = test;
        }


    }
}