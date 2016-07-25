using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebJobUniUtils {
    public class QueryXML {
        /// <summary>
        /// Set to false so that XML file is not always reloarded.  Leave as True for when in User Config
        /// and always want to reloard XML file.
        /// </summary>
        /// <remarks></remarks>

        public static bool ALWAYS_RELOAD_XML_FILE = true;
        private static XmlElement root;
        private static XmlElement child;
        private static XmlNode node;
        private static XmlNodeList nodeList;

        private static Hashtable hashtable = new Hashtable();
        /// <summary>
        /// Hashtable containing list of XML files matched to XML Documents
        /// (means that do not have to continually open same file)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Hashtable XMLFilesHashTable {
            get { return hashtable; }
            set { hashtable = value; }
        }

        /// <summary>
        /// Load an XML file and add it to hashtable (means that do not have to continually open same file)
        /// only add file to hashtable if it isn't already contained in it
        /// </summary>
        /// <param name="filename">XML file to load and add to hashtable</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument Add2HashTable(string filename) {
            try {
                //file already exists on system
                //check if it is in hashtable (if so, it is already open)
                XmlDocument doc = new XmlDocument();
                // Read all bytes in from a file on the disk.
          //R      byte[] file = File.ReadAllBytes(filename);

                if (XMLFilesHashTable.ContainsKey(filename)) {
                    //file is in hashtable so XMLDocument return it
                    doc = (XmlDocument)XMLFilesHashTable[filename];
                    // hash table does not contain filename, so it is not open
                }
                else {
          //R          using (MemoryStream ms = new MemoryStream(file)) {
            //R            using (XmlReader xmlReader = XmlReader.Create(ms)) {
                            //load XMLDocument and add to hashtable
                            doc.Load(filename);
                            XMLFilesHashTable.Add(filename, doc);
                        }
             //R       }
              //R  }

                return doc;
            }
            catch (ArgumentException ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.Add2HashTable() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.Add2HashTable() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        //public static XmlDocument OpenFile(string filename, string rootName = "Root") {
        //    try {
        //    }
        //    catch (Exception ex) {
        //        System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.OpenFile() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
        //        return null;
        //    }
        //}
        /// <summary>
        /// Open the Input Fields XML file and return XDocument. 
        /// Creates blank with the given root's name if it does not exist.        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument OpenFile(string filename, string rootName = "Root", bool isDailySheduleXml=false) {
            try {
                //Dim t As New TimerUtil("QueryXML.vb  OpenFile")
                //t.startTimer()

                //does file exist? if not create it and add to hash table
                XmlDocument doc = new XmlDocument();
                if (!File.Exists(filename)) {
                    doc = CreateBlankFile(filename, rootName, isDailySheduleXml);
                 //R   XMLFilesHashTable.Add(filename, doc);
                }
                else {
                    //note that Add2HashTable handles if to add file or not
                    //R     doc = Add2HashTable(filename);
                    doc.Load(filename);
                }
                //endIf Not File.Exists(filename) 


                //t.endTimer()

                return doc;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.OpenFile() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #region "Create and Add "

        public static string ConvertXmlNodeList2File(string originalDocFilleName, List<XmlNodeList> nodeList, bool isNodeImported) {
            try {
                dynamic tempFileName = originalDocFilleName.Replace(".xml", "(TEMP).xml");
                dynamic clientsDoc = QueryXML.CreateBlankFile(tempFileName);

                foreach (XmlNodeList nodeLi in nodeList) {
                    //If isNodeImported Then
                    clientsDoc = QueryXML.ImportChild(tempFileName, nodeLi);
                    //Else
                    //    'use append child
                    //End If
                }

                return tempFileName;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.ConvertXmlNodeList2File() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        public static string ConvertXmlNodeList2File(string originalDocFilleName, XmlNodeList nodeList, bool isNodeImported) {
            try {
                if (nodeList == null || nodeList.Count == 0) {
                    throw new Exception("ConvertXmlNodeList2File Function Error: the parameter nodeList is nothing or it does not contain any items!");
                }
                List<XmlNodeList> listOfNodeLi = new List<XmlNodeList>();
                listOfNodeLi.Add(nodeList);

                return ConvertXmlNodeList2File(originalDocFilleName, listOfNodeLi, isNodeImported);

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.ConvertXmlNodeList2File() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        //As String
        public static void ConvertXmlNode2File(string filleName, XmlElement element) {
            try {
                // Dim gtDoc = OpenFile(filleName)
                dynamic gtDoc = QueryXML.CreateBlankFile(filleName);

                //get root elements
                root = gtDoc.DocumentElement;

                //import from another xml document 
                root.AppendChild(gtDoc.ImportNode(element, false));

                //save document
                // Dim doc As New XmlDocument
                gtDoc.Save(filleName);

                // Return gtDoc

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.ConvertXmlNode2File() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                //   Return Nothing
            }
        }



        /// <summary>
        /// Create a blank Inputs file and save same.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument CreateBlankFile(string filename, string rootName = "Root", bool isDailySheduleXml = false) {
            try {
                if (File.Exists(filename)) {
                    //R  OpenFile(filename).RemoveAll()
                    File.Delete(filename);
                }
                XmlDocument doc = new XmlDocument();
                // XML declaration (param= version, encoding, standalone)
                //   XmlNode declarationNode = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlNode declarationNode = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(declarationNode);

                // Root element:  given parameter
                root = doc.CreateElement(rootName);
                doc.AppendChild(root);

                doc.Save(filename);

                return doc;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.CreateBlankFile() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// creates a child node element
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="childValue"></param>
        /// <param name="attribute1Name"></param>
        /// <param name="attribute1Value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlElement CreateNode(string nodeName, string childValue = "", string attribute1Name = "", string attribute1Value = "") {
            try {
                // Sub-element: childName
                XmlDocument doc = new XmlDocument();
                child = doc.CreateElement(nodeName);

                //child's text
                if (!string.IsNullOrEmpty(childValue)) {
                    child.InnerText = childValue;
                }

                //child attribute1
                if (!string.IsNullOrEmpty(attribute1Name)) {
                    XmlAttribute at1 = doc.CreateAttribute(attribute1Name);
                    at1.Value = attribute1Value;
                    child.Attributes.Append(at1);
                }

                return child;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.CreateNode() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// this function adds the given node to the ROOT element of the given file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument ImportChild(string filename, XmlNodeList nodeList) {

            try {
                //OrElse nodeList.Count = 0 Then
                if (nodeList == null) {
                    //     System.Diagnostics.Debug.Print("QueryXML Class, ImportChild Function ERROR: parameter xmlNodeList is nothing or doenst contain items.From File: " & filename)
                    throw new Exception("QueryXML Class, ImportChild Function ERROR: parameter xmlNodeList is nothing or doenst contain items.From File: " + filename);
                }

                //PS: if file is constantly changed (eg: userconfig xml file) it needs to be loaded every time.  'doc.Load(filename)
                // therefore, openFile which stores filename in a harsh table may NOT hv the latest file
                //See OpenFile() GasTurnine EXCEPTION and add new one if required
                dynamic doc = OpenFile(filename);

                //get root elements
                root = doc.DocumentElement;

                foreach (XmlNode node in nodeList) {
                    //import from another xml document 
                    root.AppendChild(doc.ImportNode(node, false));
                }

                //save document
                // Dim doc As New XmlDocument
                //System.Diagnostics.Debug.Print("QueryXML.vb:  ImportChild: Saving file " & filename)
                doc.Save(filename);

                return doc;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.ImportChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// this function adds the given node to the ROOT element of the given file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument ImportChild(string filename, XmlNode node) {

            try {
                if (node == null) {
                    throw new Exception("QueryXML Class, ImportChild Function ERROR: parameter xmlNode is NOTHING.");
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                //OPEN files doesnt work with this condition as it stores previous nodes (file is constantly changed so it needs to be loaded each time)
                // Dim doc = OpenFile(filename)

                //get root elements
                root = doc.DocumentElement;

                //import from another xml document 
                root.AppendChild(doc.ImportNode(node, false));

                //save document
                // Dim doc As New XmlDocument
                doc.Save(filename);

                return doc;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.ImportChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// creates a child node element in the root
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="childName"></param>
        /// <param name="childIValue"></param>
        /// <param name="attribute1Name"></param>
        /// <param name="attribute1Value"></param>
        /// <param name="attribute2Name"></param>
        /// <param name="attribute2Value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument AddChild2Root(string filename, string childName, string childIValue = "", string attribute1Name = "", string attribute1Value = "", string attribute2Name = "", string attribute2Value = "") {
            try {
                // Sub-element: childName
                XmlDocument doc = OpenFile(filename);
                child = doc.CreateElement(childName);

                //child's text
                if (!string.IsNullOrEmpty(childIValue)) {
                    child.InnerText = childIValue;
                }

                //child attribute1
                if (!string.IsNullOrEmpty(attribute1Name)) {
                    XmlAttribute at1 = doc.CreateAttribute(attribute1Name);
                    at1.Value = attribute1Value;
                    child.Attributes.Append(at1);
                }

                //child attribute2
                if (!string.IsNullOrEmpty(attribute2Name)) {
                    XmlAttribute at2 = doc.CreateAttribute(attribute2Name);
                    at2.Value = attribute2Value;
                    child.Attributes.Append(at2);
                }

                //add child to root note
                doc.DocumentElement.AppendChild(child);

                //save document
                doc.Save(filename);

                return doc;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// creates a child node element to last child
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="childName"></param>
        /// <param name="childIValue"></param>
        /// <param name="attribute1Name"></param>
        /// <param name="attribute1Value"></param>
        /// <param name="attribute2Name"></param>
        /// <param name="attribute2Value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument AddChild2LastChild(string filename, string childName, string childIValue = "", string attribute1Name = "", string attribute1Value = "") {
            try {
                // Sub-element: childName
                XmlDocument doc = OpenFile(filename);
                child = doc.CreateElement(childName);

                //child's text
                if (!string.IsNullOrEmpty(childIValue)) {
                    child.InnerText = childIValue;
                }

                //child attribute1
                if (!string.IsNullOrEmpty(attribute1Name)) {
                    XmlAttribute at1 = doc.CreateAttribute(attribute1Name);
                    at1.Value = attribute1Value;
                    child.Attributes.Append(at1);
                }               

                //add child to root note
              //R  doc.ChildNodes[parentIndex].AppendChild(child);

                doc.DocumentElement.LastChild.AppendChild(child);

                //save document
                doc.Save(filename);

                return doc;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// creates a child node element to last child
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="childName"></param>
        /// <param name="childIValue"></param>
        /// <param name="attribute1Name"></param>
        /// <param name="attribute1Value"></param>
        /// <param name="attribute2Name"></param>
        /// <param name="attribute2Value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument AddChild2SpecificNode(string filename, string parentName, string childName, string childIValue = "", string attribute1Name = "", string attribute1Value = "") {
            try {
                // Sub-element: childName
                XmlDocument doc = OpenFile(filename);
                child = doc.CreateElement(childName);

                //child's text
                if (!string.IsNullOrEmpty(childIValue)) {
                    child.InnerText = childIValue;
                }

                //child attribute1
                if (!string.IsNullOrEmpty(attribute1Name)) {
                    XmlAttribute at1 = doc.CreateAttribute(attribute1Name);
                    at1.Value = attribute1Value;
                    child.Attributes.Append(at1);
                }

                //add child to root note
                //R  doc.ChildNodes[parentIndex].AppendChild(child);
                string xpath = "//"+ parentName;

               doc.DocumentElement.SelectSingleNode(xpath).AppendChild(child);
             //   doc.DocumentElement.   .SelectNodes(parentName).Item(0)..a. .AppendChild(child);

                //save document
                doc.Save(filename);

                return doc;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static object AddChild(string filename, XmlNodeList nodeList) {

            try {
                //get root elements
                root = GetRootElements(filename);

                foreach (XmlNode node in nodeList) {
                    //add child
                    root.AppendChild(node);
                }

                //save document
                XmlDocument doc = new XmlDocument();
                doc.Save(filename);

                return doc;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        public static XmlElement AddAttributeToNode(ref XmlElement node2Add, string attributeName, string attributeValue = "") {

            try {
                dynamic aExists = node2Add.Attributes[attributeName];
                if (aExists == null) {
                    XmlDocument doc = new XmlDocument();
                    //create attribute
                    XmlAttribute at1 = doc.CreateAttribute(attributeName);
                    at1.Value = attributeValue;

                    //add attribute
                    node2Add.SetAttributeNode(at1);
                    //(doc.ImportNode(at1, True))

                }
                else {
                    throw new Exception("QueryXML, AddAttributeToNode Function - Error: the attribute " + attributeName + " already exists in this node");
                }


                return node2Add;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddAttributeToNode() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="pkAttributeName"></param>
        /// <param name="pkAttributeValue"></param>
        /// <param name="attributeName2Add"></param>
        /// <param name="attributeValue2Add"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument AddAttributeToChild(string filename, string pkAttributeName, string pkAttributeValue, string attributeName2Add, string attributeValue2Add = "") {
            try {
                //get node by pkfieldName and pkFieldValue
                nodeList = GetNodesByAttribute(filename, pkAttributeName, pkAttributeValue);

                XmlDocument doc = new XmlDocument();
                if (nodeList.Count > 1) {
                    System.Diagnostics.Debug.Print("more then one element node was found with the given pkAttributeName and pkAttributeValue ");
                    throw new Exception("QueryXML, AddAttributeToChild Function - Error: More then one element node was found with the given pkAttributeName and pkAttributeValue");
                }
                else {
                    //create attribute
                    XmlAttribute at1 = doc.CreateAttribute(attributeName2Add);
                    at1.Value = attributeValue2Add;

                    //add attribute
                    nodeList.Item(0).Attributes.Append(at1);

                    //save document
                    doc.Save(filename);
                }

                return doc;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddAttributeToChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="groupName"></param>
        /// <param name="groupID"></param>
        /// <param name="attributeName2Add"></param>
        /// <param name="attributeValue2Add"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument AddAttributeToChildren(string filename, string groupName, int groupID, string attributeName2Add, string attributeValue2Add = "") {
            try {
                //get node by pkfieldName and pkFieldValue
                nodeList = GetNodesByAttribute(filename, groupName, groupID.ToString());

                dynamic doc = OpenFile(filename);

                foreach (XmlNode n in nodeList) {
                    //create attribute
                    XmlAttribute at1 = doc.CreateAttribute(attributeName2Add);
                    at1.Value = attributeValue2Add;

                    //add attribute
                    n.Attributes.Append(at1);

                }

                //save document
                doc.Save(filename);

                return doc;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddAttributeToChildren() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="groupName"></param>
        /// <param name="groupID"></param>
        /// <param name="attributeName2Added"></param>
        /// <param name="attributeValues2Added"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument AddAttributeValuesToChildren(string filename, string groupName, int groupID, string attributeName2Added, List<string> attributeValues2Added) {
            /*     try {
                     //get node by pkfieldName and pkFieldValue
                     nodeList = GetNodesByAttribute(filename, groupName, groupID.ToString());

                     //check whether the number of values to be added match the numb or nodes found

                     if (attributeName2Added.Count == nodeList.Count) {
                         //loop list of values to be added 

                         foreach (string li in attributeValues2Added) {
                             //loop group where values are going to be added 
                             foreach (XmlNode n in nodeList) {
                                 //add attribute
                                 n.Attributes[attributeName2Added].Value = li;
                             }
                         }

                         //save document
                         XmlDocument doc = new XmlDocument();
                         doc.Save(filename);

                         return doc;

                     }
                     else {
                       System.Diagnostics.Debug.Print("the number of nodes found corresponding to the given group is: " + nodeList.Count + "\n" + "the number of values to be addes are: " + attributeName2Added.Count + "These values must be the same.");
                         throw new Exception("QueryXML, AddAttributeValuesToChildren Function - Error: " + "\n" + "the number of nodes found corresponding to the given group is: " + nodeList.Count + "\n" + "the number of values to be added are: " + attributeName2Added.Count + " These values must be the same.");
                     }


                 }
                 catch (Exception ex) {
                     System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                   }*/
            return null;

        }

        /// <summary>
        /// adds an given attribute to a root's child of choice(child numb)
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="childPosition"></param>
        /// <param name="attribute1Name"></param>
        /// <param name="attribute1Value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlDocument AddAttributeToChild(string filename, int childPosition, string attribute1Name, string attribute1Value = "") {

            try {
                //get root and its nodes
                root = GetRootElements(filename);

                //get given node 
                dynamic cExists = root.ChildNodes.Item(childPosition);

                //checks whether given child node exists
                if (cExists != null) {
                    node = root.ChildNodes.Item(childPosition);

                    //checks whether the given node is a comment node 

                    if (node.NodeType == XmlNodeType.Comment) {
                        System.Diagnostics.Debug.Print("The child you have selected: " + node.Value + " is a comment node in this xml file");
                        throw new Exception("QueryXML Class, AddAttributeToChild Function - Error: The child you have selected: " + node.Value + " is a comment node in this xml file");

                        //if given child node is not a comment node
                    }
                    else {

                        //create attribute
                        XmlDocument doc = new XmlDocument();
                        XmlAttribute at1 = doc.CreateAttribute(attribute1Name);
                        at1.Value = attribute1Value;

                        //add attribute
                        node.Attributes.Append(at1);

                        //save document
                        doc.Save(filename);

                        return doc;
                    }

                    //given child node does not  exists
                }
                else {
                    System.Diagnostics.Debug.Print("The child you have selected does not exist in this xml file");
                    throw new Exception("QueryXML Class, AddAttributeToChild Function - Error: The child you have select does not exist in this xml file");
                }


            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddAttributeToChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region "Search"

        public static XmlElement GetRootElements(string filename) {

            try {
                //open document
                dynamic doc = OpenFile(filename);

                //get root elements
                root = doc.DocumentElement;

                return root;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetRootElements() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }


        public static XmlDocument GetAllElementsWithNoComments(string filename) {

            try {
                //open file
                dynamic doc = OpenFile(filename);

                //for every child in XML document get comment nodes              
                nodeList = doc.SelectNodes("//comment()");


                //remove comment nodes
                // loop backwards as '.ParentNode.RemoveChild(x)' wont allow the loop to continue
                for (int i = nodeList.Count - 1; i >= 0; i += -1) {
                    nodeList[i].ParentNode.RemoveChild(nodeList[i]);
                }

                return doc;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetAllElementsWithNoComments() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// returns a single node that has the given node Name 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlNode GetNodeByName(string filename, string nodeName) {
            try {
                //open file
                dynamic doc = OpenFile(filename);

                //for every child in XML document that has "attributeName" as an attribure
                node = doc.SelectSingleNode("//child::" + nodeName);
                //"child::book"
                System.Diagnostics.Debug.Print(node.Name);

                return node;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetNodeByName() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// returns a single node that has the given node index
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="nodeIndex"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlNode GetChildNodeByIndex(string filename, int nodeIndex) {
            try {
                //open file
                dynamic root = GetRootElements(filename);

                //get the shared nodes (common GTs)
                node = root.ChildNodes(nodeIndex);

                return node;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.AddChild() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// returns a single node that contains the given attribute Name and value 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlNode GetNodeByAttribute(string filename, string attributeName, string attributeValue) {
            try {
                //open file
                dynamic doc = OpenFile(filename);

                //for every child in XML document that has "attributeName" as an attribure
                node = doc.SelectSingleNode("//*[@" + attributeName + "='" + attributeValue + "']");

                return node;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetNodeByAttribute() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        ///  returns all nodes that contain the given attribute Name 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlNodeList GetNodesByAttribute(string filename, string attributeName) {
            try {
                //open file
                dynamic doc = OpenFile(filename);

                //for every child in XML document that has "attributeName" as an attribute
                nodeList = doc.SelectNodes("//*[@" + attributeName + "]");

                return nodeList;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetNodesByAttribute() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        ///  returns all nodes that contain the given attribute Name and value 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static XmlNodeList GetNodesByAttribute(string filename, string attributeName, string attributeValue) {
            try {
                //open file
                dynamic doc = OpenFile(filename);

                //for every child in XML document that has "attributeName" as an attribure
                nodeList = doc.SelectNodes("//*[@" + attributeName + "=" + attributeValue + "]");

                return nodeList;
            }
            catch (System.NullReferenceException ex) {
                StringBuilder er = new StringBuilder();
                var _with1 = er;
                _with1.Append("GetNodesByAttribute: Error in getting nodes by attribute. Please check given values exist." + "\n");
                _with1.Append("Filename:" + "\t" + filename + "\n");
                _with1.Append("Attribute name:" + "\t" + attributeName + "\n");
                _with1.Append("Attribute value:" + "\t" + attributeValue + "\n");
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetNodesByAttribute() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetNodesByAttribute() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        ///  returns all nodes that contain the given parent ID and attribute Name and value 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="parentIDValues"></param>
        /// <param name="groupName"></param>
        /// <param name="groupID"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<XmlNode> GetNodesByGroupAndParentID(string filename, List<int> parentIDValues, string groupName, int groupID) {
            try {
                //open file
                dynamic doc = GetAllElementsWithNoComments(filename);
                List<XmlNode> selNodes = new List<XmlNode>();

                foreach (int parentID in parentIDValues) {
                    dynamic IDValue = parentID.ToString();


                    //checks whether given parent/equipment ID exists
                    dynamic nExists = doc.SelectSingleNode("//*[@ID=" + IDValue + "]");

                    if (nExists != null) {
                        //for every child in XML document that has an attribute "ID" with the given IDValue
                        nodeList = nExists.ChildNodes;

                        //checks whether the given attribute exists
                        //PS: this condition checks the first node and ASSUMES that ALL other nodes have the same attributes/structure 
                        //if nodes' attributes vary the if condition below needs to be moved to inside the next for loop eg: "If aExists IsNot Nothing AndAlso aExists.Value = groupID Then"
                        dynamic aExists = nodeList.Item(0).Attributes[groupName];

                        if (aExists != null) {
                            //for every node check it has the given attribute name and value
                            foreach (XmlNode node in nodeList) {
                                if (Utils.GetNumberInt(node.Attributes[groupName].Value) == groupID) {
                                    //add node to return list
                                    selNodes.Add(node);
                                }
                            }
                            //next node in nodeList

                            //end If aExists IsNot Nothing
                        }
                        else {
                            System.Diagnostics.Debug.Print("QueryXML, GetNodesByGroupAndParentID Function - Error: The field name: " + groupName + " can NOT be found in parent with ID: " + parentID);
                        }
                        //end If aExists IsNot Nothing

                    }
                    //end if If nExists IsNot Nothing


                }
                //parentID next parentIDValues


                return selNodes;


            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetNodesByGroupAndParentID() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "Return List Functions"
        /// <summary>
        /// returns a list of all required attributes by the given attributeName
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static object GetAttributeValuesByAttributeName(string filename, string attributeName, bool areValues2RetInteger) {
            try {
                //get xml all nodes with the given groupName attribute
                nodeList = GetNodesByAttribute(filename, attributeName);

                if (areValues2RetInteger) {
                    //return list of integer 
                    return GetNodesByAttributeAsListOfInteger(nodeList, attributeName);
                }
                else {
                    //return list of string 
                    return GetNodesByAttributeAsListOfString(nodeList, attributeName);
                }

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetAttributeValuesByAttributeName() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// returns a list of all required attributes by the given groupName and ID
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="groupName">attribute name</param>
        /// <param name="groupID">attribute value</param>
        /// <param name="att2Retrieve">attribute name of the values required</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<string> GetAttributeValuesByGroup(string filename, string groupName, int groupID, string att2Retrieve) {
            try {
                //creates list of string to be returned
                List<string> li = new List<string>();

                //get xml all nodes with the given groupName attribute
                nodeList = GetNodesByAttribute(filename, groupName, groupID.ToString());

                //if nodeList.Count is 0(zero) please check given parameters exist
                //Debug.print("if nodeList.Count is 0(zero) please check given parameters exist")
                //Debug.print("nodeList.Count is: " & nodeList.Count)

                dynamic aExists = nodeList.Item(0).Attributes[att2Retrieve];

                if (aExists != null) {
                    //gets the required(given parameter 'att2Retrieve') attribute value
                    foreach (XmlNode n in nodeList) {
                        //System.Diagnostics.Debug.Print(n.Name)
                        li.Add(n.Attributes[att2Retrieve].Value);
                    }

                    //end If aExists IsNot Nothing
                }
                else {
                    System.Diagnostics.Debug.Print("QueryXML, GetAttributeValuesByGroup Function - Error:  The field name: " + att2Retrieve + " can NOT be found.");
                }
                //end If aExists IsNot Nothing

                return li;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetAttributeValuesByGroup() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }
        /// <summary>
        /// returns a list of all required attributes by the given groupName and ID
        /// 
        /// see GetAttributeValueByGroupAndParentID for returning single item
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="groupName">attribute name</param>
        /// <param name="groupID">attribute value</param>
        /// <param name="att2Retrieve">attribute name of the values required</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<string> GetAttributeValuesByGroupAndParentID(string filename, string groupName, int groupID, List<int> parentIDList, string att2Retrieve) {
            try {
                //creates list of string to be returned
                List<string> li = new List<string>();

                //get all parent nodes
                dynamic parentAndGroupList = GetNodesByGroupAndParentID(filename, parentIDList, groupName, groupID);

                //if parentAndGroupList.Count is 0(zero) please check given parameters exist
                if (parentAndGroupList != null && parentAndGroupList.Count == 0) {
                    System.Diagnostics.Debug.Print("parentAndGroupList.Count is: " + parentAndGroupList.Count);
                    System.Diagnostics.Debug.Print("if parentAndGroupList.Count is 0(zero) please check given parameters exist");

                }

                //checks whether the given attribute att2Retrieve exists
                //PS: this condition checks the first node and ASSUMES that ALL other nodes have the same attributes/structure 
                //if nodes' attributes vary the if condition below needs to be moved to inside the next for loop eg: "If aExists IsNot Nothing AndAlso aExists.Value = groupID Then"

                //check list is not nothing and has items before getting item 0
                if (parentAndGroupList != null && parentAndGroupList.Count >= 1) {
                    XmlAttribute aExists = parentAndGroupList.Item(0).Attributes(att2Retrieve);
                    if (aExists != null) {
                        //gets the required(given parameter 'att2Retrieve') attribute value
                        foreach (XmlNode node in parentAndGroupList) {
                            //Debug.print(node.Name)
                            li.Add(node.Attributes[att2Retrieve].Value);
                        }

                        //end If aExists IsNot Nothing
                    }
                    else {
                        System.Diagnostics.Debug.Print("QueryXML, GetAttributeValuesByGroupAndParentID Function - Error:  The field name: " + att2Retrieve + " can NOT be found.");
                        return li;
                    }
                    //end If aExists IsNot Nothing
                }
                else {
                    System.Diagnostics.Debug.Print("QueryXML, GetAttributeValuesByGroupAndParentID Function - Error:  parentAndGroupList size is zero for attribute: " + att2Retrieve);
                    System.Diagnostics.Debug.Print("Group ID: " + "\t" + groupID);
                    System.Diagnostics.Debug.Print("Group Name: " + "\t" + groupName);
                    System.Diagnostics.Debug.Print("\n");

                    return li;
                }



                return li;

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetAttributeValuesByGroupAndParentID() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// Convert an XMLNodeList into list of Strings and return same
        /// </summary>
        /// <param name="attribute">attribute to retrieve</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<string> GetNodesByAttributeAsListOfString(XmlNodeList nodes, string attribute) {
            try {
                //return empty list if nodes list is nothing
                if (nodes == null || nodes.Count == 0) {
                    return new List<string>();
                }
                else {
                    //create list of Strings from specified attribute in XMLNodeList
                    dynamic list = null;//(from n in nodesnew string(n.Attributes[attribute].Value)).ToList;
                    return list;
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetNodesByAttributeAsListOfString() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }


        /// <summary>
        /// Convert an XMLNodeList into list of Integers and return same
        /// </summary>
        /// <param name="attribute">attribute to retrieve</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<int> GetNodesByAttributeAsListOfInteger(XmlNodeList nodes, string attribute) {
            try {
                //return empty list if nodes list is nothing
                if (nodes == null || nodes.Count == 0) {
                    return new List<int>();
                }
                else {
                    //create list of integers from specified attribute in XMLNodeList
                    dynamic list = null; // (from n in nodes int.Parse(n.Attributes[attribute].Value)).ToList;
                    return list;
                }
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetNodesByAttributeAsListOfInteger() </h2> \n" + ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region "Return String Functions"
        /// <summary>
        /// returns a SINGLE attribute value corresponding to the given attribute Name 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetAttributeValueByAttributeName(XmlNode node, string attributeName) {
            try {
                //check node is not nothing
                if (node == null) {
                    throw new NullReferenceException("QueryXML,GetAttributeValueByAttributeName Function - ERROR:  the paramenter node  is nothing!");
                }
                //end If node IsNot Nothing Then

                //checks weather node contains given attribute
                dynamic aExists = node.Attributes[attributeName];
                if (aExists != null) {
                    //gets the required(given parameter 'att2Retrieve') attribute value
                    //Debug.print(node.Name)
                    return node.Attributes[attributeName].Value;
                    //end If aExists IsNot Nothing
                }
                else {
                    //R System.Diagnostics.Debug.Print("QueryXML,GetAttributeValueByAttributeName Function - ERROR:  The attribute name: " & attributeName & " does NOT exist in this node " & node.InnerText)
                    throw new NullReferenceException("QueryXML,GetAttributeValueByAttributeName Function - ERROR:  The attribute named: " + attributeName + " does NOT exist in this node " + node.InnerText);
                }
                //end If node IsNot Nothing Then

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetAttributeValueByAttributeName() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// returns a SINGLE attribute value by the given groupName and ID
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="groupName">attribute name</param>
        /// <param name="groupID">attribute value</param>
        /// <param name="att2Retrieve">attribute name of the values required</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetAttributeValueByGroup(string filename, string groupName, string groupID, string att2Retrieve) {

            try {
                //get a single xml node with the given groupName and Id attributes
                node = GetNodeByAttribute(filename, groupName, groupID);

                if (node != null) {
                    //checks weather node contains given attribute
                    dynamic aExists = node.Attributes[att2Retrieve];
                    if (aExists != null) {
                        //gets the required(given parameter 'att2Retrieve') attribute value
                        //Debug.print(node.Name)
                        return node.Attributes[att2Retrieve].Value;
                        //end If aExists IsNot Nothing
                    }
                    else {
                        System.Diagnostics.Debug.Print("QueryXML,GetAttributeValueByGroup Function - ERROR:  The attribute name: " + att2Retrieve + " does NOT exist in this node " + node.InnerText);
                        return null;
                    }
                    //end If aExists IsNot Nothing
                    //node is nothing
                }
                else {
                    System.Diagnostics.Debug.Print("QueryXML,GetAttributeValueByGroup Function - ERROR:  The groupName: " + groupName + ", GroupID: " + groupID + ", Attribute to retrieve: " + att2Retrieve + "\n" + "Cannot be found in file: " + filename);
                    throw new NullReferenceException("QueryXML,GetAttributeValueByGroup Function - ERROR:  node is nothing, check where it is been populated.");
                }
                //end If node IsNot Nothing Then

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetAttributeValueByGroup() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Returns a single item with required attributes by the given groupName and ID
        /// see GetAttributeValuesByGroupAndParentID for returning a list of items
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="groupName"></param>
        /// <param name="groupID"></param>
        /// <param name="parentID"></param>
        /// <param name="att2Retrieve"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetAttributeValueByGroupAndParentID(string filename, string groupName, int groupID, int parentID, string att2Retrieve) {
            try {
                List<int> eqDS = new List<int>();
                eqDS.Add(parentID);

                dynamic result = QueryXML.GetAttributeValuesByGroupAndParentID(filename, XMLConstants.ID, groupID, eqDS, att2Retrieve);
                if (result != null && result.Count >= 1) {
                    dynamic PIE2UID = result.Item(0).ToString;
                    return PIE2UID;
                }
                else {
                    System.Diagnostics.Debug.Print("Cannot find PIE2UID for GroupID: " + groupID + "\t" + "ParentID :" + "\t" + parentID);
                    return null;
                }

            }
            catch (Exception ex) {
                System.Diagnostics.Debug.Print("<h2>Utils.QueryXML.GetAttributeValueByGroupAndParentID() </h2> \n" + ex.InnerException + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return null;
            }
        }

        #endregion



    }

}
