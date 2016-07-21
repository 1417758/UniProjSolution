using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSetApptTableAdapters;
using WebJobUniUtils;

namespace WebJobUniDAL {
    [System.ComponentModel.DataObject()]
    public class Provide {
        private static ProvideTableAdapter _tblProvideTableAdapter = null;

        #region "Properties"
        protected static ProvideTableAdapter Adapter {
            get {
                if (_tblProvideTableAdapter == null)
                    _tblProvideTableAdapter = new ProvideTableAdapter();
                return _tblProvideTableAdapter;
            }
        }
        #endregion

        /// <summary>
        /// function which returns all instances of Provide datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSetAppt.ProvideDataTable GetAllProvide() {
            try {
                return Adapter.GetAllProvide();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Provide.GetAllProvide() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
    }
}
