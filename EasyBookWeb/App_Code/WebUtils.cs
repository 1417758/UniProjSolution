using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Diagnostics;
using WebJobUniBLL;
using WebJobUniUtils;
using System.Xml;

namespace EasyBookWeb {
    public sealed class WebUtils : System.Web.UI.Page {

        public static Installation installation;

        public static void PutInstallationObjectinSession(Installation i) {
            try {
                HttpContext.Current.Session[XMLConstants.Session_Installation] = i;

            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>WebUtils, PutInstallationObjectinSession()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                // Log the exception and notify system operators
                ExceptionUtility.LogException(exc, "WebUtils, PutInstallationObjectinSession()");
                ExceptionUtility.NotifySystemOps(exc);

            }
        }
        /// <summary>
        /// Return installation object in session. If it is nothing, attempt
        /// to create it.
        /// 
        /// This will return the user configured installation object if user has been in user config mode.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Installation GetInstallationObjectFromSession() {
            try {
                Installation i = default(Installation);
                i = (Installation)HttpContext.Current.Session[XMLConstants.Session_Installation];

                //if Installation object in session is not nothing, return it
                if (i != null) {
                    //do nothing 
                    //installation is nothing
                }
                else {

                    // i = Installation.GetTestInstallation();
                    i = new Installation();
                    //R  XmlDocument doc = AppSettings.GetAsXMLDocument(ref i);
                    //R i = InstallationBLL.GetPopulatedInstallationObject(TimeStamp_Shared.GetLatestTimeStamp, doc, new DataTable());

                }
                //end  if  i IsNot Nothing Then

                //set InstallationTmeStamp
                SessionVariables.StartTime = i.Timestamp.ToString();

                return i;
            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>WebUtils, GetInstallationObjectFromSession()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                // Log the exception and notify system operators
                ExceptionUtility.LogException(exc, "WebUtils, GetInstallationObjectFromSession()");
                ExceptionUtility.NotifySystemOps(exc);
                return null;
            }
        }
        /*
                /// <summary>
                /// Display default dates or ones from session.
                /// </summary>
                /// <remarks></remarks>
                public static bool SetDefaultDates() {

                    try {
                        //check if start date in session is nothing, if so set it to 3 months ago (or first date if no data 3 months ago)
                        if (HttpContext.Current.Session(SessionConstants.START_DATE) == null) {
                            System.DateTime startDate = new System.DateTime();
                            System.DateTime endDate = new System.DateTime();

                            //Dim threeMonthsAgo = Date.Now.AddMonths(-3)
                            //Dim first = TimeStamp_Shared.GetFirstTimeStamp
                            //If threeMonthsAgo < first Then
                            //    startDate = first
                            //Else
                            //    startDate = threeMonthsAgo
                            //End If
                            //endDate = Date.Now

                            endDate = Inputs.GetLatestInputTimeStamp;
                            startDate = endDate.AddMonths(-3);

                            if (startDate < TimeStamp_Shared.GetFirstTimeStamp) {
                                startDate = TimeStamp_Shared.GetFirstTimeStamp;
                            }


                            HttpContext.Current.Session(SessionConstants.START_DATE) = startDate;
                            HttpContext.Current.Session(SessionConstants.END_DATE) = endDate;
                            return true;
                        }
                        else {
                            //start date in session is NOT nothing therefore show what was picked before
                            return false;
                        }

                    }
                    catch (Exception ex) {
                        UtilsShared.LogException(ex, HttpContext.Current.User.Identity.Name);
                    }
                }

                /// <summary>
                /// Return true if user is a developer or DebugOn is set to true.
                /// </summary>
                /// <returns></returns>
                /// <remarks></remarks>
                public static bool DisplayDebug() {
                    try {
                        //R               Dim userLoggedIn As String = UCase(HttpContext.Current.Session("UserName"))
                        //If UtilsShared.settings.DebugOn = True OrElse _
                        //       userLoggedIn = "RICHARDW" OrElse userLoggedIn = "RACHELA" OrElse userLoggedIn = "ANGUSC" Then
                        //    Return True
                        //Else
                        //    Return False
                        //End If
                    }
                    catch (Exception ex) {
                        UtilsShared.LogException(ex, HttpContext.Current.User.Identity.Name);
                        return false;
                    }
                }


                /// <summary>
                /// Display text on label. Display '-' if not a number etc.
                /// </summary>
                /// <param name="t"></param>
                /// <param name="value"></param>
                /// <param name="dp"></param>
                /// <remarks></remarks>
                public static void SetLabel(ref Label t, double value, int dp) {
                    //If Double.IsInfinity(value) OrElse Double.IsNaN(value) OrElse Double.IsNegativeInfinity(value) OrElse Double.IsPositiveInfinity(value) OrElse value = XMLConstants.ERROR_247 Then
                    //t.Text = "-"
                    //Else
                    t.Text = Strings.FormatNumber(value, dp);
                    //End If
                }

                /// <summary>
                /// check webconfig for path (path of settings.xml e.g. C:\Settings\Emissions Compiler\settings.xml)
                /// </summary>
                /// <returns></returns>
                /// <remarks></remarks>
                public static string GetECSettingsPath() {
                    return ConfigurationManager.AppSettings(XMLConstantsShared.SettingsXML);

                }

                /// <summary>
                /// Get Emissions Compiler settings from settings.xml file
                /// </summary>
                /// <returns></returns>
                /// <remarks></remarks>
                public static EmissionCompilerSettings GetECSettings() {
                    try {
                        //load settings if it isn't already loaded
                        if (EmissionCompilerSettings.settings == null) {
                            EmissionCompilerSettings.settings = EmissionCompilerSettings.LoadEmissionCompilerSettingsFromFile(GetECSettingsPath());
                        }

                        //return settings
                        return EmissionCompilerSettings.settings;

                    }
                    catch (Exception ex) {
                        UtilsShared.LogException(ex, HttpContext.Current.User.Identity.Name);
                        return null;
                    }
                }

               */

        /// <summary>
        /// Taken from MSDN but example calling to find GT control on page didn't work!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Controls"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static T FindControl<T>(System.Web.UI.ControlCollection Controls) where T : class {
            try {
                T found = null;

                if (Controls != null && Controls.Count > 0) {
                    for (int i = 0; i <= Controls.Count - 1; i++) {
                        //System.Diagnostics.Debug.Print(Controls(i).UniqueID)
                        if (Controls[i] is T) {
                            found = Controls[i] as T;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                        else {
                            found = FindControl<T>(Controls[i].Controls);
                        }
                    }
                }

                return found;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>WebUtils Class, FindControl Method</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
                // Log the exception and notify system operators
                ExceptionUtility.LogException(ex, "WebUtils Class, FindControl Method");
                ExceptionUtility.NotifySystemOps(ex);
                return null;
            }
        }

    }//class
}//namespace