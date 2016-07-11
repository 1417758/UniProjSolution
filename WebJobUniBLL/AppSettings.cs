using System;
using System.Text;
using System.IO;
using System.Xml.Linq;
using WebJobUniUtils;
//------------------------------------------------------------------------------------------------------
// <copyright file="AppSettings.vb" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//----
namespace WebJobUniBLL {
    public class   AppSettings {


        #region "Public Variables"


        public static AppSettings Settings;
        //Client
        public Guid SystemUserID { get; set; }
        public string ApplicationName{ get; set; }
        public string Client{ get; set; }
        public string ClientAsset{ get; set; }
        public string ClientLogo{ get; set; }
        public string ClientUnit{ get; set; }

        public string Currency{ get; set; }
        //used on DEMOs only (per user)
        public int TotalBookingsAllowed{ get; set; }
        public int NumberOfLogins{ get; set; }
        public string ApplicationsXML{ get; set; }
        public string TagMatchingXml{ get; set; }
        public string UnitsXMLFilename{ get; set; }

        public string InstallationDemoXML{ get; set; }

        public string SettingsXML{ get; set; }

        #endregion

        #region "Functions"
      
        /// <summary>
        /// Return ToString value.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public override string ToString() {
            try {
                StringBuilder x = new StringBuilder("Applications Settings:" + Environment.NewLine);
                var _with1 = x;
                _with1.Append("SettingsXML filename: " + Environment.NewLine + SettingsXML + Environment.NewLine);
                _with1.Append("Exception Handling Settings: " + Environment.NewLine + base.ToString() + Environment.NewLine);
                //.Append("Email Notifications On" & vbTab & EmailNotificationsOn & vbCrLf)
                //.Append("Exception Recipient:" & vbTab & ExceptionRecipient & vbCrLf)
                //.Append("Record to DataBase:" & vbTab & RecordToDataBase & vbCrLf)

                _with1.Append("System User ID " + "\t" + SystemUserID.ToString() + Environment.NewLine);
                _with1.Append("Application Name " + "\t" + ApplicationName + Environment.NewLine);
                _with1.Append("Client" + "\t" + Client + Environment.NewLine);

                _with1.Append("ClientAsset" + "\t" + ClientAsset + Environment.NewLine);
                _with1.Append("ClientLogo" + "\t" + ClientLogo + Environment.NewLine);
                _with1.Append("ClientUnit " + "\t" + ClientUnit + Environment.NewLine);

                //used on DEMOs only ("per user)
                _with1.Append("TotalPeriodAllowed " + "\t" + TotalBookingsAllowed.ToString() + Environment.NewLine);
                _with1.Append("NumberOfLogins " + "\t" + NumberOfLogins.ToString() + Environment.NewLine);
 
                 _with1.Append("UnitsXMLFilename " + "\t" + UnitsXMLFilename + Environment.NewLine);

                _with1.Append("ApplicationXML " + "\t" + ApplicationsXML + Environment.NewLine);

               _with1.Append("InstallationDemoXML" + "\t" + InstallationDemoXML + Environment.NewLine);

                return _with1.ToString();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Error in BLL.sendMail.SendDemoSummary \n" + XMLConstants.DEBUG_ERROR);
                return "Error in creating ToString of AppSettings";
            }
        }

        /// <summary>
        /// Get object with exception handling settings
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static AppSettings GetAppSettings(string filename) {
            try {
                if (!File.Exists(filename)) {
                    System.Diagnostics.Debug.Print("AppSettings.vb: EXCEPTION in GetAppSettings: FileNotFoundException: " + filename);
                    throw new FileNotFoundException("Exception in AppSettings.vb GetAppSettings. The file " + filename + " cannot be found /  accessed");
            }

                //load exception handling settings 
                //sdkfj assign to this public class  
               // dynamic exceptions = GetExceptionHandlingSettings(filename);

                //create new instance of AppSettings
                AppSettings sharedSets = new AppSettings();

                //load the settings XML file
                dynamic doc = XDocument.Load(filename);

                //query XML to get all children of Settings--Setting
                dynamic y = doc.Element(XMLConstants.Settings).Elements(XMLConstants.Setting);

                //create settings object from values in
                var _with2 = sharedSets;
                //SettingsXML 
                _with2.SettingsXML = filename;

                ////exception
                //_with2.EmailNotificationsOn = exceptions.EmailNotificationsOn;
                //_with2.RecordToDataBase = exceptions.RecordToDataBase;
                //_with2.ExceptionRecipient = exceptions.ExceptionRecipient;

                ////client
                //_with2.SystemUserID = new Guid(UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.SystemUserID));
                //_with2.ApplicationName = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.ApplicationName);
                //_with2.Client = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.CLIENT);

                //_with2.ClientAsset = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.ClientAsset);
                //_with2.ClientLogo = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.ClientLogo);
                //_with2.ClientUnit = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.ClientUnit);

                ////Q & A filename
                //_with2.QAFilename = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.QAFilename);

                ////units filename
                //_with2.UnitsXMLFilename = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.UnitsXMLFilename);

                ////demo
                //_with2.TotalLoginsAllowed = UtilsShared.GetNumberInt(UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.TotalPeriodAllowed));
                //_with2.NumberOfLogins = UtilsShared.GetNumberInt(UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.NumberOfLogins));
                // _with2.ApplicationsXML = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.ApplicationsXML);


                // _with2.TagMatchingXml = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.TagMatchingXml);
                //_with2.InstallationDemoXML = UtilsShared.GetSettingValueUsingLINQ(y, XMLConstantsShared.InstallationDemoXML);

                return sharedSets;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("AppSettings.vb: EXCEPTION in GetAppSettings: " + XMLConstants.DEBUG_ERROR);
                return null;
            }
        }


        #endregion

    }
}
