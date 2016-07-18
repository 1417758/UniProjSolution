using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_EndUser_ServiceSelectionUserControl : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {

    }
    public void PopulateServices(List<String> servicesName) {
       
        //loop through service names parameter
        foreach (string sName in servicesName) {
            //add to radioButton list
            this.RadioButtonListServices.Items.Add(sName);            
        }
        this.RadioButtonListServices.DataSource = servicesName;
        // this.RadioButtonListServices.DataTextField = "name";
        // this.RadioButtonListServices.DataValueField = "serviceID";
        this.RadioButtonListServices.DataBind();

    }

    public string GetServiceSelected() {
        return this.RadioButtonListServices.SelectedItem.Text;//NB: no selection return expecetion!?? 18/7/16 must test
    }
    public int GetSelectedServiceIndex() {
        return this.RadioButtonListServices.SelectedIndex;
    }

}