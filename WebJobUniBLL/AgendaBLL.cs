using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class AgendaBLL :Agenda{

        public bool isAdmin { get; set; }
        public bool syncCalendar { get; set; }

        #region "Constructor"
        public AgendaBLL() { }

        #endregion


    }//class
}//namespace
