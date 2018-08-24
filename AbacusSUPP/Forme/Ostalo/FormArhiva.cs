using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP.Forme.Ostalo
{
    public partial class FormArhiva : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        public FormArhiva()
        {
            InitializeComponent();  
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Task.Where(qq => qq.status_id == 2).OrderByDescending(ww=> ww.datum_zatv).ToList();
            gridView1.RefreshData();
            gridView1.Appearance.FocusedRow.BackColor = gridView1.Appearance.FocusedCell.BackColor =
                 gridView1.Appearance.SelectedRow.BackColor = Color.Transparent;    
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            FormTaskMain frmtm = new FormTaskMain(task);
            frmtm.Show();
        }
    }
}
