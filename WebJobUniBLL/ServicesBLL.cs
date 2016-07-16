using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class ServicesBLL : Services {

        public string name { get; set; }
        public bool isCertifReq { get; set; }
        public bool isInsuranceReq { get; set; }
        public string description { get; set; }
        public byte duration { get; set; }
        public string durationUnit { get; set; }
        public decimal price { get; set; }

        //constructor
        public ServicesBLL() {
        }

        public ServicesBLL(string _name, string _description, byte _duration, decimal _price) { 
            this.name = _name;
            this.description = _description;
            this.duration = _duration;
            this.price = _price;
        }


    }//class
}//namespace
