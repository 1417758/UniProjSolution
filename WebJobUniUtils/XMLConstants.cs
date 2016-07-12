using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
//------------------------------------------------------------------------------------------------------
// <copyright file="XMLConstantsShared.vb" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------------------------------
namespace WebJobUniUtils {
    public class XMLConstants {

        public const string YES = "Yes";
        public const string NO = "No";
        public const string ID = "ID";
        public const string UNKNOWN = "Unknown";
        public const string NA = "N/A";

        public const string NOT_APPLICABLE = "Not Applicable";
        public static string Session_Installation = "Installation";
        public static string Session_InstallationTimeStamp = "Installation_TimeStamp";
        public static string DEBUG_ERROR3 = "+ ex3.Message \n ex3.InnerException \n ex3.StackTrace" ;

        #region "Settings XML"
        public const string SETTING_ID = "SettingID";
        public const string Settings = "Settings";
        public const string Setting = "Setting";
        public const string Value = "Value";
        public const string SystemUserName = "SYSTEM";
        public const string SettingsXML = "SettingsXML";
        public const int settingsIndex = 0;
        public const string checkUpdates = "CheckUpdates";
        public const string licenseAccepted = "LicenseAccepted";
        public const string licensing = "Licensing";
        public const string status = "Status";
        public const string DEMO = "Demo";

        public const string ASSET = "Asset";
        public const string OFF = "OFF";

   	#endregion


		#region "Shared Settings "
		//Exception Handling Settings
		public const string EmailNotificationsOn = "EmailNotificationsOn";
        public const string ExceptionRecipient = "ExceptionRecipient";

        public const string RecordToDataBase = "RecordToDataBase";
        //client settings
        public const string CLIENT = "Client";
 
        public const string Currency = "Currency";
        //system
        public const string SystemUserID = "SystemUserID";

        public const string ApplicationName = "ApplicationName";
    
        //'shared' external files
        public const string ApplicationXML = "ApplicationXML";    
        public const string InstallationDemoXML = "InstallationDemoXML";
        #endregion

       #region "Clients"

        public const string SHELLDEMO = "SHELLDEMO";
        public const string SHELL = "SHELL";
        public const string BG = "BG";
        public const string TOTAL = "TOTAL";
        public const string KARACHAGANAK = "KARACHAGANAK";
        public const string BP = "BP";
        public const string NEXEN = "NEXEN";
        /// <summary>
        /// Get list of clients (hard coded)
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<string> GetClients() {
            List<string> clientLi = new List<string>();
            var _with1 = clientLi;
            _with1.Add(SHELL);
            _with1.Add(BG);
            _with1.Add(TOTAL);
            _with1.Add(KARACHAGANAK);
            _with1.Add(BP);
            _with1.Add(NEXEN);           
            return clientLi;
        }
        #endregion


        public const string TYPE = "type";

        public const string TAG = "tag";

        public const string DEFAULT_ = "Default";
        //error codes

        public const int ERROR_247 = -247;
   

        #region "Testing"
        public const string TEST = "test";
        #endregion
        public const string TEST_NOTES = "testNotes";

        #region "Trending"
        public const string DESCRIPTION = "Description";
        public const string UNIT = "Unit";
   
        public const string START_DATE = "StartDate";
        public const string START_TIME = "StartTime";
        public const string END_TIME = "EndDate";
        public const string DATASOURCE = "Datasource";
        public const string USER_TRENDS = "UserTrends";
        public const string SYSTEM_BOOLEAN = "System.Boolean";
        #endregion
        public const string SYSTEM_INT32 = "System.Int32";

      
     
        #region "Installation"
        public const string MAX_VALUE = "MaxValue";
        public const string MIN_VALUE = "MinValue";
        public const string MAX = "Max";
        public const string MIN = "Min";
        public const string DEFAULT_VALUE = "DefaultValue";
        public const string RAW_VALUE = "RawValue";
        public const string FACTOR = "Factor";
        public const string OUT_OF_RANGE = "OutOfRange";
        public const string ERROR_CODE = "ErrorCode";
        public const string TIMESTAMP = "Timestamp";
        public const string NUMBER_DECIMAL_PLACES = "NumberDecimalPlaces";

        #endregion


      }
}


