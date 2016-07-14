using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class  ServicesBLL :Services {

        public string name { get; set; }
        public string description { get; set; }
        public string duration { get; set; }
        public string price { get; set; }

        //constructor
        public ServicesBLL() {            
        }



    }//class
}//namespace
