using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_AddStaffUserControl : System.Web.UI.UserControl {

    #region "Event Handlers"
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            PolulateDropDownTitle();

    }

    protected void ButtonAdd_Click(object sender, EventArgs e) {
        //invoke add method
        AddStaff();
        
    }
    #endregion

    #region "Functions"
    public List<string> GetStaffDetails(bool isTitles = false, bool is1stNames = true, bool isLastNames = false, bool isEmails = false) {
        try {

            BulletedList selected = new BulletedList();
            selected = this.BulletedList1stName;

            //get eamils data
            if (isLastNames)
                selected = this.BulletedListLastName;
            if (isEmails)
                selected = this.BulletedListEmail;
            if (isTitles)
                selected = this.BulletedListTitle;

            //get data
            ListItem[] servDescArray = new ListItem[selected.Items.Count];
            //copy data to array
            selected.Items.CopyTo(servDescArray, 0);
  
            List<string> servDesc = new List<string>();
            //loop through array
            foreach (ListItem liItem in servDescArray) {
                //add to list
                servDesc.Add(liItem.Text);
            }

            //return
            return servDesc;

        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>AddStaffUserControl.ascx, GetStaffDetails()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "AddStaffUserControl.ascx, GetStaffDetails()");
            ExceptionUtility.NotifySystemOps(exc);
            return null;
        }
    }
    public bool IsValidFields() {
        try {
            //validate required fields
            this.RequiredFieldValidator1stName.Validate();
            this.RequiredFieldValidatorLastName.Validate();
            this.RequiredFieldValidatorEmail.Validate();
         
            //get validation result
            bool is1sNamVal = this.RequiredFieldValidator1stName.IsValid;
            bool isLstNamVal = this.RequiredFieldValidatorLastName.IsValid;
            bool isEmailVal = this.RequiredFieldValidatorEmail.IsValid;

            //NB---Return TRUE if staff has already been added
            if (this.BulletedList1stName.Items.Count > 0)
                return true;

            if (!is1sNamVal || !isLstNamVal || !isEmailVal) {
                throw new Exception("<h2>Company and/or Phone number have not been entered @IndAndNatBusUserControl useControl</h2>");
            }
            else
                return true;
        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>First and/or Last name and/or email has not been entered @AddStaffUserControl useControl</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "AddStaffUserControl.ascx, IsValidFields()");
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
            WebJobUniUtils.Utils.PopulateDDLFromXMLFile(xmlFile: hrsXML, comboBox: ref this.DropDownListTitle, text: "Name", value: "ID", sortByComboText: true);

        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>Hours.ascx, PolulateDropDownTitle()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "PersonalDetailsUserControl.ascx, PolulateDropDownTitle()");
            ExceptionUtility.NotifySystemOps(exc);
        }
    }
    protected void AddStaff() {
        try {
            //get data
            string staffTitle = this.DropDownListTitle.SelectedItem.Text;
            string staff1stName = this.TextBox1stName.Text;
            string staffLastName = this.TextBoxLastName.Text;
            string staffEmail = this.TextBoxEmail.Text;

            //add to list
            if (!String.IsNullOrEmpty(staff1stName) && !String.IsNullOrEmpty(staffLastName) && !String.IsNullOrEmpty(staffEmail)) {
                this.BulletedListTitle.Items.Add(staffTitle);
                this.BulletedList1stName.Items.Add(staff1stName);
                this.BulletedListLastName.Items.Add(staffLastName);
                this.BulletedListEmail.Items.Add(staffEmail);                
                //reset textboxes
                ClearTextBoxes();
            }
        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>AddStaffUserControl.ascx, AddStaff()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "AddStaffUserControl.ascx, AddStaff()");
            ExceptionUtility.NotifySystemOps(exc);
        }
    }
    protected void ClearTextBoxes() {
        this.TextBox1stName.Text = "";
        this.TextBoxLastName.Text = "";
        this.TextBoxEmail.Text = "";
        this.DropDownListTitle.SelectedIndex = -1;
    }
    #endregion








}//class