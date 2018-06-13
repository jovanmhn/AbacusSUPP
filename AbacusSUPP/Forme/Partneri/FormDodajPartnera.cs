using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP
{
    public partial class FormDodajPartnera : DevExpress.XtraEditors.XtraForm
    {
        int id_partner;
        Partneri partner;
        AbacusSUPEntities Baza { get; set; }
        public FormDodajPartnera(int _idpartner)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            id_partner = _idpartner;
            if (id_partner != 0)
            {
                partner = Baza.Partneri.First(qq => qq.id == id_partner);
            }
            else
            {
                partner = new Partneri();
                Baza.Partneri.Add(partner);
                
            }
            bindingSource1.Add(partner);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (!Baza.Partneri.Select(qq => qq.naziv).Contains(partner.naziv))
            {
                Baza.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else XtraMessageBox.Show("Partner vec postoji!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
