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
    public class Employee : Person {

        private static PersonReturnTableAdapter _tblEmployee = null;
        //??
        public static void Main() {
            Employee Employee = new Employee();
        }

        #region "Properties"
        protected static PersonReturnTableAdapter Adapter {
            get {
                if (_tblEmployee == null)
                    _tblEmployee = new PersonReturnTableAdapter();

                return _tblEmployee;
            }
        }
        #endregion

        #region "GET Methods"

        /// <summary>
        /// function which returns all instances of Employee datatable
        /// </summary>all instances of inputs
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonReturnDataTable GetAllEmployees() {

            try {
                return Adapter.GetAllPersonInherit((byte)RolesEnum.EMPLOYEE);

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Employee.GetAllEmployees() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// function which returns an instance of PersonReturn datatable that has the given contactID
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.PersonReturnDataTable GetEmployeeByID(int? employeeID) {
            try {
                return Adapter.GetPersonInheritByID((byte)RolesEnum.EMPLOYEE, employeeID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Employee.GetEmployeeByID(employeeID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static DataSet1Main.PersonReturnDataTable GetEmployeeByAgendaID(short? agendaID) {
            try {
                return Adapter.GetEmployeeByAgendaID(agendaID);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Employee.GetEmployeeByAgendaID(agendaID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonReturnDataTable GetEmployeeByLastName(string lastName) {

            try {
                return Adapter.GetPersonInheritByLastName((byte)RolesEnum.EMPLOYEE, lastName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Employee.GetEmployeeByLastName(lastName))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }


        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static DataSet1Main.PersonDataTable GetEmployeeIDByLastName(string lastName) {

            try {
                return GetPersonIDByLastName(lastName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Employee.GetEmployeeIDByLastName(lastName))</h2> </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "ADD Functions"
        /// <summary>
        /// function which insert a record in Employee table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int? AddEmployee(string title, string firstName, string lastName, int contactDetailID, Guid asp_netUSER_ID, string natInsNumb, string jobTitle, short? agendaID) {
            try {
                //NB tableAdapter returns decimal value by default. TYPE= object {decimal}
                dynamic result = Adapter.InsertPersonInherit(title, firstName, lastName, contactDetailID, (byte)RolesEnum.EMPLOYEE, asp_netUSER_ID, natInsNumb, jobTitle, agendaID);
                return (int?)result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Employee.AddEmployee(x5 params) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "DELETE Functions"
        /// <summary>
        /// function which removed a record in Employee table
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static int DeleteEmployeeByID(int? EmployeeID) {
            try {
                return (int)Adapter.DeletePersonInheritByID(EmployeeID, (byte)RolesEnum.EMPLOYEE);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>DAL.Employee.DeleteEmployeeByID(EmployeeID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        #endregion

        #region "UPDATE Functions"
        #endregion


    }//class
}//namespace
