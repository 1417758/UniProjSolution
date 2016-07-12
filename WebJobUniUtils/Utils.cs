using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using Microsoft.Office.Interop;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
//using Ionic.Utils.Zip;
using System.Xml;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using WebJobUniUtils;
using System.Windows.Forms;

//------------------------------------------------------------------------------------------------------
// <copyright file="Utils.vb" company="">
// Copyright (c) Rachie Holding Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------------------------------
namespace WebJobUniUtils {
    public class Utils {


        /// <summary>
        /// Function to return the integer value of an enumeration
        /// </summary>
        /// <param name="_enum">Enum to work with</param>
        /// <param name="value">The value we're looking for</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int? GetEnumIntValue(Type _enum, string value) {

            try {
                dynamic intVal = (int)Enum.Parse(_enum, value);
                return intVal;

            }
            catch (Exception ex) {

                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #region "Guid"
        public static bool IsGuid(string guidString) {
            bool bResult = false;
            try {
                bResult = true;
            }
            catch {
                bResult = false;
            }

            return bResult;
        }
        /// <summary>
        /// returns test asp.net User ID corresponding to rachelASPcreated
        /// </summary>
        /// <returns></returns>
        public static Guid? GetASP_UserID() {
            try {
                Guid userID = new Guid("9091A8A7-1460-4F22-B95D-81061CF358E7");
                return userID;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>BLL.AppSettings.GetASP_UserID() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// convert string to GUID
        /// </summary>
        /// <param name="aspUserID"></param>
        /// <returns></returns>
        public static Guid? GetASP_UserID(string aspUserID) {
            try {
                Guid userID = new Guid(aspUserID);
                return userID;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>BLL.AppSettings.GetASP_UserID(aspUserID) </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool? GetBooleanFromString(string s) {
            try {
                if (s == null)
                    return false;

                else if (string.IsNullOrEmpty(s))
                    return false;

                else if (s.ToLower() == "true")
                    return true;

                else if (s.ToLower() == "false")
                    return false;
                else
                    return false;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #region "LINQ"
        /// <summary>
        /// Helper Function For reading XML elements named "Setting" from a settings file. XML to read is in format
        /// <Setting SettingID="RecordToDataBase" Value="True"/>
        /// </summary>
        /// <param name="y">List of XElements</param>
        /// <param name="settingName">Setting name to get Value of</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetSettingValueUsingLINQ(IEnumerable<XElement> y, string settingName) {
            try {
                dynamic result = null; // (from c in y where c.Attribute(XMLConstants.SETTING_ID).Value == settingName c.Attribute(XMLConstants.Value));
                dynamic value = result.FirstOrDefault();
                if (value != null) {
                    return value.Value;
                }
                else {
                    throw new Exception("Error in GetSettingValueUsingLINQ: setting name " + settingName + " does not exist!");
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Utils.Utils.GetSettingValueUsingLINQ() \n" + ex.Message);
                return null;
            }
        }
        #endregion

        #region "String"

        /// <summary>
        /// Capitalise the first letter in a string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string CapitilizeFirstLetter(ref string text) {
            try {
                // Check for empty string.
                if (string.IsNullOrEmpty(text)) {
                    return string.Empty;
                }
                // Return char and concat substring.
                return char.ToUpper(text[0]) + text.Substring(1);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetStringFromStringArray(int index, string[] array) {
            if (index > array.Length - 1 || array.Length == 0)
                return "";
            else
                // here += yearArray(c)
                return array[index];

        }

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/system.string.trimend(VS.80).aspx
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetValueApartFromLastVBCRLF(string value) {
            if (value.Length > 0) {
                value = value.TrimEnd("\n".ToCharArray());
                return value;
            }
            else {
                return value;
            }
        }
        #endregion

        #region "Numbers"

        public static double RoundDownToNearest(double value, int nearest) {
            double y = Math.Round(value / nearest) * nearest - nearest;
            return y;
        }

        public static double RoundUpToNearest(double value, int nearest) {
            double y = Math.Round(value / nearest) * nearest + nearest;
            return y;
        }



        /// <summary>
        /// Remove trailing 0's from strings (note these are ONLY trailing zeros being those AFTER 
        /// decimal point that are not required)
        /// </summary>
        /// <param name="formattedValue">e.g. 0, 0.1, -0.1, 1.00, 1.000, 1,000,000</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string RemoveEndingZeros(string formattedValue) {
            //s = Regex.Replace(s, "(\.?[0]+$)", "") 'regex not work for thousands separators
            //Return s
            //Return NormalizeDouble(s) 'normalise can put E for thousancd

            //there is a decimal place in value, so check for extra 0's
            if (formattedValue.Contains(".")) {
                //there is a decimal place and value ends in "0" so must be extra decimal
                while (formattedValue.EndsWith("0")) {
                    formattedValue = formattedValue.Substring(0, formattedValue.Length - 1);
                }

                if (formattedValue.EndsWith(".")) {
                    formattedValue = formattedValue + "0";
                }
            }
            return formattedValue;
        }

        public static string NormalizeDouble(string s) {
            double v = 0;
            if (double.TryParse(s, out v))
                s = v.ToString("g");
            return s;
        }

        /* /// <summary>
         /// Format number as a string with 'correct' number of decimal places
         /// and with thousand separators
         /// </summary>
         /// <param name="number"></param>
         /// <returns></returns>
         /// <remarks></remarks>
         public static dynamic GetNumberFormatted(double number) {
             if (number == XMLConstants.ERROR_247) {
                 return double.NaN;
             }

             //convert negative numbers to positive and remember (will be converted back at end)
             bool numberLessThanZero = false;
             if (number < 0) {
                 //number is less than 0
                 numberLessThanZero = true;
                 //make number positive
                 number = number * -1;
             }

             string formattedValue = null;
             if (number == 0.0) {
                 return 0;
             }
             else if (number < 1E-09) {
                 formattedValue = String.FormatNumber(number, 12, TriState.True);
             }
             else if (number < 1E-08) {
                 formattedValue = Strings.FormatNumber(number, 11, TriState.True);
             }
             else if (number < 1E-06) {
                 formattedValue = Strings.FormatNumber(number, 10, TriState.True);
             }
             else if (number < 1E-05) {
                 formattedValue = Strings.FormatNumber(number, 9, TriState.True);
             }
             else if (number < 0.0001) {
                 formattedValue = Strings.FormatNumber(number, 8, TriState.True);
             }
             else if (number < 0.001) {
                 formattedValue = Strings.FormatNumber(number, 7, TriState.True);
             }
             else if (number < 0.01) {
                 formattedValue = Strings.FormatNumber(number, 6, TriState.True);
             }
             else if (number < 0.1) {
                 formattedValue = Strings.FormatNumber(number, 5, TriState.True);
             }
             else if (number < 0) {
                 formattedValue = Strings.FormatNumber(number, 4, TriState.True);
             }
             else if (number < 1) {
                 formattedValue = Strings.FormatNumber(number, 3, TriState.True);
             }
             else if (number < 10) {
                 formattedValue = Strings.FormatNumber(number, 2);
             }
             else if (number < 100) {
                 formattedValue = Strings.FormatNumber(number, 1);
             }
             else if (number < 1000) {
                 formattedValue = Strings.FormatNumber(number, 0, TriState.True);
             }
             else {
                 formattedValue = Strings.FormatNumber(number, 0, TriState.True);
             }

             //append negative if required
             if (numberLessThanZero) {
                 formattedValue = "-" + formattedValue;
             }

             //remove surplus zeros AFTER decimal points, 
             //note this works and does not simply remove trailing zeros (like convent 1000 to 1)
             formattedValue = RemoveEndingZeros(formattedValue);

             return formattedValue;
         }*/




        public static bool IsNumeric(string strgNumb) {
            //Source: http://www.codeproject.com/Articles/16329/C-Equivalent-of-VB-s-IsNumeric
            ////Parse throws ArgumentNullExceptionint
            //ie: dynamic result1 = Int32.Parse(null);
            ////Convert doesn't throw an exception, returns 0
            //ie:int result2 = Convert.ToInt32(null);
            //String.IsNullOrEmpty(value) value.Trim().Length == 0; //White - space
            if (!String.IsNullOrEmpty(strgNumb))
                if (Convert.ToDouble(strgNumb) != 0)
                    return true;
                else
                    return false;
            return false;
        }

        /// <summary>
        /// Get number if it is numeric else return NaN
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static double GetNumber(string strgNumb) {
            //is the string an actual number
            if (IsNumeric(strgNumb)) {
                //is numb the error code
                if (strgNumb.Equals(XMLConstants.ERROR_247))
                    return double.NaN;
                else
                    //is numeric return double value
                    return Convert.ToDouble(strgNumb);
            }
            else
                return double.NaN;
        }

        public static double GetNumberDouble(string x) {
            return GetNumber(x);
        }

        public static Int16? GetNumberShort(string x) {
            if (IsNumeric(x))
                return Int16.Parse(x);
            else
                return null;
        }



        public static Int32? GetNumberInt(string x) {
            if (IsNumeric(x))
                return Int32.Parse(x);
            else
                return null;
        }



        /// <summary>
        /// Return a value if it is valid and not XMLConstantsShared.ERROR_247, otherwise return 0.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static double GetNumberIfItIsValidNotNaNorNeg247(double x) {
            if (double.IsNaN(x) || double.IsInfinity(x) || double.IsPositiveInfinity(x) || double.IsNegativeInfinity(x) || x == -247) {
                return 0;
            }
            else {
                return x;
            }
        }



        /// <summary>
        /// Get "number", ignores  infinity values
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static double GetNumber(double number) {
            if (double.IsNaN(number) || double.IsNegativeInfinity(number) || double.IsPositiveInfinity(number))
                return 0;
            else
                return number;
        }


        /// <summary>
        /// Remove non-numeric characters from a string and return a value of type double.
        /// If the string is empty or has no numbers, zero is returned.
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static double RemoveNonNumeric(string originalString) {
            //return 0 for nulls or empty strings
            if (originalString == null)
                return 0;
            else if (string.IsNullOrEmpty(originalString.Trim()))
                return 0;

            //replace all numbers in Period string using regular expression. Removes all text sure as "Period x" when user has entered "Period x"
            //replace all inputs that match specific regular expression with empty string
            //Dim number As String = Regex.Replace(originalString, pattern, replacement)
            string numberString = Regex.Replace(originalString, "[^0-9]", "");
            //convert number to string if numeric, otherwise return 0
            if (!IsNumeric(numberString)) {
                return 0;
            }

            // TryParse() will return true or false, depending on whether the
            // conversion worked or not.
            // Parse() will raise an exception if the conversion failed
            try {
                return double.Parse(numberString);
            }
            catch (Exception ex) {
                throw new Exception("PROBLEM WITH RECORD \t" + numberString);
                return 0;
            }

        }

        /// <summary>
        /// Check an array to see if it contains any non-zero numbers.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static object ContainsNonZero(List<string> list) {
            int i;
            for (i = 0; i <= list.Count - 1; i++) {
                if (list[i] != "0") {
                    return true;
                }
            }

            return false;

        }
        #endregion

        #region "Arrays and Lists"

        /// <summary>
        /// Reverse an array
        /// </summary>
        /// <param name="coefficientsDouble"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static double[] ReverseArray(double[] coefficientsDouble) {
            double[] reversedArray = new double[coefficientsDouble.Length];
            int x;
            for (x = 0; x <= coefficientsDouble.Length - 1; x++) {
                dynamic reversedIndex = coefficientsDouble.Length - 1 - x;
                reversedArray[reversedIndex] = coefficientsDouble[x];
            }

            return reversedArray;
        }

        /// <summary>
        /// Create a List of double from an array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<double> ConvertDoubleArrayToList(double[] data) {
            try {
                List<double> dataList = new List<double>();
                int i;
                for (i = 0; i <= data.Length - 1; i++) {
                    dataList.Add(data[i]);
                }
                return dataList;
            }
            catch (Exception ex) {
                return null;
            }
        }

        /// <summary>
        /// Create array of points each equally spaced.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="points">Number of points</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static double[] GetEquallySpacedArray(double min, double max, int points) {
            double[] equallySpacedArray = new double[points];
            double spacing = (max - min) / (points - 1);
            equallySpacedArray[0] = min;
            equallySpacedArray[points - 1] = max;
            for (int i = 1; i <= points - 1; i++) {
                equallySpacedArray[i] = min + i * spacing;
            }

            return equallySpacedArray;

        }

        /// <summary>
        /// takes a string with multiple IDs separated by comma and return a list of IDs (short)
        /// </summary>
        /// <param name="stringOfIDs"></param>
        /// <returns></returns>
        /// <remarks></remarks>
    /*    public static List<short> GetIDsFromString(string stringOfIDs) {
            try {
                List<short> PIe2IDLi = new List<short>();
                //check string contains multiple IDs separated by coma
                if (stringOfIDs.Contains(",")) {
                    //split string items into array of string
                    dynamic tagsArray = stringOfIDs.Split(", ");
                    //convert array to list of string 
                    dynamic tags = tagsArray.ToList;
                    Debug.Print(tags.Last);

                    //'remove last item if empty
                    //If tags.Last = " " OrElse tags.Last = "" Then
                    //    tags.RemoveAt(tags.Count - 1)
                    //    Debug.Print(tags.Count)
                    //End If

                    //add ids to list
                    foreach (object PIE2UID_loopVariable in tags) {
                        PIE2UID = PIE2UID_loopVariable;
                        //dont add items that r  empty
                        if (PIE2UID != " " && !string.IsNullOrEmpty(PIE2UID)) {
                            PIe2IDLi.Add(Utils.GetNumberShort(Strings.Trim(PIE2UID)));
                        }
                    }
                }

                return PIe2IDLi;

            }
            catch (Exception ex) {

                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }*/

        #endregion

        #region "Date & Time"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime? GetDateFromStringArray(int index, string[] array) {
            if (index > array.Length - 1 || array.Length == 0) {
                return null;
            }
            else {
                //try and parse the string
                DateTime theDate = default(DateTime);
                if (DateTime.TryParse(array[index], out theDate)) {
                    return theDate;
                }
                else {
                    return null;
                }
            }

        }

        /// <summary>
        ///returns the passed date parameter without seconds 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime? GetDateWithNOSeconds(ref DateTime d) {
            try {
                dynamic retDate = Convert.ToDateTime(d.ToString("yyyy-MM-dd HH:mm"));
                //("dd-MM-yyyy HH:mm"))
                System.Diagnostics.Debug.Print(retDate.ToString());


                dynamic r = Convert.ToDateTime(retDate);
                System.Diagnostics.Debug.Print(r);
                return r;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }


        public static DateTime? GetDatetimeNOW() {
            try {
                string nowDateSt = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                System.Diagnostics.Debug.Print(nowDateSt);

                DateTime resultDate = new DateTime();
                DateTime.TryParse(nowDateSt, out resultDate);
                System.Diagnostics.Debug.Print(resultDate.ToString());
                return resultDate;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// convert string to dateTime
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime? GetDateFromString(string dateString) {
            try {
                //try and parse the string
                DateTime theDate = new DateTime();
                if (DateTime.TryParse(dateString, out theDate)) {
                    return theDate;
                }
                else {
                    //nothing returns todays datetime
                    throw new Exception("Utils Class,GetDateFromString Function - invalid parameter " + dateString + " , not a date: ");
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// convert string to date
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime? GetDateFromString2(string dateString) {
            try {
                //try and parse the string
                DateTime theDate = new DateTime();
                if (DateTime.TryParse(dateString, out theDate)) {
                    return DateTime.Parse(theDate.ToString("yyyy-MM-dd"));
                }
                else {
                    //nothing returns todays date and/or default date: "01/01/0001 00:00:00")
                    throw new Exception("Utils Class,GetDateFromString2 Function - invalid parameter " + dateString + " is NOT a valid date: ");
                }

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "Date Processing / Counting"

        /// <summary>
        /// Count number of lines in a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Count_LineCount(string s) {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(s);
            MemoryStream ms = new MemoryStream(bytes);

            int lines = 0;
            lines = Count_LineCount(ms);
            return lines;
        }

        /// <summary>
        /// Count number of lines in a memory stream
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int Count_LineCount(MemoryStream ms) {
            StreamReader sr = new StreamReader(ms);
            int myLineCount = 0;

            while (sr.ReadLine() != null) {
                myLineCount += 1;
            }

            sr.Close();
            sr.Dispose();

            return myLineCount;
        }

        /// <summary>
        /// Count number of decimal places.
        /// </summary>
        /// <param name="double1"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int CountDecimalPlaces(double double1) {
            return double1.ToString().Substring(double1.ToString().IndexOf(".") + 1).Length;
        }

        public static int CountNoOfDaysInYear(int year) {

            try {
                dynamic IsLeapYear = 0;

                if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) {
                    IsLeapYear = 1;
                }

                return 365 + IsLeapYear;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }

        public static int CountNoOfDaysInMonth(int month, int year) {
            try {
                dynamic lastDM = LastDayOfMonth(month, year);
                dynamic firstDM = new DateTime(year, month, 1);

                return CountDifferenceDays(lastDM, firstDM);


            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }
        /// <summary>
        /// returns the number of days from the beginning of the year up to given date
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int CountNoOfDaysSoFar(DateTime d) {
            try {
                dynamic year = d.Year;
                DateTime startDate = FirstDayOfYear(year);
                //System.Diagnostics.Debug.Print("timestamp: " & d & vbTab & "year: " & year & vbTab & "start date: " & startDate)

                dynamic daysSoFar = (d.Subtract(startDate)).Days + 1;

                return daysSoFar;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Calculate difference in months between two dates.
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int CountDifferenceMonths(DateTime d1, DateTime d2) {
            int M = Math.Abs((d1.Year - d2.Year));
            int months = ((M * 12) + Math.Abs((d1.Month - d2.Month)));
            return months;
        }


        /// <summary>
        /// Calculate difference in DAYS between two dates.
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int CountDifferenceDays(DateTime d1, DateTime d2) {

            try {
                int d = (d1 - d2).Days;

                return d + 1;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return 0;
            }
        }

        /// <summary>
        /// Get the last day of specified month.
        /// </summary>
        /// <param name="currentMonth"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime LastDayOfMonth(DateTime currentMonth) {
            dynamic endDate = new DateTime(currentMonth.Year, currentMonth.Month, 1).AddMonths(1).AddDays(-1);
            return endDate;
        }

        /// <summary>
        /// Get the last day of specified month.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DateTime LastDayOfMonth(int month, int year) {
            dynamic endDate = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            return endDate;
        }

        /// <summary>
        /// Get last day of the specified year.
        /// </summary>
        public static DateTime LastDayOfYear(int year) {
            DateTime time = new DateTime(year + 1, 1, 1);
            return time.AddDays(-1);
        }

        /// <summary>
        /// Get first day of the specified year.
        /// </summary>
        public static DateTime FirstDayOfYear(int year) {
            return new DateTime(year, 1, 1);
        }

        #endregion

        #region "Units"   
        /*    
        /// <summary>
        /// Remove /day and /d from a unit, to give the total of unit over period 
        /// e.g. replace b/d with b
        /// </summary>
        /// <param name="dailyUnit"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetTotalUnitFromDailyUnit(ref string dailyUnit) {
            if (dailyUnit == null) {
                return "";
            }
            else {
                dynamic removedDay = dailyUnit.Replace("/d", "");

                return removedDay;
            }
        }

        public static string ValidateDailyUnit(ref string unit, DateTime startDate, DateTime endDate) {

            try {
                if ((startDate.Month != endDate.Month) || startDate.Year != endDate.Year) {
                    return Utils.GetTotalUnitFromDailyUnit(ref unit);
                }
                else {
                    return unit;
                }

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print( ex.ToString());
                return null;
            }
        }
        */
        #endregion

        #region "Exception Handling - proxy to Exception handling class"
        /*  /// <summary>
          /// uses systemID
          /// </summary>
          /// <param name="ex"></param>
          /// <returns></returns>
          /// <remarks></remarks>
          public static string SendEmailException(ref Exception ex) {
              return ExceptionHandling.sendEmailException(ex);
          }

          public static void LogException(ref System.Exception exception) {
              ExceptionHandling.LogException(exception);
          }

          public static void LogException(ref System.Exception exception, string userName) {
              ExceptionHandling.LogException(exception, userName);
          }

          public static void LogException(ref System.Exception exception, string userName, string pageOrFormName, string queryString = "", string referer = "") {
              ExceptionHandling.LogException(exception, userName, pageOrFormName, queryString, referer);
          }
          */
        #endregion

        #region "Data tables & DataSets"
        /// <summary>
        /// "Converts" a tab delimited string into a dataset
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static DataSet GetDataSetFromString(string s) {
            try {
                DataSet ds = new DataSet("DataSetName");
                /*   ds.Tables.Add(new DataTable("DataToSave"));
                  string[] LineArr = s.Split(Constants.vbCrLf);

                  //add enough columns for data
                  string fieldname = null;

                  //for every row
                  DataRow NewDataRow = null;
                  for (x = 0; x <= LineArr.Length - 1; x++) {
                      //split row into String array 
                      string[] y = LineArr[x].Split(Constants.vbTab);

                      //add columns til there are enough
                      while (y.Length > ds.Tables["DataToSave"].Columns.Count) {
                          fieldname = "Field" + ds.Tables["DataToSave"].Columns.Count + 1;

                          ds.Tables["DataToSave"].Columns.Add(new DataColumn(fieldname, typeof(string)));
                      }

                      //create new row with tab separated data
                      NewDataRow = ds.Tables["DataToSave"].NewRow();

                      //populate row fields with text
                      for (int z = 0; z <= y.Length - 1; z++) {
                          fieldname = "Field" + z + 1;
                          NewDataRow[fieldname] = y[z];
                      }

                      ds.Tables["DataToSave"].Rows.Add(NewDataRow);
                  }
                  */
                return ds;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Check if column exists in a Data Table
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool ColumnExists(DataTable Table, string ColumnName) {
            bool bRet = false;
            foreach (DataColumn col in Table.Columns) {
                if (col.ColumnName == ColumnName) {
                    bRet = true;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }

            return bRet;
        }

        /// <summary>
        /// Summarise data table into monthly data if date range is greater than 1 month,
        /// </summary>
        /// <param name="fulldata"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="IsAverage"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /*    public static DataTable GetDataTableSummaried(DataTable fulldata, DateTime startDate, DateTime endDate, bool isAverage = false) {

                try {
                    if (fulldata == null || fulldata.Rows.Count == 0) {
                        throw new Exception("fullDataTable parameter is empty or has no rows, please check dates and pie2ID that populate this dataTable exist on the database!");
                    }

                    DataTable summaryDT = new DataTable("SummaryTable");
                    DataRow summaryDR = null;
                    dynamic moreThanAMonth = "";

                    //NOTE: when filling in missing data, if end date is > last date in SQL timestamp table, take last date in timestamp
                    dynamic lastInSQL = TimeStamp_Shared.GetLatestTimeStamp();
                    if (DateTime.Compare(endDate, lastInSQL) == 1) {
                        endDate = lastInSQL;
                    }

                    dynamic firstInSQL = TimeStamp_Shared.GetFirstTimeStamp;
                    if (DateTime.Compare(startDate, firstInSQL) == -1) {
                        startDate = firstInSQL;
                    }

                    dynamic d = startDate;
                    bool firstRound = true;

                    double[] totalLi = new double[fulldata.Columns.Count + 1];


                    //System.Diagnostics.Debug.Print("dataTable parameter has: " & fulldata.Rows.Count & " rows, " & vbTab & "fullDataTable parameter has: " & fulldata.Columns.Count & " columns.")

                    //for each dataTable parameter column add it to summary data table - create summary table
                    for (i = 0; i <= fulldata.Columns.Count - 1; i++) {
                        //create new column, this will create DateTimeField column followed by all the other columns e.g. PIE2_123
                        dynamic colName = fulldata.Columns[i].ColumnName;
                        summaryDT.Columns.Add((new DataColumn(colName)));
                    }

                    //depending on period of time data is summed
                    //more than a month
                    if ((startDate.Month != endDate.Month) || startDate.Year != endDate.Year) {
                        //System.Diagnostics.Debug.Print("MORE THAN A MONTH!!!")
                        moreThanAMonth = XMLConstantsShared.YES;

                        //add the data for every month
                        while (d <= endDate) {
                            //now populate sum of data
                            //new row
                            summaryDR = summaryDT.Rows.Add();
                            //fill in DateTimeField column - format as a Month Year
                            summaryDR[0] = d.ToString("MMM yy");

                            //fill in every column of data
                            //note if its the 1st column it isn't summed (start at index 1)

                            for (i = 1; i <= fulldata.Columns.Count - 1; i++) {
                                //data column so do sum of column
                                dynamic colIndex = i;

                                //get sum per month
                                //check where the column 0 is not nothing (date/time) and also value not error code -247
                                dynamic sum = (from a in fulldata.Rowsawhere a[0] != null && a[colIndex].ToString() != XMLConstantsShared.ERROR_247 && DateTime.Parse(a[0]).Month == d.Month && DateTime.Parse(a[0]).Year == d.Year).Sum(x => x.Field<double>(colIndex));
                            //render sum or calculate average 
                            if (isAverage) {
                                dynamic numDaysMonth = (from a in fulldata.Rowsawhere a[0] != null && DateTime.Parse(a[0]).Month == d.Month && DateTime.Parse(a[0]).Year == d.Year).Count;

                                //Debug.Print(numDaysMonth)
                                summaryDR[i] = sum / numDaysMonth;
                                totalLi[colIndex] += sum / numDaysMonth;
                            }
                            else {
                                summaryDR[i] = sum;
                                totalLi[colIndex] += sum;
                            }

                        }
                        d = d.AddMonths(1);
                    }
                    //Debug.Print(totalLi(1).ToString)
                } else {
                    //less than a month
                    moreThanAMonth = XMLConstantsShared.NO;
                    //System.Diagnostics.Debug.Print("LESS THAN A MONTH!!!")
                    //add the data for every date
                    dynamic rowIndex = 0;
                    while (d <= endDate) {
                        //now populate sum of data
                        //new row
                        summaryDR = summaryDT.Rows.Add();
                        //fill in DateTimeField column - format as a day/month
                        summaryDR[0] = d.ToString("dd/MM/yy");

                        //fill in every column of data
                        //note if its the 1st column it isn't summed (start at index 1)
                        for (i = 1; i <= fulldata.Columns.Count - 1; i++) {
                            //data column so do sum of column
                            dynamic colIndex = i;
                            //set the value - no summing
                            dynamic value = fulldata.Rows[rowIndex][i];

                            if (value == XMLConstantsShared.ERROR_247) {
                                summaryDR[i] = double.NaN;
                            }
                            else {
                                summaryDR[i] = value;
                                totalLi[colIndex] += value;
                            }


                        }

                        rowIndex += 1;

                        d = d.AddDays(1);
                    }
                }

                //Add total 
                DataRow dr_Empty = null;
                dr_Empty = summaryDT.NewRow();
                summaryDT.Rows.Add(dr_Empty);

                //add a new row, labelled "Average" or "Total"
                DataRow dr_total = null;
                dr_total = summaryDT.NewRow();

                //this assumes 1st column is of type datetime, so it doesnt hv a sum
                if (!isAverage) {
                    dr_total[0] = "Total";
                }
                else {
                    dr_total[0] = "Average";
                }

                for (i = 1; i <= fulldata.Columns.Count - 1; i++) {
                    if (isAverage) {
                        dr_total[i] = totalLi[i] / Utils.GetNumberInt((endDate - startDate).Days + 1);
                    }
                    else {
                        //add sum from array
                        dr_total[i] = totalLi[i];
                    }

                }

                summaryDT.Rows.Add(dr_total);

                return summaryDT;



            } catch (Exception ex) {

                    System.Diagnostics.Debug.Print( ex.ToString());
                    return null;
                }*/

        /*
    /// <summary>
    /// sets dataTable column names / titles
    /// </summary>
    /// <param name="fulldata"></param>
    /// <param name="tittlesList"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DataTable SetDataTableTitles(ref DataTable fulldata, List<string> tittlesList) {


        try {
            //System.Diagnostics.Debug.Print("dataTable parameter has: " & fulldata.Rows.Count & " rows, " & vbTab & "fullDataTable parameter has: " & fulldata.Columns.Count & " columns.")
            if (fulldata == null || fulldata.Rows.Count == 0) {
                throw new Exception("fullDataTable parameter is empty or has no rows, please check dates and pie2ID that populate this dataTable exist on the database!");
            }
            //end If fulldata IsNot Nothing AndAlso fulldata.Rows.Count > 0 


            //check Numb of tittlesList items are the same as the dataTable columns
            if (fulldata.Columns.Count == tittlesList.Count) {
                    int i;
                //update dataTable column names
                for (i = 0; i <= tittlesList.Count - 1; i++) {
                    fulldata.Columns[i].ColumnName = tittlesList[i];
                }

            }
            else {
                throw new Exception("Utils Class, SetDataTableTitles Function ERROR: The number of titles provided MUST correspond to the SAME number of the dataTable columns.");
            }

            return fulldata;



        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print( ex.ToString());
            return null;
        }
    }

    /// <summary>
    /// returns a sum of all columns values 
    /// SUMS UP ALL COLUMNS IN ONE ROW and returns a dt with only one column (+ datetime if it exists)
    /// </summary>
    /// <param name="multiColumnDatatable"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DataTable SumUpDatatableColumns(ref DataTable multiColumnDatatable) {
        try {
            //check datatable parameter is valid to sum up 
            if (multiColumnDatatable == null && multiColumnDatatable.Rows.Count > 0 && multiColumnDatatable.Columns.Count < 2) {
                throw new Exception("multiColumnDatatable parameter is empty, has no rows or has only one column, please check given paramenter!");
            }
            //end If fulldata IsNot Nothing AndAlso fulldata.Rows.Count > 0 

            //get given datatables details
            //Debug.Print("*DATA TABLE DETAILS:")
            //Debug.Print("Rows: " & multiColumnDatatable.Rows.Count & vbTab & "Columns: " & multiColumnDatatable.Columns.Count)

            DataTable dt = new DataTable();
            DataRow dr = null;
            dynamic colStartupIndex = 0;
            dynamic colSum = 0.0;
            dynamic addDateTimeCol = false;

            dynamic sumColName = multiColumnDatatable.Columns[0].ColumnName;
            dynamic item1st = multiColumnDatatable.Rows[0][0];
            //check first column item is of date type
            if (Utils.GetDateFromString(item1st.ToString()) != null) {
                //dont sum up 1st column and add this column to return datatable
                dt.Columns.Add(new DataColumn(multiColumnDatatable.Columns[0].ColumnName));
                colStartupIndex = 1;
                addDateTimeCol = true;
                sumColName = multiColumnDatatable.Columns[1].ColumnName;
            }

            //   Debug.Print(sumColName)
            //add sum up column 
            dt.Columns.Add(new DataColumn(sumColName));
            //, GetType(Double)

            //'does table has a total row
            dynamic hasEmptyB4Total = false;
            if (multiColumnDatatable.Rows[multiColumnDatatable.Rows.Count - 1][0].ToString() == "Total") {
                if (string.IsNullOrEmpty(multiColumnDatatable.Rows[multiColumnDatatable.Rows.Count - 2][0].ToString()) || multiColumnDatatable.Rows[multiColumnDatatable.Rows.Count - 2][0].ToString() == " ") {
                    hasEmptyB4Total = true;
                }
            }
                int x;
            //loop through rows
            for (x = 0; x <= multiColumnDatatable.Rows.Count - 1; x++) {
                dynamic row = multiColumnDatatable.Rows[x];
                dr = dt.NewRow();
                //reset colSum
                colSum = 0.0;
                    int i;
                //loop through multiColumnDatatable columns
                for (i = colStartupIndex; i <= multiColumnDatatable.Columns.Count - 1; i++) {
                    //sum up column values
                    colSum += Utils.GetNumberDouble(row(i).ToString);
                }

                //dont add sum to empty row
                if (x == multiColumnDatatable.Rows.Count - 2 && hasEmptyB4Total) {
                    //Debug.Print("empty row, so not adding sum")
                    dr[sumColName] = "";
                }
                else {
                    dr[sumColName] = colSum;
                }

                //add datetime column if parameter also contains it
                if (addDateTimeCol) {
                    dr[0] = row.Item(0);
                }

                dt.Rows.Add(dr);
            }

            return dt;

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print( ex.ToString());
            return null;
        }
    }

    /// <summary>
    /// ADD ALL COLUMNS OF DT2 (EXCEPT COLUMN 1 DATETIME, IF ANY) TO DT1.
    /// NUMBER OF ROWS MUST BE THE SAME IN BOTH DATATABLES BEFORE THEY CAN BE COMBINED
    /// 1st datatable is kept in the same form ONLY second dt columns are added 
    /// </summary>
    /// <param name="datatable1"></param>
    /// <param name="datatable2"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DataTable CombinedDatatableCOLS(ref DataTable datatable1, ref DataTable datatable2) {

        try {
            if (datatable1 == null || datatable1.Rows.Count == 0 || datatable2 == null || datatable2.Rows.Count == 0) {
                throw new Exception("datatable1 and/or datatable2 given as parameter is/are empty or has no rows, please check given paramenters!");
            }


            //'combine inputs and outputs data
            //Debug.Print("*DETAILS OF INPUTS DATA TABLE:")
            //Debug.Print("Rows:" & vbTab & datatable1.Rows.Count & vbTab & "Columns: " & datatable1.Columns.Count)

            //Debug.Print("*DETAILS OF OUTPUTS DATA TABLE:")
            //Debug.Print("Rows:" & vbTab & datatable2.Rows.Count & vbTab & "Columns: " & datatable2.Columns.Count)

            //only combine tables if numb of rows are the same
            if (datatable1.Rows.Count != datatable2.Rows.Count) {
                throw new Exception("datatable1 and datatable2 have different number of rows! so they can NOT be combined!");
            }

            //PLEASE NOTE DT1 FORMAT IS KEPT THE SAME
            DataTable actualDataDatatable = datatable1;
            dynamic colStartupIndex = 0;
            dynamic dt1Cols = datatable1.Columns.Count;
            dynamic dt2_1stItem = datatable2.Rows[0][0];

            //check if first column item is of date type
            if (Utils.GetDateFromString(dt2_1stItem.ToString()) != null) {
                //dont need to add/repeat this column (ASSUMES THAT dt1 already has this column)
                colStartupIndex = 1;
                actualDataDatatable.Columns[0].ColumnName = "Period";
            }


            //loop through datatable2 columns
            for (i = colStartupIndex; i <= datatable2.Columns.Count - 1; i++) {
                //add dt2 remaining columns 
                dynamic dt2currColName = datatable2.Columns[i].ColumnName;
                //check whether column name already exists
                if (!Utils.ColumnExists(actualDataDatatable, dt2currColName)) {
                    actualDataDatatable.Columns.Add(new DataColumn(dt2currColName));
                }
                else {
                    actualDataDatatable.Columns.Add(new DataColumn(dt2currColName + " tb2"));
                }

            }

            dynamic index = 0;
                int j;
            //loop through return datatable rows
            for (i = 0; i <= actualDataDatatable.Rows.Count - 1; i++) {
                index = colStartupIndex;
                dynamic row = actualDataDatatable.Rows[i];
                //add data to new added columns
                for (int j = dt1Cols; j <= actualDataDatatable.Columns.Count - 1; j++) {
                    row.Item(j) = datatable2.Rows[i][index];
                    index += 1;
                }

            }


            //Debug.Print("Actual data row count: " & vbTab & actualDataDatatable.Rows.Count)
            //Debug.Print("Actual data col count: " & vbTab & actualDataDatatable.Columns.Count)

            return actualDataDatatable;


        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print( ex.ToString());
            return null;
        }
    }

    /// <summary>
    /// ADD ROWS OF ALL DTS TO DT1
    /// NUMBER OF COLUMNS MUST BE THE SAME IN ALL DATATABLES BEFORE THEY CAN BE COMBINED
    /// 1st datatable is kept in the same form ONLY remaining dts rows are added 
    /// </summary>
    /// <param name="ds"></param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DataTable CombinedDatatableROWS(ref DataSet ds) {

        try {
            if (ds == null || ds.Tables.Count < 2) {
                throw new Exception("datatable1 and/or datatable2 given as parameter is/are empty or has no rows, please check given paramenters!");
            }

            //PLEASE NOTE DT1 FORMAT IS KEPT THE SAME
            DataTable actualDataDatatable = ds.Tables[0];
            dynamic dt0_numbCols = actualDataDatatable.Columns.Count;

            for (i = 1; i <= ds.Tables.Count - 1; i++) {
                dynamic dt = ds.Tables[i].Copy();

                //only combine tables if numb of columns are the same
                if (dt0_numbCols != dt.Columns.Count) {
                    Debug.Print("CombinedDatatableROWS Function ERROR: " + dt.TableName + "have different number of columns! so it can NOT be combined to " + actualDataDatatable.TableName);
                }
                else {
                    //add all rows of current dt
                    foreach (DataRow row in dt.Rows) {
                        actualDataDatatable.Rows.Add(row.ItemArray);
                    }
                }

            }

            return actualDataDatatable;


        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print( ex.ToString());
            return null;
        }
    }

    /// <summary>
    /// Create data table with input values that are out of range.  
    /// Note this works for the Inputs.xml not Outputs.xml - it could be modified to handle Outputs, too.
    /// </summary>
    /// <param name="inputs">table from SQL with list of Inputs</param>
    /// <param name="tagMatchingDT">table generated from Inputs.xml with info on all the inputs tags</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static DataTable GetDataTableWithValuesOutOfRange(DataTable inputs, DataTable tagMatchingDT) {
        try {
            //create a copy of this Inputs table;  add fields Max, Min and Out of Range
            dynamic dtWithValidation = inputs.Clone();
            var _with1 = dtWithValidation.Columns;
            _with1.Add(XMLConstantsShared.MAX);
            _with1.Add(XMLConstantsShared.MIN);
            _with1.Add(XMLConstantsShared.OUT_OF_RANGE);


            //for each row in Inputs data table check if Value is in or out of range
            double max = 0;
            double min = 0;
            double theValue = 0;
            foreach (DataRow r in inputs.Rows) {
                //get the PIE2UID
                dynamic PIE2UID = r["PIE2_I_ID"];

                //get details of the Max, Min for this PIE2ID
                //NOTE: Expect this is the slow part of code;  could use a hash table say rather than always querying a datatable
                DataRow PIE2UID_Info = (from x in tagMatchingDT.Rowswhere x.item(XMLConstantsShared.PIE2UID) == PIE2UIDx).FirstOrDefault;
                //end of slow section?

                //get the max and min values, this comes from the XML file
                var _with2 = PIE2UID_Info;
                max = _with2.Item(XMLConstantsShared.MAX_VALUE);
                min = _with2.Item(XMLConstantsShared.MIN_VALUE);

                //get the actual value in data row
                theValue = r[XMLConstantsShared.Value];

                //check if the value is within or out of range
                if (theValue > max || theValue < min) {
                    dynamic dr = dtWithValidation.Rows.Add(r.ItemArray);
                    var _with3 = dr;
                    _with3.Item(XMLConstantsShared.MAX) = max;
                    _with3.Item(XMLConstantsShared.MIN) = min;
                    _with3.Item(XMLConstantsShared.OUT_OF_RANGE) = "OUT OF RANGE";
                }
                else {
                    //DO NOTHING AS VALUE IS IN RANGE
                    //dr.Item(XMLConstantsShared.OUT_OF_RANGE) = ""
                }
            }

            return dtWithValidation;

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print( ex.ToString());
            return null;
        }
    }

    /// <summary>
    /// Return true or false for valid date. 
    /// 
    /// Uses Textboxes opposed to Strings to allow textboxes to be shown
    /// 
    /// Displays any errors on error label
    /// </summary>
    /// <param name="ErrorLabel">error label</param>
    /// <param name="txtStartDate">start date input textbox</param>
    /// <param name="txtEndDate">end date input textbox</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public static bool ValidateDates(Label ErrorLabel, TextBox txtStartDate, TextBox txtEndDate) {
        try {
            //results
            DateTime StartDate = default(DateTime);
            DateTime EndDate = default(DateTime);

            //valid start date text? if not set to first date in year
            if (DateTime.TryParse(txtStartDate.Text, out StartDate) == false) {
                txtStartDate.Text = new DateTime(DateTime.Now.Year, 1, 1);
            }

            //valid end date text? if not set to now
            if (DateTime.TryParse(txtEndDate.Text, out EndDate) == false) {
                txtEndDate.Text = DateTime.Now.ToShortDateString();
            }

            //Check if Start Date > Last day of data
            dynamic lastDayDate = TimeStamp_Shared.GetLatestTimeStamp;
            if (DateTime.Compare(StartDate, lastDayDate) == 1) {
                ErrorLabel.Text = "Start Date must be less than Last Date of data (" + lastDayDate.ToShortDateString + ")";
                ErrorLabel.Visible = false;

                //exit function
                return false;
            }

            //Check if Start Date > End Date
            if (DateTime.Compare(StartDate, EndDate) == 1) {
                ErrorLabel.Text = "Start Date must be less than End Date";
                ErrorLabel.Visible = false;
                return false;
            }

            //Check if Start Date < First Date of data
            dynamic firstDayData = TimeStamp_Shared.GetFirstTimeStamp;
            if (DateTime.Compare(StartDate, firstDayData) == -1) {
                ErrorLabel.Text = "Start Date must be greater than First Date of data (" + firstDayData.ToShortDateString + ")";
                ErrorLabel.Visible = false;
                return false;
            }

            //Check if End Date > Last Date of data
            if (DateTime.Compare(EndDate, lastDayDate) == 1) {
                ErrorLabel.Text = "End Date must be less than Last Date of data (" + lastDayDate.ToShortDateString + ")";
                ErrorLabel.Visible = false;
                return false;
            }

            //only get here if dates are valid
            ErrorLabel.Text = "";
            ErrorLabel.Visible = false;
            return true;

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print( ex.ToString());
        }
    }
        */
        #endregion

        #region "File and XML"
        /*
        /// <summary>
        /// Format XML nicely for debug.
        /// </summary>
        /// <param name="doc"></param>
        /// <remarks></remarks>
        public static string FormatXML(XmlDocument doc) {
            try {
                using (StringWriter sw = new StringWriter()) {
                    // Make the XmlTextWriter to format the XML.
                    using (XmlTextWriter xml_writer = new XmlTextWriter(sw)) {
                        xml_writer.Formatting = Formatting.Indented;
                        doc.WriteTo(xml_writer);
                        xml_writer.Flush();

                        // Display the result.
                        return sw.ToString();
                    }
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print( ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Returns formatted xml string (indent and newlines) from unformatted XML
        /// string for display in eg textboxes.
        /// </summary>
        /// <param name="sUnformattedXml">Unformatted xml string.</param>
        /// <returns>Formatted xml string and any exceptions that occur.</returns>
        public static string FormatXml(StringBuilder sUnformattedXml) {
            //load unformatted xml into a dom
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXml.ToString());

            //will hold formatted xml
            StringBuilder sb = new StringBuilder();

            //pumps the formatted xml into the StringBuilder above
            StringWriter sw = new StringWriter(sb);
            //does the formatting
            XmlTextWriter xtw = null;

            try {
                //point the xtw at the StringWriter
                xtw = new XmlTextWriter(sw);
                //we want the output formatted
                xtw.Formatting = Formatting.Indented;
                //get the dom to dump its contents into the xtw 
                xd.WriteTo(xtw);
            }
            finally {
                //clean up even if error
                if (xtw != null) {
                    xtw.Close();
                }
            }

            //return the formatted xml
            return sb.ToString();
        }



        /// <summary>
        /// Convert a byte array into string.
        /// </summary>
        /// <param name="bytData"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetStringFromByteArray(byte[] bytData) {
            try {
                MemoryStream ms = new MemoryStream(bytData);
                dynamic fileXMLContents = GetStringFromMemoryStream(ms);

                return fileXMLContents;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print( ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Convert a memory stream into string.
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetStringFromMemoryStream(MemoryStream ms) {
            try {
                dynamic sr = new StreamReader(ms);
                dynamic fileXMLContents = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                ms.Close();
                ms.Dispose();

                return fileXMLContents;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print( ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Convert a zip file into string
        /// </summary>
        /// <param name="zip2"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetStringFromZipFile(ref ZipFile zip2) {
            try {
                MemoryStream ms = new MemoryStream();
                zip2(0).Extract(ms);
                ms.Position = 0;
                dynamic fileXMLContents = GetStringFromMemoryStream(ms);
                return fileXMLContents;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print( ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Return text in XML file (unzip if necessary)
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string LoadFile(string filename) {
            try {
                //get file contents from saved file, either XML or ZIP (containing XML)
                string fileXMLContents = null;
                //ZIP file
                if (filename.EndsWith(".zip")) {
                    //read the zip file
                    using (zip2 == ZipFile.Read(filename)) {
                        fileXMLContents = GetStringFromZipFile(ref zip2);
                    }
                }
                else {
                    //read (normal) XML file which is not zipped.
                    fileXMLContents = File.ReadAllText(filename);
                }

                return fileXMLContents;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print( ex.ToString());
                return false;
            }
        }

    */
        /// <summary>
        ///  populates the dropdownlist from xml file  
        /// check Testing_UserControls_TestPopulateComboFromXML page for example
        /// </summary>
        /// <param name="xmlFile">PLEASE MAKE SURE FILES USED IN THIS METHOD HAVE NAME AND ID CHILDREN FOR EACH TAG. SEE Countries.xml or months.xml for examples</param>
        /// <param name="comboBox"></param>
        /// <param name="sortByComboText"></param>
        /// <remarks></remarks>
        public static void PopulateDDLFromXMLFile(string xmlFile, ref DropDownList comboBox, string text, string value, bool sortByComboText = false) {
            try {
                //Dim txt = "Name"
                //Dim value = "ID"

                //clear combo items
                comboBox.Items.Clear();

                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);

                //get the dataview of table, which is default table name  
                DataView dv = ds.Tables[0].DefaultView;

                //Now sort the DataView vy column name "Name"  
                if (sortByComboText) {
                    dv.Sort = text;
                }

                //now define datatext field and datavalue field of dropdownlist  
                comboBox.DataTextField = text;
                comboBox.DataValueField = value;

                //now bind the dropdownlist to the dataview  
                comboBox.DataSource = dv;
                comboBox.DataBind();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils. x () </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 9/7 method dedicated to popuating Industries (must review in order to make it generic)
        /// </summary>
        /// <param name="xmlFile">refer to "SIC07CHcondensedList.xml" for xml file structure</param>
        /// <param name="dropDown"></param>
        public static void PopulateComboFromXMLFile(string xmlFile, ref DropDownList dropDown) {
            try {

                if (!File.Exists(xmlFile)) {
                    throw new Exception("<h2>Utils.Utils.PopulateComboFromXMLFile()</h2>\n" + xmlFile + " does not exist!");
                }

                //clear combo items
                dropDown.Items.Clear();

                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);

                //get the dataview of table, which is default table name  
                DataView industries = ds.Tables[0].DefaultView;

                //now define datatext field and datavalue field of dropdownlist  
                dropDown.DataTextField = "Domain";
                dropDown.DataValueField = "UID";

                //now bind the dropdownlist to the dataview  
                dropDown.DataSource = industries;
                dropDown.DataBind();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.Utils.PopulateComboFromXMLFile() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace + "\n" + ex.Message);
            }
        }

        #endregion

    }
}