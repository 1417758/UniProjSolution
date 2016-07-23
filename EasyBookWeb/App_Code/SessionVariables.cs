using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebJobUniBLL;
using WebJobUniUtils;

namespace EasyBookWeb {
    public class SessionVariables {

       
        public static string Username {
            get { return HttpContext.Current.User.Identity.Name; }
        }

        public static string EndUserURL {
            get { return "UI/EndUser/WelcomeUser.aspx"; } //("~/UI/EndUser/WelcomeUser.aspx"); }
        }
        public static string TempStaffFolder {
            get { return HttpContext.Current.Server.MapPath("~/App_Data/DailySchedules/"); }
        }

        public static string TempUserFolder {
            get { return HttpContext.Current.Server.MapPath("~/App_Data/SavedFiles/" + Username + "/temp/"); }
        }
        public static string ErrorFolder {
            get { return HttpContext.Current.Server.MapPath("~/Error/ErrorLogs/"); }
        }
        public static string HttpErrorPage {
            get { return HttpContext.Current.Server.MapPath("~/Error/HttpError.aspx"); }
        }
        public static int? CompanyID {
            get { return (int?)HttpContext.Current.Session["CompanyID"]; }
            set { HttpContext.Current.Session["CompanyID"] = value; }
        }

        public static string IndAndNatBusinessXML {
            get {
                /* //test get path from web.config
                 string indAppSet = ConfigurationSettings.AppSettings["IndandBusNatXML"];
                 System.Diagnostics.Debug.Print(indAppSet);*/
                return HttpContext.Current.Server.MapPath("~/App_Data/SIC07CHcondensedList.xml");
            }
        }

        public static string HourXml {
            get { return HttpContext.Current.Server.MapPath("~/App_Data/Hours.xml"); }
        }
        public static string TitlesXml {
            get { return HttpContext.Current.Server.MapPath("~/App_Data/Titles.xml"); }
        }

        public static string StartTime {
            get { return (string)HttpContext.Current.Session[XMLConstants.START_TIME]; }
            set { HttpContext.Current.Session[XMLConstants.START_TIME] = value; }
        }

        public static string EndTime {
            get { return (string)HttpContext.Current.Session[XMLConstants.END_TIME]; }
            set { HttpContext.Current.Session[XMLConstants.END_TIME] = value; }
        }

        public static string ApptTimeBttonID {
            get { return (string)HttpContext.Current.Session["ApptTimeBttonID"]; }
            set { HttpContext.Current.Session["ApptTimeBttonID"] = value; }
        }

        public static ApptBLL CURRENT_APPOINTMENT {
            get { return (ApptBLL)HttpContext.Current.Session[XMLConstants.CURRENT_APPT]; }
            set { HttpContext.Current.Session[XMLConstants.CURRENT_APPT] = value; }           
        }
        

    }//class
}//namespace
