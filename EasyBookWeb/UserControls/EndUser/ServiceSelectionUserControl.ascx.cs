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
       this.RadioButtonListServices.DataSource = servicesName;
        this.RadioButtonListServices.DataBind();
    }

    public string GetServiceSelected() {
        return this.RadioButtonListServices.SelectedItem.Text;
    }
}