using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
            barStaticItem1.Caption = "Ulogovan kao: " + OperaterLogin.operater.username;
            //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (operater.isAdmin == true)
            {
                //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                
            }

            gridView1.Appearance.FocusedRow.BackColor = gridView1.Appearance.FocusedCell.BackColor =
                 gridView1.Appearance.SelectedRow.BackColor = Color.Transparent;

            //timer1.Tick += new EventHandler(timer1_Tick); // Everytime timer ticks, timer_Tick will be called
            timer1.Interval = (1000) * (15);             // Timer will tick evert 10 seconds
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();                              // Start the timer
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
            //if (e.RowHandle == view.FocusedRowHandle) return;
            if (e.Column.FieldName == "Prioritet.opis")
            {
                if (e.RowHandle >= 0)
                {


                    if (e.CellValue.ToString() == "High")
                    {
                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("highpriority_16x16.png")];

                        e.Cache.DrawImage(image, e.Bounds.Left+5, e.Bounds.Top + 15);
                    }
                    if (e.CellValue.ToString() == "Medium")
                    {
                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("normalpriority_16x16.png")];

                        e.Cache.DrawImage(image, e.Bounds.Left+5, e.Bounds.Top + 15);
                    }
                    if (e.CellValue.ToString() == "Low")
                    {


                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("lowpriority_16x16.png")];
                        e.Cache.DrawImage(image, e.Bounds.Left+5,e.Bounds.Top+15);
                    }
                }
            }
            if (e.Column.FieldName == "BrKomentara")
            {
                if (e.RowHandle >= 0)
                {
                    
                   Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("comment_16x16.png")];

                   e.Cache.DrawImage(image, e.Bounds.Left+5, e.Bounds.Top + 15);
                    
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

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;

            GridHitInfo hitInfo = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            //var a = MousePosition;

            if ((e.Button == MouseButtons.Right) && (hitInfo.InDataRow))
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = Baza.Task.ToList().OrderBy(qq => qq.datum);
            gridView1.RefreshData();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = Baza.Task.Where(ww=>ww.Status.opis=="U toku").ToList().OrderBy(qq => qq.datum);
            gridView1.RefreshData();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = Baza.Task.Where(ww => ww.Status.opis == "Zavrseno").ToList().OrderBy(qq => qq.datum);
            gridView1.RefreshData();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Task.ToList().OrderBy(qq => qq.datum);
            gridView1.RefreshData();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == BrKomentara)
            {
                var row = (Task)e.Row;
                e.Value = Baza.Komentar.Where(qq => qq.id_task == row.id_task).Count();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task zaDel = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            deleteTask(zaDel);
        }
        public void deleteTask(Task taskzaDelete)
        {
            //int id = taskzaDelete.id_task;
            //List<Komentar> listakom = Baza.Komentar.Where(qq => qq.id_task == id).ToList();           
            //Baza.Komentar.RemoveRange(listakom);
            //Baza.SaveChanges();
            Baza.Task.Remove(taskzaDelete);
            Baza.SaveChanges();
            gridControl1.DataSource = Baza.Task.ToList();
            gridView1.RefreshData();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                FormAddTask frmat = new FormAddTask(task.id_task);
                frmat.ShowDialog();
            }
            //Baza.Entry(task).Reload();
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Task.ToList().OrderBy(qq=>qq.datum);
            gridView1.RefreshData();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTest testforma = new FormTest();
            testforma.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            FormOperater fdo = new FormOperater();
            fdo.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Task> stara_lista = (gridControl1.DataSource as IEnumerable<Task>).OrderBy(it=> it.datum).ToList();
            List<Task> nova_lista = Baza.Task.OrderBy(qq => qq.datum).ToList();
            //var razlika = nova_lista.Except(stara_lista).ToList();
            var razlika = nova_lista.Where(qq => qq.datum > stara_lista.Max(ww => ww.datum)).ToList();
            if (razlika.Count>0)
            {
                Baza = new AbacusSUPEntities();
                gridControl1.DataSource = nova_lista.OrderBy(qw=>qw.datum);
                gridView1.RefreshData();
                List<VezaLT> listaveza = Baza.VezaLT.ToList();
                
                foreach(Task novi in razlika)
                {
                    toastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.True;
                    if(listaveza.Where(qq=>qq.id_task==novi.id_task && qq.id_login==OperaterLogin.operater.id)!=null)
                        toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
                }

                
            }
        }
    }
}
