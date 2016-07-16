﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class OrderBLL : Order {

        public static readonly int GRACE_PERIOD = 15;
        public static readonly string GRACE_PERIOD_UNIT = "min";

        public string status { get; set; }
        public decimal amount { get; set; }
        public bool isPaidinFull { get; set; }
        public int finTransID { get; set; }
        public int apptID { get; set; }

        #region "Constructor"
        public OrderBLL() { }

        #endregion

    }//class
}//namespace