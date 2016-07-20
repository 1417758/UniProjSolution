using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class AgendaBLL : Agenda {
        public int? ID { get; set; }
        public bool isAdmin { get; set; }
        public bool syncCalendar { get; set; }

        // private Calendar myCalendar { get; set; }

        //DateTime here represents CalendarDay
        public SerializableDictionary<DateTime, DaySchedule> staffCalendar { get; set; }


        #region "Constructor"
        public AgendaBLL() {
            //source: https://msdn.microsoft.com/en-us/library/system.globalization.calendar(v=vs.110).aspx
            // Uses the default calendar of the InvariantCulture.
            // this.myCalendar = CultureInfo.InvariantCulture.Calendar;
            this.staffCalendar = new SerializableDictionary<DateTime, DaySchedule>();
        }

        #endregion

        #region "Functions"
        public static DaySchedule GetDaySchedule(ref SerializableDictionary<DateTime, DaySchedule> staffCalendar, DateTime date2Add) {
            try {

                //clean dateTime parameter to only show date
                DateTime cleanDate = date2Add.Date;
                DaySchedule resultDaySchedule = null;

                //TryGet daySchedule for giving date
                if (staffCalendar.TryGetValue(cleanDate, out resultDaySchedule))
                    //add daySchedule to local variable
                    //  SerializableDictionary<int, string> staffDaySchedule = resultDaySchedule.daySchedule;
                    //add to daySchedule and return
                    return resultDaySchedule;

                //this will be null if not found
                return resultDaySchedule;

            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>BLL.AgendaBLL.GetDaySchedule(x2)</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                return null;
            }

        }//end AddBooking


        public static bool AddBooking(ref SerializableDictionary<DateTime, DaySchedule> staffCalendar, DateTime date2Add, int time2Add) {
            try {
                bool bookingAdded = false;
                bool isStaffBusy = false;
                //clean dateTime parameter to only show date
                DateTime cleanDate = date2Add.Date;
                DaySchedule newDaySchedule = new DaySchedule();//(isTest: true);
                DaySchedule resultDaySchedule = null;

                //check staff isnt already busy at the given date and time
                //NB IsStaffBusy could be null then an cast error is going to occur here 19/7/16, must test
                isStaffBusy = (bool)IsStaffBusy(ref staffCalendar, cleanDate, time2Add);

                //check whether a dailySchedule exists for the given date
                if (!staffCalendar.TryGetValue(cleanDate, out resultDaySchedule))
                    //create one if is doesnt exist
                    staffCalendar[cleanDate] = newDaySchedule;


                if (!isStaffBusy) {
                    //TryGet daySchedule for giving date
                    if (staffCalendar.TryGetValue(cleanDate, out resultDaySchedule)) {
                        //add daySchedule to local variable
                        SerializableDictionary<int, string> staffDaySchedule = resultDaySchedule.daySchedule;
                        //add to daySchedule and return
                        return DaySchedule.AddBooking(ref staffDaySchedule, time2Add);
                    }
                }

                //shouldnt get here
                return bookingAdded;
            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>BLL.AgendaBLL.AddBooking(x3)</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                return false;
            }

        }//end AddBooking


        public static bool? IsStaffBusy(ref SerializableDictionary<DateTime, DaySchedule> staffCalendar, DateTime date2Check, int time2Check) {
            try {
                //source http://www.dotnetperls.com/dictionary
                //ie: d.Remove("cat"); // Removes cat.
                DaySchedule resultDaySchedule = null;
                DaySchedule newDaySchedule = new DaySchedule();//(isTest: true);
                //clean dateTime parameter to only show date
                DateTime cleanDate = date2Check.Date;

                //try to find if staffCalendar has this date set on it.
                if (staffCalendar.TryGetValue(cleanDate, out resultDaySchedule)) // Returns true or false.
                {
                    //if true fills in newDaySchedule with corresponding value of given key

                    //print current date to check
                    System.Diagnostics.Debug.Print("Current Day being checked is: " + cleanDate.ToString());
                    //check day schedule status 

                    return DaySchedule.IsStaffBusy(newDaySchedule.daySchedule, time2Check);
                }

                //current day doesnt exist on staff calendar so add it a new day shedule for the given date              
                //R   staffCalendar[cleanDate] = newDaySchedule;
                return false;
            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>BLL.AgendaBLL.IsStaffBusy(x3)</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                return null;
            }
        }//end IsStaffBusy
        #endregion





    }//class
}//namespace
