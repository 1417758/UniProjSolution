using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class ServicesBLL : Services {

        public int? ID { get; set; }
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


        public static int? GetServiceIDByServName_Int(string servName) {
            try {
                var allServsFound = GetServiceIDByServName(servName);
                int numbServsFound = allServsFound.Rows.Count;

                //if data wasnt found
                if (numbServsFound == 0)
                    return null;
                //more than 1
                else if (numbServsFound > 1)
                    throw new Exception("BLL.ServicesBLL.GetServiceIDByServName_Int(x1), MORE THAN ONE SERVICE WAS FOUND WITH THE GIVEN NAME");
                else  //count=1 return value
                    return (int)allServsFound.Rows[0].ItemArray[0];
            }
           catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }

    }//class
}//namespace
