using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_OpeningHrs : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            ApplyDefault();
    }

    #region "Get Functions"   
    public string GetOpeningHour() {
        return this.hoursOpening.GetHour();
    }

    public string GetClosingHour() {
        return this.hoursClosing.GetHour();
    }

    public int GetOpeningHourInt() {
        return this.hoursOpening.GetHourInt();
    }

    public int GetClosingHourInt() {
        return this.hoursClosing.GetHourInt();
    }

    #endregion


    protected void ApplyDefault(int hrOpen=8, int hrClose=5) {
        try {
            //set labels
            this.hoursOpening.SetHourLabel("am");
            this.hoursClosing.SetHourLabel("pm");

            //set times
            this.hoursOpening.SetDefaultHour(hrOpen);
            this.hoursClosing.SetDefaultHour(hrClose);
        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>OpeningHrs.ascx, ApplyDefault()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "OpeningHrs.ascx, ApplyDefault()");
            ExceptionUtility.NotifySystemOps(exc);
        }
    }//ApplyDefault


}//class