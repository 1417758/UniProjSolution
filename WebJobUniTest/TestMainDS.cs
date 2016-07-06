using System;
using WebJobUniUtils;
using WebJobUniDAL;
using System.Windows.Forms;
using System.Diagnostics;


namespace WebJobUniTest {

    public partial class TestMainDS : Form {
        public TestMainDS() {
            InitializeComponent();
        }

        private void TestMainDS_Load(object sender, EventArgs e) {
            try {
                /// Load the settings object on form load.
                dynamic filename = "C:\\forecaster\\settings.xml";
                //"C:\Settings\Emissions Compiler\settings.xml" 
                //'use the line below to test Testshared project when running forecaster 
                //ForecasterSettings.Settings = ForecasterSettings.LoadSettingsFromXML(filename)
                //load exception handling
                //R      AppSettings.Settings = AppSettings.GetSharedSettings(filename);
                //R     System.Diagnostics.Debug.Print(AppSettings.Settings.ToString);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }
        }

        private void btnStartup_Click(object sender, EventArgs e) {
            StartUp Check = new StartUp();
            Check.Show();
            Hide();
        }
        #region "Miscelleneous"        
        public void ResetTextBoxes(bool showGridRowCount = true) {
            this.textBoxAddress.Text = "";
            this.textBoxLastName.Text = "";
            this.textBoxFirstName.Text = "";
            this.textBoxID.Text = "";
            this.textBoxASPUserID.Text = "";
            if (showGridRowCount)
                this.LblReturn.Text = (DataGridView1.RowCount - 1).ToString();
        }
        public int? GetID() {
            dynamic getInt = Utils.GetNumberInt(this.textBoxID.Text);
            if (getInt != null)
                return (int)getInt;
            else {
                MessageBox.Show("Please Enter ID",
                            "Important Note",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                this.textBoxID.Focus();
                return null;
            }
        }
        public Guid GetASP_UserID() {
            try {
                Guid userID = new Guid(textBoxASPUserID.Text);
                return userID;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("GetASP_UserID() \n" + ex.Message);
                return new Guid();
            }
        }
        public string GetLastName() {

            if (!String.IsNullOrEmpty(this.textBoxLastName.Text))
                return this.textBoxLastName.Text;
            else {
                MessageBox.Show("Please Enter Last Name",
                                "Important Note",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                this.textBoxLastName.Focus();
                return null;
            }
        }
        public string GetFirstName() {
            return this.textBoxLastName.Text;
        }
        #endregion

        #region "Person"
        private void GetAllPersons(object sender, EventArgs e, bool showGridRowCount = true) {
            //populate gridView with tableAdapter data
            this.DataGridView1.DataSource = Person.GetAllPerson();
            //show number of records (NB requested by default)
            if (showGridRowCount)
                this.LblReturn.Text = (this.DataGridView1.RowCount - 1).ToString();
        }
        private void btnGetAllPersons_Click(object sender, EventArgs e) {
            GetAllPersons(sender, e);
        }

        private void btnPersonByID_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Person.GetPersonByID(GetID());
            ResetTextBoxes();
        }

        private void btnPersonByUserName_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Person.GetPersonByLastName(GetLastName());
            ResetTextBoxes();
        }
        private void btnGetPersonByAspID_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Person.GetPersonByASPuserID(GetASP_UserID());
            ResetTextBoxes();
        }
        private void bttonGetPersonIDByLastName_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Person.GetPersonIDByLastName(GetLastName());
            ResetTextBoxes();
        }

        private void btnAddPerson_Click(object sender, EventArgs e) {
            Guid userID = new Guid("294CB0FF-0F68-4A31-8F12-C26E34DCC0B8");
            int? result = Person.AddPerson(Person.MRS, "ADDED PERSON", "FORM-TEST", 1, 1, userID);
            ResetTextBoxes();
            this.LblReturn.Text = result.ToString();
            GetAllPersons(sender, e, showGridRowCount: false);
        }
        private void btnDeletePersonByID_Click(object sender, EventArgs e) {
            this.LblReturn.Text = Person.DeletePersonByID(GetID()).ToString();
            ResetTextBoxes(showGridRowCount: false);
            GetAllPersons(sender, e, showGridRowCount: false);
        }
        #endregion

        #region "End-Users"  
        private void GetAllUsers(object sender, EventArgs e, bool showGridRowCount = true) {
            //populate gridView with tableAdapter data
            this.DataGridView1.DataSource = EndUser.GetAllEndUsers();
            //show number of records (NB requested by default)
            if (showGridRowCount)
                this.LblReturn.Text = (this.DataGridView1.RowCount - 1).ToString();
        }
        private void bttonGetAllUsers_Click(object sender, EventArgs e) {
            GetAllUsers(sender, e);
        }
        private void bttonGetUserByID_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = EndUser.GetEndUserByID(GetID());
            ResetTextBoxes();
        }
        private void bttonGetUserByLastName_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = EndUser.GetEndUserByLastName(GetLastName());
            ResetTextBoxes();
        }
        private void bttonGetUserIDByLastName_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = EndUser.GetEndUserIDByLastName(GetLastName());
            ResetTextBoxes();
        }
        private void bttonAddUser_Click(object sender, EventArgs e) {
            Guid userID = new Guid("294CB0FF-0F68-4A31-8F12-C26E34DCC0B8");
            this.LblReturn.Text = EndUser.AddEndUser(Person.MR, "ADDED END-USER", "FORM-TEST", 1, userID).ToString();
            GetAllUsers(sender, e, showGridRowCount: false);
        }
        private void bttonDeleteUser_Click(object sender, EventArgs e) {
            this.LblReturn.Text = EndUser.DeleteEndUserByID(GetID()).ToString();
            ResetTextBoxes(showGridRowCount: false);
            GetAllUsers(sender, e, showGridRowCount: false);
        }
        #endregion

        #region "Company"
        private void BtonGetCompanies_Click(System.Object sender, System.EventArgs e) {
            this.DataGridView1.DataSource = Company.GetAllCompanies();

        }

        private void BtonInsertCompany_Click(System.Object sender, System.EventArgs e) {
            try {
                //R this.LblReturn.Text = "Companies Num: " + Company.AddCompany("rachels group");

                //this.DataGridView1.DataSource = Companies.GetCompanies();
                //this.DataGridView1.Visible = true;

                BtonGetCompanies_Click(sender, e);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }

        }



        /*          private void Button1BtonGetCompaniesIDByCompName_Click(System.Object sender, System.EventArgs e) {
                    try {
                        dynamic l = Strings.Trim(this.textBoxUserName.Text);

                        if (l == null || string.IsNullOrEmpty(l)) {
                            MessageBox.Show("Please enter a valid COMPANY name");
                            this.textBoxUserName.Focus();

                        }
                        else {
                            this.LblReturn.Text = Companies.GetCompanyIDByCompanyName(l);
                            this.DataGridView1.DataSource = Companies.GetCompanies;
                    

                        }

                        ResetTextBoxes();

                    }
                    catch (Exception ex) {
                       System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
                    }

                }

            */
        #endregion

        #region "Employee"
        private void GetAllEmployees(object sender, EventArgs e, bool showGridRowCount = true) {
            //populate gridView with tableAdapter data
            this.DataGridView1.DataSource = Employee.GetAllEmployees();
            //show number of records (NB requested by default)
            if (showGridRowCount)
                this.LblReturn.Text = (this.DataGridView1.RowCount - 1).ToString();
        }
        private void bttonGetAllEmployee_Click(object sender, EventArgs e) {
            GetAllEmployees(sender, e);
        }

        private void bttonGetEmployeeByID_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Employee.GetEmployeeByID(GetID());
            ResetTextBoxes();
        }

        private void bttonGetEmployeeByLastName_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Employee.GetEmployeeByLastName(GetLastName());
            ResetTextBoxes();
        }

        private void bttonGetEmployeeIDByLastName_Click(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Employee.GetEmployeeIDByLastName(GetLastName());
            ResetTextBoxes();
        }

        private void bttonAddEmployee_Click(object sender, EventArgs e) {
            Guid userID = new Guid("9091a8a7-1460-4f22-b95d-81061cf358e7");
            this.LblReturn.Text = Employee.AddEmployee(Person.MRS, "ADDED EMPLOYEE", "FORM-TEST", 1, userID, "BF-73-58-47-B", "developer", 1).ToString();
            GetAllEmployees(sender, e, showGridRowCount: false);
        }

        private void bttonDeleteEmployee_Click(object sender, EventArgs e) {
            this.LblReturn.Text = Employee.DeleteEmployeeByID(GetID()).ToString();
            ResetTextBoxes(showGridRowCount: false);
            GetAllEmployees(sender, e, showGridRowCount: false);
        }
        #endregion


        #region "Client"
        private void GetAllClients(object sender, EventArgs e, bool showGridRowCount = true) {
            //populate gridView with tableAdapter data
            this.DataGridView1.DataSource = Client.GetAllClients();
            //show number of records (NB requested by default)
            if (showGridRowCount)
                this.LblReturn.Text = (this.DataGridView1.RowCount - 1).ToString();
        }
        private void bttonGetAllClients_Click(object sender, EventArgs e) {
            GetAllClients(sender, e);
        }

        private void bttonGetClientByID_Click_1(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Client.GetClientByID(GetID());
            ResetTextBoxes();
        }

        private void bttonGetClientByLastName_Click_1(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Client.GetClientByLastName(GetLastName());
            ResetTextBoxes();
        }

        private void bttonGetClientIDByLastName_Click_1(object sender, EventArgs e) {
            this.DataGridView1.DataSource = Client.GetClientIDByLastName(GetLastName());
            ResetTextBoxes();
        }

        private void bttonAddClient_Click_1(object sender, EventArgs e) {
            Guid userID = new Guid("9091a8a7-1460-4f22-b95d-81061cf358e7");
            this.LblReturn.Text = Client.AddClient(Person.MS, "ADDED CLIENT", "FORM-TEST", 1, userID).ToString();
            GetAllClients(sender, e, showGridRowCount: false);
        }

        private void bttonDeleteClientByID_Click(object sender, EventArgs e) {
            this.LblReturn.Text = Client.DeleteClientByID(GetID()).ToString();
            ResetTextBoxes(showGridRowCount: false);
            GetAllClients(sender, e, showGridRowCount: false);
        }
        #endregion

        #region "BackgroundWorker"

        private void Button1_Click(System.Object sender, System.EventArgs e) {
            //Dim d As New TestDatabaseSizingDataSetTableAdapters.QueriesTableAdapter
            //d.AddRecord(1, 2, DateTime.Now)
            BackgroundWorker1.RunWorkerAsync();
        }



        private void BackgroundWorker1_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e) {
            //R            Dim d As New QueriesTableAdapter
            dynamic r = new Random();

            dynamic PIE2UID = 0;
            dynamic dataDate = new DateTime(2010, 1, 1);

            //NOTE: CODE HERE DOES NOT HANDLE e.g. 60 inputs per minute, only 525600 records

            /*
            for (x = 0; x <= dateTimeCount - 1; x++) {
                if (x % numberOfInputsPerMinute == 0) {
                    dataDate = dataDate.AddMinutes(1);
                }


                if (BackgroundWorker1.CancellationPending) {
                    break; // TODO: might not be correct. Was : Exit For
                }
                else {
                    if (PIE2UID % 30000 == 0) {
                        PIE2UID = 0;
                    }
                    PIE2UID = PIE2UID + 1;

                    dynamic value = Math.Round(r.NextDouble * 1000, 5);
                    //R     d.AddRecordVarchar(PIE2UID, value, dataDate)
                    //R   d.AddRecord(PIE2UID, value, dataDate)

                    if (x % 5000 == 0) {
                        BackgroundWorker1.ReportProgress(x / dateTimeCount * 100 * 0.9);
                    }
                }
            }*/

            BackgroundWorker1.ReportProgress(100);
        }

        private void BackgroundWorker1_ProgressChanged(System.Object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            this.ProgressBar1.Value = e.ProgressPercentage;
            this.Label1.Visible = true;
            //Me.Label1.Text = e.ProgressPercentage & " %" & " of " & dateTimeCount & " records."
        }

        private void BackgroundWorker1_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            //R   this.Label1.Text = "Completed adding of " + dateTimeCount + " records.";
        }
        #endregion


        public void Main() {
            Load += TestMainDS_Load;
        }


    }//class
}//namespace