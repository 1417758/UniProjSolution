using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {

    public enum AgendaStatusEnum : byte {
        //NB: this numeration is used on Stored Procedures and Functions (ie: GetAllPersonInherit...) 
        // a change on these will require those to be revised 
        AVAILABLE = 0, //false
        BUSY = 1  //true      
    }

     public class AgendaBLL :Agenda{
        public int? ID { get; set; }
        public bool isAdmin { get; set; }
        public bool syncCalendar { get; set; }

        public SerializableDictionary<int, string> calendar { get; set; }

        #region "Constructor"
        public AgendaBLL() {
            calendar = GetNewCalendar();
        }

        #endregion

        #region "Methods"
        public void CheckWholeCalendar(SerializableDictionary<int, string> calendar) {
            // Use var keyword to enumerate dictionary.
            foreach (var pair in calendar) {
                System.Diagnostics.Debug.Print("AVAILABLE = false, \t BUSY = true");   
                System.Diagnostics.Debug.Print("Key: {0},\t Value: {1}", pair.Key, pair.Value);
            }
        }
        public void AddBooking(SerializableDictionary<int, string> calendar, int time2Add) {
            //NB: round parameter up and/or down if not full or half hour
            //add here 16/7/16

            //add to calendar.
            calendar.Add(time2Add, Enum.GetName(typeof(AgendaStatusEnum), AgendaStatusEnum.BUSY));
        }
        #endregion

        #region "Functions"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public SerializableDictionary<int, string> GetNewCalendar(int startTime=8, int endtime=5) {
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
                calendar.Add(fullHr, Enum.GetName(typeof(AgendaStatusEnum), AgendaStatusEnum.AVAILABLE));
                calendar.Add(halfHr, Enum.GetName(typeof(AgendaStatusEnum), AgendaStatusEnum.AVAILABLE));
            }//end for loop

            return calendar;
        }

        public bool IsStaffBusy(SerializableDictionary<int, string> calendar, int time2Check) {
            //source http://www.dotnetperls.com/dictionary

            //NB: round parameter up and/or down if not full or half hour
            //add here 16/7/16

            // bool testResult;
            string testResult;
            //TryGetValue implies, it tests for the key. It then returns the value if it finds the key.
            if (calendar.TryGetValue(time2Check, out testResult)) // Returns true or false.
            {
                System.Diagnostics.Debug.Print(testResult.ToString()); 
            }
            
            //check result
           // if test


            return calendar.TryGetValue(time2Check, out testResult);
        }
        #endregion

    }//class
}//namespace
