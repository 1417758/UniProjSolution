using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
   public class PayMethodBLL : PaymentMethod  {

        public int? ID { get; set; }
        public bool isOnline { get; set; }
        public bool isCash { get; set; }
        public string type { get; set; } //ref: DAL.PaymentMethodhodsEnum

        //constructor
        public PayMethodBLL() { }


    }//class
}//namespace
