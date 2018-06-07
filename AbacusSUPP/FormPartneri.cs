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
    public partial class FormPartneri : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        public FormPartneri()
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Partneri.ToList();
            gridView1.RefreshData();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Partneri partner = new Partneri();
            FormDodajPartnera fdp = new FormDodajPartnera(partner.id);
            var res = fdp.ShowDialog();
            if (res == DialogResult.OK)
            {
                Baza = new AbacusSUPEntities();
                gridControl1.DataSource = Baza.Partneri.ToList();
                gridView1.RefreshData();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Partneri partner = (Partneri)gridView1.GetRow(gridView1.FocusedRowHandle);

            if (partner!=null)
            {
                FormDodajPartnera fdp = new FormDodajPartnera(partner.id);
                var res = fdp.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Baza = new AbacusSUPEntities();
                    gridControl1.DataSource = Baza.Partneri.ToList();
                    gridView1.RefreshData();
                } 
            }
        }
    }
}
