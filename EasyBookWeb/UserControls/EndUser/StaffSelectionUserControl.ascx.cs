using EasyBookWeb;
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

        //Add option with no staff prefence
        this.RadioButtonListStaff.Items.Add("No Preference");

        //loop through service names parameter
        foreach (string sName in StaffName) {
            //add to radioButton list
            this.RadioButtonListStaff.Items.Add(sName);
        }
    }

    public string GetStaffelected() {
        try {
            return this.RadioButtonListStaff.SelectedItem.Text;
        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>ITEM NOT SELECTED @StaffSelectionUserControl useControl</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "StaffSelectionUserControl.ascx, StaffSelectionUserControl()");
            ExceptionUtility.NotifySystemOps(exc);
            return null;
        }
    }
    public int GetSelectedServiceIndex() {
        return this.RadioButtonListStaff.SelectedIndex;
    }
}