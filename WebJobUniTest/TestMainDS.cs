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

        public void ResetTextBoxes() {
            this.TextBoxTimeStamp.Text = "";
            this.TextBoxUserName.Text = "";
            this.TextBoxUserID.Text = "";
        }

        /*

        #region "Test Logins"
        /// <summary>
        /// Add a dummy login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnAddLogin_Click(System.Object sender, System.EventArgs e) {
            try {
                this.LblReturn.Text = "Login Num: " + Logins.AddLogin(System.DateTime.Now, "JUST ADDED", "LOGIN", true, "you hv successfully added a login", "123.456.789.101", SharedSettings.Settings.SystemUserID);

                this.DataGridView1.DataSource = Logins.GetLogins;
                this.DataGridView1.Visible = true;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Test.TestMainDS.btnAddLogin_Click() \n" + XMLConstants.DEBUG_ERROR);                
            }
        }

        private void btnAddLoginWithUserName_Click(System.Object sender, System.EventArgs e) {
            try {
                dynamic l = this.TextBoxUserName.Text.Trim();

                if (l == null || string.IsNullOrEmpty(l)) {
                    MessageBox.Show("Please enter a valid user name");
                }
                else {
                    this.LblReturn.Text = "Login Num: " + Logins.AddLogin(System.DateTime.Now, "JUST ADDED", "LOGIN", true, "you hv successfully added a login", "123.456.789.101", l);

                    this.DataGridView1.DataSource = Logins.GetLogins;
                    this.DataGridView1.Visible = true;
                }
                ResetTextBoxes();
                this.TextBoxUserName.Focus();
            }
            catch (Exception ex) {
               System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }
        }
        private void btnAddLoginWithStrUserId_Click(System.Object sender, System.EventArgs e) {
            try {
                dynamic l = this.TextBoxUserID.Text.Trim();

                if (l == null || string.IsNullOrEmpty(l)) {
                    MessageBox.Show("Please enter a valid user id");
                }
                else {
                    this.LblReturn.Text = "Login Num: " + Logins.AddLogin(System.DateTime.Now, "JUST ADDED", "LOGIN", true, "you hv successfully added a login", "123.456.789.101", l);

                    this.DataGridView1.DataSource = Logins.GetLogins;
                    this.DataGridView1.Visible = true;
                }

                ResetTextBoxes();
                this.TextBoxUserID.Focus();
            }
            catch (Exception ex) {
               System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }
        }
        /// <summary>
        /// Get record of all logins and display on gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnGetAllLogins_Click(System.Object sender, System.EventArgs e) {
            this.DataGridView1.DataSource = Logins.GetLogins;
            this.DataGridView1.Visible = true;
        }

        /// <summary>
        /// Get count of number of logins for particular user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>

        private void btnGetLoginsByUserName_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxUserName.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid user name");
            }
            else {
                this.DataGridView1.DataSource = Logins.GetLoginsByUserName_ALL(l);
                this.DataGridView1.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxUserName.Focus();
        }


        private void btnGetLoginByDate_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxTimeStamp.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid date");
            }
            else {
                l = Utils.GetDateFromString(l);
                this.DataGridView1.DataSource = Logins.GetLoginsByDate(l);
                this.DataGridView1.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxTimeStamp.Focus();
        }
        #endregion


        #region "Test Usage"
        /// <summary>
        /// Add a dummy page visit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnAddUsage_Click(System.Object sender, System.EventArgs e) {
            dynamic userID = SharedSettings.Settings.SystemUserID;
            this.LblReturn.Text = "Usage Num: " + Usage.AddUsage(System.DateTime.Now, userID, "JUST ADDED USAGE");
            this.DataGridView1.DataSource = Usage.GetUsage;
            this.DataGridView1.Visible = true;


        }


        private void btnAddUsageByUserName_Click(System.Object sender, System.EventArgs e) {
            try {
                dynamic l = Strings.Trim(this.TextBoxUserName.Text);

                if (l == null || string.IsNullOrEmpty(l)) {
                    MessageBox.Show("Please enter a valid user name");
                }
                else {
                    this.LblReturn.Text = "Usage Num: " + Usage.AddUsage(System.DateTime.Now, l, "JUST ADDED USAGE");
                    this.DataGridView1.DataSource = Usage.GetUsage;
                    this.DataGridView1.Visible = true;
                }
                ResetTextBoxes();
                this.TextBoxUserName.Focus();
            }
            catch (Exception ex) {
               System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }
        }
        /// <summary>
        /// Get record of all page usage and display on gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnTestGetAllUsage_Click(System.Object sender, System.EventArgs e) {
            this.DataGridView1.DataSource = Usage.GetUsage;
            this.DataGridView1.Visible = true;
        }

        private void BttonGetUsageByUserName_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxUserName.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid user name");
            }
            else {
                this.DataGridView1.DataSource = Usage.GetUsageByUserName(l);
                this.DataGridView1.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxUserName.Focus();
        }


        private void BttonGetUsageByDate_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxTimeStamp.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid date");
            }
            else {
                l = Utils.GetDateFromString(l);
                this.DataGridView1.DataSource = Usage.GetUsageByDate(l);
                this.DataGridView1.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxTimeStamp.Focus();
        }


        private void BttonGetUsageByUserNameAndDate_Click(System.Object sender, System.EventArgs e) {
            dynamic d = Utils.GetDateFromString(Strings.Trim(this.TextBoxTimeStamp.Text));
            dynamic l = Strings.Trim(this.TextBoxUserName.Text);

            if (l == null || string.IsNullOrEmpty(l) || d == null || !Information.IsDate(d)) {
                MessageBox.Show("Please enter a valid user name and date/timestamp ");
            }
            else {
                this.DataGridView1.DataSource = Usage.GetUsageByDateAndUserName(d, l);
                this.DataGridView1.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxTimeStamp.Focus();

        }


        #endregion

        #region "Test Exceptions"


        private void BttonGetExceptions_Click(System.Object sender, System.EventArgs e) {
            this.DataGridView1.DataSource = Exceptions.GetExceptions;
            this.DataGridView1.Visible = true;
        }


        private void BtonGetExByUserName_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxUserName.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid user name");
            }
            else {
                this.DataGridView1.DataSource = Exceptions.GetExceptionsByUserName(l);
                this.DataGridView1.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxUserName.Focus();
        }

        private void BtonGetExByDate_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxTimeStamp.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid date");
            }
            else {
                l = Utils.GetDateFromString(l);
                this.DataGridView1.DataSource = Exceptions.GetExceptionsByDate(l);
                this.DataGridView1.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxTimeStamp.Focus();
        }

        private void BtonAddException_Click(System.Object sender, System.EventArgs e) {
            try {
                dynamic id = SharedSettings.Settings.SystemUserID;
                System.Diagnostics.Debug.Print(id.ToString());
                this.LblReturn.Text = "Exception Num: " + Exceptions.AddException(DateTime.Now, "JUST ADDED", "EXCEPTION", "", "", "lajksdf", "lajksdf", "", id);
                this.DataGridView1.DataSource = Exceptions.GetExceptions;
                this.DataGridView1.Visible = true;
            }
            catch (Exception ex) {
               System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }
        }
        private void BttonAddExceptionByUserName_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxUserName.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid user name");
            }
            else {
                this.LblReturn.Text = "Exception Num: " + Exceptions.AddException(System.DateTime.Now, "JUST ADDED", "EXCEPTION", "", "", "lajksdf", "lajksdf", "", l);
                this.DataGridView1.DataSource = Exceptions.GetExceptions;
                this.DataGridView1.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxUserName.Focus();


        }
        #endregion


        #region "Test Users"

        private void BttonUserExists_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxUserName.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid user name");
            }
            else {
                this.LblReturn.Text = Users.UserExists(l);
                this.LblReturn.Visible = true;
            }

        }

        private void BttonGetUsers_Click(System.Object sender, System.EventArgs e) {
            this.DataGridView1.DataSource = Users.GetUsers;
            this.DataGridView1.Visible = true;
        }



        private void BttonGetUserIDByUserName_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxUserName.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid user name");
            }
            else {
                this.LblReturn.Text = Users.GetUserIDByUserName(l).ToString;
                this.LblReturn.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxUserName.Focus();
        }


        private void BttonGetUserNameByUserID_Click(System.Object sender, System.EventArgs e) {
            dynamic l = Strings.Trim(this.TextBoxUserID.Text);

            if (l == null || string.IsNullOrEmpty(l)) {
                MessageBox.Show("Please enter a valid user id");
            }
            else {
                this.LblReturn.Text = Users.GetUserNameByUserID(l).ToString;
                this.LblReturn.Visible = true;
            }

            ResetTextBoxes();
            this.TextBoxUserID.Focus();

        }

        #endregion
        */


        /*
        private void BttonLogExc2Database_Click(System.Object sender, System.EventArgs e) {
            dynamic user = "rachela";
            try {
                //do calc that will throw exception
                System.Diagnostics.Debug.Print(SharedSettings.Settings.ToString);
                this.DataGridView1.Hide();
                string x = "XXX";
                int y = 122;
                dynamic z = x + y;
                System.Diagnostics.Debug.Print("Z" + Constants.vbTab + z);
            }
            catch (Exception ex) {
                Utils.LogException(ex, user);
            }

        }

        #region "FeedBack"

        private void BtonGetFeedbacks_Click(System.Object sender, System.EventArgs e) {

            try {
                this.DataGridView1.DataSource = Feedbacks.GetFeedBacks;
                this.DataGridView1.Visible = true;

            }
            catch (Exception ex) {
               System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }
        }

        private void BtonGetFeedbacksByUserName_Click(System.Object sender, System.EventArgs e) {
            try {
                dynamic l = Strings.Trim(this.TextBoxUserName.Text);

                if (l == null || string.IsNullOrEmpty(l)) {
                    MessageBox.Show("Please enter a valid user name");
                    this.TextBoxUserName.Focus();

                }
                else {
                    this.DataGridView1.DataSource = Feedbacks.GetFeedBacksByUserName(l);
                    this.DataGridView1.Visible = true;

                }
                ResetTextBoxes();

            }
            catch (Exception ex) {
               System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }
        }

        private void BtonInsertFeedback_Click(System.Object sender, System.EventArgs e) {
            try {
                this.LblReturn.Text = "FeedBack Num: " + Feedbacks.AddFeedBack("demouser", 1, "demouser@pi-kets", "JUST ADDED", "FeedBack", "True", "you hv successfully added a FeedBack");
                System.Diagnostics.Debug.Print(this.LblReturn.Text);
                this.DataGridView1.DataSource = Feedbacks.GetFeedBacks;
                this.DataGridView1.Visible = true;
            }
            catch (Exception ex) {
               System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
            }
        }

        #endregion
        */



        #region "Company"


        private void BtonGetCompanies_Click(System.Object sender, System.EventArgs e) {
            this.DataGridView1.DataSource = Companies.GetAllCompanies();
            this.DataGridView1.Visible = true;
        }

        private void BtonInsertCompany_Click(System.Object sender, System.EventArgs e) {
            try {
                this.LblReturn.Text = "Companies Num: " + Companies.AddCompany("rachels group");

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
                        dynamic l = Strings.Trim(this.TextBoxUserName.Text);

                        if (l == null || string.IsNullOrEmpty(l)) {
                            MessageBox.Show("Please enter a valid COMPANY name");
                            this.TextBoxUserName.Focus();

                        }
                        else {
                            this.LblReturn.Text = Companies.GetCompanyIDByCompanyName(l);
                            this.DataGridView1.DataSource = Companies.GetCompanies;
                            this.DataGridView1.Visible = true;

                        }

                        ResetTextBoxes();

                    }
                    catch (Exception ex) {
                       System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
                    }

                }

            */
        #endregion





        private void GroupBox3_Enter(System.Object sender, System.EventArgs e) {
        }

        private void GroupBox2_Enter(System.Object sender, System.EventArgs e) {
        }

        private void GroupBox1_Enter(System.Object sender, System.EventArgs e) {
        }

        private void GroupBoxUsage_Enter(System.Object sender, System.EventArgs e) {
        }

        private void GroupBoxLogin_Enter(System.Object sender, System.EventArgs e) {
        }

        private void GroupBoxTestUsers_Enter(System.Object sender, System.EventArgs e) {
        }

        private void LabelUserName_Click(System.Object sender, System.EventArgs e) {
        }

        private void LabelUserID_Click(System.Object sender, System.EventArgs e) {
        }

        private void TextBoxUserName_TextChanged(System.Object sender, System.EventArgs e) {
        }

        private void TextBoxUserID_TextChanged(System.Object sender, System.EventArgs e) {
        }

        private void GroupBoxUser_Enter(System.Object sender, System.EventArgs e) {
        }

        private void LblReturn_Click(System.Object sender, System.EventArgs e) {
        }

        private void Label5_Click(System.Object sender, System.EventArgs e) {
        }

        private void TextBoxStartDate_TextChanged(System.Object sender, System.EventArgs e) {
        }

        private void Label6_Click(System.Object sender, System.EventArgs e) {
        }

        private void TextBoxEndDate_TextChanged(System.Object sender, System.EventArgs e) {
        }

        private void groupBoxTimeStamp_Enter(System.Object sender, System.EventArgs e) {
        }

        private void TextBoxTimeStamp_TextChanged(System.Object sender, System.EventArgs e) {
        }

        private void Label1_Click(System.Object sender, System.EventArgs e) {
        }

        private void ProgressBar1_Click(System.Object sender, System.EventArgs e) {
        }

        private void DataGridView1_CellContentClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e) {
        }
        public void Main() {
            Load += TestMainDS_Load;
        }

        private void btnStartup_Click(object sender, EventArgs e) {
            StartUp Check = new StartUp();
            Check.Show();
            Hide();
        }
    }
}



