using AjaxControlToolkit;
using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniBLL;
using WebJobUniUtils;

public partial class UI_EndUser_BookAppt : System.Web.UI.Page {

    #region "Event Handlers"
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            PopulateUserControlsFromSession();

        //invoke sub-usercontrol event_click
        this.DateSelectionUserControl.CalendarSelectionChanged += new EventHandler(DateSelectionUserControl_CalendarSelectionChanged);

    }

    protected void DateSelectionUserControl_CalendarSelectionChanged(object sender, EventArgs e) {
        try {
            System.Diagnostics.Debug.Print("calendar selection change new eventHandlers IS working");

            Installation i = WebUtils.GetInstallationObjectFromSession();
            EmployeeBLL selStaff = null;
            //get staff selected
            int staffSel_index = this.StaffSelectionUserControl.GetSelectedServiceIndex();//staff can be null
            //NB index 0 = "No Preference"
            if (staffSel_index > 0)
                selStaff = i.Employees[staffSel_index - 1];
            else
                //ALWAYS pick 1st staff by default
                selStaff = i.Employees[0];//staff can be null


            //updated usercontrol with new date
            DateTime userNewSelDate = this.DateSelectionUserControl.GetSelectedDate();
            PopulateDateAndTimeUserControl(selStaff, userNewSelDate);
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, DateSelectionUserControl_CalendarSelectionChanged()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, DateSelectionUserControl_CalendarSelectionChanged()");
            ExceptionUtility.NotifySystemOps(ex);
        }//e
    }
    /// <summary>
    /// NEXT button click btween book appt steps
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button_Click(object sender, EventArgs e) {
        try {
            bool isComplete = false;
            //cast so can get tellesense
            Button selectedBt = (Button)sender;
            string btID = selectedBt.ID;
            //ie: buttonID = ButtonUserInfo
            int idNumb = (int)Utils.GetNumberInt(btID.Substring(6, 1));
            //get panel
            //R AccordionPane curPanel = (AccordionPane)Master.FindControl("MainContent").FindControl("AccordionPane" + idNumb);
            //get ajax accordion panel
            Accordion accordion1 = (Accordion)this.Master.FindControl("MainContent").FindControl("Accordion1");

            //check validation
            int userSevSelected = -1;
            bool isUserDetVal = false, isValid = false;
            string userSel1, userSel2;
            switch (idNumb) {
                case 1://services
                    //check service is selected
                    userSevSelected = this.ServiceSelectionUserControl.GetSelectedServiceIndex();
                    if (userSevSelected >= 0)
                        isValid = true;
                    break;
                case 2://staff
                    userSel1 = this.StaffSelectionUserControl.GetStaffelected();
                    if (!String.IsNullOrEmpty(userSel1))
                        isValid = true;
                    break;
                case 3://date & time
                    userSel1 = this.DateSelectionUserControl.GetSelectedDateStrg();
                    userSel2 = this.DateSelectionUserControl.GetSelectedTimeStrg();
                    if (!String.IsNullOrEmpty(userSel1) && !String.IsNullOrEmpty(userSel2))
                        isValid = true;
                    break;
                case 4://user info
                    isUserDetVal = this.UserInfoUserControl.IsValidFields();
                    if (isUserDetVal)
                        isValid = true;
                    break;
                case 5://payment
                    //add payment validation
                    isValid = true;
                    break;
                case 6://confirmation
                    //add confirmation validation
                    isValid = true;
                    break;
            }

            //if current usercontrol validation passes (is valid)
            if (isValid) {
                //move on to next accordion step
                accordion1.SelectedIndex = idNumb;
                //save to session
                goto save2InstSess;
            }
            else {
                //remain on same usercontrol till validation is corrected
                accordion1.SelectedIndex = idNumb - 1;
                goto Outer;
            }
            save2InstSess://goto1
            //save to session accordingly, 
            switch (idNumb) {
                case 1://services                 
                    UpdateInstallationObject(isService: true);
                    break;
                case 2://staff AND popupate staff agenda to date&time
                    UpdateInstallationObject(isStaff: true);
                    break;
                case 3://date & time
                    UpdateInstallationObject(isDateAndTime: true);
                    break;
                case 4://user info
                    UpdateInstallationObject(isUserInfo: true);
                    break;
                case 5://payment
                    UpdateInstallationObject(isPayment: true);
                    //show confirmation msg and exit button
                    this.confirmationTag.Visible = true;
                    this.button6.Visible = true;
                    break;
                case 6://confirmation
                    UpdateInstallationObject(isConfirmation: true);
                    isComplete = true;
                    break;
            }//end switch2

            Outer://goto2
            System.Diagnostics.Debug.Print("BookAppt.aspx Button_Click() \t Do Nothing and exit");

            //once finished rediret
            if (isComplete) {
                //redirect to home page
                Response.Redirect("WelcomeUser", false);        //write redirect
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, Button_Click()</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, Button_Click()");
            ExceptionUtility.NotifySystemOps(ex);
        }//end catch
    }//end Button_Click
    #endregion

    #region "Methods"
    public void PopulateUserControlsFromSession() {
        try {
            //Get installation from session             
            Installation i = WebUtils.GetInstallationObjectFromSession();

            //services
            List<string> servNames = InstallationBLL.GetServiceDetailsFull(i);
            this.ServiceSelectionUserControl.PopulateServices(servNames);

            //Staff
            List<string> staffNames = InstallationBLL.GetStaff1stNameWithTitle(i);
            this.StaffSelectionUserControl.PopulateStaff(staffNames);

            //date&time
            DateTime todaysDate = this.DateSelectionUserControl.GetSelectedDate();
            System.Diagnostics.Debug.Print("CALENDAR TIME: " + todaysDate.TimeOfDay.ToString() + "ON todays date: " + todaysDate.ToString());
            //ALWAYS pick 1st staff by default
            EmployeeBLL selStaff = i.Employees[0];//staff can be null
            PopulateDateAndTimeUserControl(selStaff, todaysDate);

            //End-user Details 
            //DO nothing start with empty fields

            //Payment

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, PopulateUserControlsFromSession Method</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, PopulateUserControlsFromSession Method");
            ExceptionUtility.NotifySystemOps(ex);
        }//end catch
    }//end void


    private void UpdateInstallationObject(bool isService = false, bool isStaff = false, bool isDateAndTime = false, bool isUserInfo = false, bool isPayment = false, bool isConfirmation = false) {
        try {

            //get installation and current appt from session 
            Installation i = WebUtils.GetInstallationObjectFromSession();
            ApptBLL currAppt = SessionVariables.CURRENT_APPOINTMENT;
            if (currAppt == null)
                currAppt = new ApptBLL();

            //R SaveInstallationToDB (test installation isnt save to DB)

            //get selected service details
            if (isService) {//1
                int servSel = this.ServiceSelectionUserControl.GetSelectedServiceIndex();
                int? servID = i.Services[servSel].ID;
                currAppt.serviceID = (int)servID;
            }

            //get selected employee details
            if (isStaff) {//2               
                int staffSel_index = this.StaffSelectionUserControl.GetSelectedServiceIndex();
                string staffSel_1stnameWithTitle = this.StaffSelectionUserControl.GetStaffelected();
                EmployeeBLL selStaff = null;
                //NB index 0 = "No Preference"
                if (staffSel_index > 0) {
                    selStaff = i.Employees[staffSel_index - 1];
                    currAppt.provider = staffSel_1stnameWithTitle;
                    //update date&time control == staff calendar
                    PopulateDateAndTimeUserControl(selStaff, this.DateSelectionUserControl.GetSelectedDate());
                }
                else {
                    //ALWAYS pick 1st staff by default
                    selStaff = i.Employees[0];//staff can be null
                    currAppt.provider = selStaff.title + " " + selStaff.firstName;
                }
                //update LabelServProvider
                //-- IMPORTANT LABEL USED ON UPDATE_INSTALLATION()
                this.LabelServProvider.Text = selStaff.firstName;
                //R PopulateDateAndTimeUserControl(selStaff, )

            }//endif isStaff

            //get selected Date&Time details
            if (isDateAndTime) {//3
                // get user entries from userControl
                string userSelDate = this.DateSelectionUserControl.GetSelectedDateStrg();
                string userSelTime = this.DateSelectionUserControl.GetSelectedTimeStrg();
                //convert entries into correct datat type
                DateTime userDate = (DateTime)Utils.GetDateFromString(userSelDate);
                TimeSpan userTime = (TimeSpan)Utils.GetTimeFromString(userSelTime);

                //assign entries to current appt in the session
                currAppt.date = userDate;
                currAppt.time = userTime;
                System.Diagnostics.Debug.Print(currAppt.provider);
            }

            //get entered userInformation details
            if (isUserInfo) {
                //get user entries from user control
                List<string> userPersoDet = this.UserInfoUserControl.GetPersonalDetails();

                //NB added programmatically END-USER username is their email address.
                //add ASP.NETUSER, If it already exists return aspnetID
                Guid endUserASPUserID = WebUtils.AddEndUserASPNETUser(userPersoDet[2], userPersoDet[1], userPersoDet[3]);
                //check user exists of DB/session 20/716 revise?
                int userIndex = i.EndUsers.FindIndex(endUser => endUser.aspnetUserID.ToString().Equals(endUserASPUserID.ToString(), StringComparison.Ordinal));
                //create new
                if (userIndex < 0) {
                    //create new end-user contact Details
                    ContactDetailsBLL newEndUserContact = new ContactDetailsBLL(userPersoDet[5], userPersoDet[6], userPersoDet[7], "UK", null, userPersoDet[4], userPersoDet[3]);
                    //create new end-user
                    EndUserBLL newEndUser = new EndUserBLL(userPersoDet[0], userPersoDet[1], userPersoDet[2], newEndUserContact, endUserASPUserID);
                    //add to installation
                    i.EndUsers.Add(newEndUser);
                }
                //add notes to current appt (userID is added on SaveInstallationToDB2)
                currAppt.notes = userPersoDet[8];
            }

            if (isPayment) {
                //

            }

            if (isConfirmation) {
                //----- Add appt to installation on session ------                
                i.Appointments.Add(currAppt);
                string curSelStaff1stName = this.LabelServProvider.Text;

                //----- process data and save to database ------
                InstallationBLL.SaveInstallationToDB2(ref i, ref currAppt, curSelStaff1stName, SessionVariables.TempStaffFolder, SessionVariables.ISummaryXML);
            }

            //save current appt back to session installation and current appt from session 
            SessionVariables.CURRENT_APPOINTMENT = currAppt;

            //add installation back to session
            WebUtils.PutInstallationObjectinSession(i);



        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, UpdateInstallationObject(x6)</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, UpdateInstallationObject(x6)");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }//end UpdateInstallationObject(x6)


    public void PopulateDateAndTimeUserControl(EmployeeBLL employee, DateTime selectedDate) {
        try {
            //get staff agenda
            SerializableDictionary<DateTime, DaySchedule> staffCalendar = employee.agenda.staffCalendar;

            //CHECK STAFF BUSY DAYS 
            // Use var keyword to enumerate dictionary. The same as: foreach (KeyValuePair<string, int> pair in calendar)
            //R    bool? isEmployeeBusy = AgendaBLL.IsStaffBusy(ref staffCalendar, selectedDate, selectedTime);//time is irrelevant here as this method is called to create this date on staff's calendar

            DaySchedule employeeDaySchedule = AgendaBLL.GetDaySchedule(ref staffCalendar, selectedDate);

            if (employeeDaySchedule != null) {
                //loop through day's time. ie: each hr and 1/h of the staff agenda
                foreach (var pair in employeeDaySchedule.daySchedule) {
                    int tempTime;
                    string tempTimeStatus;
                    tempTime = pair.Key;
                    tempTimeStatus = pair.Value;
                    System.Diagnostics.Debug.Print("Key: {0},  Value: {1}", tempTime, tempTimeStatus);
                    //check if staff is busy 
                    if (pair.Value == DaySchedule.GetDayStatusEnumString(DayStatusEnum.BUSY))
                        //set these on date&time usercontrol  
                        this.DateSelectionUserControl.DisableShowTimeCell(tempTime);
                }//endforloop
            }//endif
            else
                //staff daySchedule is empty so enable all buttons
                this.DateSelectionUserControl.EnableAllShowTimeCells();

            //update LabelServProvider
            this.LabelServProvider.Text = employee.firstName; //employee.title + " " + employee.firstName; 

        }//endtry
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, PopulateDateAndTimeUserControl(x6)</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, PopulateDateAndTimeUserControl(x6)");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }


    /// <summary>
    ///NB 20/7/16 ATM one employees agenda will overwrite the other instead of adding details to userControl 
    /// </summary>
    /// <param name="employees"></param>
    /// <param name="selectedDate"></param>
    /*  public void PopulateDateAndTimeUserControl(List<EmployeeBLL> employees, DateTime selectedDate) {
          //loop through each hr and 1/h of the staff agenda
          foreach (EmployeeBLL employee in employees) {
              //upate user control for this particular employee
              PopulateDateAndTimeUserControl(employee, selectedDate);
          }
      }*/
    #endregion

    #region "Functions"

    /*public EmployeeBLL GetNextAvailableStaff(List<EmployeeBLL> employees, DateTime date, int time) {
      try {
          bool isEmployeeBusy = true;
          //loop through each hr and 1/h of the staff agenda
          foreach (EmployeeBLL employee in employees) {
              //get staff agenda
              SerializableDictionary<DateTime, DaySchedule> staffCalendar = employee.agenda.staffCalendar;
              //upate user control for this particular employee
              PopulateDateAndTimeUserControl(employee);
              //CHECK STAFF BUSY DAYS 
              // Use var keyword to enumerate dictionary. The same as: foreach (KeyValuePair<string, int> pair in calendar)
              isEmployeeBusy = (bool)AgendaBLL.IsStaffBusy(ref staffCalendar, date, time);//time is irrelevant here as this method is called to create this date on staff's calendar
              if (!isEmployeeBusy)
                  return employee;
          }//enf forloop
          return null;
      }
      catch (Exception ex) {
          System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, GetNextAvailableStaff1stName(x3)</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
          // Log the exception and notify system operators
          ExceptionUtility.LogException(ex, "BookAppt.aspx, GetNextAvailableStaff1stName(x3)");
          ExceptionUtility.NotifySystemOps(ex);
          return null;
      }
  }*/
    #endregion



}//class