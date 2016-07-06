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
    public class EndUser : Person {

        private static PersonReturnTableAdapter _tblEndUser = null;

        public static void Main() {
            EndUser end_user = new EndUser();
        }

        #region "Properties"
        protected static PersonReturnTableAdapter Adapter {
            get {
                if (_tblEndUser == null)
                    _tblEndUser = new PersonReturnTableAdapter();

                return _tblEndUser;
            }
        }
        #endregion

        #region "GET Methods"

        /// <summary>
        /// function which returns all instances of EndUser datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonReturnDataTable GetAllEndUsers() {

            try {
                return Adapter.GetAllPersonInherit((byte)RolesEnum.END_USER);

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.EndUser.GetAllEndUsers() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of PersonReturn datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.PersonReturnDataTable GetEndUserByID(int endUserID) {

            try {
                return Adapter.GetPersonInheritByID((byte)RolesEnum.END_USER, endUserID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.EndUser.GetEndUserByID(endUserID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonReturnDataTable GetEndUserByLastName(string lastName) {

            try {
                return Adapter.GetPersonInheritByLastName((byte)RolesEnum.END_USER, lastName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.EndUser.GetEndUserByLastName(lastName))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonDataTable GetEndUserIDByLastName(string lastName) {

            try {
                return GetPersonIDByLastName(lastName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.EndUser.GetEndUserByLastName(lastName))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in PersonReturn table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddEndUser(string title, string firstName, string lastName, int contactDetailID, Guid asp_netUSER_ID) {
            try {

                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertPersonInherit(title, firstName, lastName, contactDetailID, (byte)RolesEnum.END_USER, asp_netUSER_ID, "", "", null);
                return (int?)result;
                //     return 0;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.EndUser.AddPersonReturn(x6 params) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }

        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which removed a record in PersonReturn table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteEndUserByID(int endUserID) {
            try {
                return (int)Adapter.DeletePersonInheritByID(endUserID, (byte)RolesEnum.END_USER);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.EndUser.DeletePersonReturnByID(PersonReturnID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion


    }//class
}//namespace
