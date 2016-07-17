using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_EndUser_StaffSelectionUserControl : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {

    }
    public void PopulateStaff(List<String> StaffName) {
        this.RadioButtonListStaff.Items.Add("No Preference");
        //loop through service names parameter
        foreach (string sName in StaffName) {
            //add to radioButton list
            this.RadioButtonListStaff.Items.Add(sName);
        }
    }

    public string GetStaffelected() {
        return this.RadioButtonListStaff.SelectedItem.Text;
    }
}