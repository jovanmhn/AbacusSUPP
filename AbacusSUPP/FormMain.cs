using DevExpress.XtraEditors;
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
            gridControl1.DataSource = Baza.Task.ToList().OrderBy(qq=> qq.datum);


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                FormTaskMain frmtm = new FormTaskMain(task);
                frmtm.ShowDialog();
                gridControl1.DataSource = Baza.Task.ToList().OrderBy(qq => qq.datum);
                gridView1.RefreshData();

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

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle) return;
            if (e.Column.FieldName != "Prioritet.opis") return;
            // Fill a cell's background if its value is greater than 30. 
            if (e.RowHandle >= 0)
            {


                if (e.CellValue.ToString() == "High" )
                {
                    Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("highpriority_16x16.png")];

                    e.Cache.DrawImage(image, e.Bounds.Location);
                }
                if (e.CellValue.ToString() == "Medium" )
                {
                    Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("normalpriority_16x16.png")];

                    e.Cache.DrawImage(image, e.Bounds.Location);
                }
                if (e.CellValue.ToString() == "Low" )
                {
                    
                    
                    Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("lowpriority_16x16.png")];
                    e.Cache.DrawImage(image, e.Bounds.Location);
                }
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string status = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Status.opis"]);
                if (status == "Zavrseno")
                {
                    e.Appearance.BackColor = Color.LightGray;
                    goto kraj;
                }
                    
                string prioritet = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Prioritet.opis"]);
                if (prioritet == "High")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
                if (prioritet == "Low")
                {
                    //e.Appearance.BackColor = Color.LightYellow;
                    //e.Appearance.BackColor2 = Color.LightGoldenrodYellow;
                }
                if (prioritet == "Medium")
                {
                    e.Appearance.BackColor = Color.LightYellow;
                    e.Appearance.BackColor2 = Color.LightGoldenrodYellow;
                }
                kraj:;
            }
        }
    }
}
