using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class FinancialTransBLL : FinancialTransaction {

        public int? ID { get; set; }
        public string status { get; set; }//FinTransStatusEnum
        public decimal? amount { get; set; }     
        public PayMethodBLL payMethod { get; set; }//ref: DAL.PaymentMethodhodsEnum
        public Guid? authorisCode { get; set; }
        public DateTime? timeStamp { get; set; }

        #region "Constructor"
        public FinancialTransBLL() {
            this.payMethod = new PayMethodBLL();
        }

        #endregion

    }//class
}//namespace
