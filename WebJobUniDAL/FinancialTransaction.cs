using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSetApptTableAdapters;
using WebJobUniUtils;

namespace WebJobUniDAL {
    public enum FinTransStatusEnum : byte {
        //NB: this numeration is used on Stored Procedures and Functions (ie: GetAllPersonInherit...) 
        // a change on these will require those to be revised 
        COMPLETED = 1,
        ABORTED = 2,
        CANCELED = 3,
        PENDING = 4,
        PROCESSING = 5
    }

    [System.ComponentModel.DataObject()]
    public class FinancialTransaction {
        private static FinancialTransactionTableAdapter _tblFinancialTransTableAdapter = null;

        #region "Properties"
        protected static FinancialTransactionTableAdapter Adapter {
            get {
                if (_tblFinancialTransTableAdapter == null)
                    _tblFinancialTransTableAdapter = new FinancialTransactionTableAdapter();
                return _tblFinancialTransTableAdapter;
            }
        }
        #endregion
        #region "GET Methods"
        /// <summary>
        /// function which returns all instances of FinancialTrans datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSetAppt.FinancialTransactionDataTable GetAllFinancialTransactions() {
            try {
                return Adapter.GetAllFinTrans();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.FinancialTranss.GetAllFinancialTranss() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of FinancialTrans datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSetAppt.FinancialTransactionDataTable GetFinancialTransByID(int? financialTransID) {
            try {
                return Adapter.GetFinTransByID(financialTransID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.FinancialTranss.GetFinancialTransByID(FinancialTransID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in FinancialTrans table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddFinancialTrans(string status, decimal amount,  int payMetType, Guid authorisCode, DateTime date) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertFinancialTrans(status, amount, payMetType, authorisCode, date);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.FinancialTranss.AddFinancialTrans(x2 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return null;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which insert a record in FinancialTrans table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteFinancialTransByID(int? financialTransID) {
            try {
                return (int)Adapter.DeleteFinancialTransByID(financialTransID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.FinancialTranss.DeleteFinancialTransByID(FinancialTransID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion

    }//CLASS
}//namespace