using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniUtils;

//------------------------------------------------------------------------------------------------------
// <copyright file="Exceptions.vb" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------------
namespace WebJobUniDAL {

    [System.ComponentModel.DataObject()]
    public class Client : Person {

        private static PersonReturnTableAdapter _tblClient = null;

        public static void Main() {
            Client client = new Client();
        }

        #region "Properties"
        protected static PersonReturnTableAdapter Adapter {
            get {
                if (_tblClient == null)
                    _tblClient = new PersonReturnTableAdapter();

                return _tblClient;
            }
        }
        #endregion

        #region "GET Methods"

        /// <summary>
        /// function which returns all instances of Client datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonReturnDataTable GetAllClients() {

            try {
                return Adapter.GetAllPersonInherit((byte)RolesEnum.CLIENT);

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Client.GetAllClients() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of PersonReturn datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.PersonReturnDataTable GetClientByID(int? clientID) {
            try {
                return Adapter.GetPersonInheritByID((byte)RolesEnum.CLIENT, clientID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Client.GetClientByID(clientID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonReturnDataTable GetClientByLastName(string lastName) {

            try {
                return Adapter.GetPersonInheritByLastName((byte)RolesEnum.CLIENT, lastName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Client.GetClientByLastName(lastName))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonDataTable GetClientIDByLastName(string lastName) {

            try {
                return GetPersonIDByLastName(lastName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Client.GetClientIDByLastName(lastName))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in Client table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddClient(string title, string firstName, string lastName, int contactDetailID, Guid asp_netUSER_ID) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertPersonInherit(title, firstName, lastName, contactDetailID, (byte)RolesEnum.CLIENT, asp_netUSER_ID, "", "", null);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Client.AddClient(x5 params) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which removed a record in Client table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteClientByID(int? clientID) {
            try {
                return (int)Adapter.DeletePersonInheritByID(clientID, (byte)RolesEnum.CLIENT);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Client.DeleteClientByID(clientID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion


    }//class
}//namespace
