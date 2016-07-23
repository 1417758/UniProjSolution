using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobUniBLL {

    public enum DayStatusEnum : byte {
        //NB: this numeration is used on Stored Procedures and Functions (ie: GetAllPersonInherit...) 
        // a change on these will require those to be revised 
        AVAILABLE = 0, //false
        BUSY = 1  //true      
    }

    public class DaySchedule {

        //class variables
        public SerializableDictionary<int, string> daySchedule { get; set; }

        //AgendaEnum as string
        public static string GetDayStatusEnumString(DayStatusEnum status) {
            return Enum.GetName(typeof(DayStatusEnum), status);
        }

        #region "Constructors"
        //default constructor
        public DaySchedule() {
             daySchedule = GetNewDaySchedule();
          //  daySchedule = GetTestDaySchedule();
            // daySchedule = new SerializableDictionary<int, string>();
        }
        public DaySchedule(bool isTest = false) {
            daySchedule = GetNewDaySchedule();
            if (isTest)
                daySchedule = GetTestDaySchedule();
            // daySchedule = new SerializableDictionary<int, string>();
        }
        #endregion

        #region "Methods"
        public void CheckWholeDaySchedule(SerializableDictionary<int, string> calendar) {
            // Use var keyword to enumerate dictionary.           
            foreach (var pair in calendar) {
                System.Diagnostics.Debug.Print("Key: {0},\t Value: {1}", pair.Key, pair.Value);
            }
        }

        #endregion

        #region "Functions"
        public static bool AddBooking(ref SerializableDictionary<int, string> daySchedule, int time2Add) {
            try {
                //add to calendar.
                // calendar.Add(time2Add, GetAgendaEnumString(AgendaStatusEnum.BUSY));
                //NB--19/7 wot if time2Add doesnt exist? should calendar.Add() then???? TEST  
                // ------ assume time already exists ------------
                //set unavailable to  calendar
                daySchedule[time2Add] = GetDayStatusEnumString(DayStatusEnum.BUSY);
                return true;
            }
           catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);return false;
            }

        }

         /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public SerializableDictionary<int, string> GetNewDaySchedule(int startTime = 8, int endtime = 5) {
            SerializableDictionary<int, string> calendar = new SerializableDictionary<int, string>();
            int fullHr, halfHr;
            string fullHr_string, halfHr_string;
            //sort parameters
            if (endtime < startTime)
                endtime += 12;

            //loop through start and end time
            for (int i = startTime; i < endtime; i++) {
                //make up time :)
                fullHr_string = i.ToString() + "00";
                halfHr_string = i.ToString() + "30";

                fullHr = (int)WebJobUniUtils.Utils.GetNumberInt(fullHr_string);
                halfHr = (int)WebJobUniUtils.Utils.GetNumberInt(halfHr_string);
                System.Diagnostics.Debug.Print("Full Hour: {0},\t Half Hour: {1}", fullHr, halfHr);

                //add times to calendar
                calendar.Add(fullHr, GetDayStatusEnumString(DayStatusEnum.AVAILABLE));
                calendar.Add(halfHr, GetDayStatusEnumString(DayStatusEnum.AVAILABLE));
            }//end for loop

            return calendar;
        }

        public SerializableDictionary<int, string> GetTestDaySchedule() {
            SerializableDictionary<int, string> calendar = GetNewDaySchedule();
            //set list of busy times
            List<int> busyTimes = new List<int> { 830, 900, 1100, 1130, 1230, 1400, 1430, 1530, 1600 };
            string tempAvailability;
            //check with print debug
            CheckWholeDaySchedule(calendar);

            //loop through list
            foreach (int time in busyTimes) {
                //check staff has that time on his/hers agenda
                if (calendar.ContainsKey(time)) {
                    //check whether time is busy or available
                    tempAvailability = calendar[time];
                    //set unavailable on calendar
                    calendar[time] = GetDayStatusEnumString(DayStatusEnum.BUSY);
                }

            }//end for loop

            return calendar;
        }

        public static bool? IsStaffBusy(SerializableDictionary<int, string> daySchedule, int time2Check) {
            try {
                //source http://www.dotnetperls.com/dictionary
                //ie: d.Remove("cat"); // Removes cat.

                string testResult;
                //TryGetValue implies, it tests for the key. It then returns the value if it finds the key.
                if (daySchedule.TryGetValue(time2Check, out testResult)) // Returns true or false.
                {
                    //print current status
                    System.Diagnostics.Debug.Print("Current Day Schedule Status at " + time2Check.ToString() + " is: " + testResult);
                    //check status is busy
                    if (testResult == GetDayStatusEnumString(DayStatusEnum.BUSY))
                        return true;
                    else
                        //status is available
                        return false;
                }

                //time paramater doesnt exist on dictionary
                //R   throw new Exception("Given time paramater doesnt exist on dictionary!");
                return false;
            }
           catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);return null;
            }

        }
        #endregion



    }//class
}//namespace
