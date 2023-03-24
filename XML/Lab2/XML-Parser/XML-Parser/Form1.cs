using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XML_Parser_Validator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //================ Adjust Window =================//
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void ReadBtn_Click(object sender, EventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            using (var fileStream = File.OpenText("Test.xml"))
            using (XmlReader reader = XmlReader.Create(fileStream, settings))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            ElementsList.Items.Add($"Start Element: {reader.Name}. Has Attributes? : {reader.HasAttributes}");
                            break;
                        case XmlNodeType.Text:
                            ElementsList.Items.Add($"Inner Text: {reader.Value}");
                            break;
                        case XmlNodeType.EndElement:
                            ElementsList.Items.Add($"End Element: {reader.Name}");
                            break;
                        default:
                            ElementsList.Items.Add($"Unknown: {reader.NodeType}");
                            break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", Path.GetFullPath("schema.xsd"));

            XDocument doc = XDocument.Load(Path.GetFullPath("Test.xml"));
            string msg = "";
            doc.Validate(schemas, (o, es) =>
            {
                msg += es.Message + Environment.NewLine;
            });
            MessageBox.Show(msg == "" ? "Document is valid" : "Document invalid: " + msg);
            if (msg == "")
            {
                ValidationBox.Text = "Document is valid ";
                ValidationBox.BackColor = Color.Chartreuse;
            }
            else
            {
                ValidationBox.Text = "Document invalid: " + msg;
                ValidationBox.BackColor = Color.IndianRed;
            }
        }
    }
}

// https://dotnetcoretutorials.com/2020/04/23/how-to-parse-xml-in-net-core/
// https://learn.microsoft.com/en-us/troubleshoot/developer/visualstudio/csharp/language-compilers/read-xml-data-from-url
// https://www.c-sharpcorner.com/article/simple-xml-parser-in-C-Sharp/
// https://www.educba.com/xml-parser-in-c-sharp/?source=leftnav
// https://www.c-sharpcorner.com/article/how-to-validate-xml-using-xsd-in-c-sharp/
// https://www.aspsnippets.com/questions/806741/Read-and-validate-Xml-using-XDocumentValidate-method-xsd-file-in-ASPNet/
// https://learn.microsoft.com/en-us/dotnet/api/system.xml.schema.extensions.validate?view=net-7.0

//Parameters
//source
//XDocument
//The XDocument to validate.

//schemas
//XmlSchemaSet
//An XmlSchemaSet to validate against.

//validationEventHandler
//ValidationEventHandler
//A ValidationEventHandler for an event that occurs when the reader encounters validation errors. If null, throws an exception upon validation errors.