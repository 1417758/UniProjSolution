using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSetApptTableAdapters;

namespace WebJobUniDAL {
    [System.ComponentModel.DataObject()]
    public class Services {
        private static ServicesTableAdapter _tblServicesTableAdapter = null;

        #region "Properties"
        protected static ServicesTableAdapter Adapter {
            get {
                if (_tblServicesTableAdapter == null)
                    _tblServicesTableAdapter = new ServicesTableAdapter();
                return _tblServicesTableAdapter;
            }
        }
        #endregion
        #region "GET Methods"
        /// <summary>
        /// function which returns all instances of Services datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSetAppt.ServicesDataTable GetAllServices() {
            try {
                return Adapter.GetAllServices();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Services.GetAllServices() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of Services datatable that has the given ServicesID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSetAppt.ServicesDataTable GetServiceByID(int? servicesID) {
            try {
                return Adapter.GetServiceByID(servicesID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Services.GetServiceByID(servicesID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// function which returns an instance of Services datatable that has the given ServicesID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSetAppt.ServicesDataTable GetServicesByStaffID(int? staffID) {
            try {
                return Adapter.GetServicesProvByStaffID(staffID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Services.GetServicesByApptID(apptID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in Services table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddService(string name,bool isCertifReq, bool isInsReq, string description, byte duration, string durationUnit) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertService(name, isCertifReq, isInsReq, description, duration, durationUnit);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Services.AddServices(x6 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return 0;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which insert a record in Services table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteServicesByID(int? servicesID) {
            try {
                return (int)Adapter.DeleteServiceByID(servicesID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Services.DeleteServicesByID(ServicesID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion

    }//CLASS
}//namespace