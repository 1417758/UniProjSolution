using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniBLL;

public partial class UI_EndUser_BookAppt : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            PopulateUserControlsFromSession();
    }

    public void PopulateUserControlsFromSession() {
        try {
            //Get installation from session             
            Installation i = WebUtils.GetInstallationObjectFromSession();

            //services
            List<string> servNames = InstallationBLL.GetServiceDetailsFull(i);
            this.ServiceSelectionUserControl.PopulateServices(servNames);
            //Staff
            List<string> staffNames = InstallationBLL.GetStaffNames(i);
            this.StaffSelectionUserControl.PopulateStaff(staffNames);

            //date&time



            //End-user Details

            //Payment

        }
        catch (Exception ex) {
            System.Diagnostics.Debug.Print("<h2>BookAppt.aspx, PopulateUserControlsFromSession Method</h2>\n" + ex.ToString() + "\n" + ex.InnerException + "\n" + ex.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(ex, "BookAppt.aspx, PopulateUserControlsFromSession Method");
            ExceptionUtility.NotifySystemOps(ex);
        }
    }




}//class