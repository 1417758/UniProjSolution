using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobUniDAL;

namespace WebJobUniBLL {
    public class CompanyBLL : Company {

        #region "Variables"
        public string domain { get; set; }
        public string industry { get; set; }
        public int natureOfBusiness { get; set; }
        public string regNumb { get; set; }
        public DateTime dateIncorporated { get; set; }
        public string url { get; set; }
        public ClientBLL mainClientContact { get; set; }
        public ContactDetailsBLL businessAddress { get; set; }
        public bool isVATreg { get; set; }
        public string VATnumb { get; set; }
        public string notes { get; set; }  
  
        public enum DaysWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
        public enum Months : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };
        public List<int> OpeningTime = new List<int>(7) { 8, 8, 8, 8, 8, 8, 8 };
        public List<int> ClosingTime = new List<int>(7) { 5, 5, 5, 5, 5, 5, 5 };
        public List<bool> OpeningDays = new List<bool>(7) { true, true, true, true, true, false, false };
        #endregion

        //default constructor
        public CompanyBLL() {
            this.businessAddress = new ContactDetailsBLL();
            this.mainClientContact = new ClientBLL();
        }

        public CompanyBLL(string _domain, string _industry, int _natOfBusiness, string _regNumb, DateTime _dateIncorporated, string _url, bool _isVATreg, string _VATnumb, string _notes) {
            this.domain = _domain;
            this.industry = _industry;
            this.natureOfBusiness = _natOfBusiness;
            this.regNumb = _regNumb;
            this.dateIncorporated = _dateIncorporated;
            this.url = _url;
            this.isVATreg = _isVATreg;
            this.VATnumb = _VATnumb;
            this.notes = _notes;
        }



        public void SetCompanyTimes(List<int> items2Set, bool isOpeningtime = true, bool isClosingTime = false) {
            try {
                //select enum required
                List<int> selectedEnum = OpeningTime;
                if (isClosingTime)
                    selectedEnum = ClosingTime;

                //loop throught selected list
                // foreach (int time in selectedEnum) {
                for (int i = 0; i < selectedEnum.Count; i++) {
                    //set given time
                    selectedEnum[i] = items2Set[i];
                }
            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>BLL.CompanyBLL.SetCompanyTimes()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);
                
            }
        }
        public void SetCompanyOpeningDays(List<bool> items2Set) {
            try {
              
                //loop throught selected list
                // foreach (int time in selectedEnum) {
                for (int i = 0; i < OpeningDays.Count; i++) {
                    //set given time
                    OpeningDays[i] = items2Set[i];
                }
            }
            catch (Exception exc) {
                System.Diagnostics.Debug.Print("<h2>BLL.CompanyBLL.SetCompanyOpeningDays()</h2>\n" + exc.ToString() + "\n" + exc.InnerException + "\n" + exc.Message);

            }
        }





    }//class
}//namespace
