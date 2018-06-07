﻿using System;
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
                        
                        checkEdit1.Checked = Convert.ToBoolean(reader.GetAttribute("Tray"));
                        checkEdit2.Checked = Convert.ToBoolean(reader.GetAttribute("MinimizeNotif"));


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
                    let attr = node.Attribute("Tray")
                    where attr != null 
                    select node;
            q.ToList().ForEach(x => x.Remove());
            doc.Save(putanja);
            


            dok.Load(putanja);
            XmlNode setting = dok.CreateElement("Setting");

            XmlAttribute tray = dok.CreateAttribute("Tray");
            tray.InnerText = checkEdit1.Checked.ToString();
            setting.Attributes.SetNamedItem(tray);

            XmlAttribute minimizeNotif = dok.CreateAttribute("MinimizeNotif");
            minimizeNotif.InnerText = checkEdit2.Checked.ToString();
            setting.Attributes.SetNamedItem(minimizeNotif);



            XmlElement elem = (XmlElement)dok.SelectSingleNode("/Configuration/" + "Settings");
            elem.AppendChild(setting);
            dok.Save(putanja);

            AbacusSUPP.Helper.load_settings();
            
            this.Close();
        }
        

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == false) checkEdit2.Enabled = false;
            if (checkEdit1.Checked == true) checkEdit2.Enabled = true;
        }
    }
}
