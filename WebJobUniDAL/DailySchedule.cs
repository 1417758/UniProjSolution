using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniUtils;

namespace WebJobUniDAL {
    [System.ComponentModel.DataObject()]
   public class DailySchedule {
        private static DailyScheduleTableAdapter _tblDailyScheduleTableAdapter = null;

        #region "Properties"
        protected static DailyScheduleTableAdapter Adapter {
            get {
                if (_tblDailyScheduleTableAdapter == null)
                    _tblDailyScheduleTableAdapter = new DailyScheduleTableAdapter();
                return _tblDailyScheduleTableAdapter;
            }
        }
        #endregion
        #region "GET Methods"
        /// <summary>
        /// function which returns all instances of DailySchedule datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.DailyScheduleDataTable GetAllDailySchedules() {
            try {
                return Adapter.GetData();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.DailySchedule.GetAllDailySchedules() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of DailySchedule datatable that has the given DailyScheduleID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.DailyScheduleDataTable GetDailyScheduleByID(int? DailyScheduleID) {
            try {
                return Adapter.GetDailyScheduleByID(DailyScheduleID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.DailySchedule.GetDailyScheduleByID(DailyScheduleID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.DailyScheduleDataTable GetDailyScheduleByDateAndStaffID(DateTime date, int? staffID) {
            try {
                return Adapter.GetDailyScheduleByDateAndStaffID(date, staffID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.DailySchedule.GetDailyScheduleByApptID(apptID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.DailyScheduleDataTable GetDailyScheduleByDateAndAgendaID(DateTime date, short? agendaID) {
            try {
                return Adapter.GetDailyScheduleByDateAndAgID(date, agendaID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.DailySchedule.GetDailyScheduleByDateAndAgendaID(x2) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.DailyScheduleDataTable GetDailySchedulesByAgendaID(short? agendaID) {
            try {
                return Adapter.GetDailySchedulesByAgendaID(agendaID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.DailySchedule.GetDailySchedulesByAgendaID(x1) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in DailySchedule table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddDailySchedule(short? agendaID, DateTime date, XmlDocument dailyBookingsXML) {
            try {

                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertDailySchedule(agendaID, date, dailyBookingsXML.OuterXml);//exception if XmlDocument is null
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.DailySchedule.AddDailySchedule(x3 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return null;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which insert a record in DailySchedule table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteDailyScheduleByID(int? dailyScheduleID) {
            try {
                return (int)Adapter.DeleteDailyScheduleByID(dailyScheduleID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.DailySchedule.DeleteDailyScheduleByID(dailyScheduleID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion

    }//CLASS
}//namespace