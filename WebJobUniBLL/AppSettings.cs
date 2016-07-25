using System;
using System.Text;
using System.IO;
using System.Xml.Linq;
using WebJobUniUtils;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using WebJobUniDAL;
using System.Collections.Generic;
using System.Linq;
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

        public const string iTimestamp = "Timestamp";
        public const string iCompanyID = "CompanyID";
        public const string iEmpID = "EmpID";
        public const string iServID = "ServID";
        public const string iuserID = "UserID";
        public const string iApptID = "ApptID";

        //Client
        public Guid SystemUserID { get; set; }
        public string ApplicationName { get; set; }
        public string Client { get; set; }
        public string ClientAsset { get; set; }
        public string ClientLogo { get; set; }
        public string ClientUnit { get; set; }

        public string Currency { get; set; }
        public string InstallationXML { get; set; }
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
                ExceptionHandling.LogException(ref ex);
                return false;
            }
        }

        public static Guid? GetUserIDByUserName(string userName) {
            try {
                return AspNetUser.GetUserIDByUserName(userName);
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }

        #region "Installation Summary XML File "       
        public static XmlDocument GetInstallationSummaryXML(Installation i, string fileName) {
            try {

                //create XML file                
                XmlDocument xmlDoc = QueryXML.OpenFile(fileName);
                XDocument xDoc = XDocument.Parse(xmlDoc.OuterXml);
                //get xml file timestamp
                var xTimestamp = from key in xDoc.Descendants(AppSettings.iTimestamp) select key.Value;
                DateTime? xFileTimestamp = Utils.GetDateFromString(xTimestamp.ToList().First());
                if (xFileTimestamp == null || DateTime.Compare((DateTime)xFileTimestamp, i.Timestamp) != 0)
                    xmlDoc = CreateNewInstallSummaryXML(fileName);

                //get given installation timestamp
                DateTime curInstTimestamp = i.Timestamp;
                //add to xml
                xmlDoc = AddNode2ISummaryXML(fileName, AppSettings.iTimestamp, curInstTimestamp.ToString());

                //get company
                int curInstCoID = (int)i.Company.ID;
                //add to xml
                xmlDoc = AddNode2ISummaryXML(fileName, AppSettings.iCompanyID, curInstCoID.ToString());

                // Loop through all employees
                int tempStaffID = 0;
                for (int a = 0; a < i.Employees.Count - 1; a++) {
                    EmployeeBLL employee = i.Employees[a];
                    //get staff ID
                    tempStaffID = (int)employee.ID;
                    //add to xml
                    xmlDoc = AddNode2ISummaryXML(fileName, AppSettings.iEmpID, tempStaffID.ToString(), a);
                }

                // Loop through all services
                int tempServID = 0;
                for (int b = 0; b < i.Services.Count - 1; b++) {
                    ServicesBLL service = i.Services[b];
                    //get service ID
                    tempServID = (int)service.ID;
                    //add to xml
                    xmlDoc = AddNode2ISummaryXML(fileName, AppSettings.iServID, tempServID.ToString(), b);
                }

                // Loop through all endUsers
                int tempEndUserID = 0;
                for (int c = 0; c < i.EndUsers.Count - 1; c++) {
                    EndUserBLL endUser = i.EndUsers[c];
                    //get endUser ID
                    tempEndUserID = (int)endUser.ID;
                    //add to xml
                    xmlDoc = AddNode2ISummaryXML(fileName, AppSettings.iuserID, tempEndUserID.ToString(), c);
                }
                //still add EndUser parent node if users dont exist this point
                if (i.EndUsers.Count == 0)
                    xmlDoc = AddNode2ISummaryXML(fileName, AppSettings.iuserID, String.Empty, 0, addChild: false);


                // Loop through all appointments
                int tempApptID = 0;
                for (int d = 0; d < i.Appointments.Count - 1; d++) {
                    ApptBLL appt = i.Appointments[d];
                    //get appt ID
                    tempApptID = (int)appt.ID;
                    //add to xml
                    xmlDoc = AddNode2ISummaryXML(fileName, AppSettings.iApptID, tempApptID.ToString(), d);
                }
                ////still add appt parent node if users dont exist this point
                if (i.Appointments.Count == 0)
                    xmlDoc = AddNode2ISummaryXML(fileName, AppSettings.iApptID, String.Empty, 0, addChild: false);


                //return XML file
                return xmlDoc;

            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }//end GetInstallationSummaryXML
        public static XmlDocument CreateNewInstallSummaryXML(string fileName) {
            try {

                //ie default fileName: "~/App_Data/ISummaryXML.xml"                

                //OpenFile handles creating a new file 
                XmlDocument iSumXMLdoc = QueryXML.CreateBlankFile(fileName, rootName: "Installation");

                //save document           
                iSumXMLdoc.Save(fileName);

                //return xmlDocument
                return iSumXMLdoc;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }//end CreateISummaryXML

        public static XmlDocument AddNode2ISummaryXML(string fileName, string perform, string value2Add, int index = 0, bool addChild = true) {
            try {

                //OpenFile handles new file 
                XmlDocument xdoc = QueryXML.OpenFile(fileName, rootName: "Installation");

                //declare parent Names
                string parentName = "";
                string parentValue = "";
                string childName = "";
                string childValue = "";

                bool addparent = true;
                //only allow 1 child Parent to be added once
                if (index != 0)
                    addparent = false;

                //set parent Names
                switch (perform) {
                    case iTimestamp:
                        // case operations
                        parentName = iTimestamp;
                        parentValue = value2Add;
                        addChild = false;
                        break;
                    case iCompanyID:
                        // case operations
                        parentName = iCompanyID;
                        parentValue = value2Add;
                        addChild = false;
                        break;
                    case iEmpID:
                        // case operations
                        parentName = "Employees";
                        childName = iEmpID;
                        childValue = value2Add;
                        break;
                    case iServID:
                        // case operations
                        parentName = "Services";
                        childName = iServID;
                        childValue = value2Add;
                        break;
                    case iuserID:
                        // case operations
                        parentName = "EndUsers";
                        childName = iuserID;
                        childValue = value2Add;
                        break;
                    case iApptID:
                        // case operations
                        parentName = "Appointments";
                        childName = iApptID;
                        childValue = value2Add;
                        break;
                        //   default:
                        // Do nothing
                }

                //Add parents to xml file
                if (addparent)
                    xdoc = QueryXML.AddChild2Root(filename: fileName, childName: parentName, childIValue: parentValue);
                if (addChild)
                    xdoc = QueryXML.AddChild2LastChild(filename: fileName, childName: childName, childIValue: childValue);

                //save document           
                xdoc.Save(fileName);

                return xdoc;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }//end AddNode2ISummaryXML

        public static XmlDocument AddChild2ISummaryXML(string fileName, string perform, string value2Add) {
            try {

                //OpenFile handles new file 
                XmlDocument xdoc = QueryXML.OpenFile(fileName, rootName: "Installation");

                //declare parent Names
                string parentName = "";
                string childName = "";
                string childValue = "";

                //set parent Names
                switch (perform) {
                    case iuserID:
                        // case operations
                        parentName = "EndUsers";
                        childName = iuserID;
                        childValue = value2Add;
                        break;
                    case iApptID:
                        // case operations
                        parentName = "Appointments";
                        childName = iApptID;
                        childValue = value2Add;
                        break;
                        //   default:
                        // Do nothing
                }

                xdoc = QueryXML.AddChild2SpecificNode(filename: fileName, parentName: parentName, childName: childName, childIValue: childValue);

                //save document           
                xdoc.Save(fileName);

                return xdoc;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }//end AddNode2ISummaryXML

        public static List<int> GetIDsList(XmlDocument iSumXmlDoc, string perform) {
            try {
                //convert to XDoc         
                XDocument xDoc = XDocument.Parse(iSumXmlDoc.OuterXml);
                //check file is not null
                xDoc = xDoc ?? new XDocument();

                string id2Search = "";

                //select ID according to given parameter
                switch (perform) {
                    case iTimestamp:
                        // case operations
                        id2Search = iTimestamp;                       
                        break;
                    case iCompanyID:
                        // case operations
                        id2Search = iCompanyID;
                        break;
                    case iEmpID:
                        // case operations
                        id2Search = iEmpID;
                        break;
                    case iServID:
                        // case operations
                        id2Search = iServID;
                        break;
                    case iuserID:
                        // case operations
                        id2Search =  iuserID;
                        break;
                    case iApptID:
                        // case operations
                        id2Search = iApptID;
                        break;
                        //   default:
                        // Do nothing
                }

                //ie:   get NatureBusiness code
                //  var indElem = from key in xmlDocument.Descendants("ID") where key.Parent.Element("Name").Value == natureOfBus select key.Value;

                //  var items = from key in xDoc.Descendants("Time") where key.ElementsAfterSelf.items[0].Value == "Busy"  select key.Value select key.value;
                var items = from key in xDoc.Descendants(id2Search) select key.Value;

                //convert items to list 
                List<string> stringItems = items.ToList();

                //convert to ints
                List<int> intIDs = new List<int>();
                // ... Loop with the foreach string.
                foreach (string idStrg in stringItems) {
                    System.Diagnostics.Debug.Print(id2Search +"\t ID: \t" + idStrg);
                    //convert to int and add to list
                    intIDs.Add((int)Utils.GetNumberInt(idStrg));
                }

                return intIDs;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return new List<int>();
            }
        }//end AddNode2ISummaryXML

        #endregion
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
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
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

                return _with1.ToString();

            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
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
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex); return null;
            }
        }


        #endregion

    }
}
