﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class  ProvideBLL : Provide {

        public int ServiceID { get; set; }
        public int StaffID { get; set; }

        #region "Constructor"
        public ProvideBLL() { }

        #endregion
    }
}
