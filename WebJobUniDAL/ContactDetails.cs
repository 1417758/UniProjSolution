using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    public class ContactDetails {

        private static ContactDetailsTableAdapter _tblContacDetTableAdapter = null;

        #region "Properties"
        protected static ContactDetailsTableAdapter Adapter {
            get {
                if (_tblContacDetTableAdapter == null)
                    _tblContacDetTableAdapter = new ContactDetailsTableAdapter();                

                return _tblContacDetTableAdapter;
            }
        }
        #endregion

        #region "GET Methods"
        
        /// <summary>//1
        /// function which returns all instances of contactDetails datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.ContactDetailsDataTable GetAllContactDetails() {

            try {
                return Adapter.GetAllContactDetails();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.ContactDetails.GetAllContactDet() </h2> \n" +  ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>//2
        /// function which returns an instance of contactDetails datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.ContactDetailsDataTable GetContactDetailByID(int contactDetID) {

            try {
                return Adapter.GetContactDetByID(contactDetID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.ContactDetails.GetContactDetailByID(contacDettID) </h2> \n" +  ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        //3
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.ContactDetailsDataTable GetContactDetByCompID(int companyID) {

            try {
                return Adapter.GetContactDetByCompID(companyID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.ContactDetails.GetContactDetByCompID(companyID))</h2> </h2> \n" +  ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        //4
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.ContactDetailsDataTable GetContactDetByPersonID(int personID) {

            try {
                return Adapter.GetContactDetByPersonID(personID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.ContactDetails.GetContactDetByPersonID(personID))</h2> </h2> \n" +  ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "ADD Functions"
        /// <summary>//5
        /// function which insert a record in contactDetails table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int AddContactDetails(string address, string postcode, string city, string country, string landline, string mobilePhone, string email) {
            try {

                DateTime dateNow = (DateTime)Utils.GetDatetimeNOW();
                return (int)Adapter.InsertContactDet(address: address, postCode: postcode, city: city, country: country, 
                                                    landLine: landline, mobile: mobilePhone, email: email, dateCreated:dateNow, lastUpdated:dateNow );
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.ContactDetails.AddContactDetails(x7string param) </h2> \n" +  ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return 0;
            }
        }
        //6
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
        public static int AddContactDetailsAllNull() { 
            try {
                //string address = null, string postcode = null, string city = null, string country = null, string landline = null, string mobilePhone = null, string email = null) {

                    DateTime dateNow = (DateTime)Utils.GetDatetimeNOW();
                return (int)Adapter.InsertContactDet(address: null, postCode: null, city: null, country: null,
                                                    landLine: null, mobile: null, email: null, dateCreated: dateNow, lastUpdated: dateNow);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.ContactDetails.AddContactDetailsAllNull() </h2> \n" +  ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return 0;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>//7
        /// function which removed a record in contactDetails table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteContactDetailByID(int contactDetID) {
            try {
                return (int)Adapter.DeleteContDetByID(contactDetID);                   
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.ContactDetails.DeleteContactDetailByID(contactDetID) </h2> \n" +  ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                 return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion


    }//class
}//namespace

