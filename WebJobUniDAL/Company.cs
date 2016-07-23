using System;
using System.Data;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniUtils;
using System.Collections.Generic;
using System.Text;

//------------------------------------------------------------------------------------------------------
// <copyright file="Exceptions.vb" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------------
namespace WebJobUniDAL {

    [System.ComponentModel.DataObject()]
    public class Company {


        private static CompanyTableAdapter _tblCompanyTableAdapter = null;

        #region "Properties"

        protected static CompanyTableAdapter Adapter {
            get {
                if (_tblCompanyTableAdapter == null)
                    _tblCompanyTableAdapter = new CompanyTableAdapter();

                return _tblCompanyTableAdapter;
            }
        }
        #endregion

        #region "GET Methods"
        /// <summary>
        /// function which returns all instances of companies datatable
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.CompanyDataTable GetAllCompanies() {
            try {
                return Adapter.GetAllCompanies();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Companies.GetAllCompanies() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns all instances of companies datatable
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.CompanyDataTable GetCompanyByID(int? companyID) {
            try {
                return Adapter.GetCompanyByID(companyID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Companies.GetCompanyByID(companyID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.CompanyDataTable GetCompanyByClientID(int? clientID) {
            try {
                return Adapter.GetCompanyByClientID(clientID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Companies.GetCompanyByClientID(clientID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        

        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in company table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
        public static int? AddCompany(string compName, string industry, int natureOfBusiness, string compNumber, DateTime dateRegistered, string URL, int clientID, int contactDetID, bool isVARreg, string VATNumb, string notes) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertCompany(compName, industry, natureOfBusiness, compNumber, dateRegistered, URL, clientID, contactDetID, isVARreg, VATNumb, notes);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Companies.AddCompany(x11 params) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddCompany(string compName, string industry, int natureOfBusiness, int clientID, int contactDetID) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertCompany(compName, industry, natureOfBusiness, null, null, null, clientID, contactDetID, null, null, null);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Company.AddCompany(x5 params) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which removed a record in Company table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteCompanyByID(int? companyID) {
            try {
                return (int)Adapter.DeleteCompanyByID(companyID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Company.DeleteCompanyByID(companyID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion
    }

}

