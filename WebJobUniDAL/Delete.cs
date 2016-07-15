using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSet1MainTableAdapters;

namespace WebJobUniDAL
{
    [System.ComponentModel.DataObject()]
    public class Delete
    {

        private static DeleteALLAndResetTableAdapter _tblClient = null;

        public static void Main() {
            Client client = new Client();
        }
        

        protected static DeleteALLAndResetTableAdapter Adapter {
            get {
                if (_tblClient == null)
                    _tblClient = new DeleteALLAndResetTableAdapter();

                return _tblClient;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static DataSet1Main.DeleteALLAndResetDataTable DeletAllAndReset() {

            try {
                return Adapter.GetData();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Person.GetAll() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }





    }//class
}//nameSpace
