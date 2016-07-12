using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_PersonalDetailsUserControl : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            //polulate dropdownList
            PolulateDropDownTitle();
    }

    #region "Get Functions"
    public string GetTitle() {
        return this.DropDownListTitles.SelectedItem.Value;
    }
    public string GetFirstName() {
        return this.TextBoxFirstName.Text;
    }
    public string GetLastName() {
        return this.TextBoxLastName.Text;
    }

    public List<string> GetPersonalDetails() {
        List<string> persDetails = new List<string>();
        persDetails.Add(this.DropDownListTitles.SelectedItem.Text);
        persDetails.Add(TextBoxFirstName.Text);
        persDetails.Add(TextBoxLastName.Text);
        return persDetails;
    }
    #endregion

    #region "Set Methods"
    protected void PolulateDropDownTitle() {
        try {
            string hrsXML = SessionVariables.TitlesXml;
            //
            WebJobUniUtils.Utils.PopulateDDLFromXMLFile(xmlFile: hrsXML, comboBox: ref this.DropDownListTitles, text: "Name", value: "ID", sortByComboText: true);

        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>Hours.ascx, PolulateDropDownTitle()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "PersonalDetailsUserControl.ascx, PolulateDropDownTitle()");
            ExceptionUtility.NotifySystemOps(exc);
        }
    }
    #endregion





}//class