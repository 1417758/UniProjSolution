using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_WebUserControl : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            //polulate dropdownList
            PolulateDropDown();
    }

    protected void DropDownListHrs_SelectedIndexChanged(object sender, EventArgs e) {

    }
    #region "Get Functions"
    public string GetHourLabel() {
       return this.LabelHr.Text;
    }

    public string GetHour() {
        return this.DropDownListHrs.SelectedItem.Value;
    }
    public int GetHourInt() {
        return this.DropDownListHrs.SelectedIndex;
    }
    #endregion


    #region "Set Methods"
    protected void PolulateDropDown() {
        try {
            string hrsXML = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Hours.xml");
            //
            WebJobUniUtils.Utils.PopulateDDLFromXMLFile(xmlFile: hrsXML, comboBox: ref this.DropDownListHrs, text: "Name", value: "ID", sortByComboText: false);


        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>Hours.ascx, PolulateDropDown()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "Hours.ascx, PolulateDropDown()");
            ExceptionUtility.NotifySystemOps(exc);
        }
    }
    public void SetHourLabel(string lblText) {
        this.LabelHr.Text = lblText;
    }

    public void SetDefaultHour(int hr2set) {
        //make selection
        this.DropDownListHrs.SelectedIndex = hr2set;
    }
    #endregion
}