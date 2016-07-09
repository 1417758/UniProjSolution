using EasyBookWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_OpeningHrsWeek : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {
        // if (!IsPostBack)
        //ApplyDefault(new List<int>, new List<int>);
    }

    #region "Get Functions"
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