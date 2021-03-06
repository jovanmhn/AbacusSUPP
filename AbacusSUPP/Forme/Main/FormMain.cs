﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using Octokit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace AbacusSUPP
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Dictionary<string, Task> NotificationsTask { get; set; }
        Dictionary<string, Komentar> NotificationsKomentar { get; set; }
        //AbacusSUPEntities Baza { get; set; }
        List<Task> Main_lista = new List<Task>();
        AbacusSUPEntities Baza { get; set; }


        public FormMain(Login operater, ProgressBarControl progressBar)
        {
            NotificationsTask = new Dictionary<string, Task>();
            NotificationsKomentar = new Dictionary<string, Komentar>();

            InitializeComponent();
            OperaterLogin.NotifOverride = true;
            progressBar.PerformStep();
            progressBar.Update();

            Baza = new AbacusSUPEntities();
            taskBindingSource.DataSource = Main_lista = Baza.Task.OrderByDescending(qq=>qq.datum).ToList();

            progressBar.PerformStep();
            progressBar.Update();


            //gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq=> qq.datum);
            barStaticItem1.Caption = "Operater: " + OperaterLogin.operater.username;
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
            //DevExpress.Data.ShellHelper.TryCreateShortcut("377853e6-0719-4ea9-89f3-f5db7e72b26c", "AbacusSupport");

            progressBar.PerformStep();
            progressBar.Update();
            OperaterLogin.seen_tasks = Baza.Task.Select(qq => qq.id_task).ToList();

            AbacusSUPP.Helper.load_settings(); //UCITAVANJE SETTINGS.XML
            gridView1.OptionsBehavior.AllowPixelScrolling = OperaterLogin.operater.Podesavanja.pixel_scr ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

            progressBar.Position = 0;
            progressBar.Update();

            OperaterLogin.stara_kom_lista = Baza.Komentar.ToList();


        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIconNotifikacija.Visible = false;
            if(OperaterLogin.NE_IZLAZI_AOAO==false) System.Windows.Forms.Application.Exit();
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
            //gridControl1.DataSource = Baza.Task.ToList();
            gridControl1.DataSource = taskBindingSource.DataSource;
            gridView1.RefreshData();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            Task task = new Task
            {
                login_id = OperaterLogin.operater.id,
                datum = DateTime.Now,
                status_id = 1,
            };
            FormAddTask frmat = new FormAddTask(task);

            var res = frmat.ShowDialog();

            if (res == DialogResult.OK)
            {
                Baza = new AbacusSUPEntities();
                var new_task = Baza.Task.FirstOrDefault(qq => qq.id_task == task.id_task);
                Main_lista.Add(new_task);
                Main_lista.OrderByDescending(qq => qq.datum);
                taskBindingSource.DataSource = Main_lista.OrderByDescending(qq => qq.datum);
                gridView1.RefreshData();
            }


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            GridHitInfo hitinfo = gridView1.CalcHitInfo(Cursor.Position);

            if (true /*hitinfo.InDataRow*/)
            {
                Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
                if (task != null)
                {
                    OperaterLogin.seen_tasks.Add(task.id_task);
                    FormTaskMain frmtm = new FormTaskMain(task, splashScreenManager1);
                    //frmtm.MdiParent = this;
                    //xtraTabControl1.Visible = false;
                    //frmtm.Show();

                    frmtm.FormClosed += (ss, ee) =>         //NOVO**    
                    {
                        if (frmtm.DialogResult == DialogResult.OK)
                        {
                            Task local = Main_lista.First(qq => qq.id_task == task.id_task);
                            int index = Main_lista.IndexOf(local);
                            Main_lista.Remove(local);
                            var db = new AbacusSUPEntities();
                            //var editovan = Baza.Task.First(qq => qq.id_task == task.id_task);

                            xtraTabControl1.Visible = true;
                            Task novi = db.Task.First(qq => qq.id_task == task.id_task);
                            Main_lista.Insert(index, novi);
                            db.Entry(novi).Reload();
                            //gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq=>qq.datum);
                            Main_lista.OrderByDescending(qq => qq.datum);
                            gridView1.RefreshData();
                        }
                    };

                    if (!OperaterLogin.operater.Podesavanja.task_novi_prozor)
                    {
                        var page = xtraTabControl1.TabPages.FirstOrDefault(it => (string)it.Tag == task.id_task.ToString());

                        if (page == null)
                        {
                            page = new DevExpress.XtraTab.XtraTabPage()
                            {
                                Tag = task.id_task.ToString(),
                                Text = task.id_task.ToString() + " - " + task.naslov,

                            };


                            page.ImageOptions.Image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("task_16x16.png")];
                            page.Controls.Add(frmtm.MainPanel);
                            
                            xtraTabControl1.TabPages.Add(page);
                            if (!OperaterLogin.operater.Podesavanja.task_novi_prozor)
                            {
                                frmtm.koriguj_izgled(); 
                            }

                        }

                        xtraTabControl1.SelectedTabPage = page; 
                    }

                    else
                    {

                        //*************************STARO**************************
                        //this.WindowState = FormWindowState.Minimized;
                        frmtm.Show();
                        frmtm.Focus();
                        frmtm.BringToFront();


                        if (frmtm.DialogResult==DialogResult.OK)
                        {
                            Baza = new AbacusSUPEntities();
                            gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq => qq.datum);
                            gridView1.RefreshData(); 
                        }
                        //*****************************************************/
                    }
                }
            }
            else MessageBox.Show("Nije prosao hit info!");

            //this.WindowState = FormWindowState.Maximized;
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
            
            if (e.Column.FieldName == "Prioritet.opis")
            {
                if (e.RowHandle >= 0)
                {


                    if (e.CellValue.ToString() == "High")
                    {
                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("highpriority_16x16.png")];

                        e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15);
                    }
                    if (e.CellValue.ToString() == "Medium")
                    {
                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("normalpriority_16x16.png")];

                        e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15);
                    }
                    if (e.CellValue.ToString() == "Low")
                    {


                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("lowpriority_16x16.png")];
                        e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15);
                    }
                }
            }
            if (e.Column.FieldName == "BrKomentara")
            {
                if (e.RowHandle >= 0)
                {

                    Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("comment_16x16.png")];

                    e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15);

                }
            }
            if (e.Column.FieldName == "id_task")
            {
                if (e.RowHandle >= 0)
                {

                    var row = (Task)gridView1.GetRow(e.RowHandle);

                    if (row != null)
                    {
                        var Baza = new AbacusSUPEntities();
                        Task red = Baza.Task.FirstOrDefault(qq => qq.id_task == row.id_task);
                        if (red != null && Baza.VezaLT.ToList().FirstOrDefault(qq => qq.id_task == red.id_task && qq.id_login == OperaterLogin.operater.id) != null)
                        {
                            Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("feature_16x16.png")];
                            e.Cache.DrawImage(image, e.Bounds.Left + 45, e.Bounds.Top + 15);
                        }
                    }
                    if (!OperaterLogin.seen_tasks.Contains(row.id_task))
                    {
                        Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("newtask_16x16.png")];
                        e.Cache.DrawImage(image, e.Bounds.Left + 15, e.Bounds.Top + 15);
                    }
                    
                }
            }
            if(e.Column.FieldName == "Labela")
            {
                Task task = (Task)gridView1.GetRow(e.RowHandle);
                if (e.RowHandle >= 0)
                {
                    if (task.Label != null)
                    {
                        switch (task.id_label)
                        {
                            case (1): { Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("zubcanik 100ico.png")]; e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15); return; }
                            case (2): { Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("ERP16x16png.png")]; e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15); return; }
                            case (3): { Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("POSpng32x32.png")]; e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15);  return; }
                            case (4): { Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("RMSpng16x16.png")]; e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15); return; }
                            default: { Image image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("ide_16x16.png")]; e.Cache.DrawImage(image, e.Bounds.Left + 5, e.Bounds.Top + 15); return; }
                        }



                    }
                    else
                    {
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.BackColor2 = Color.White;
                    }
                    e.Handled = true;
                }
            }
            
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                Task task = (Task)View.GetRow(e.RowHandle);

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
            if ((e.Button == MouseButtons.Middle) && (hitInfo.InDataRow))
            {
                view.FocusedRowHandle = hitInfo.RowHandle;
                radialMenu1.ShowPopup(MousePosition);
                
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var db = new AbacusSUPEntities();
            Main_lista = Baza.Task.OrderByDescending(qq => qq.datum).ToList();
            taskBindingSource.DataSource = Main_lista;
            gridView1.RefreshData();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Main_lista = Main_lista.Where(ww => ww.Status.opis == "U toku").OrderByDescending(qq => qq.datum).ToList();
            taskBindingSource.DataSource = Main_lista;
            gridView1.RefreshData();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Main_lista = Main_lista.Where(ww => ww.Status.opis == "Zavrseno").OrderByDescending(qq => qq.datum).ToList();
            taskBindingSource.DataSource = Main_lista;
            gridView1.RefreshData();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var db = new AbacusSUPEntities();
            Main_lista = db.Task.OrderByDescending(qq => qq.datum).ToList();
            taskBindingSource.DataSource = Main_lista;
            gridView1.RefreshData();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var Baza = new AbacusSUPEntities();

            if (e.Column == BrKomentara)
            {
                var row = (Task)e.Row;
                e.Value = Baza.Komentar.Where(qq => qq.id_task == row.id_task).Count();
            }

            if (e.Column == Labela)
            {

               
                var row = (Task)e.Row;
                row = Baza.Task.First(qq => qq.id_task == row.id_task);
                if (row.id_label != null)
                {
                    e.Value = row.Label.label1;
                }
                else e.Value = "OST";
            }
        }


        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Baza = new AbacusSUPEntities();
            Task zaDel = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            Main_lista.Remove(Main_lista.First(qq => qq.id_task == zaDel.id_task));
            Baza.Task.Remove(Baza.Task.First(qq => qq.id_task == zaDel.id_task));
            Baza.SaveChanges();

            try
            {
                Directory.Delete(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + zaDel.id_task.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq => qq.datum);
            Main_lista.OrderByDescending(qq => qq.datum);
            taskBindingSource.DataSource = Main_lista.OrderByDescending(qq => qq.datum);  
            gridView1.RefreshData();


        }
        public void deleteTask(Task taskzaDelete) // ne koristi se!
        {
            //int id = taskzaDelete.id_task;
            //List<Komentar> listakom = Baza.Komentar.Where(qq => qq.id_task == id).ToList();           
            //Baza.Komentar.RemoveRange(listakom);
            //Baza.SaveChanges();
            var Baza = new AbacusSUPEntities();
            Baza.Task.Remove(taskzaDelete);
            Baza.SaveChanges();
            gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq => qq.datum);
            gridView1.RefreshData();
            Baza = new AbacusSUPEntities();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                FormAddTask frmat = new FormAddTask(task);
                var res = frmat.ShowDialog();
                if (res == DialogResult.OK)
                {
                    int index = Main_lista.IndexOf(task);
                    Main_lista.Remove(task);
                    var db = new AbacusSUPEntities();
                    //var editovan = Baza.Task.First(qq => qq.id_task == task.id_task);


                    Task novi = db.Task.First(qq => qq.id_task == task.id_task);
                    Main_lista.Insert(index, novi);
                    db.Entry(novi).Reload();
                    //gridControl1.DataSource = Baza.Task.ToList().OrderByDescending(qq=>qq.datum);
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
            //foreach (Form form in Application.OpenForms)        //da ne prikazuje duple forme
            //{
            //    if (form.GetType() == typeof(FormOperater))
            //    {
            //        form.Activate();
            //        return;
            //    }
            //}

            //FormOperater fdo = new FormOperater();
            //fdo.MdiParent = this;
            //fdo.Show();
            //xtraTabControl1.Visible = false;
            var page = xtraTabControl1.TabPages.FirstOrDefault(it => it.Tag == barButtonItem2.Tag);

            if (page == null)
            {
                page = new DevExpress.XtraTab.XtraTabPage()
                {
                    Tag = barButtonItem2.Tag,
                    Text = barButtonItem2.Caption,

                };

                FormOperater formoperater = new FormOperater();
                page.ImageOptions.Image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("usergroup_16x16.png")];
                page.Appearance.Header.Font = new Font("Tahoma", (float)8.25, FontStyle.Bold);
                page.Controls.Add(formoperater.MainPanel);
                xtraTabControl1.TabPages.Add(page);
                
            }

            xtraTabControl1.SelectedTabPage = page;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            var Baza = new AbacusSUPEntities();

            List<Task> stara_lista = Main_lista.OrderByDescending(qq => qq.datum).ToList();
            List<Task> nova_lista = Baza.Task.OrderByDescending(qq => qq.datum).ToList();
            //var razlika = nova_lista.Except(stara_lista).ToList();
            var razlika = nova_lista.Where(qq => qq.datum > stara_lista.Max(ww => ww.datum)).ToList();
            if (stara_lista.Count == 0 && nova_lista.Count > 0) razlika.AddRange(nova_lista);
            if (razlika.Count > 0)
            {

                //gridControl1.DataSource = Baza.Task.OrderByDescending(qq => qq.datum).ToList();
                Main_lista.Clear();
                Main_lista.AddRange(nova_lista);
                taskBindingSource.DataSource = Main_lista.OrderByDescending(qq => qq.datum);
                gridView1.RefreshData();

                List<VezaLT> listaveza = Baza.VezaLT.ToList();

                foreach (Task novi in razlika)
                {
                    stara_lista.Add(novi); // dodaj u staru listu

                    if (listaveza.Where(qq => qq.id_task == novi.id_task && qq.id_login == OperaterLogin.operater.id) != null)
                    {

                        if (OperaterLogin.operater.Podesavanja.novitask_notif && novi.Login.id != OperaterLogin.operater.id && OperaterLogin.NotifOverride)  // ako su podesavanja ispravna i operater razlicit od logovanog
                        {

                            //toastNotificationsTask.Activated += (ss, ee) =>         //NOVO**
                            //{
                            //    //FormTaskMain frmtm = new FormTaskMain(novi);
                            //    //frmtm.Show();

                            //    MessageBox.Show("Task notifikacija kliknuta! \n " + "Elemenata u listi razlika" + razlika.Count.ToString() + "\n Task trenutno: " + novi.naslov + "\nTask ID:" + novi.id_task.ToString());
                            //};

                            string guid = Guid.NewGuid().ToString();
                            var notification = new DevExpress.XtraBars.ToastNotifications.ToastNotification()
                            {
                                ID = guid,
                                Body = novi.Login.username + " je otvorio novi task, " + novi.naslov + "!",
                                Sound = DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.IM,
                                
                                
                            };
                            //notification.Image = notification.AppLogoImage;
                            NotificationsTask.Add(guid, novi);
                            toastNotificationsTask.Notifications.Add(notification);
                            toastNotificationsTask.ShowNotification(notification);

                            //toastNotificationsTask.Notifications[0].Body = novi.Login.username + " je otvorio novi task, " + novi.naslov + "!";
                            //toastNotificationsTask.ShowNotification(toastNotificationsTask.Notifications[0]);
                        }
                        if (this.WindowState == FormWindowState.Minimized && OperaterLogin.operater.Podesavanja.minimize_tray)
                        {
                            this.notifyIcon1.Visible = false;
                            this.notifyIconNotifikacija.Visible = true;
                        }

                        //toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
                        FlashWindowEx(this);
                    }



                }
                razlika.Clear();


            }
            //Baza.SaveChanges();

            Baza = new AbacusSUPEntities();

            List<Komentar> nova_kom_lista = Baza.Komentar.ToList();

            var razlika_kom = nova_kom_lista.Where(qq => qq.datum > OperaterLogin.stara_kom_lista.Max(ww => ww.datum)).ToList();
            if (OperaterLogin.stara_kom_lista.Count == 0 && nova_kom_lista.Count > 0) razlika_kom.AddRange(nova_kom_lista);
            if (razlika_kom.Count > 0)
            {

                List<VezaLT> listaveza = Baza.VezaLT.ToList();

                foreach (Komentar novi in razlika_kom)
                {
                    OperaterLogin.stara_kom_lista.Add(novi); //dodaj aktuelni komentar u staru listu

                    if (listaveza.Where(qq => qq.id_task == novi.id_task && qq.id_login == OperaterLogin.operater.id) != null)
                    {

                        if (OperaterLogin.operater.Podesavanja.novikom_notif && OperaterLogin.operater.id != novi.Login.id && OperaterLogin.NotifOverride) // ako podesavanj dozvoljavaju i ako je komentar od operatera koji nije trenutno logovan
                        {
                            string guid = Guid.NewGuid().ToString();
                            var notification = new DevExpress.XtraBars.ToastNotifications.ToastNotification()
                            {
                                ID = guid,
                                Body = novi.Login.username + " je dodao novi komentar na task, " + novi.Task.naslov + "!",
                                Sound = DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.IM,


                            };
                            //notification.Image = notification.AppLogoImage;
                            NotificationsKomentar.Add(guid, novi);
                            toastNotificationsKomentar.Notifications.Add(notification);
                            toastNotificationsKomentar.ShowNotification(notification);
                            

                        }
                        if (this.WindowState == FormWindowState.Minimized && OperaterLogin.operater.Podesavanja.minimize_tray)
                        {
                            this.notifyIcon1.Visible = false;
                            this.notifyIconNotifikacija.Visible = true;
                        }


                        //toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
                        FlashWindowEx(this);
                    }


                }
                razlika_kom.Clear();


            }
            timer1.Interval = (1000) * (15);             // Timer will tick evert 10 seconds
            timer1.Enabled = true;                       // Enable the timer
            timer1.Start();
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
            if (this.WindowState == FormWindowState.Minimized && OperaterLogin.operater.Podesavanja.minimize_tray)
            {
                notifyIcon1.Visible = true;
                if (OperaterLogin.operater.Podesavanja.minimize_notif) notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                notifyIcon1.Visible = false;
                notifyIconNotifikacija.Visible = false;
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
            settings:
            if(OperaterLogin.operater.id_podesavanja!=0 && OperaterLogin.operater.id_podesavanja != null)
            {

                FormSettings frmsett = new FormSettings(OperaterLogin.operater.Podesavanja,gridView1);
                var res = frmsett.ShowDialog();
                if (res == DialogResult.OK)
                {
                    var Baza = new AbacusSUPEntities();
                    OperaterLogin.operater = Baza.Login.First(qq => qq.id == OperaterLogin.operater.id);
                }
            }
            else
            {
                Podesavanja pod = new Podesavanja
                {
                    minimize_notif = false,
                    minimize_tray = true,
                    novitask_notif = true,
                    novikom_notif = true,
                    task_novi_prozor = false,
                    pixel_scr = false,
                    task_github_upload = false,
                    kom_github_upload = false,
                };
                var db = new AbacusSUPEntities();
                db.Podesavanja.Add(pod);
                db.SaveChanges();
                var op = db.Login.First(qq => qq.id == OperaterLogin.operater.id);
                op.id_podesavanja = pod.id_podesavanja;
                db.SaveChanges();
                var log = db.Login.First(qq => qq.id == OperaterLogin.operater.id);
                OperaterLogin.operater = log;
                goto settings;

            }

            /*frmsett.FormClosed += (ss, ee) =>         //NOVO**
            {
                Baza = new AbacusSUPEntities();
                OperaterLogin.operater = Baza.Login.First(qq => qq.id == OperaterLogin.operater.id);
            };*/
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
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
            //foreach (Form form in Application.OpenForms)        //da ne prikazuje duple forme
            //{
            //    if (form.GetType() == typeof(FormPartneri))
            //    {
            //        form.Activate();
            //        return;
            //    }
            //}

            //FormPartneri fpart = new FormPartneri();
            //fpart.Show();
            //fpart.MdiParent = this;
            //fpart.Show();
            //xtraTabControl1.Visible = false;

            var page = xtraTabControl1.TabPages.FirstOrDefault(it => it.Tag == barButtonItem14.Tag);

            if (page == null)
            {
                page = new DevExpress.XtraTab.XtraTabPage()
                {
                    Tag = barButtonItem14.Tag,
                    Text = barButtonItem14.Caption,
                    
                };

                FormPartneri formpartneri = new FormPartneri();
                page.ImageOptions.Image = imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("user_16x16.png")];
                page.Appearance.Header.Font = new Font("Tahoma", (float)8.25, FontStyle.Bold);
                page.Controls.Add(formpartneri.MainPanel);
                xtraTabControl1.TabPages.Add(page);
            }

            xtraTabControl1.SelectedTabPage = page;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (xtraTabControl1.Visible == true) xtraTabControl1.Visible = false;
            //else xtraTabControl1.Visible = true;
            xtraTabControl1.TabPages.First(qq => (string)qq.Tag == barButtonItem15.Caption).PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages.First(qq => (string)qq.Tag == barButtonItem15.Caption);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
        }




        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var db = new AbacusSUPEntities();
            List<VezaLT> listaveza = db.VezaLT.Where(qq => qq.id_login == OperaterLogin.operater.id).ToList();
            List<Task> listataskova = new List<Task>();
            foreach (VezaLT veza in listaveza)
            {
                listataskova.Add(db.Task.First(ww => ww.id_task == veza.id_task));
            }
            Main_lista.Clear();
            Main_lista.AddRange(listataskova);
            Main_lista.OrderByDescending(pp => pp.datum);
            //Main_lista = listataskova.OrderByDescending(we=>we.datum).ToList();
            foreach (Binding X in taskBindingSource.CurrencyManager.Bindings) X.WriteValue();
            gridView1.RefreshData();
        }

        private async void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            Main_lista.Remove(task);

            
            var db = new AbacusSUPEntities();
            db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).datum_zatv = DateTime.Now;
            db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).login_id_zatv = OperaterLogin.operater.id;
            db.Task.First(qw => qw.id_task == task.id_task).status_id = 2;
            db.SaveChanges();
            var db2 = new AbacusSUPEntities();
            Main_lista.Add(db2.Task.First(qq => qq.id_task == task.id_task));
            taskBindingSource.DataSource = Main_lista.OrderByDescending(qq => qq.datum);
            gridView1.RefreshData();

            if (task.git_id.HasValue)
            {
                try
                {
                    var client = new GitHubClient(new ProductHeaderValue("AbacusSUPP"));
                    var basicAuth = new Credentials("jovanmhn", "jovan123");
                    client.Credentials = basicAuth;

                    var issueupitanju = await client.Issue.Get("jovanmhn", "AbacusSUPP", task.git_id.Value);
                    var update = issueupitanju.ToUpdate();
                    update.State = ItemState.Closed;

                    var updatetest = await client.Issue.Update("jovanmhn", "AbacusSUPP", task.git_id.Value, update);
                }
                catch
                {
                    
                }
            }
        }

       

        private void toastNotificationsTask_Activated_1(object sender, DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs e)
        {
            string guid = (string)e.NotificationID;
            if (NotificationsTask.ContainsKey(guid))
            {
                Task task = NotificationsTask[guid];
                NotificationsTask.Remove(guid);

                FormTaskMain frmtask = new FormTaskMain(task);
                frmtask.Show();

            }
        }

        private void toastNotificationsKomentar_Activated(object sender, DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs e)
        {
            string guid = (string)e.NotificationID;
            if (NotificationsKomentar.ContainsKey(guid))
            {
                Task task = NotificationsKomentar[guid].Task;
                NotificationsKomentar.Remove(guid);

                FormTaskMain frmtask = new FormTaskMain(task);
                frmtask.Show();

            }
        }

        private void barToggleSwitchItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barToggleSwitchItem1.Checked)
            {
                OperaterLogin.NotifOverride = true;
            }
            else
            {
                OperaterLogin.NotifOverride = false;
            }
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            var page = arg.Page as XtraTabPage;
            if ((string)page.Tag != barButtonItem15.Caption)
            {
                
                (arg.Page as XtraTabPage).Dispose();
            }
            else page.PageVisible = false;
            //xtraTabControl1.SelectedTabPage.Dispose();
            //xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
            if (xtraTabControl1.TabPages.Count > 0)
            {
                xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages.Last();
            }
            
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            GridView view = sender as GridView;
            FormKolone frmkolone = new FormKolone(view.Columns, view);
            frmkolone.Show();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OperaterLogin.NE_IZLAZI_AOAO = true;
            this.Close();
            OperaterLogin.loginforma.Show();
        }

        private void gridControl1_PaintEx(object sender, DevExpress.XtraGrid.PaintExEventArgs e)
        {/* // ROW BORDER 
            GridViewInfo viewInfo = gridView1.GetViewInfo() as GridViewInfo;
            foreach (GridRowInfo rowInfo in viewInfo.RowsInfo)
            {
                if (ShouldDrawThickBorder(gridView1, rowInfo.RowHandle))
                {
                    Color boja = new Color();
                    Task task = (Task)gridView1.GetRow(rowInfo.RowHandle);
                    switch (task.Label.id_label)
                    {
                        case 1: boja = Color.Green; break;
                        case 2: boja = Color.Red; break;
                        case 3: boja = Color.Blue; break;
                        default: MessageBox.Show("ID label vratio neocekivanu vrijednost."); break;
                    }
                    Pen p = new Pen(boja, 1);
                    Point p1 = new Point(rowInfo.Bounds.Left+1, rowInfo.Bounds.Bottom-1);
                    Point p2 = new Point(rowInfo.Bounds.Right-1, rowInfo.Bounds.Bottom-1);

                    Point p3 = new Point(rowInfo.Bounds.Left+1, rowInfo.Bounds.Top+1);
                    Point p4 = new Point(rowInfo.Bounds.Right-1, rowInfo.Bounds.Top+1);
                    e.Cache.Graphics.DrawLine(p, p1, p2);
                    e.Cache.Graphics.DrawLine(p, p3, p4);
                    e.Cache.Graphics.DrawLine(p, p1, p3);
                    e.Cache.Graphics.DrawLine(p, p2, p4);
                }
            } */
        }

        private bool ShouldDrawThickBorder(GridView gridView1, int rowHandle)
        {
            if (gridView1.IsGroupRow(rowHandle)) return false;
            Task task = (Task)gridView1.GetRow(rowHandle);
            if (task!=null && task.Label != null) return true;
            else return false;
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            foreach (Form form in System.Windows.Forms.Application.OpenForms)        //da ne prikazuje duple forme
            {
                if (form.GetType() == typeof(AbacusSUPP.Forme.Ostalo.FormArhiva))
                {
                    form.Activate();
                    return;
                }
            }
            AbacusSUPP.Forme.Ostalo.FormArhiva formArhiva = new Forme.Ostalo.FormArhiva();
            formArhiva.Show();
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Labela")
            {
                Task task = (Task)gridView1.GetRow(e.RowHandle);
                if (e.RowHandle >= 0)
                {
                    if (task.Label != null)
                    {
                        switch (task.id_label)
                        {
                            //case (1): { e.Appearance.ForeColor = Color.GreenYellow; /*e.Appearance.BackColor2 = Color.White;*/ return; }
                            //case (2): { e.Appearance.ForeColor = Color.Blue; /*e.Appearance.BackColor2 = Color.White;*/ return; }
                            //case (3): { e.Appearance.ForeColor = Color.Red; /*e.Appearance.BackColor2 = Color.White;*/ return; }
                            default: { e.Appearance.ForeColor = Color.Gray;/* e.Appearance.BackColor2 = Color.White;*/ return; }
                        }



                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Gray;
                        //e.Appearance.BackColor2 = Color.White;
                    }
                    //e.Handled = true;
                }
            }
            if (e.Column.FieldName == "Prioritet.opis")
            {
                Task task = (Task)gridView1.GetRow(e.RowHandle);
                if (e.RowHandle >= 0)
                {
                    if (task.Prioritet.opis != null)
                    {
                        switch (task.Prioritet.opis)
                        {
                            case ("Low"): { e.Appearance.ForeColor = Color.Green; /*e.Appearance.BackColor2 = Color.White;*/ return; }
                            case ("Medium"): { e.Appearance.ForeColor = Color.Orange; /*e.Appearance.BackColor2 = Color.White;*/ return; }
                            case ("High"): { e.Appearance.ForeColor = Color.Red; /*e.Appearance.BackColor2 = Color.White;*/ return; }
                            default: { e.Appearance.ForeColor = Color.Gray;/* e.Appearance.BackColor2 = Color.White;*/ return; }
                        }



                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.Gray;
                        //e.Appearance.BackColor2 = Color.White;
                    }
                    //e.Handled = true;
                }
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (/*e.GroupRowHandle != GridControl.InvalidRowHandle &&*/ e.Column.FieldName == "Labela")
            {
                //e.DisplayText = string.Empty;
            }
        }

        private async void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //-------------GitHub test sync----------------

            var client = new GitHubClient(new ProductHeaderValue("AbacusSUPP"));
            var basicAuth = new Credentials("jovanmhn", "jovan123");
            client.Credentials = basicAuth;

            var pomocniFiltar = new RepositoryIssueRequest
            {
                //Assignee = "none",
                //Milestone = "none",
                //Filter = IssueFilter.All,
                State = ItemStateFilter.Closed
                
            };

            var issues = await client.Issue.GetAllForRepository("jovanmhn", "AbacusSUPP");//ovdje treci parametar moze da ide tipa RepositoryIssueRequest
            List<int> otvoreni= new List<int>();

            var db = new AbacusSUPEntities();
            foreach (Issue iss in issues) otvoreni.Add(iss.Number);
            foreach(Task task in Main_lista.Where(qq=>qq.status_id==1))
            {
                if (task.git_id.HasValue)
                {
                    if (!otvoreni.Contains(task.git_id.Value))
                    {
                        db.Task.First(qq => qq.id_task == task.id_task).status_id = 2;
                        db.Task.First(qq => qq.id_task == task.id_task).login_id_zatv = OperaterLogin.operater.id;
                        db.Task.First(qq => qq.id_task == task.id_task).datum_zatv = DateTime.Now;
                    }

                }
            }
            db.SaveChanges();
            Main_lista = db.Task.ToList();
            gridControl1.DataSource = Main_lista;
            gridView1.RefreshData();
            
            //---------------------------------------------
        }
    }

}
