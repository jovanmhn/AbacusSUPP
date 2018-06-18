﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AbacusSUPP
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        AbacusSUPEntities Baza { get; set; }
        public FormMain(Login operater, ProgressBarControl progressBar)
        {
            InitializeComponent();
            progressBar.PerformStep();
            progressBar.Update();
            Baza = new AbacusSUPEntities();
            progressBar.PerformStep();
            progressBar.Update();
            gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq=> qq.datum);
            barStaticItem1.Caption = "Ulogovan kao: " + OperaterLogin.operater.username;
            progressBar.PerformStep();
            progressBar.Update();
            //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (operater.isAdmin == true)
            {
                //barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                
            }
            progressBar.PerformStep();
            progressBar.Update();
            notifyIcon1.Visible = false;
            notifyIconNotifikacija.Visible = false;

            gridView1.Appearance.FocusedRow.BackColor = gridView1.Appearance.FocusedCell.BackColor =
                 gridView1.Appearance.SelectedRow.BackColor = Color.Transparent;
            

            //timer1.Tick += new EventHandler(timer1_Tick); // Everytime timer ticks, timer_Tick will be called
            timer1.Interval = (1000) * (15);             // Timer will tick evert 10 seconds
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();                              // Start the timer

            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
            this.notifyIcon1.BalloonTipText = "Minimizovan u tray!";
            this.notifyIcon1.BalloonTipTitle = "AbacusSupport";
            progressBar.PerformStep();
            progressBar.Update();
            //this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon"))); //The tray icon to use
            this.notifyIcon1.Text = "Dupli klik za restore";

            DevExpress.Data.ShellHelper.TryCreateShortcut("c65ba894-3c54-4851-85e5-cdb49d097c02", "AbacusSupport");
            progressBar.PerformStep();
            progressBar.Update();
            OperaterLogin.seen_tasks = Baza.Task.Select(qq => qq.id_task).ToList();

            AbacusSUPP.Helper.load_settings(); //UCITAVANJE SETTINGS.XML

            progressBar.Position=0;
            progressBar.Update();


            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIconNotifikacija.Visible = false;
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
            gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq=> qq.datum);


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            
            
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                OperaterLogin.seen_tasks.Add(task.id_task);
                FormTaskMain frmtm = new FormTaskMain(task, splashScreenManager1);
                frmtm.Show();
                frmtm.FormClosed += (ss, ee) =>         //NOVO**
                {
                    if (frmtm.DialogResult == DialogResult.OK)
                    {
                        Baza = new AbacusSUPEntities();
                        gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq => qq.datum);
                        gridView1.RefreshData();
                    }
                };

                
                /**************************STARO**************************
                //this.WindowState = FormWindowState.Minimized;
                var res = frmtm.ShowDialog();
                frmtm.Focus();
                frmtm.BringToFront();
                

                if (res==DialogResult.OK)
                {
                    Baza = new AbacusSUPEntities();
                    gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq => qq.datum);
                    gridView1.RefreshData(); 
                }
                *****************************************************/
            }
            this.WindowState = FormWindowState.Maximized;
            notifyIcon1.Visible = false;
            notifyIconNotifikacija.Visible = false;
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
            if (e.Column.FieldName == "id_task")
            {
                if (e.RowHandle >= 0)
                {
                    var row = (Task)gridView1.GetRow(e.RowHandle);
                    if (!OperaterLogin.seen_tasks.Contains(row.id_task))
                    {
                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("newtask_16x16.png")];
                        e.Cache.DrawImage(image, e.Bounds.Left + 15, e.Bounds.Top + 15);
                        using (Pen p = new Pen(Color.Salmon, 1))
                        {
                            Rectangle rect = e.Bounds;
                            rect.Width -= 1;
                            rect.Height -= 1;
                            e.Graphics.DrawRectangle(p, rect);
                        }
                        e.Handled = true;
                    }
                    if(Baza.VezaLT.ToList().FirstOrDefault(qq=>qq.id_task==row.id_task && qq.id_login == OperaterLogin.operater.id) != null)
                    {
                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("feature_16x16.png")];
                        e.Cache.DrawImage(image, e.Bounds.Left + 45, e.Bounds.Top + 15);
                    }

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
            gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq => qq.datum);
            gridView1.RefreshData();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = Baza.Task.Where(ww=>ww.Status.opis=="U toku").ToList().OrderByDescending(qq => qq.datum);
            gridView1.RefreshData();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = Baza.Task.Where(ww => ww.Status.opis == "Zavrseno").ToList().OrderByDescending(qq => qq.datum);
            gridView1.RefreshData();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Baza = new AbacusSUPEntities();
            gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq => qq.datum);
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
            gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq=>qq.datum);
            gridView1.RefreshData();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                FormAddTask frmat = new FormAddTask(task.id_task);
                var res = frmat.ShowDialog();
                if (res == DialogResult.OK)
                {

                Baza = new AbacusSUPEntities();
                gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq=>qq.datum);
                gridView1.RefreshData();
                }
            }
            //Baza.Entry(task).Reload();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormTest testforma = new FormTest();
            testforma.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            FormOperater fdo = new FormOperater();
            fdo.MdiParent = this;
            fdo.Show();
            xtraTabControl1.Visible = false;
            fdo.FormClosed += (ss, ee) =>         //NOVO**
            {              
                xtraTabControl1.Visible = true;           
            };
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Task> stara_lista = (gridControl1.DataSource as IEnumerable<Task>).OrderByDescending(it=> it.datum).ToList();
            List<Task> nova_lista = Baza.Task.OrderByDescending(qq => qq.datum).ToList();
            //var razlika = nova_lista.Except(stara_lista).ToList();
            var razlika = nova_lista.Where(qq => qq.datum > stara_lista.Max(ww => ww.datum)).ToList();
            if (razlika.Count>0)
            {
                Baza = new AbacusSUPEntities();
                gridControl1.DataSource = Baza.Task.OrderByDescending(qq => qq.datum).ToList();
                gridView1.RefreshData();
                List<VezaLT> listaveza = Baza.VezaLT.ToList();
                
                foreach(Task novi in razlika)
                {

                    if (listaveza.Where(qq => qq.id_task == novi.id_task && qq.id_login == OperaterLogin.operater.id) != null)
                    {
                        toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
                        this.notifyIcon1.Visible = false;
                        this.notifyIconNotifikacija.Visible = true;
                        
                        //toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
                        FlashWindowEx(this);
                    }
                        

                }

                
            }
        }
        // To support flashing.
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;

        // Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12;

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        // Do the flashing - this does not involve a raincoat.
        public static bool FlashWindowEx(Form form)
        {
            IntPtr hWnd = form.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;

            return FlashWindowEx(ref fInfo);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && OperaterLogin.podesavanja.tray)
            {
                notifyIcon1.Visible = true;
                if(OperaterLogin.podesavanja.minimizeNotification) notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void notifyIconNotifikacija_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
            notifyIconNotifikacija.Visible = false;
        }

        

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormSettings frmsett = new FormSettings();
            frmsett.ShowDialog();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                popupMenu2.ShowPopup(MousePosition);
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void notifyIconNotifikacija_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu2.ShowPopup(MousePosition);
            }
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPartneri fpart = new FormPartneri();
            fpart.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.Visible == true) xtraTabControl1.Visible = false;
            else xtraTabControl1.Visible = true;
        }
    }
     
}