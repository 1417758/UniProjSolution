using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class FinancialTransBLL : FinancialTransaction {
        public int? ID { get; set; }
        public string status { get; set; }
        public decimal amount { get; set; }
        public int payMetType { get; set; }
        public Guid authorisCode { get; set; }
        public DateTime timeStamp { get; set; }

        #region "Constructor"
        public FinancialTransBLL() { }

        #endregion

    }//class
}//namespace
