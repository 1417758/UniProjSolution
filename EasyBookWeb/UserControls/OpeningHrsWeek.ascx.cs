using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebJobUniUtils;

public partial class UserControls_OpeningHrsWeek : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {
        // if (!IsPostBack)
        //ApplyDefault(new List<int>, new List<int>);
    }

    #region "Get Functions"
    public List<bool> GetOpeningDays() {
        try {
            List<bool> openingDays = new List<bool>();
            //loop through page all controls
            foreach (Control ctrl in this.Controls) {
                if (ctrl is RadioButtonList) {
                    //select a radioButtonList
                    RadioButtonList rbl = (RadioButtonList)ctrl;
                    //loop through items of the current radioButtonList
                    for (int i = 0; i < rbl.Items.Count; i++) {
                        if (rbl.Items[i].Selected) {
                            //get the text value of the selected radio button
                            //System.Diagnostics.Debug.Print(rbl.Items[i].Text);
                            //System.Diagnostics.Debug.Print(rbl.Items[i].Value);
                            //add to return list
                            openingDays.Add(Utils.GetBooleanFromString(rbl.Items[i].Value));
                        }//end inner if
                    }//end forloop
                }//endif
            }//end foreach
            return openingDays;
        }
        catch (Exception exc) {
            System.Diagnostics.Debug.Print("<h2>AddServicesUserControl.ascx, AddService()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
            // Log the exception and notify system operators
            ExceptionUtility.LogException(exc, "AddServicesUserControl.ascx, AddService()");
            ExceptionUtility.NotifySystemOps(exc);
            return null;
        }

    }
    public List<int> GetOpeningHourInt() {
        List<int> openingHr = new List<int>();
        openingHr.Add(this.OpeningHrsMonday.GetOpeningHourInt());
        openingHr.Add(this.OpeningHrsTuesday.GetOpeningHourInt());
        openingHr.Add(this.OpeningHrsWednesday.GetOpeningHourInt());
        openingHr.Add(this.OpeningHrsThursday.GetOpeningHourInt());
        openingHr.Add(this.OpeningHrsFriday.GetOpeningHourInt());
        openingHr.Add(this.OpeningHrsSaturday.GetOpeningHourInt());
        openingHr.Add(this.OpeningHrsSunday.GetOpeningHourInt());

        return openingHr;
    }

    public List<int> GetClosingHourInt() {
        List<int> closingHr = new List<int>();
        closingHr.Add(this.OpeningHrsMonday.GetClosingHourInt());
        closingHr.Add(this.OpeningHrsTuesday.GetClosingHourInt());
        closingHr.Add(this.OpeningHrsWednesday.GetClosingHourInt());
        closingHr.Add(this.OpeningHrsThursday.GetClosingHourInt());
        closingHr.Add(this.OpeningHrsFriday.GetClosingHourInt());
        closingHr.Add(this.OpeningHrsSaturday.GetClosingHourInt());
        closingHr.Add(this.OpeningHrsSunday.GetClosingHourInt());

        return closingHr;
    }


    public List<string> GetOpeningHour() {
        List<string> openingHr = new List<string>();
        openingHr.Add(this.OpeningHrsMonday.GetOpeningHour());
        openingHr.Add(this.OpeningHrsTuesday.GetOpeningHour());
        openingHr.Add(this.OpeningHrsWednesday.GetOpeningHour());
        openingHr.Add(this.OpeningHrsThursday.GetOpeningHour());
        openingHr.Add(this.OpeningHrsFriday.GetOpeningHour());
        openingHr.Add(this.OpeningHrsSaturday.GetOpeningHour());
        openingHr.Add(this.OpeningHrsSunday.GetOpeningHour());

        return openingHr;
    }

    public List<string> GetClosingHour() {
        List<string> closingHr = new List<string>();
        closingHr.Add(this.OpeningHrsMonday.GetClosingHour());
        closingHr.Add(this.OpeningHrsTuesday.GetClosingHour());
        closingHr.Add(this.OpeningHrsWednesday.GetClosingHour());
        closingHr.Add(this.OpeningHrsThursday.GetClosingHour());
        closingHr.Add(this.OpeningHrsFriday.GetClosingHour());
        closingHr.Add(this.OpeningHrsSaturday.GetClosingHour());
        closingHr.Add(this.OpeningHrsSunday.GetClosingHour());

        return closingHr;
    }



    #endregion

}