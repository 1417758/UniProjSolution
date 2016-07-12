using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniUtils;

//------------------------------------------------------------------------------------------------------
// <copyright file="AspNetUser.cs" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------------
namespace WebJobUniDAL {
    [System.ComponentModel.DataObject()]
    public class AspNetUser {

        private static aspnet_UsersTableAdapter _tblASPNetUserTableAdapter = null;

        #region "Properties"
        protected static aspnet_UsersTableAdapter Adapter {
            get {
                if (_tblASPNetUserTableAdapter == null)
                    _tblASPNetUserTableAdapter = new aspnet_UsersTableAdapter();
                return _tblASPNetUserTableAdapter;
            }
        }
        #endregion

        #region "GET Functions"
        /// <summary>
        /// function which returns all instances of users in the datatable
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.aspnet_UsersDataTable GetAllAspNetUsers() {

            try {
                return Adapter.GetData();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.AspNetUser.GetAllAspNetUsers() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an userID of type GUID that corresponds to the given userName
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Guid? GetUserIDByUserName(string userName) {
            try {              
                return (Guid?)Adapter.GetUserIDByUserName(userName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.AspNetUser.GetUserIDByUserName() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion




    }//class
}//namespace
