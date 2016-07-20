using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobUniBLL {
    public class SampleCalendar : Calendar {

        public Calendar myCal { get; set; }

        //default constructor
        public SampleCalendar() {
            //source: https://msdn.microsoft.com/en-us/library/system.globalization.calendar(v=vs.110).aspx
            // Uses the default calendar of the InvariantCulture.
            this.myCal = CultureInfo.InvariantCulture.Calendar;
        }
       /* public SampleCalendar(DateTime todaysDate) {
            // Sets a DateTime to April 3, 2002 of the Gregorian calendar.
            DateTime myDT = new DateTime(2002, 4, 3, new GregorianCalendar());
        }*/

        public void DisplayValues(DateTime myDT) {
            StringBuilder myStgB = new StringBuilder();
            myStgB.Append(String.Format("   Era:          {0}", this.myCal.GetEra(myDT)));
            myStgB.Append(String.Format("   Year:         {0}", this.myCal.GetYear(myDT)));
            myStgB.Append(String.Format("   Month:        {0}", this.myCal.GetMonth(myDT)));            
            myStgB.Append(String.Format("   DayOfMonth:   {0}", this.myCal.GetDayOfMonth(myDT)));
            myStgB.Append(String.Format("   DayOfWeek:    {0}", this.myCal.GetDayOfWeek(myDT)));
            myStgB.Append(String.Format("   DayOfYear:    {0}", this.myCal.GetDayOfYear(myDT)));
            myStgB.Append(String.Format("   Hour:         {0}", this.myCal.GetHour(myDT)));
            myStgB.Append(String.Format("   Minute:       {0}", this.myCal.GetMinute(myDT)));
            myStgB.Append(String.Format("   Second:       {0}", this.myCal.GetSecond(myDT)));
            myStgB.Append(String.Format("   Milliseconds: {0}", this.myCal.GetMilliseconds(myDT)));
            System.Diagnostics.Debug.Print(myStgB.ToString());
        }

        public override int[] Eras {
            get {
                return this.myCal.Eras;
            }
        }

        public override DateTime AddMonths(DateTime time, int months) {
            throw new NotImplementedException();
        }

        public override DateTime AddYears(DateTime time, int years) {
            throw new NotImplementedException();
        }

        public override int GetDayOfMonth(DateTime time) {
            throw new NotImplementedException();
        }

        public override DayOfWeek GetDayOfWeek(DateTime time) {
            throw new NotImplementedException();
        }

        public override int GetDayOfYear(DateTime time) {
            throw new NotImplementedException();
        }

        public override int GetDaysInMonth(int year, int month, int era) {
            throw new NotImplementedException();
        }

        public override int GetDaysInYear(int year, int era) {
            throw new NotImplementedException();
        }

        public override int GetEra(DateTime time) {
            throw new NotImplementedException();
        }

        public override int GetMonth(DateTime time) {
            throw new NotImplementedException();
        }

        public override int GetMonthsInYear(int year, int era) {
            throw new NotImplementedException();
        }

        public override int GetYear(DateTime time) {
            throw new NotImplementedException();
        }

        public override bool IsLeapDay(int year, int month, int day, int era) {
            throw new NotImplementedException();
        }

        public override bool IsLeapMonth(int year, int month, int era) {
            throw new NotImplementedException();
        }

        public override bool IsLeapYear(int year, int era) {
            throw new NotImplementedException();
        }

        public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) {
            throw new NotImplementedException();
        }
    }
}
