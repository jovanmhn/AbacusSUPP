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
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        AbacusSUPEntities Baza { get; set; }
        public FormMain(Login operater)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Task.ToList().OrderBy(qq=> qq.datum);
            //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (operater.isAdmin == true)
            {
                //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                
            }
            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*FormAddTask frmat = new FormAddTask();
            frmat.ShowDialog();*/
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = Baza.Task.ToList();
            gridView1.RefreshData();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task task = new Task();
            FormAddTask frmat = new FormAddTask(task.id_task);

            frmat.ShowDialog();

            //Baza.Entry(task).Reload();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Task.ToList();


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                FormTaskMain frmtm = new FormTaskMain(task);
                frmtm.ShowDialog();
            }
            /*************EDIT TASK*************************************
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                FormAddTask frmat = new FormAddTask(task.id_task);
                frmat.ShowDialog();
            }
            //Baza.Entry(task).Reload();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Task.ToList();
            gridView1.RefreshData();
            ***************************************************************/
        }
    }
}
