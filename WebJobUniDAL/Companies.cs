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
                return (int)Adapter.InsertCompany(companyName, null, null, null, null, null, null, null, null, null, null);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("DAL.Companies.GetCompanies() \n" + XMLConstants.DEBUG_ERROR);
                // return null;
                return 0;
            }
        }
        /// <summary>
        /// function which insert a record in inputs table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int AddCompany(List<string> companyAttributes) {
            try {

                /* StringBuilder sBuilder = new StringBuilder();
                 var _with1 = sBuilder;
                 // Loop over list elements using foreach-loop.
                 foreach (string element in companyAttributes) {
                     _with1.Append("\"" + element + ", \"");
                 }
                 System.Diagnostics.Debug.Print(sBuilder.ToString());
                 return (int)Adapter.InsertCompany(sBuilder.ToString());

                var name = companyAttributes[1];
                var industry = companyAttributes[2];
                byte nature = (byte)Utils.GetNumberShort(companyAttributes[3]);
                var string coNumb varchar(50),
              var date incorporated ,
              var string url varchar(100),
              var int mainContact  FOREIGN KEY REFERENCES Client(clientID)ON DELETE CASCADE ON UPDATE CASCADE,
              var int contactDet  NOT NULL FOREIGN KEY REFERENCES ContactDetails(contactDetID) ON DELETE CASCADE ON UPDATE CASCADE,
              var bit   isVATreg,
              var string   vatNumb varchar(50),
              var string   notes varchar(200)
*/
                return 0;

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

