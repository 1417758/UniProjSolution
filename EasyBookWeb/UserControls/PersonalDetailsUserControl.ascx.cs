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

    public bool IsValidFields() {
        try {
            //validate required fields
            this.RequiredFieldValidatorFirstName.Validate();
            this.RequiredFieldValidatorLastName.Validate();
            //get validation result
            bool is1sNamVal = this.RequiredFieldValidatorFirstName.IsValid;
            bool isLstNamVal = this.RequiredFieldValidatorLastName.IsValid;

            if (!is1sNamVal || !isLstNamVal) 
                //first and last name have not been entered               
                throw new Exception("<h2>First and/or Last names have not been entered @PersonalDetailsUserControl useControl</h2>");            
            else
                return true;
        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>First and/or Last names have not been entered @PersonalDetailsUserControl useControl</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "IndAndNatBusUserControl.ascx, IsValidFields()");
            ExceptionUtility.NotifySystemOps(exc);
            return false;
        }
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
            System.Diagnostics.Debug.Print("<h2>PersonalDetailsUserControl.ascx, PolulateDropDownTitle()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "PersonalDetailsUserControl.ascx, PolulateDropDownTitle()");
            ExceptionUtility.NotifySystemOps(exc);
        }
    }
    #endregion



}//class