using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSetApptTableAdapters;

namespace WebJobUniDAL {
    public enum OrderStatusEnum : byte {
        //NB: this numeration is used on Stored Procedures and Functions (ie: GetAllPersonInherit...) 
        // a change on these will require those to be revised 
        Completed = 1,
        Waiting_Payment = 2,
        Waiting_ApptConfirmation = 3
    }

    [System.ComponentModel.DataObject()]
   public class Order {
        private static OrderTableAdapter _tblOrderTableAdapter = null;

        #region "Properties"
        protected static OrderTableAdapter Adapter {
            get {
                if (_tblOrderTableAdapter == null)
                    _tblOrderTableAdapter = new OrderTableAdapter();
                return _tblOrderTableAdapter;
            }
        }
        #endregion
        #region "GET Methods"
        /// <summary>
        /// function which returns all instances of Order datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSetAppt.OrderDataTable GetAllOrders() {
            try {
                return Adapter.GetAllOrders();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Order.GetAllOrders() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of Order datatable that has the given orderID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSetAppt.OrderDataTable GetOrderByID(int? orderID) {
            try {
                return Adapter.GetOrderByID(orderID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Order.GetOrderByID(OrderID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// function which returns an instance of Order datatable that has the given orderID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSetAppt.OrderDataTable GetOrderByApptID(int? apptID) {
            try {
                return Adapter.GetOrderByApptID(apptID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Order.GetOrderByApptID(apptID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in Order table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddOrder(string status, decimal amount, bool isPaidInFull, int finTransID, int apptID) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertOrder(status, amount, isPaidInFull, finTransID, apptID);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Order.AddOrder(x5 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return null;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which insert a record in Order table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteOrderByID(int? orderID) {
            try {
                return (int)Adapter.DeleteOrderByID(orderID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Order.DeleteOrderByID(orderID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion

    }//CLASS
}//namespace