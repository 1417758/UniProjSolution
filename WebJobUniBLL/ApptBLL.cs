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

        #region "Constructor"
        public ApptBLL() { }

        #endregion

    }//class
}//namespace
