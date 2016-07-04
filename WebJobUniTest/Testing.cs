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

        private void btnPopComboBox_Click(object sender, EventArgs e) {
            try {
                string fileName = txtBoxFileName.Text;
                string yearXML = @"C:\RachieServer\Projects\ProjectInvestigation\UniProjSolution\App_Data\Years.xml";
                string yearXML2 = @"C:\RachieServer\Projects\ProjectInvestigation\UniProjSolution\App_Data\SIC07CHcondensedList.xml";
                // Utils.PopulateComboFromXMLFile(yearXML, ref this.comboBox1);               
                PopulateComboFromXMLFile(yearXML2, ref this.comboBox1);
              
                //R (working vs)    PopulateComboWithIndustries(yearXML2);


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

                var indElem = from key in xmlDocument.Descendants("Industry") where key.Attribute("Section").Value == "A" select key.Value ;
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


        public void PopulateComboWithIndustries(string xmlFile) {

            try {
                //attribute example: http://stackoverflow.com/questions/4721436/binding-xml-to-combobox
        
                //clear combo items
                this.comboBox1.Items.Clear();

                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);

                //get the dataview of table, which is default table name  
                DataView industries = ds.Tables[0].DefaultView;

                //show dataView Table on gridview
               this.DataGridView1.DataSource = industries;
               
                //now define datatext field and datavalue field of dropdownlist  
                this.comboBox1.DataSource = industries;
                this.comboBox1.DisplayMember = "Domain"; //Name

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
        }





    }//class
}//namespace
