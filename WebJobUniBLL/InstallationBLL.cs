using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;
using WebJobUniUtils;

namespace WebJobUniBLL {
    public class InstallationBLL {

        public static void SaveInstallationToDB(Installation i) {
            try {
                System.Diagnostics.Debug.Print(i.ToString());

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>BLL.InstallationBLL.SaveInstallationToDB()</h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
            }
        }






    }//class
}//namespace

