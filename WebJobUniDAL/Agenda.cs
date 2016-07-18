using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniUtils;

//------------------------------------------------------------------------------------------------------
// <copyright file="Agenda.cs" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------------
namespace WebJobUniDAL {

    [System.ComponentModel.DataObject()]
    public class Agenda {


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

        #region "GET Functions"

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
        public static DataSet1Main.AgendaDataTable GetAgendaByID(short? agendaID) {
            try {
                return Adapter.GetAgendaByID(agendaID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Agenda.GetAgendaByID(agendaID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// function which returns an instance of Agenda datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.AgendaDataTable GetAgendaByStaffID(short? agendaID) {
            try {
                return Adapter.GetAgendaByStaffID(agendaID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Agenda.GetAgendaByStaffID(agendaID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
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
        public static short? AddAgenda(bool isAppuser, bool syncCalendar) { 
            try {
                // NB tableAdapter returns decimal value by default.TYPE = object { decimal}
                dynamic result = Adapter.InsertAgenda(isAppuser, syncCalendar);
                return (short?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Agenda.AddAgenda(x2 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return null;
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
        public static int DeleteAgendaByID(short? agendaID) {
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
