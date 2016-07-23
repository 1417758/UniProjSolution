using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    class ExceptionHandling {


        #region "Public variables"
        public static bool RecordToDataBase = true;

        private static int Number_of_exceptions_sent = 0;
        private static DateTime RecentDateOfException;
        private static int MAX_EXCEPTIONS_TO_SEND_IN_PERIOD = 5;
        private static int REPEAT_TIME_PERIOD_milliseconds = 1 * 60 * 1000;

        #endregion



        #region "Email exceptions"
        /// <summary>
        /// Build "friendly" string error message from an exception.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string BuildErrorMessage(ref Exception ex, string username = "") {
            try {
                StringBuilder details = new StringBuilder();
                details.Append("<p></p>Error message");
                details.Append("<p></p>");
                details.Append(ex.ToString());
                details.Append("<p></p>");

                //details.Append("<p></p>")
                //details.AppendLine("App Domain Friendly Name:")
                //details.AppendLine(AppDomain.CurrentDomain.FriendlyName)


                //details.AppendLine()
                //log exception messages
                if (ex != null) {
                    //details.AppendLine()

                    if (ex.InnerException != null && ex.InnerException.Message != null) {
                        details.Append("<p></p>");
                        details.Append(ex.InnerException.Message);
                        details.Append("<p></p>");
                    }

                    if (ex.StackTrace != null) {
                        details.Append("<p></p>");
                        details.Append(ex.StackTrace);
                        details.Append("<p></p>");
                    }

                }

                //return error message
                return details.ToString();

            }
            catch (Exception ex2) {
                //do nothing if there is an exception logging an exception - really bad!
                System.Diagnostics.Debug.Print("Error in buildErrorMessage \n" + ex2.InnerException + "\n" + ex.Message + "\n" + ex2.StackTrace);
                return "Error in creating Exception message! " + ex.StackTrace;
            }
        }

        /// <summary>
        /// Send email notification that an exception has occurred.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Details of if exception was successful/unsuccessful</returns>
        /// <remarks></remarks>
        /*public static string SendEmailException(ref Exception ex) {

            try {
                if (SharedSettings.Settings == null) {
                    throw new Exception("Shared Settings is empty! this means settings.xml needs to be loaded in the application");
                }
                dynamic exceptionHand = SharedSettings.Settings;



                if (exceptionHand.EmailNotificationsOn) {
                    //create email message
                    MailAddress fromAddress = new MailAddress("errors@pi-e2-software.com", exceptionHand.Client + " " + exceptionHand.ApplicationName + " Exception");

                    string exceptionRecipient = exceptionHand.ExceptionRecipient;
                    MailAddress toAddress = new MailAddress(exceptionRecipient, "To PI-e2 Support");


                    //set email body

                    string Body = "";
                    //= "<html><head>Application Exception</head><body>"
                    Body = Body + "Error on: " + exceptionHand.Client + " " + exceptionHand.ApplicationName + ExceptionHandling.buildErrorMessage(ex);
                    Body = "\n" + "Dear PI-e2 Supporter,<p></p>Unfortunately an exception has occurred on " + exceptionHand.Client + " " + exceptionHand.ApplicationName + " Please check the client's database exceptions table and read the exception below for details.<p></p>" + Body;
                    Body = Body + "<p></p>Regards," + "\n" + "<p></p>PI-e2 developers";
                    //Body = Body & "</body></html>"

                    string Subject = "Error on " + exceptionHand.Client + " " + exceptionHand.ApplicationName;
                    //, sent at " & DateTime.Now.ToString()

                    DeliveryNotificationOptions DeliveryOptions = DeliveryNotificationOptions.OnFailure;
                    System.Net.Mail.MailPriority Priority = MailPriority.Normal;

                    string Attachfile = null;
                    MailAddress bcc = null;
                    MailAddress CC = null;
                    SendMail.Send(Body, Subject, DeliveryOptions, Priority, toAddress, fromAddress, Attachfile, bcc, CC);

                    return "Successfully send email exception";
                }
                return "Settings mean this is not to send an email!";
            }
           catch (Exception ex) {
                //do nothing if there is an exception logging an exception - really bad!
                System.Diagnostics.Debug.Print("Error in sending email exception " + "\n" + ex.StackTrace + "\n" + ex.Message); ExceptionHandling.LogException(ref ex);
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string sendEmailException(ref string message) {
            try {
                if (SharedSettings.Settings == null) {
                    throw new Exception("Shared Settings is empty! this means settings.xml needs to be loaded in the application");
                }
                dynamic exceptionHand = SharedSettings.Settings;

                if (exceptionHand.EmailNotificationsOn) {
                    //create email message
                    string exceptionRecipient = exceptionHand.ExceptionRecipient;
                    MailAddress fromAddress = new MailAddress("pi-e2.Errors@pi-ltd.com", exceptionHand.Client + " " + exceptionHand.ApplicationName + " Exception");
                    MailAddress toAddress = new MailAddress(exceptionRecipient, "To PI-e2 Support");

                    //set email body
                    string Body = message;
                    string Subject = "Message from " + exceptionHand.Client + " " + exceptionHand.ApplicationName + ", sent at " + DateTime.Now.ToString();


                    DeliveryNotificationOptions DeliveryOptions = DeliveryNotificationOptions.OnFailure;
                    System.Net.Mail.MailPriority Priority = MailPriority.Normal;

                    string Attachfile = null;
                    MailAddress bcc = null;
                    MailAddress CC = null;
                    SendMail.Send(Body, Subject, DeliveryOptions, Priority, toAddress, fromAddress, Attachfile, bcc, CC);


                    return "Successfully send email exception";
                }
                return "Settings mean this is not to send an email!";
            }
           catch (Exception ex) {
                //do nothing if there is an exception logging an exception - really bad!
                System.Diagnostics.Debug.Print("Error in sending email exception " + "\n" + ex3.StackTrace + "\n" + ex.Message);  ExceptionHandling.LogException(ref ex);
                return "";
            }
        }*/

        #endregion

        /// <summary>
        /// Log exception to text file.
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="FullPath"></param>
        /// <remarks></remarks>
        //As Boolean
        public static void LogExceptionTextFile(ref string strData, ref string FullPath) {
            try {
                // Get a StreamReader class that can be used to read the file
                System.Diagnostics.Debug.Print("LogException 3:");
                StreamWriter objStreamWriter = null;
                objStreamWriter = File.AppendText(FullPath);


                // Append the the end of the string
                // followed by the current date and time
                objStreamWriter.WriteLine("Exception occurred at: " + System.DateTime.Now.ToString()); // + Strings.Chr(13));
                objStreamWriter.WriteLine(strData);
                objStreamWriter.WriteLine("------------------------------------------------------------");

                // Close the stream
                objStreamWriter.Close();
                objStreamWriter = null;

            }
            catch (Exception ex) {
                //error in logging exception - really bad!
                System.Diagnostics.Debug.Print("Error in LogException" + "\n" + ex.StackTrace + "\n" + ex.Message); ExceptionHandling.LogException(ref ex);
                System.Diagnostics.Debug.Print(ex.StackTrace.ToString());
            }
        }


        #region "Log Exceptions"
        /// <summary>
        /// Function to decide if to log exception or not.
        /// 
        /// Only X exceptions are sent in duration of Y milliseconds.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private static bool LogExceptionOrNot(DateTime TimeNow) {
            try {
                dynamic timeDiff = TimeNow - RecentDateOfException;

                if (Number_of_exceptions_sent == 0) {
                    //System.Diagnostics.Debug.Print("Recent Exception Count is ZERO")
                    RecentDateOfException = TimeNow;
                    Number_of_exceptions_sent += 1;
                    return true;
                }
                else if (timeDiff.Milliseconds >= REPEAT_TIME_PERIOD_milliseconds) {
                    //System.Diagnostics.Debug.Print("Time period is GREATER than " & REPEAT_TIME_PERIOD_milliseconds & " ms. Time period is: " & timeDiff.Milliseconds & " ms")
                    Number_of_exceptions_sent = 0;
                    RecentDateOfException = TimeNow;
                    Number_of_exceptions_sent += 1;
                    return true;
                }
                else {
                    if (Number_of_exceptions_sent < MAX_EXCEPTIONS_TO_SEND_IN_PERIOD) {
                        //System.Diagnostics.Debug.Print("Less than " & MAX_EXCEPTIONS_TO_SEND_IN_PERIOD & " sent in period.  Number sent: " & Number_of_exceptions_sent)
                        Number_of_exceptions_sent += 1;
                        return true;
                    }
                    else {
                        //System.Diagnostics.Debug.Print("Greater than " & MAX_EXCEPTIONS_TO_SEND_IN_PERIOD & " sent in period...not sending")
                        return false;
                    }
                }
            }
            catch (Exception ex) {
                //error in logging exception - really bad!
                return false;
            }
        }


        /// <summary>
        /// use this method if userName is known 
        /// Log exception and send email notification if it is set on in Web.config
        /// </summary>
        /// <param name="exception"></param>
        /// <remarks></remarks>
        public static void LogException(ref System.Exception exception, string userName = "") {
            try {
                //if (SharedSettings.Settings == null) {
                //    throw new Exception("Shared Settings is empty! this means settings.xml needs to be loaded in the application");
                //}
                //      dynamic exceptionHand = SharedSettings.Settings;

                Guid? userID = AppSettings.GetUserIDByUserName(userName);

                if (LogExceptionOrNot(System.DateTime.Now)) {
                    StringBuilder errorMsg = new StringBuilder(ExceptionHandling.BuildErrorMessage(ref exception, userName));
                    StackTrace stacktrace = new StackTrace();
                    dynamic x = ((System.Reflection.MethodBase)stacktrace.GetFrame(1).GetMethod()).ReflectedType;
                    var _with1 = errorMsg;
                    _with1.Append("\n" + x.ToString() + "\n");
                    _with1.Append(stacktrace.GetFrame(1).ToString() + "\n");
                    if (exception.InnerException != null)
                        _with1.Append(exception.InnerException.ToString() + "\n");
                    _with1.Append(exception.Source + "\n");
                    _with1.Append(exception.TargetSite + "\n");
                    if (exception.InnerException != null)
                        System.Diagnostics.Debug.Print("<h2> INNER EXC </h2> \t" + exception.InnerException.ToString());
                    System.Diagnostics.Debug.Print("<h2> MESSAGE </h2> \t" + exception.Message);
                    System.Diagnostics.Debug.Print("<h2> STACK-TRACE </h2> \t" + exception.StackTrace);
                    System.Diagnostics.Debug.Print("<h2> SOURCE </h2> \t" + exception.Source);
                    System.Diagnostics.Debug.Print("<h2> TARGET </h2> \t" + exception.TargetSite);

                    //log exception to text file too
                    //Call LogToTextfile(errorMsg)

                    //log exception to database
                    LogExceptionToDatabase(exception, ExceptionHandling.RecordToDataBase, userID);

                    //send email
                    //           SendEmailException(ref exception);
                }
                else {
                    System.Diagnostics.Debug.Print("Not sending exception as duplicate!" + exception.ToString());
                }

            }
            catch (Exception ex2) {
                //do nothing if there is an exception logging an exception - really bad!
                System.Diagnostics.Debug.Print("Error in LogException" + "\n" + ex2.InnerException + "\n" + ex2.Message + "\n" + ex2.StackTrace);
            }
        }



        /// <summary>
        /// Add exception details to database - extra parameters which are to be added when using this on the website.
        /// 
        /// Connection string is in settings.xml
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="logIt"></param>
        /// <remarks></remarks>
        private static void LogExceptionToDatabase(Exception exc, bool logIt, Guid? userID) {

            try {
                if (logIt) {
                    string innerException = "";
                    if (exc.InnerException == null)
                        innerException = "";
                    else
                        innerException = exc.InnerException.ToString();
                    Exceptions.AddException(System.DateTime.Now, exc.Source, exc.Message.ToString(), innerException, exc.StackTrace.ToString(), exc.TargetSite.ToString(), userID);
                }

            }
            catch (Exception ex) {
                //if there is an invalid UserID an exception happens here (f.k. INSERT if user id is not in asp_users table)
                System.Diagnostics.Debug.Print(ex.ToString() + "\n" + "userID: " + userID.ToString());

                //verify that all parameters are valid, including userID
                System.Diagnostics.Debug.Print("BLL.LogExceptionToDatabase function(). verify that all parameters are valid, including userID");
                System.Diagnostics.Debug.Print(System.DateTime.Now.ToString());
                System.Diagnostics.Debug.Print(ex.Source);
                System.Diagnostics.Debug.Print(ex.InnerException.ToString());
                System.Diagnostics.Debug.Print(ex.Message); ExceptionHandling.LogException(ref ex);
                System.Diagnostics.Debug.Print(ex.TargetSite.ToString());
                System.Diagnostics.Debug.Print(ex.StackTrace.ToString());
                System.Diagnostics.Debug.Print(userID.ToString());
            }
        }

        #endregion
    }
}

