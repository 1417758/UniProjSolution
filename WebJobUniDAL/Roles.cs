using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL.DataSet1MainTableAdapters;
using WebJobUniUtils;

namespace WebJobUniDAL {

    public enum  RolesEnum : byte {
        //NB: this numeration is used on Stored Procedures and Functions (ie: GetAllPersonInherit...) 
        // a change on these will require those to be revised 
        ADMIN = 1,
        END_USER = 2,
        EMPLOYEE = 3,
        CLIENT = 4,
        ALL = 0
    }

    [System.ComponentModel.DataObject()]
    public class Roles {

        private static RolesTableAdapter _tblRoleTableAdapter = null;


        #region "Enum Functions"
        public static byte GetRolesEnumValue(string role) {
            //ie:'get parameter emission as string
            //    Dim pollutant = System.[Enum].GetName(GetType(EmissionsEnum), intParam)
            string roleUpper = role.ToUpper();
            try {
                switch (roleUpper) {
                    case "ADMIN":
                        return (byte)RolesEnum.ADMIN;
                    case "END_USER":
                        return (byte)RolesEnum.END_USER;
                    case "ENDUSER":
                        return (byte)RolesEnum.END_USER;
                    case "STAFF":
                        return (byte)RolesEnum.EMPLOYEE;
                    case "EMPLOYEE":
                        return (byte)RolesEnum.EMPLOYEE;
                    case "CLIENT":
                        return (byte)RolesEnum.CLIENT;
                    case "ALL":
                        return (byte)RolesEnum.ALL;
                    default://case else
                        throw new Exception(role + " role could not be found");
                }//endof switch
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Roles.GetRoleEnumValue(RolesID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }

        public static bool IsRoleWithinRolesEnum(byte role) {
            //ie:'get parameter emission as string
            //    Dim pollutant = System.[Enum].GetName(GetType(EmissionsEnum), intParam)
            try {
                //get all enum roles in an array
                Array values = Enum.GetValues(typeof(RolesEnum));

                foreach (RolesEnum roleVal in values) {
                    System.Diagnostics.Debug.Print(String.Format("{0}: {1}", Enum.GetName(typeof(RolesEnum), roleVal), roleVal));
                    //check it matches the parameter
                    if ((byte)roleVal == role)
                        return true;
                }
                //parameter doesnt match any items of RolesEnum 
                return false;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Roles.IsRoleWithinRolesEnum(role) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return false;
            }
        }

        #endregion

        #region "Properties"
        protected static RolesTableAdapter Adapter {
            get {
                if (_tblRoleTableAdapter == null)
                    _tblRoleTableAdapter = new RolesTableAdapter();
                return _tblRoleTableAdapter;
            }
        }
        #endregion

        #region "GET Methods"
        /// <summary>
        /// function which returns all instances of Role datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.RolesDataTable GetAllRoles() {
            try {
                return Adapter.GetData();
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Roles.GetAllRoles() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of Role datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.RolesDataTable GetRoleByID(byte? roleID) {
            try {
                return Adapter.GetRoleByID(roleID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Roles.GetRoleByID(roleID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in Role table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddRole(bool isAdmin, string roleDesc) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertRole(isAdmin, roleDesc);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Roles.AddRole(x2 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return null;
            }
        }

        public static int AddRole2(bool isAdmin, string roleDesc) {
            try {
                //ASP.NET Default DS insert
                return (int)Adapter.Insert(isAdmin, roleDesc);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Roles.AddRole2(x2 param) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;
                return 0;
            }
        }
        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which insert a record in Role table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteRoleByID(byte? roleID) {
            try {
                return (int)Adapter.DeleteRoleByID(roleID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Roles.DeleteRoleByID(roleID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion

    }//endof Class
}//endof namespace
