using System;
using System.IO;
using System.Web;

namespace EasyBookWeb {
    public sealed class ExceptionUtility {
        // All methods are static, so this can be private 
        private ExceptionUtility() { }

        // Log an Exception 
        public static void LogException(Exception exc, string source) {
            try {
                //get saving location
                string errorFolder = SessionVariables.ErrorFolder;
                //create folder if it doesnt exist
                if (!Directory.Exists(errorFolder)) {
                    Directory.CreateDirectory(errorFolder);
                }
                // Include enterprise logic for logging exceptions 
                // Get the absolute path to the log file 
                string errorLogFileName = "ErrorLog" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                string logFile = errorFolder + errorLogFileName;

                if (logFile.Contains("MemberShip and RoleProvider Demo"))
                    //do nothing
                    System.Diagnostics.Debug.Print("<h2>MemberShip and RoleProvider Demo ERROR, web.config I think.</h2>");
                else {

                    // Open the log file for append and write the log
                    StreamWriter sw = new StreamWriter(logFile, true);
                    sw.WriteLine("********** {0} **********", DateTime.Now);
                    if (exc.InnerException != null) {
                        sw.Write("Inner Exception Type: ");
                        sw.WriteLine(exc.InnerException.GetType().ToString());
                        sw.Write("Inner Exception: ");
                        sw.WriteLine(exc.InnerException.Message);
                        sw.Write("Inner Source: ");
                        sw.WriteLine(exc.InnerException.Source);
                        if (exc.InnerException.StackTrace != null) {
                            sw.WriteLine("Inner Stack Trace: ");
                            sw.WriteLine(exc.InnerException.StackTrace);
                        }
                    }
                    sw.Write("Exception Type: ");
                    sw.WriteLine(exc.GetType().ToString());
                    sw.WriteLine("Exception: " + exc.Message);
                    sw.WriteLine("Source: " + source);
                    sw.WriteLine("Stack Trace: ");
                    if (exc.StackTrace != null) {
                        sw.WriteLine(exc.StackTrace);
                        sw.WriteLine();
                    }
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex) {
                //  Utils.LogException(ex, User.Identity.Name);
                System.Diagnostics.Debug.Print("<h1>ExceptionUtility, CATCH LogException Method</h1>\n" + ex.Message + ex.InnerException + "\n" + "\n" + ex.ToString());
            }
        }

        // Notify System Operators about an exception 
        public static void NotifySystemOps(Exception exc) {
            // Include code for notifying IT system operators
            //Rs ie: email notification
        }
    }
}