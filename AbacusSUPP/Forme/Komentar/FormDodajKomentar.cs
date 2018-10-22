﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid;
using DevExpress.XtraRichEdit.API.Native;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;

namespace AbacusSUPP //cijela ova forma je govno, treba prepravit
{
    public partial class FormDodajKomentar : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        Task task;
        int count = 0;
        DocumentImageCollection imageCollection;
        GridControl gridControl1;
        LayoutView layoutView1;
        XtraScrollableControl xtraScrollableControl1;
        Komentar kom = new Komentar();
        int tempid;
        public FormDodajKomentar(Task _task, GridControl gridcontrol, LayoutView layoutView, XtraScrollableControl xtraScrollableControl)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            task = _task;
            imageCollection = richEditControl1.Document.Images;
            gridControl1 = gridcontrol;
            layoutView1 = layoutView;
            xtraScrollableControl1 = xtraScrollableControl;

            #region Da olaksa .rtf! brisanje styleova i sl
            //richEditControl1.Document.BeginUpdate();
            //try
            //{
            //    for (int i = richEditControl1.Document.TableStyles.Count - 1; i >= 1; i--)
            //        richEditControl1.Document.TableStyles.Delete(richEditControl1.Document.TableStyles[i]);

            //    for (int i = richEditControl1.Document.ParagraphStyles.Count - 1; i >= 1; i--)
            //        richEditControl1.Document.ParagraphStyles.Delete(richEditControl1.Document.ParagraphStyles[i]);

            //    for (int i = richEditControl1.Document.CharacterStyles.Count - 1; i >= 1; i--)
            //        richEditControl1.Document.CharacterStyles.Delete(richEditControl1.Document.CharacterStyles[i]);
            //}
            //finally
            //{
            //    richEditControl1.Document.EndUpdate();
            //} 
            #endregion

            kom = new Komentar
            {
                datum = DateTime.Now,
                sadrzaj = null,
                id_login = OperaterLogin.operater.id,
                id_task = task.id_task
            };
            Baza.Komentar.Add(kom);
            Baza.SaveChanges();

            tempid = kom.id;
        }
    

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            byte[] r1 = AbacusSUPP.Helper.Zip(richEditControl1.Document.RtfText);
            string base64 = Convert.ToBase64String(r1);
            var db = new AbacusSUPEntities();

            db.Komentar.First(qq => qq.id == tempid).sadrzaj = base64;
            db.SaveChanges();
            int id = 0;
                        
            //var db2 = new AbacusSUPEntities();
            gridControl1.DataSource = db.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            layoutView1.RefreshData();

            LayoutViewInfo info = layoutView1.GetViewInfo() as LayoutViewInfo;
            layoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            gridControl1.Size = new Size(xtraScrollableControl1.Width - SystemInformation.VerticalScrollBarWidth, info.CalcRealViewHeight(new Rectangle(0, 0, 300, Int32.MaxValue)));


            //List<string> fajlovi = new List<string>();
            //opet:
            //if (Directory.Exists(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
            //{

            //    fajlovi = System.IO.Directory.GetFiles(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()).ToList();
            //    id = Baza.Komentar.OrderByDescending(qq => qq.datum).ToList()[0].id;
            //    if (id != 0)
            //    {
            //        Directory.CreateDirectory(Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString());
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Komentar_id vratio 0! (folder ime)"); goto kraj;
            //    }
            //}
            //else { Directory.CreateDirectory(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()); goto opet; };
            //if (fajlovi.Count>0)
            //{

            //    foreach (string fajl in fajlovi)
            //    {
            //        System.IO.File.Move(fajl, Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString() + "\\" + Path.GetFileName(fajl));
            //    }
            //}

            #region Ovo sve je sranje, cijelu formu treba ispraviti, mozda GUID za link za sliku prije nego sto dobije ID...

            //string uri = Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString() + "\\";
            //int broj = 0;
            //foreach (DocumentImage image in richEditControl1.Document.Images)
            //{
            //    var a = image.Range;
            //    uri += broj.ToString() + ".bmp";
            //    HyperlinkCollection hypcol = richEditControl1.Document.Hyperlinks;
            //    Hyperlink hyperlink = hypcol.Create(a);
            //    //Hyperlink hyperlink = richEditControl1.Document.CreateHyperlink(a);
            //    hyperlink.NavigateUri = uri;
            //    broj++;
            //}
            //byte[] test = AbacusSUPP.Helper.Zip(richEditControl1.Document.RtfText);
            //string test2 = Convert.ToBase64String(test);
            //var db3 = new AbacusSUPEntities();
            //Komentar testkom = db3.Komentar.Single(qq => qq.id == tempid);
            //testkom.sadrzaj = test2;
            //db3.SaveChanges();
            //gridControl1.DataSource = db3.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            //layoutView1.RefreshData();
            #endregion




            OperaterLogin.stara_kom_lista.Add(kom);
            this.Close();
            this.DialogResult = DialogResult.OK;
            kraj:;
        }


    

        private void richEditControl1_ContentChanged(object sender, EventArgs e)
        {
            //DocumentImageCollection imageCollection = richEditControl1.Document.Images;
            if (imageCollection.Count > count)
            {

                DocumentImage image = imageCollection[imageCollection.Count - 1];
                var a = image.Image.NativeImage;
                
                if (!System.IO.Directory.Exists(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()+"\\"+tempid.ToString()))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()+"\\"+tempid.ToString());
                }
                
                string uri = Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + tempid.ToString() +"\\"+ count.ToString() + ".bmp";
                a.Save(uri);
                DocumentRange b = image.Range;
                richEditControl1.Document.Delete(b);                
                var c = AbacusSUPP.Helper.ResizeImage(a, 350, 350 * a.Height / a.Width);
                imageCollection.Insert(richEditControl1.Document.CaretPosition, c);
                var d = imageCollection[imageCollection.Count - 1];
                b = d.Range;
                Hyperlink hyperlink = richEditControl1.Document.CreateHyperlink(b);
                hyperlink.NavigateUri = uri;

                
                count++;

            }
            if (imageCollection.Count < count) count--;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(Application.StartupPath + "\\Fajlovi"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Fajlovi");
                }
                List<string> fajlovi = ofd.FileNames.ToList();
                foreach (string file in fajlovi)
                {
                    string ime = Guid.NewGuid().ToString();
                    string uri = Application.StartupPath + "\\Fajlovi" + "\\" +ime + Path.GetExtension(file);
                    File.Copy(file, uri);
                    string file1 = Path.GetFileName(file) + System.Environment.NewLine;
                    DocumentRange range = richEditControl1.Document.AppendText(file1);
                    Hyperlink hyperlink = richEditControl1.Document.CreateHyperlink(range);
                    hyperlink.NavigateUri = uri;
                }
            }
        }

        private void FormDodajKomentar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK) //Ako nije save, a forma se zatvorila. Brisati slike...
            {
                var db = new AbacusSUPEntities();
                db.Komentar.Remove(db.Komentar.First(qq => qq.id == tempid));
                db.SaveChanges();


                try                //Directory.Delete(path, true) vjerovatno moze da obrise sve u direktorijumu, ali directory info je korisna klasa za znat
                {
                    System.IO.DirectoryInfo direktorijum = new DirectoryInfo(Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + tempid.ToString());

                    foreach (FileInfo file in direktorijum.GetFiles())      //sve fajlove
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in direktorijum.GetDirectories()) //sve foldere
                    {
                        dir.Delete(true);
                    }
                    Directory.Delete(Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + tempid.ToString()); //sam direktorijum
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
}
