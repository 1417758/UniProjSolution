using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WebJobUniUtils;

namespace WebJobUniTest {
    public partial class Testing : Form {
        public Testing() {
            InitializeComponent();
        }

        private void Testing_Load(object sender, EventArgs e) {

            //populate industry combobox
            PopulateIndComboFromXMLFile(sender, e);


        }


        private void btnAddReadFile_Click(object sender, EventArgs e) {
            try {

                int counter = 0;
                string line;
                string filename = @"C:\RachieServer\Projects\ProjectInvestigation\UniProjSolution\App_Data\SIC07CHcondensedList.xml";

                //// Read the file and display it line by line.
                //System.IO.StreamReader file =
                //    new System.IO.StreamReader(filename);
                //while ((line = file.ReadLine()) != null) {
                //    System.Console.WriteLine(line);
                //    counter++;
                //}

                //file.Close();
                //System.Console.WriteLine("There were {0} lines.", counter);
                //// Suspend the screen.
                //System.Console.ReadLine();

                ReadMyfile(filename);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Test.Testing.btnAddReadFile_Click() \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;               
            }
        }

        private void ReadMyfile(string fileName) {
            try {

                StringBuilder result = new StringBuilder();

                if (System.IO.File.Exists(fileName)) {
                    using (StreamReader streamReader = new StreamReader(fileName)) {
                        String line;
                        while ((line = streamReader.ReadLine()) != null) {
                            string newLine = String.Concat(line, "</Name></activity>", Environment.NewLine);
                            // newLine = newLine + "</Name></activity>";
                            result.Append(newLine);
                        }
                    }
                }
                string newFilename = @"C:\RachieServer\Projects\ProjectInvestigation\UniProjSolution\App_Data\SIC07CHcondensedList.xml";

                //   using (FileStream fileStream = new FileStream(newFilename, FileMode.Open) {
                using (StreamWriter sw = new StreamWriter(newFilename)) {

                    sw.Write(result);
                    sw.Flush();
                    sw.Close();

                    // fileStream.Close();
                    // }
                }

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Test.Testing.btnAddReadFile_Click() \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;               
            }
        }

        private void btnStartup_Click(object sender, EventArgs e) {
            StartUp Check = new StartUp();
            Check.Show();
            Hide();
        }

        private void PopulateIndComboFromXMLFile(object sender, EventArgs e) {
            try {

                //string yearXML = @"C:\RachieServer\Projects\ProjectInvestigation\UniProjSolution\App_Data\Years.xml";
                // Utils.PopulateComboFromXMLFile(yearXML, ref this.comboBox1);   

                string yearXML2 = @"C:\RachieServer\Projects\ProjectInvestigation\UniProjSolution\EasyBookWeb\App_Data\SIC07CHcondensedList.xml";
                //populate industries
                PopulateComboWithIndustries(yearXML2);

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("Test.Testing.btnAddReadFile_Click() \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                // return null;               
            }

        }

        public void PopulateComboFromXMLFile(string xmlFile, ref ComboBox comboBox) {

            try {
                //attribute example: http://stackoverflow.com/questions/4721436/binding-xml-to-combobox
                //Dim txt = "Name"
                //Dim value = "ID"

                //clear combo items
                comboBox.Items.Clear();

                //select desired items
                var xmlDocument = XDocument.Load(xmlFile);
                //  dynamic result = null; // (from c in y where c.Attribute(XMLConstants.SETTING_ID).Value == settingName c.Attribute(XMLConstants.Value));

                var indElem = from key in xmlDocument.Descendants("Industry") where key.Attribute("Section").Value == "A" select key.Value;
                var indElem2 = from key in xmlDocument.Descendants("Name") where key.Parent.Parent.Parent.Attribute("Section").Value == "A" select key.Value;


                //var secKeyItems = from key in xmlDocument.Descendants("key2") select key.Value;
                //var alphaItems = from key in xmlDocument.Descendants("key3") select key.Value;

                DataGridView1.DataSource = indElem.ToList();
                DataGridView2.DataSource = indElem2.ToList();

                //bind each combo to the selected result
                comboBox.DataSource = indElem2.ToList();



            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
        }

        public void PopulateComboFromXMLFile(string xmlFile, string parentSelection) {

            try {

                //load file
                var xmlDocument = XDocument.Load(xmlFile);
                
                //select desired items
                var indElem = from key in xmlDocument.Descendants("Name") where key.Parent.Parent.Parent.Element("UID").Value == parentSelection select key.Value;
              
                //DataGridView1.DataSource = indElem.ToString();
               
                //bind each combo to the selected result
                this.comboNat.DataSource = indElem.ToList();

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
        }

        public void PopulateComboWithIndustries(string xmlFile) {

            try {
                //attribute example: http://stackoverflow.com/questions/4721436/binding-xml-to-combobox

                //clear combo items
                this.comboInd.Items.Clear();

                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);

                //get the dataview of table, which is default table name  
                DataView industries = ds.Tables[0].DefaultView;

                //show dataView Table on gridview
                this.DataGridView1.DataSource = industries;

                //now define datatext field and datavalue field of dropdownlist  
                this.comboInd.DataSource = industries;
                this.comboInd.DisplayMember = "Domain";

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
        }

        private void comboInd_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                string yearXML2 = @"C:\RachieServer\Projects\ProjectInvestigation\UniProjSolution\EasyBookWeb\App_Data\SIC07CHcondensedList.xml";

                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                int selectedVal = cmb.SelectedIndex;
                string selectedText = cmb.SelectedText;
                dynamic selectedItem = cmb.SelectedItem;

                // MessageBox.Show(String.Format("Index: [{0}] Text={1}; Value={2}", selectedIndex, selectedText, selectedVal));

                //populate combo nature according industry selected 
                PopulateComboFromXMLFile(yearXML2, (selectedIndex + 1).ToString());

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
        }

        private void comboNat_SelectedIndexChanged(object sender, EventArgs e) {
            GetNatureCode(sender, e);

        }

        public void GetNatureCode(object sender, EventArgs e) {

            try {

                string yearXML2 = @"C:\RachieServer\Projects\ProjectInvestigation\UniProjSolution\EasyBookWeb\App_Data\SIC07CHcondensedList.xml";

                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                string selectedVal = cmb.SelectedValue.ToString();
                string selectedText = cmb.SelectedText;
                dynamic selectedItem = cmb.SelectedItem;


                //load file
                var xmlDocument = XDocument.Load(yearXML2);
               string natSelection = "Freshwater aquaculture";

                //select desired items
                var indElem = from key in xmlDocument.Descendants("ID") where key.Parent.Element("Name").Value == selectedVal select key.Value;

                DataGridView1.DataSource = indElem.ToString();

                //bind each combo to the selected result
                this.LblReturn.Text = indElem.ToList().ElementAt(0);

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
        }

        private void btnPopComboBox_Click(object sender, EventArgs e) {

        }
    }//class
}//namespace
