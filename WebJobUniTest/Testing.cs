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

                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);

                //get the dataview of table, which is default table name  
                DataView industries = ds.Tables[0].DefaultView;
       

                DataGridView1.DataSource = industries;
                
                //DataGridView4.DataSource = dv3.Table;


                //now define datatext field and datavalue field of dropdownlist  
                comboBox.DataSource = industries;
                comboBox.DisplayMember = "Name";
                

                /*    //----  try 2 ---
                    //select desired items
                    var xmlDocument = XDocument.Load(xmlFile);
                    var indElem = from key in xmlDocument.Descendants("StdIndustClass") select key.Value;
                    var indName = from key in xmlDocument.Descendants("Name") select key.Value.Trim();
                    //var secKeyItems = from key in xmlDocument.Descendants("key2") select key.Value;
                    //var alphaItems = from key in xmlDocument.Descendants("key3") select key.Value;

                    //bind each combo to the selected result
                    comboBox.DataSource = indName.ToList();
                    */


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
                this.comboBox1.DisplayMember = "Name";

           }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print(ex.ToString());
            }
        }





    }//class
}//namespace
