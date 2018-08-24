using DevExpress.Skins;
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
        AbacusSUPEntities Baza { get; set; }
        Podesavanja podesavanja { get; set; }
        string skinName_old;

        public FormSettings(Podesavanja _podesavanja)
        {
            InitializeComponent();
            #region staro xml
            //STARO XML
            /*
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
            */
            #endregion
            Baza = new AbacusSUPEntities();
            podesavanja = Baza.Podesavanja.First(qq => qq.id_podesavanja == _podesavanja.id_podesavanja);
            PodesavanjaBindingSource.Add(podesavanja);
            checkEdit1.Checked = podesavanja.minimize_tray;
            if (!checkEdit1.Checked) { checkEdit2.Checked = false; checkEdit2.Enabled = false; }
            else { checkEdit2.Checked = podesavanja.minimize_notif; }
            checkEdit3.Checked = podesavanja.novitask_notif;
            checkEdit4.Checked = podesavanja.minimize_tray;
            checkEdit5.Checked = podesavanja.task_novi_prozor;
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {

                List<string> listaskinova = new List<string>();
                listaskinova.Add(cnt.SkinName);
                
                comboBoxEdit1.Properties.Items.AddRange(listaskinova);
            }
            skinName_old = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (Binding q in PodesavanjaBindingSource.CurrencyManager.Bindings) q.WriteValue();
            Baza.SaveChanges();
            #region staro xml
            /*
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
            */
            #endregion
            OperaterLogin.operater = Baza.Login.First(qq => qq.id == OperaterLogin.operater.id);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == false) {  checkEdit2.Checked = false; checkEdit2.Enabled = false; }
            if (checkEdit1.Checked == true) checkEdit2.Enabled = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }


        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string skinName = comboBoxEdit1.EditValue.ToString();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinName;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult!=DialogResult.OK) DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinName_old;
        }
    }
}
