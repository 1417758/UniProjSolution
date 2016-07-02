using System;
using System.Data;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniBLL;

//------------------------------------------------------------------------------------------------------
// <copyright file="Exceptions.vb" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------------
namespace WebJobUniDAL {

    [System.ComponentModel.DataObject()]
    public class Companies {
        

        private static CompanyTableAdapter _tblCompanyTableAdapter = null;

        #region "Properties"

        protected static CompanyTableAdapter Adapter {
            get {
                if (_tblCompanyTableAdapter == null) {
                    _tblCompanyTableAdapter = new CompanyTableAdapter();
                }

                return _tblCompanyTableAdapter;
            }
        }


        #endregion

        #region "Functions"
        /// <summary>
        /// function which returns all instances of inputs datatable
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.CompanyDataTable GetCompanies() {

            try {
                return Adapter.GetAllCompanies();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("DAL.Companies.GetCompanies() \n" + XMLConstants.DEBUG_ERROR);
                return null;
            }
        }

        /// <summary>
        /// function which returns all instances of inputs datatable
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.CompanyDataTable GetCompanyIDByCompanyID(int companyID) {

            try {
                return Adapter.GetCompanyByID(companyID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("DAL.Companies.GetCompanyIDByCompanyID() \n" + XMLConstants.DEBUG_ERROR);
                return null;
            }
        }


        /// <summary>
        /// function which insert a record in inputs table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int AddCompany(string companyName) {

            try {
                return Adapter.Insert(companyName, null, null, null, null, null, null, null, null, null, null);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("DAL.Companies.GetCompanies() \n" + XMLConstants.DEBUG_ERROR);
                // return null;
                return 0;
            }
        }

        #endregion

    }

}

