using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FormKolone : DevExpress.XtraEditors.XtraForm
    {
        List<kolona> listakolona = new List<kolona>();
        public FormKolone(GridColumnCollection kolone, GridView view)
        {
            InitializeComponent();
            foreach(GridColumn kolona in kolone)
            {
                kolona kol = new kolona
                {
                    Naziv = kolona.Name,
                    Enabled = kolona.Visible,
                };
            }
            gridControl1.DataSource = listakolona;
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
    public class kolona
    {
        public string Naziv { get; set; }
        public bool Enabled { get; set; }
    }
}
