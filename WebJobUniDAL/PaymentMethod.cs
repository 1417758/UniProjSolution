using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSetApptTableAdapters;

namespace WebJobUniDAL {
    public enum PaymentMethodhodsEnum : byte {
        //NB: this numeration is stored on Payment Transactions DB_Table  
        // a change on these will require those to be revised 
        CREDIT_CARD = 1,
        BANK_TRANSFER = 2,
        PAYPAL = 3,
        CASH = 4,
        DIRECT_DEBIT = 5,
        ONILE_PAYMENT = 6
    }

    [System.ComponentModel.DataObject()]
    public class PaymentMethod {

        private static PaymentMethodsTableAdapter _tblPaymentMethodTableAdapter = null;

        #region "Properties"
        protected static PaymentMethodsTableAdapter Adapter {
            get {
                if (_tblPaymentMethodTableAdapter == null)
                    _tblPaymentMethodTableAdapter = new PaymentMethodsTableAdapter();
                return _tblPaymentMethodTableAdapter;
            }
        }
        #endregion
        #region "GET Methods"
        /// <summary>
        /// function which returns all instances of PaymentMethod datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSetAppt.PaymentMethodsDataTable GetAllPaymentMethods() {
            try {
                return Adapter.GetAllPayMets();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.PaymentMethods.GetAllPaymentMethods() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of PaymentMethod datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSetAppt.PaymentMethodsDataTable GetPaymentMethodByID(int? paymentMethodID) {
            try {
                return Adapter.GetPayMetByID(paymentMethodID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.PaymentMethods.GetPaymentMethodByID(PaymentMethodID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in PaymentMethod table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddPaymentMethod(bool isOnlinePay, bool isCashPay, string payMetType) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertPayMethod(isOnlinePay, isCashPay, payMetType);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.PaymentMethods.AddPaymentMethod(x2 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return null;
            }
        }      
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which insert a record in PaymentMethod table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeletePaymentMethodByID(int? paymentMethodID) {
            try {
                return (int)Adapter.DeletePayMetByID(paymentMethodID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.PaymentMethods.DeletePaymentMethodByID(PaymentMethodID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion



    }//CLASS
}//namespace
