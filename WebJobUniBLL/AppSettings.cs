using System;
using System.Text;
using System.IO;
using System.Xml.Linq;
using WebJobUniUtils;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using WebJobUniDAL;
//------------------------------------------------------------------------------------------------------
// <copyright file="AppSettings.vb" company="">
// Copyright (c) Rachie Holdings Ltd. All rights reserved.
// </copyright>
//----
namespace WebJobUniBLL { 
    public class AppSettings {

        #region "Public Variables"
        public static XmlSerializer oXS = new XmlSerializer(typeof(Installation));

        public static AppSettings Settings;
        //Client
        public Guid SystemUserID { get; set; }
        public string ApplicationName { get; set; }
        public string Client { get; set; }
        public string ClientAsset { get; set; }
        public string ClientLogo { get; set; }
        public string ClientUnit { get; set; }

        public string Currency { get; set; }
        //used on DEMOs only (per user)
        public int TotalBookingsAllowed { get; set; }
        public int NumberOfLogins { get; set; }
        public string ApplicationsXML { get; set; }
        public string TagMatchingXml { get; set; }
        public string UnitsXMLFilename { get; set; }

        public string InstallationDemoXML { get; set; }

        public string SettingsXML { get; set; }

        #endregion

        #region "Functions"
        public static bool IsUserOfType(string aspUserName, bool isTypeClient = false, bool isTypeEndUser = false) {
            try {
                //get aspUserID
                Guid aspUserID = (Guid)AppSettings.GetUserIDByUserName(aspUserName);              
                var curUser = ClientBLL.GetPersonByASPuserID(aspUserID);
                byte curUserRole = 0;
                
                // get curUser ROLE
                if (curUser != null)
                    curUserRole = (byte)curUser.Rows[0].ItemArray[5];

                //check parameters condition which applys
                if (isTypeClient) {
                    if (curUserRole == (byte)RolesEnum.CLIENT)
                        return true;
                }

                if (isTypeEndUser) {
                    if (curUserRole == (byte)RolesEnum.END_USER)
                        return true;
                }

                //for now 18/7/16  --- anything else return false
                return false;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>BLL.InstallationBLL.IsUserOfType(x2)</h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return false;
            }
        }
        public static Guid? GetUserIDByUserName(string userName) {
            try {                
                return AspNetUser.GetUserIDByUserName(userName);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>BLL.AppSettings.GetUserIDByUserName() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// Get data from SQL to populate installation object.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="doc">Serialized installation object</param>
        /// <param name="dt">data table passed (empty) will be populated with tags being read</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Installation GetPopulatedInstallationObject(System.DateTime d, ref XmlDocument doc, ref DataTable dt) {
            try {
                /*   InstallationXML.GetPopulatedInstallationObject(d, doc, dt, SharedSettings.Settings.InputsXML);

                   //recreate installation object from doc, the doc nodes have been modified with Tag values
                   //basically deserialize
                   dynamic i = InstallationBLL.GetFromXMLDocument(doc);

                   //TODO: set timestamp to correct one...it is the MAX of all timestamps retrieved,
                   //not necessarily what is queried.
                   i.TimeStamp = d;

                   return i;*/
                //R
                return null;
            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>BLL.AppSettings.GetPopulatedInstallationObject() EXCEPTION </h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                return null;
            }
        }

        /// <summary>
        /// Convert an Installation object into XMLDocument.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument GetAsXMLDocument(ref Installation i) {
            try {
                //Dim t As New TimerUtil("5 GetAsXMLDocument (returns an XMLDocument from Installation)")
                //t.startTimer()
                //working ~20sec
                XmlDocument doc = new XmlDocument();
                MemoryStream stream = new MemoryStream();
                AppSettings.oXS.Serialize(stream, i);
                stream.Position = 0;
                doc.Load(stream);
                stream.Flush();
                stream.Close();
                stream = null;

                //  t.endTimer()
                //Debug.Print("5 Created XML Document length: " & vbTab & doc.InnerXml.Length)
                //Debug.Print(t.outputDetails())


                //Dim f As New StreamWriter("C:\GetAsXMLDocument5.xml", FileMode.Create)
                //f.Write(doc.InnerXml)
                //f.Flush()
                //f.Close()

                return doc;

            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>AppSettings.vb: EXCEPTION in GetAsXMLDocument:</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                return null;
            }
        }

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
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>Error in BLL.AppSettings.ToString() </h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
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
                    System.Diagnostics.Debug.Print("BLL.AppSettings.GetAppSettings(): EXCEPTION in GetAppSettings: FileNotFoundException: " + filename);
                    throw new FileNotFoundException("Exception in BLL.AppSettings.GetAppSettings()" + filename + " cannot be found /  accessed");
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
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>AppSettings.vb: EXCEPTION in GetAppSettings: </h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                return null;
            }
        }


        #endregion

    }
}
