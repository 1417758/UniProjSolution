using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniUtils;

namespace WebJobUniDAL{
    [System.ComponentModel.DataObject()]
    public class Exceptions {
        private static ExceptionsTableAdapter _tblExceptionsTableAdapter = null;

        #region "Properties"
        protected static ExceptionsTableAdapter Adapter {
            get {
                if (_tblExceptionsTableAdapter == null)
                    _tblExceptionsTableAdapter = new ExceptionsTableAdapter();
                return _tblExceptionsTableAdapter;
            }
        }
        #endregion
        #region "GET Methods"
        /// <summary>
        /// function which returns all instances of Exceptions datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.ExceptionsDataTable GetAllExceptionss() {
            try {
                return Adapter.GetAllExceptions();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Exceptions.GetAllExceptions() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of Exceptions datatable that has the given ExceptionsID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.ExceptionsDataTable GetExceptionsByDate(DateTime date) {
            try {
                return Adapter.GetExceptionsByDate(date);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Exceptions.GetExceptionsByDate(date) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.ExceptionsDataTable GetExceptionsByUsername(string userName) {
            try {
                return Adapter.GetExceptionsByUserName(userName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Exceptions.GetExceptionsByUsername(userName) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in Exceptions table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static DateTime? AddException(DateTime timeStamp, string source, string message, string innerMsg, string stackTrace, string target, Guid? aspUserID) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertException(timeStamp, source, message, innerMsg, stackTrace, target, aspUserID);
                return (DateTime?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Exceptions.AddException(x7 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return null;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which insert a record in Exceptions table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteAllExceptions() {
            try {
                return (int)Adapter.DeleteExceptions();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Exceptions.DeleteExceptionsByID(ExceptionsID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion

    }//CLASS
}//namespace