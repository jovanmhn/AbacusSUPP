using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AbacusSUPP
{
    public partial class FormSettings : DevExpress.XtraEditors.XtraForm
    {
        public FormSettings()
        {
            InitializeComponent();
            string putanja = System.IO.Path.Combine(Application.StartupPath, "Settings.xml");
            XmlReader reader = XmlReader.Create(putanja);
            //dok.Load(putanja);


            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Setting"))
                {
                    if (reader.HasAttributes)
                    {
                        if (Convert.ToInt32(reader.GetAttribute("Name")) == OperaterLogin.operater.id)
                        {
                            checkEdit1.Checked = Convert.ToBoolean(reader.GetAttribute("Tray"));
                        }

                    }
                }
            }
            reader.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string putanja = System.IO.Path.Combine(Application.StartupPath, "Settings.xml");
            XmlDocument dok = new XmlDocument();
            //XmlReader reader = XmlReader.Create(putanja);

            XDocument doc = XDocument.Load(putanja);
            var q = from node in doc.Descendants("Setting")
                    let attr = node.Attribute("Name")
                    where attr != null && attr.Value == OperaterLogin.operater.id.ToString()
                    select node;
            q.ToList().ForEach(x => x.Remove());
            doc.Save(putanja);
            


            dok.Load(putanja);
            XmlNode setting = dok.CreateElement("Setting");

            XmlAttribute tray = dok.CreateAttribute("Tray");
            tray.InnerText = checkEdit1.Checked.ToString();
            setting.Attributes.SetNamedItem(tray);

            XmlAttribute name = dok.CreateAttribute("Name");
            name.InnerText = OperaterLogin.operater.id.ToString();
            setting.Attributes.SetNamedItem(name);

            XmlElement elem = (XmlElement)dok.SelectSingleNode("/Configuration/" + "Settings");
            elem.AppendChild(setting);
            dok.Save(putanja);

            load_settings();
            this.Close();
        }
        private void load_settings()
        {
            string putanja = System.IO.Path.Combine(Application.StartupPath, "Settings.xml");
            //XmlDocument dok = new XmlDocument();
            XmlReader reader = XmlReader.Create(putanja);
            //dok.Load(putanja);


            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Setting"))
                {
                    if (reader.HasAttributes)
                    {
                        if (Convert.ToInt32(reader.GetAttribute("Name")) == OperaterLogin.operater.id)
                        {
                            OperaterLogin.podesavanja.tray = true;
                            var test = reader.GetAttribute("Tray");
                            OperaterLogin.podesavanja.tray = Convert.ToBoolean(reader.GetAttribute("Tray"));
                        }

                    }
                }
            }

        }
    }
}
