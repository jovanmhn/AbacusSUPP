using DevExpress.Office.Utils;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP
{

    public partial class FormTaskMain : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        Task task { get; set; }
        int broj_slike = 0;
        Size org_size = new Size();
        public Panel MainPanel { get { return this.panel1; } }

        public string rtfprezip;
        public string rtfpostunzip;

        XtraScrollableControl scrollableControl = new XtraScrollableControl();

        public FormTaskMain(Task _task, [Optional] DevExpress.XtraSplashScreen.SplashScreenManager splashscreenmanager)
        {
            InitializeComponent();
            scrollableControl = xtraScrollableControl1;
            Baza = new AbacusSUPEntities();
            //this.IsMdiContainer = true;
            task = Baza.Task.First(qq => qq.id_task == _task.id_task);
            if (task == null) { MessageBox.Show("Neki problem sa taskom."); this.Close(); }
            this.Text += " - " + task.naslov.ToString();
            gridControl1.DataSource = Baza.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            labelControl1.Text = task.id_task.ToString();


            memoEdit2.Text = task.opis;
            labelControl2.Text = "Prioritet: " + task.Prioritet.opis;
            if (task.Login != null)
            {
                labelControl3.Text = "Task otvorio: " + task.Login.username;
            }
            else labelControl3.Text = "Task otvorio: (OBRISAN)";
            labelControl4.Text = "Datum:" + task.datum.ToString();
            if (task.status_id == 2)
            {
                labelControl6.Visible = true;
                labelControl6.Text = "Task zatvorio " + task.Login1.username.ToString() + ", " + task.datum_zatv.ToString();
            }
            this.Text = task.naslov;
            labelControl5.Text = task.naslov;
            layoutView1.PanModeSwitch();
            org_size = richEditControl1.Size;

            if (task.status_id == 2)
            {
                simpleButton2.Text = "Otvori task";
                simpleButton3.Enabled = false;
            }

            List<VezaLT> listaveza = Baza.VezaLT.Where(qq => qq.id_task == task.id_task).ToList();
            List<Login> listaoperatera = new List<Login>();
            foreach (VezaLT veza in listaveza)
            {
                Login operater = Baza.Login.FirstOrDefault(qq => qq.id == veza.id_login);
                listaoperatera.Add(operater);

            }

            string[] fajlovi = null;
            //if (Directory.Exists(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
            //{
            //    fajlovi = Directory.GetFiles(Application.StartupPath + "\\Slike\\" + task.id_task.ToString());
            //    if (fajlovi.Count() > 0)
            //    {
            //        foreach (string file in fajlovi)
            //        {
            //            File.Delete(file); //ako postoje fajlovi od cancelovanih komentara
            //        }
            //    }
            //}

            if (splashscreenmanager != null)
            {
                splashscreenmanager.CloseWaitForm();
            }

            repositoryItemPictureEdit1.ContextMenuStrip = new ContextMenuStrip(); //da nema right click meni
            richEditControl1.Options.Behavior.ShowPopupMenu = DocumentCapability.Disabled;

            #region Fora sa scroll controlom
            //gridControl1.Location = xtraScrollableControl1.Location;
            LayoutViewInfo info = layoutView1.GetViewInfo() as LayoutViewInfo;
            layoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            gridControl1.Size = new Size(xtraScrollableControl1.Width - SystemInformation.VerticalScrollBarWidth, info.CalcRealViewHeight(new Rectangle(0, 0, 300, Int32.MaxValue)));
            #endregion

            simpleButtonGitHub.Visible = task.git_id == null ? true : false;
            gridControl1.MouseWheel += GridControl1_MouseWheel;


            //CustomRepRichTextEdit testeditor = new CustomRepRichTextEdit();
            //testeditor.AllowMouseWheel = false;
            //gridControl1.RepositoryItems.Add(testeditor);
            //layoutView1.Columns["UnboundKomentar"].ColumnEdit = testeditor;
        }

        public void koriguj_izgled()
        {
            xtraScrollableControl1.Width = Program.MainForm.xtraTabControl1.Width;
            LayoutViewInfo info = layoutView1.GetViewInfo() as LayoutViewInfo;
            gridControl1.Size = new Size(xtraScrollableControl1.Width - SystemInformation.VerticalScrollBarWidth, info.CalcRealViewHeight(new Rectangle(0, 0, 300, Int32.MaxValue)));
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var db = new AbacusSUPEntities();
            if ( db.Task.FirstOrDefault(qq=> qq.id_task==task.id_task).status_id == 1)
            {
                //var Baza = new AbacusSUPEntities();
                db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).status_id = db.Status.FirstOrDefault(qw => qw.opis == "Zavrseno").id_status;
                db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).datum_zatv = DateTime.Now;
                db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).login_id_zatv = OperaterLogin.operater.id;
                labelControl6.Text = db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).datum_zatv.ToString();

                List<VezaLT> listaveza = db.VezaLT.Where(qq => qq.id_task == task.id_task).ToList();
                foreach (VezaLT veza in listaveza)
                {
                    db.VezaLT.FirstOrDefault(qw => qw.id_veza == veza.id_veza).isActive = false;
                }
                simpleButton2.Text = "Otvori task";

                db.SaveChanges();
                var db2 = new AbacusSUPEntities();
                labelControl6.Visible = true;
                labelControl6.Text = "Task zatvorio " + db2.Task.FirstOrDefault(qq=>qq.id_task==task.id_task).Login1.username.ToString() + ", " + db2.Task.FirstOrDefault(qq => qq.id_task == task.id_task).datum_zatv.ToString();
                simpleButton1.Enabled = false;
                if (OperaterLogin.operater.Podesavanja.task_github_upload)
                {
                    zatvorigittask(task); 
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).status_id == 2)
            {

                if (XtraMessageBox.Show("Ovaj task je zatvoren. Otvoriti opet?", "Provjera", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).status_id = db.Status.FirstOrDefault(qw => qw.opis == "U toku").id_status;
                    db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).datum_zatv = null;
                    db.Task.FirstOrDefault(qq => qq.id_task == task.id_task).login_id_zatv = null; 
                    List<VezaLT> listaveza = db.VezaLT.Where(qq => qq.id_task == task.id_task).ToList();
                    foreach (VezaLT veza in listaveza)
                    {
                       db.VezaLT.FirstOrDefault(qw => qw.id_veza == veza.id_veza).isActive = true;
                    }
                    simpleButton2.Text = "Zatvori task";
                    simpleButton1.Enabled = true;
                    db.SaveChanges();
                    simpleButton3.Enabled = true;
                    labelControl6.Visible = false;
                    if (OperaterLogin.operater.Podesavanja.task_github_upload)
                    {
                        otvorigittask(task); 
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

        }
        public async void zatvorigittask(Task task)
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
            catch (Exception)
            {
  
            }
        }
        public async void otvorigittask(Task task)
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("AbacusSUPP"));
                var basicAuth = new Credentials("jovanmhn", "jovan123");
                client.Credentials = basicAuth;

                var issueupitanju = await client.Issue.Get("jovanmhn", "AbacusSUPP", task.git_id.Value);
                var update = issueupitanju.ToUpdate();
                update.State = ItemState.Open;

                var updatetest = await client.Issue.Update("jovanmhn", "AbacusSUPP", task.git_id.Value, update);
            }
            catch (Exception)
            {

            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            rtfprezip = richEditControl1.RtfText;

            byte[] r1 = Zip(richEditControl1.Document.RtfText);
            string base64 = Convert.ToBase64String(r1);


            Komentar kom = new Komentar
            {
                datum = DateTime.Now,
                sadrzaj = base64,
                id_login = OperaterLogin.operater.id,
                id_task = task.id_task
            };
            int id = 0;
            Baza.Komentar.Add(kom);
            Baza.SaveChanges();
            gridControl1.DataSource = Baza.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            layoutView1.RefreshData();
            richEditControl1.Document.Delete(richEditControl1.Document.Range);
            string[] fajlovi = null;
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
            {
                fajlovi = System.IO.Directory.GetFiles(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString());
                id = Baza.Komentar.OrderByDescending(qq => qq.datum).ToList()[0].id;
                if (id != 0)
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString());
                }
                else
                {
                    XtraMessageBox.Show("Komentar_id vratio 0! (folder ime)"); goto kraj;
                }
            }
            else { XtraMessageBox.Show("Nema task foldera!"); goto kraj; }
            foreach (string fajl in fajlovi)
            {
                System.IO.File.Move(fajl, System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString() + "\\" + Path.GetFileName(fajl));
            }
            broj_slike = 0;

            OperaterLogin.stara_kom_lista.Add(kom);

            kraj:;
        }
        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }

        private void layoutView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == UnboundKomentar)
            {
                var row = (Komentar)e.Row;


                if (row != null)
                {
                    byte[] zipovan = Convert.FromBase64String(row.sadrzaj);
                    string rtfraw = Unzip(zipovan);

                    rtfpostunzip = rtfraw;

                    repositoryItemRichTextEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
                    e.Value = rtfraw;
                }


            }
            if (e.Column == UnboundSlika)
            {
                var row = (Komentar)e.Row;

                var db = new AbacusSUPEntities();
                Komentar kom = db.Komentar.FirstOrDefault(qq => qq.id == row.id);
                if (kom != null)
                {
                    e.Value = AbacusSUPP.Helper.GetImageFromByteArray(kom.Login.avatar);
                }
                else MessageBox.Show("Nesto ne valja.");


            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {


            //Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString()
            Komentar kom = (Komentar)layoutView1.GetRow(layoutView1.FocusedRowHandle);
            string[] fajlovi = null;
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + kom.id.ToString()))
            {
                fajlovi = Directory.GetFiles(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + kom.id.ToString());
            }
            else { XtraMessageBox.Show("Nedostaju full res slike!"); goto kraj; }


            if (fajlovi.Count() > 0)
            {
                FormSlike frmslike = new FormSlike(fajlovi);
                frmslike.Show();
            }
            kraj:;
            /* FormKomentarDetalj fkdetalj = new FormKomentarDetalj(kom.sadrzaj);
             fkdetalj.ShowDialog();*/

        }

        private void layoutView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                layoutView1.PanModeSwitch();
            }
        }

        private void layoutView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                layoutView1.PanModeSwitch();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
                FormDodajKomentar frmdkom = new FormDodajKomentar(task, gridControl1, layoutView1, xtraScrollableControl1);
                //frmdkom.MdiParent = this;
                if (frmdkom.ShowDialog() == DialogResult.OK)
                {
                    var db = new AbacusSUPEntities();
                    gridControl1.DataSource = db.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(qq => qq.datum).ToList();
                    layoutView1.RefreshData();
                if (!OperaterLogin.operater.Podesavanja.task_novi_prozor)
                {
                    koriguj_izgled(); 
                }

                //    LayoutViewInfo info = layoutView1.GetViewInfo() as LayoutViewInfo;
                //    layoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
                //    gridControl1.Size = new Size(xtraScrollableControl1.Width - SystemInformation.VerticalScrollBarWidth, info.CalcRealViewHeight(new Rectangle(0, 0, 300, Int32.MaxValue)));
                }
            
            

        }

        private void richEditControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {



                DocumentImageCollection collection = richEditControl1.Document.GetImages(richEditControl1.Document.Range);
                var a = Clipboard.GetText();


                string[] b = (string[])Clipboard.GetData(DataFormats.FileDrop);


                var c = Clipboard.GetImage();
                if (c != null)
                {
                    //collection.Get(richEditControl1.Document.Range);

                    int h, w;

                    w = 200;
                    h = (int)(c.Height * w / c.Width);
                    System.Drawing.Bitmap mala_slika = AbacusSUPP.Helper.ResizeImage(c, w, h);
                    //richEditControl1.Document.InsertImage(richEditControl1.Document.CaretPosition, mala_slika);

                    DocumentRange range = collection[collection.Count - 1].Range;
                    richEditControl1.Document.Delete(range);
                    collection.Insert(richEditControl1.Document.CaretPosition, mala_slika);

                    if (!System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
                    {
                        System.IO.Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString());
                    }
                    c.Save(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + broj_slike.ToString() + ".bmp");
                    broj_slike++;
                }
                if (b != null)
                {
                    collection = richEditControl1.Document.GetImages(richEditControl1.Document.Range);
                    //collection.Get(richEditControl1.Document.Range);
                    DocumentRange range = collection[collection.Count - 1].Range;
                    richEditControl1.Document.Delete(range);
                    int h, w;
                    System.Drawing.Image slika = Image.FromFile(b[0]);
                    w = 200;
                    h = (int)(slika.Height * w / slika.Width);
                    System.Drawing.Bitmap mala_slika = AbacusSUPP.Helper.ResizeImage(slika, w, h);
                    //richEditControl1.Document.InsertImage(richEditControl1.Document.CaretPosition, mala_slika);
                    collection.Insert(richEditControl1.Document.CaretPosition, mala_slika);
                    if (!System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
                    {
                        System.IO.Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString());
                    }
                    slika.Save(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + broj_slike.ToString() + ".bmp");
                    broj_slike++;
                }


            }

        }

        private void richEditControl1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            DocumentImageCollection collection = richEditControl1.Document.GetImages(richEditControl1.Document.Range);
            //collection.Get(richEditControl1.Document.Range);
            DocumentRange range = collection[collection.Count - 1].Range;
            richEditControl1.Document.Delete(range);
            int h, w;
            System.Drawing.Image slika = Image.FromFile(files[0]);
            w = 200;
            h = (int)(slika.Height * w / slika.Width);
            System.Drawing.Bitmap mala_slika = AbacusSUPP.Helper.ResizeImage(slika, w, h);
            //richEditControl1.Document.InsertImage(richEditControl1.Document.CaretPosition, mala_slika);
            collection.Insert(richEditControl1.Document.CaretPosition, mala_slika);

            if (!System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
            {
                System.IO.Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString());
            }
            slika.Save(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + broj_slike.ToString() + ".bmp");
            broj_slike++;
        }

        private void FormTaskMain_Shown(object sender, EventArgs e)
        {
            //Program.MainForm.WindowState = FormWindowState.Minimized;     
            
        }
        
        private void FormTaskMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            //Program.MainForm.WindowState = FormWindowState.Maximized;
        }

        private void richEditControl1_Enter(object sender, EventArgs e)
        {
            richEditControl1.Bounds = new Rectangle(richEditControl1.Location, new Size(richEditControl1.Size.Width, 2 * richEditControl1.Size.Height));
        }

        private void richEditControl1_Leave(object sender, EventArgs e)
        {
            richEditControl1.Size = org_size;
        }

        private void FormTaskMain_Click(object sender, EventArgs e)
        {
            labelControl1.Focus();
        }


        private void layoutView1_CustomDrawCardBackground(object sender, DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomDrawCardBackgroundEventArgs e)
        {
            //if (Program.MainForm.xtraTabControl1.SelectedTabPage.Disposing) return;
            if (e.RowHandle >= 0)
            {
                var db = new AbacusSUPEntities();
                Komentar kom1 = (Komentar)layoutView1.GetRow(e.RowHandle);
                if (kom1 == null) return;
                Komentar kom = db.Komentar.FirstOrDefault(qq => qq.id == kom1.id);
                if (kom != null && kom.Login.outline_kom == true)
                {
                    e.DefaultDraw();

                    using (var highlight = new SolidBrush(Color.FromArgb(25, Color.Green)))
                    {
                        // Fill card with semi-transparent color 
                        
                        e.Cache.FillRectangle(highlight, Rectangle.Inflate(e.Bounds, -1, -1));

                    }

                }
            }

        }

     

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Komentar kom = (Komentar)layoutView1.GetRow(layoutView1.FocusedRowHandle);
            string[] fajlovi = null;
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + kom.id.ToString()))
            {
                fajlovi = Directory.GetFiles(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + kom.id.ToString());
            }
            else { XtraMessageBox.Show("Nedostaju full res slike!"); goto kraj; }


            if (fajlovi.Count() > 0)
            {
                FormSlike frmslike = new FormSlike(fajlovi);
                frmslike.Show();
            }
            kraj:;
        }
        
        private void layoutView1_ShownEditor(object sender, EventArgs e)
        {
            ColumnView columnView = sender as ColumnView;
            
            
            if (columnView != null)
            {
                RichTextEdit activeEditor = columnView.ActiveEditor as RichTextEdit;

                if (activeEditor != null)
                {
                    RichEditControl richEditControl = (RichEditControl)activeEditor.Controls[0];
                    
                    richEditControl.Views.SimpleView.Padding = new Padding(5, 0, 0, 0); //za onaj mali pomjeraj kad je editor postaje aktivan
                    richEditControl.AutoSizeMode = DevExpress.XtraRichEdit.AutoSizeMode.Vertical;
                    
                    
                    ColumnView view = (ColumnView)sender;
                    Komentar a = (Komentar)view.GetFocusedRow();
                    richEditControl.Options.Hyperlinks.ModifierKeys = Keys.None;
                    richEditControl.Options.Hyperlinks.ShowToolTip = false;

                    richEditControl.MouseWheel += OnMouseWheel;
                    richEditControl.Disposed += Control_Disposed;

                    if (a.Login.outline_kom == true)
                    {
                        //richEditControl.CustomDrawActiveView -= new DevExpress.XtraRichEdit.RichEditViewCustomDrawEventHandler(this.richEditControl_CustomDrawActiveView);
                        //richEditControl.CustomDrawActiveView += new DevExpress.XtraRichEdit.RichEditViewCustomDrawEventHandler(this.richEditControl_CustomDrawActiveView);
                        
                        //GraphicsCache pokusaj = new GraphicsCache(richEditControl.CreateGraphics());
                        //SolidBrush brush = new SolidBrush(Color.FromArgb(25, Color.Green));
                        //pokusaj.FillRectangle(brush, richEditControl.Bounds);


                    }
                    else
                    {
                        //richEditControl.ActiveView.BackColor = Color.White;
                    }

                }
            }
        }

        void OnMouseWheel(object sender, MouseEventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            int scrollValue = scrollableControl.VerticalScroll.Value;
            int largeChange = scrollableControl.VerticalScroll.LargeChange;
            if (e.Delta < 0)
                scrollableControl.VerticalScroll.Value += scrollableControl.VerticalScroll.LargeChange;
            else
                if (scrollValue < largeChange)
                scrollableControl.VerticalScroll.Value = 0;
            else
                scrollableControl.VerticalScroll.Value -= largeChange;
        }
        private void Control_Disposed(object sender, EventArgs e)
        {
            RichEditControl richEdit = (RichEditControl)sender;
            richEdit.MouseWheel -= OnMouseWheel;
            richEdit.Disposed -= Control_Disposed;
        }

        private void richEditControl_CustomDrawActiveView(object sender, DevExpress.XtraRichEdit.RichEditViewCustomDrawEventArgs e)
        {
             
            
            RichEditControl rec = (RichEditControl)sender;
            SolidBrush brush = new SolidBrush(Color.FromArgb(25, Color.Green));
            e.Cache.FillRectangle(brush, rec.Bounds);
            
            

        }

        

        private void layoutView1_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo hitInfo = layoutView1.CalcHitInfo(e.Location);
            if (layoutView1.FocusedRowHandle != hitInfo.RowHandle && layoutView1.FocusedColumn != hitInfo.Column) return;
            if (hitInfo.InCard)
            {
                
                if (hitInfo.Column != null)
                {

                    if (hitInfo.Column.FieldName == "UnboundKomentar")
                    {
                        layoutView1.FocusedRowHandle = hitInfo.RowHandle;
                        layoutView1.FocusedColumn = hitInfo.Column;
                        layoutView1.ShowEditor();
                        
                        //bool a = false; bool b = false;
                        //if (layoutView1.FocusedRowHandle != hitInfo.RowHandle)
                        //{
                        //    layoutView1.FocusedRowHandle = hitInfo.RowHandle;
                        //    a = true;
                        //}
                        //if (layoutView1.FocusedColumn != hitInfo.Column)
                        //{
                        //    layoutView1.FocusedColumn = hitInfo.Column;
                        //    b = true;
                        //}
                        //if (a || b) layoutView1.ShowEditor();
                        
                    }
                    else { layoutView1.HideEditor(); xtraScrollableControl1.Focus(); }
                    
                }
            }
            
        }
        private void GridControl1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            GridControl control = sender as GridControl;
            if (!control.Focused)
            {
                (e as DXMouseEventArgs).Handled = true;
                if (xtraScrollableControl1.VerticalScroll.Value <= e.Delta / 3) { xtraScrollableControl1.VerticalScroll.Value = 0; }
                xtraScrollableControl1.VerticalScroll.Value -= e.Delta/3;
            }
        }

        private void memoEdit2_Enter(object sender, EventArgs e)
        {
            memoEdit2.Height = memoEdit2.Height * 3;
        }

        private void memoEdit2_Leave(object sender, EventArgs e)
        {
            memoEdit2.Height = memoEdit2.Height / 3;
        }

        private void FormTaskMain_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = new Pen(Color.PaleVioletRed,2);
            //e.Graphics.DrawLine(pen, panel1.DisplayRectangle.Left, panel1.DisplayRectangle.Top, panel1.DisplayRectangle.Right, panel1.DisplayRectangle.Top);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("Upload na GitHub?", "GitHub", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                napravigithubissue(task);
            }
        }
        public async void napravigithubissue(Task task)
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("AbacusSUPP"));
                var basicAuth = new Credentials("jovanmhn", "jovan123");
                client.Credentials = basicAuth;

                var noviIssue = new NewIssue(task.naslov);
                noviIssue.Body = task.opis;

                var issue = await client.Issue.Create("jovanmhn", "AbacusSUPP", noviIssue);
                var db = new AbacusSUPEntities();
                db.Task.First(qq => qq.id_task == task.id_task).git_id = issue.Number;
                db.SaveChanges();

                //var comment = client.Issue.Comment.Create("jovanmhn", "AbacusSUPP", 5, "test KOmentar 123"); //ovo radi, argumenti su owner/repo/issueNo/komentar

                //var issueupitanju = await client.Issue.Get("jovanmhn", "AbacusSUPP", 3);
            }
            catch (Exception)
            {

                MessageBox.Show("Greska prilikom dodavanja na GitHub issues");
            }
        }
        public class CustomRepRichTextEdit : DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit
        {
            public override bool AllowMouseWheel { get => base.AllowMouseWheel; set => base.AllowMouseWheel = value; }
            
        }
        public class CustomRichTextEdit : RichTextEdit
        {
            protected override void OnMouseWheel(MouseEventArgs e)
            {
                //base.OnMouseWheel(e);
            }

        }
        
    }



}
