using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebJobUniTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        #region "Test Logins"
        /*  /// <summary>
      /// Add a dummy login.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      /// <remarks></remarks>
      private void btnAddLogin_Click(System.Object sender, System.EventArgs e) {
          try {
              this.LblReturn.Text = "Login Num: " + Logins.AddLogin(System.DateTime.Now, "JUST ADDED", "LOGIN", true, "you hv successfully added a login", "123.456.789.101", SharedSettings.Settings.SystemUserID);

              this.DataGridView1.DataSource = Logins.GetLogins;
      
          }
          catch (Exception ex) {
              System.Diagnostics.Debug.Print("Test.TestMainDS.btnAddLogin_Click() \n" + XMLConstants.DEBUG_ERROR);                
          }
      }

      private void btnAddLoginWithUserName_Click(System.Object sender, System.EventArgs e) {
          try {
              dynamic l = this.textBoxUserName.Text.Trim();

              if (l == null || string.IsNullOrEmpty(l)) {
                  MessageBox.Show("Please enter a valid user name");
              }
              else {
                  this.LblReturn.Text = "Login Num: " + Logins.AddLogin(System.DateTime.Now, "JUST ADDED", "LOGIN", true, "you hv successfully added a login", "123.456.789.101", l);

                  this.DataGridView1.DataSource = Logins.GetLogins;
          
              }
              ResetTextBoxes();
              this.textBoxUserName.Focus();
          }
          catch (Exception ex) {
             System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
          }
      }
      private void btnAddLoginWithStrUserId_Click(System.Object sender, System.EventArgs e) {
          try {
              dynamic l = this.textBoxUserID.Text.Trim();

              if (l == null || string.IsNullOrEmpty(l)) {
                  MessageBox.Show("Please enter a valid user id");
              }
              else {
                  this.LblReturn.Text = "Login Num: " + Logins.AddLogin(System.DateTime.Now, "JUST ADDED", "LOGIN", true, "you hv successfully added a login", "123.456.789.101", l);

                  this.DataGridView1.DataSource = Logins.GetLogins;
          
              }

              ResetTextBoxes();
              this.textBoxUserID.Focus();
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
  
      }

      /// <summary>
      /// Get count of number of logins for particular user.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      /// <remarks></remarks>

      private void btnGetLoginsByUserName_Click(System.Object sender, System.EventArgs e) {
          dynamic l = Strings.Trim(this.textBoxUserName.Text);

          if (l == null || string.IsNullOrEmpty(l)) {
              MessageBox.Show("Please enter a valid user name");
          }
          else {
              this.DataGridView1.DataSource = Logins.GetLoginsByUserName_ALL(l);
      
          }

          ResetTextBoxes();
          this.textBoxUserName.Focus();
      }


      private void btnGetLoginByDate_Click(System.Object sender, System.EventArgs e) {
          dynamic l = Strings.Trim(this.textBoxTimeStamp.Text);

          if (l == null || string.IsNullOrEmpty(l)) {
              MessageBox.Show("Please enter a valid date");
          }
          else {
              l = Utils.GetDateFromString(l);
              this.DataGridView1.DataSource = Logins.GetLoginsByDate(l);
      
          }

          ResetTextBoxes();
          this.textBoxTimeStamp.Focus();
      }*/
        #endregion

        #region "Test Usage"
        /*  /// <summary>
          /// Add a dummy page visit.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          /// <remarks></remarks>
          private void btnAddUsage_Click(System.Object sender, System.EventArgs e) {
              dynamic userID = SharedSettings.Settings.SystemUserID;
              this.LblReturn.Text = "Usage Num: " + Usage.AddUsage(System.DateTime.Now, userID, "JUST ADDED USAGE");
              this.DataGridView1.DataSource = Usage.GetUsage;
      


          }


          private void btnAddUsageByUserName_Click(System.Object sender, System.EventArgs e) {
              try {
                  dynamic l = Strings.Trim(this.textBoxUserName.Text);

                  if (l == null || string.IsNullOrEmpty(l)) {
                      MessageBox.Show("Please enter a valid user name");
                  }
                  else {
                      this.LblReturn.Text = "Usage Num: " + Usage.AddUsage(System.DateTime.Now, l, "JUST ADDED USAGE");
                      this.DataGridView1.DataSource = Usage.GetUsage;
              
                  }
                  ResetTextBoxes();
                  this.textBoxUserName.Focus();
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
      
          }

          private void bttonGetUsageByUserName_Click(System.Object sender, System.EventArgs e) {
              dynamic l = Strings.Trim(this.textBoxUserName.Text);

              if (l == null || string.IsNullOrEmpty(l)) {
                  MessageBox.Show("Please enter a valid user name");
              }
              else {
                  this.DataGridView1.DataSource = Usage.GetUsageByUserName(l);
          
              }

              ResetTextBoxes();
              this.textBoxUserName.Focus();
          }


          private void bttonGetUsageByDate_Click(System.Object sender, System.EventArgs e) {
              dynamic l = Strings.Trim(this.textBoxTimeStamp.Text);

              if (l == null || string.IsNullOrEmpty(l)) {
                  MessageBox.Show("Please enter a valid date");
              }
              else {
                  l = Utils.GetDateFromString(l);
                  this.DataGridView1.DataSource = Usage.GetUsageByDate(l);
          
              }

              ResetTextBoxes();
              this.textBoxTimeStamp.Focus();
          }


          private void bttonGetUsageByUserNameAndDate_Click(System.Object sender, System.EventArgs e) {
              dynamic d = Utils.GetDateFromString(Strings.Trim(this.textBoxTimeStamp.Text));
              dynamic l = Strings.Trim(this.textBoxUserName.Text);

              if (l == null || string.IsNullOrEmpty(l) || d == null || !Information.IsDate(d)) {
                  MessageBox.Show("Please enter a valid user name and date/timestamp ");
              }
              else {
                  this.DataGridView1.DataSource = Usage.GetUsageByDateAndUserName(d, l);
          
              }

              ResetTextBoxes();
              this.textBoxTimeStamp.Focus();

          }

  */
        #endregion

        #region "Test Exceptions"
        /* private void bttonLogExc2Database_Click(System.Object sender, System.EventArgs e) {
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

                private void bttonGetExceptions_Click(System.Object sender, System.EventArgs e) {
                    this.DataGridView1.DataSource = Exceptions.GetExceptions;
            
                }


                private void BtonGetExByUserName_Click(System.Object sender, System.EventArgs e) {
                    dynamic l = Strings.Trim(this.textBoxUserName.Text);

                    if (l == null || string.IsNullOrEmpty(l)) {
                        MessageBox.Show("Please enter a valid user name");
                    }
                    else {
                        this.DataGridView1.DataSource = Exceptions.GetExceptionsByUserName(l);
                
                    }

                    ResetTextBoxes();
                    this.textBoxUserName.Focus();
                }

                private void BtonGetExByDate_Click(System.Object sender, System.EventArgs e) {
                    dynamic l = Strings.Trim(this.textBoxTimeStamp.Text);

                    if (l == null || string.IsNullOrEmpty(l)) {
                        MessageBox.Show("Please enter a valid date");
                    }
                    else {
                        l = Utils.GetDateFromString(l);
                        this.DataGridView1.DataSource = Exceptions.GetExceptionsByDate(l);
                
                    }

                    ResetTextBoxes();
                    this.textBoxTimeStamp.Focus();
                }

                private void BtonAddException_Click(System.Object sender, System.EventArgs e) {
                    try {
                        dynamic id = SharedSettings.Settings.SystemUserID;
                        System.Diagnostics.Debug.Print(id.ToString());
                        this.LblReturn.Text = "Exception Num: " + Exceptions.AddException(DateTime.Now, "JUST ADDED", "EXCEPTION", "", "", "lajksdf", "lajksdf", "", id);
                        this.DataGridView1.DataSource = Exceptions.GetExceptions;
                
                    }
                    catch (Exception ex) {
                       System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
                    }
                }
                private void bttonAddExceptionByUserName_Click(System.Object sender, System.EventArgs e) {
                    dynamic l = Strings.Trim(this.textBoxUserName.Text);

                    if (l == null || string.IsNullOrEmpty(l)) {
                        MessageBox.Show("Please enter a valid user name");
                    }
                    else {
                        this.LblReturn.Text = "Exception Num: " + Exceptions.AddException(System.DateTime.Now, "JUST ADDED", "EXCEPTION", "", "", "lajksdf", "lajksdf", "", l);
                        this.DataGridView1.DataSource = Exceptions.GetExceptions;
                
                    }

                    ResetTextBoxes();
                    this.textBoxUserName.Focus();


                }*/
        #endregion

        #region "FeedBack"
        /*
              private void BtonGetFeedbacks_Click(System.Object sender, System.EventArgs e) {

                  try {
                      this.DataGridView1.DataSource = Feedbacks.GetFeedBacks;
              

                  }
                  catch (Exception ex) {
                     System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
                  }
              }

              private void BtonGetFeedbacksByUserName_Click(System.Object sender, System.EventArgs e) {
                  try {
                      dynamic l = Strings.Trim(this.textBoxUserName.Text);

                      if (l == null || string.IsNullOrEmpty(l)) {
                          MessageBox.Show("Please enter a valid user name");
                          this.textBoxUserName.Focus();

                      }
                      else {
                          this.DataGridView1.DataSource = Feedbacks.GetFeedBacksByUserName(l);
                  

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
              
                  }
                  catch (Exception ex) {
                     System.Diagnostics.Debug.Print("Test.TestMainDS._Click() \n" + XMLConstants.DEBUG_ERROR);
                  }
              }
         */
        #endregion



    }
}
