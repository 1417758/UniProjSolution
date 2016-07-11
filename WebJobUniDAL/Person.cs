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
    // abstract class Person {
    public class Person {

        #region "Variables"
        private static PersonTableAdapter _tblPersonTableAdapter = null;

        //NB: these are checked on PERSON table insert command
        public static readonly string MR = "Mr";
        public static readonly string MS = "Ms";
        public static readonly string MRS = "Mrs";
        //------------------------------------
        
        #endregion

        #region "Properties"
        protected static PersonTableAdapter Adapter {
            get {
                if (_tblPersonTableAdapter == null)
                    _tblPersonTableAdapter = new PersonTableAdapter();

                return _tblPersonTableAdapter;
            }
        }
        #endregion

        #region "GET Methods"

        /// <summary>//1
        /// function which returns all instances of Person datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonDataTable GetAllPerson() {

            try {
                return Adapter.GetData();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Person.GetAll() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>//2
        /// function which returns an instance of Person datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.PersonDataTable GetPersonByID(int? personID) {

            try {
                return Adapter.GetPersonByID(personID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Person.GetPersonByID(PersontID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        //3
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonDataTable GetPersonByLastName(string lastName) {

            try {
                return Adapter.GetPersonByLastName(lastName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Person.GetPersonByLastName(lastName))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        //4
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonDataTable GetPersonByASPuserID(Guid aspnetUserID) {

            try {
                return Adapter.GetPersonByASPuserID(aspnetUserID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Person.GetPersonByASPuserID(aspnetUserID))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        //5
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonDataTable GetPersonIDByLastName(string lastName) {

            try {
                //NB 6/7/16
                //asp.net runtime error here as more than one value returned
                //modify to show all table 1st then select wanted user
                return Adapter.GetPersonIDByLastName(lastName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Person.GetPersonIDByLastName(lastName))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "Functions"
        /// <summary>//6
        /// function which insert a record in Person table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddPerson(string title, string firstName, string lastName, int contactDetailID, byte roleID, Guid asp_netUSER_ID) {
            try {
                int? pIDReturn = 0;
                Adapter.InsertPerson(ref pIDReturn, title, firstName, lastName, contactDetailID, roleID, asp_netUSER_ID);
                return pIDReturn;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Person.AddPerson(x6 params) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "DELETE Functions"
        /// <summary>//7
        /// function which removed a record in Person table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeletePersonByID(int? personID) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {int}
                dynamic result = Adapter.DeletePersonByID(personID);
                return (int)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Person.DeletePersonByID(personID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion


    }//class
}//namespace
