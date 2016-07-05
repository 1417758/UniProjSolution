using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniUtils;


namespace WebJobUniDAL {
    class Agenda {


        private static AgendaTableAdapter _tblAgendaTableAdapter = null;

        #region "Properties"
        protected static AgendaTableAdapter Adapter {
            get {
                if (_tblAgendaTableAdapter == null)
                    _tblAgendaTableAdapter = new AgendaTableAdapter();
                return _tblAgendaTableAdapter;
            }
        }
        #endregion

        #region "GET Methods"

        /// <summary>
        /// function which returns all instances of Agenda datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.AgendaDataTable GetAllAgendas() {

            try {
                return Adapter.GetAllAgendas();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Agenda.GetAllAgenda() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of Agenda datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.AgendaDataTable GetAgendaByID(int agendaID) {
            try {
                return Adapter.GetAgendaByID(agendaID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Agenda.GetAgendaByID(agendaID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in Agenda table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int AddAgenda(bool isAppuser, bool syncCalendar) { 
            try {
                return (int)Adapter.InsertAgenda(isAppuser, syncCalendar);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Agenda.AddAgenda(x2 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return 0;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which insert a record in Agenda table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteAgendaByID(int agendaID) {
            try {
                return (int)Adapter.DeleteAgendaByID(agendaID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Agenda.DeleteAgendaByID(agendaID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion

        

    }//endof Class
}//endof namespace
