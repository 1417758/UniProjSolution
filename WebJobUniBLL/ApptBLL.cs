using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class ApptBLL : Appointment {
        public int? ID { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public int endUserID { get; set; }
        public int serviceID { get; set; }
        public string provider { get; set; } //staff1stName
        public string notes { get; set; } 

        #region "Constructors"
        public ApptBLL() { }

        public ApptBLL(DateTime _date, TimeSpan _time, int _endUserID, int _serviceID, string _provider, string _notes) {
            this.date = _date;
            this.time = _time;
            this.endUserID = _endUserID;
            this.serviceID = _serviceID;
            this.provider = _provider;
            this.notes = _notes;
        }


        #endregion

    }//class
}//namespace
