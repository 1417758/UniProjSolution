using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WebJobUniDAL;
using WebJobUniUtils;

namespace WebJobUniBLL {
    public class DayScheduleXML {

        public static string STAFF_DAYSCHEDULEXML_FILENAME;

        /// <summary>
        /// Either Returns the XMLDocument or full fileName created (including file path) depending on isFileNameReq parameter passed
        /// by default ist returns the xmlDoc
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="agendaID"></param>
        /// <param name="date"></param>
        /// <param name="isFileNameReq"></param>
        /// <returns></returns>
        public static dynamic CreateDayScheduleXML(string filePath, short? agendaID, DateTime date, bool isFileNameReq = false) {
            try {
                string staff1stName = EmployeeBLL.GetStaffByAgendaID(agendaID, isFirstName: true);
                string staffFilePath = filePath + "/" + staff1stName;

                //ie default filePath: "~/App_Data/DailySchedules/"
                if (!Directory.Exists(staffFilePath)) {
                    Directory.CreateDirectory(staffFilePath);
                }

                string staffDaySchedXMLFileName = staffFilePath + "/" + date.ToString("yyyy_MM_dd") + ".xml";
                STAFF_DAYSCHEDULEXML_FILENAME = staffDaySchedXMLFileName;

                //OpenFile handles creating a new file 
                XmlDocument xdoc = QueryXML.OpenFile(staffDaySchedXMLFileName, rootName: "DailySchedule");

                //get root element
                XmlElement root = xdoc.DocumentElement;

                //add attributes to root node
                root.SetAttribute(name: "AgendaID", value: agendaID.ToString());
                root.SetAttribute(name: "Date", value: date.ToString("yyyy_MM_dd"));
                xdoc.AppendChild(root);

                //save document           
                xdoc.Save(staffDaySchedXMLFileName);

                //if required on parameter return fileName 
                if (isFileNameReq)
                    return staffDaySchedXMLFileName;
                //return xmlDocument
                return xdoc;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }//end CreateDayScheduleXML

        /// <summary>
        /// Adds a new appointment child to DailySchedule XML
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="isBusy"></param>
        /// <returns></returns>
        public static XmlDocument AddApptNode2DayScheduleXML(string fileName, DateTime date, int time, bool isBusy = true) {
            try {
                //set booking status to BUSY
                string bookStatus = DaySchedule.GetDayStatusEnumString(DayStatusEnum.BUSY);
                if (!isBusy)
                    //set booking status to AVAILABLE
                    bookStatus = DaySchedule.GetDayStatusEnumString(DayStatusEnum.AVAILABLE);

                //OpenFile handles new file 
                XmlDocument xdoc = QueryXML.OpenFile(fileName);

                xdoc = QueryXML.AddChild2Root(filename: fileName, childName: "Booking");
                xdoc = QueryXML.AddChild2LastChild(filename: fileName, childName: "Time", childIValue: time.ToString());
                xdoc = QueryXML.AddChild2LastChild(filename: fileName, childName: "Status", childIValue: bookStatus);

                //save document           
                xdoc.Save(fileName);

                return xdoc;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }//end AddAppt2DayScheduleXML

        public static XmlDocument Add_ID_2DayScheduleXML(string fileName, string dayScheduleID) {
            try {

                if (!String.IsNullOrEmpty(fileName)) {
                    //OpenFile handles new file 
                    XmlDocument xdoc = QueryXML.OpenFile(fileName);

                    //get root element
                    XmlElement root = xdoc.DocumentElement;

                    //add attributes to root node
                    root.SetAttribute(name: "ID", value: dayScheduleID.ToString());
                    xdoc.AppendChild(root);

                    //save document           
                    xdoc.Save(fileName);

                    //return xmlDocument
                    return xdoc;
                }
                //if fileName is invalid
                return null;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }//end AddAppt2DayScheduleXML

        /// <summary>
        ///Returns the XMLDocument created from staff daily Shedule
        /// it returns fileName by default
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="filePath"></param>
        /// <param name="date"></param>
        /// <param name="isFileNameReq"></param>
        /// <returns></returns>
        public static XmlDocument CreateXMLFromDaySchedule(EmployeeBLL employee, string filePath, DateTime date) {
            try {
                //get staff's agenda calendar
                SerializableDictionary<DateTime, DaySchedule> staffCalendar = employee.agenda.staffCalendar;
                //get staff day schedule for given day
                DaySchedule employeeDaySchedule = AgendaBLL.GetDaySchedule(ref staffCalendar, date);

                //create XML file
                XmlDocument xdoc = new XmlDocument();
                string fileName = DayScheduleXML.CreateDayScheduleXML(filePath, employee.agenda.ID, date, isFileNameReq: true);

                if (employeeDaySchedule != null) {

                    //loop through day schedule. ie: each hr and 1/h of the staff agenda
                    foreach (var pair in employeeDaySchedule.daySchedule) {

                        //get time and availability
                        int tempTime = pair.Key; //ie: 1100, 1130
                        string tempTimeStatus = pair.Value; //ie BUSY, AVAILABLE
                        System.Diagnostics.Debug.Print("Key: {0},  Value: {1}", tempTime, tempTimeStatus);


                        //check if staff is busy 
                        if (pair.Value == DaySchedule.GetDayStatusEnumString(DayStatusEnum.BUSY))

                            //Add child to xml / appointment  
                            xdoc = DayScheduleXML.AddApptNode2DayScheduleXML(fileName, date, tempTime);
                    }//endforloop
                }//endif
                else {
                    //staff daySchedule is empty so enable all buttons
                    System.Diagnostics.Debug.Print("<h2>BLL.DayScheduleXML.CreateXMLFromDaySchedule()</h2> \t  staff daySchedule is empty!");
                    return null;
                }

                //return XML file
                return xdoc;
            }
            catch (Exception ex) {
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }//end CreateDayScheduleXML

        public static List<int> GetTimesFromDayScheduleXML(XDocument xDoc) {
            try {
                // //load file
                //  var xmlDocument = XDocument.Load("fileName");

                //select booking time tags
                //get NatureBusiness code
                //  var indElem = from key in xmlDocument.Descendants("ID") where key.Parent.Element("Name").Value == natureOfBus select key.Value;

                //  var items = from key in xDoc.Descendants("Time") where key.ElementsAfterSelf.items[0].Value == "Busy"  select key.Value select key.value;
                var items = from key in xDoc.Descendants("Time") select key.Value;
                
                //convert items to list 
                List<string> stringItems = items.ToList();

                //convert to ints
                List<int> intItems = new List<int>();
                // ... Loop with the foreach string.
                foreach (string value in stringItems) {
                    System.Diagnostics.Debug.Print(value);
                    //convert to int and add to list
                    intItems.Add((int)Utils.GetNumberInt(value));                    
                }

                return intItems;


            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>BLL.DaySheculeXML.GetTimesFromDayScheduleXML(xdoc)</h2>\n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.ToString() );
                // Log the exception and notify system operators
                ExceptionHandling.LogException(ref ex);
                return null;
            }
        }

    }//class
}//namespace
