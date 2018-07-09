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

namespace AbacusSUPP
{
    public partial class FormDodajKomentar : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        Task task;
        int count = 0;
        DocumentImageCollection imageCollection;
        GridControl gridControl1;
        LayoutView layoutView1;
        public FormDodajKomentar(Task _task, GridControl gridcontrol, LayoutView layoutView)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            task = _task;
            imageCollection = richEditControl1.Document.Images;
            gridControl1 = gridcontrol;
            layoutView1 = layoutView;

        }
    

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            

            byte[] r1 = AbacusSUPP.Helper.Zip(richEditControl1.Document.RtfText);
            string base64 = Convert.ToBase64String(r1);


            Komentar kom = new Komentar
            {
                datum = DateTime.Now,
                sadrzaj = base64,
                id_login = OperaterLogin.operater.id,
                id_task = task.id_task
            };
            int id = 0;
            var db = new AbacusSUPEntities();
            db.Komentar.Add(kom);
            db.SaveChanges();
            db.Entry(kom).Reload();
            var db2 = new AbacusSUPEntities();
            gridControl1.DataSource = db2.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            layoutView1.RefreshData();
            //var x = kom.Login.username;
            
            List<string> fajlovi = new List<string>();
            if (Directory.Exists(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
            {
                fajlovi = System.IO.Directory.GetFiles(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()).ToList();
                id = Baza.Komentar.OrderByDescending(qq => qq.datum).ToList()[0].id;
                if (id != 0)
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString());
                }
                else
                {
                    XtraMessageBox.Show("Komentar_id vratio 0! (folder ime)"); goto kraj;
                }
            }
            else { Directory.CreateDirectory(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()); };
            if (fajlovi.Count>0)
            {

                foreach (string fajl in fajlovi)
                {
                    System.IO.File.Move(fajl, Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString() + "\\" + Path.GetFileName(fajl));
                }
            }
            

            OperaterLogin.stara_kom_lista.Add(kom);
            this.Close();
            kraj:;
        }


    

        private void richEditControl1_ContentChanged(object sender, EventArgs e)
        {
            //DocumentImageCollection imageCollection = richEditControl1.Document.Images;
            if (imageCollection.Count > count)
            {

                DocumentImage image = imageCollection[imageCollection.Count - 1];
                var a = image.Image.NativeImage;
                
                if (!System.IO.Directory.Exists(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Slike\\" + task.id_task.ToString());
                }
                a.Save(Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + count.ToString()+".bmp");
                DocumentRange b = image.Range;
                richEditControl1.Document.Delete(b);
                //var d = 200 * a.Height / a.Width;
                var c = AbacusSUPP.Helper.ResizeImage(a, 200, 200 * a.Height / a.Width);
                imageCollection.Insert(richEditControl1.Document.CaretPosition, c);
                

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
                    string uri = Application.StartupPath + "\\Fajlovi" + "\\" + Path.GetFileName(file);
                    File.Copy(file, uri);
                    string file1 = Path.GetFileName(file) + System.Environment.NewLine;
                    DocumentRange range = richEditControl1.Document.AppendText(file1);

                    //string rec1String = richEditControl1.Text.Replace("\r\n", "\n");
                    //string fileN = file1.Replace("\r\n", "\n");
                    //int rec1Length = rec1String.Length;
                    //int fileNameLength = fileN.Length;

                    Hyperlink hyperlink = richEditControl1.Document.CreateHyperlink(range);
                    hyperlink.NavigateUri = uri;
                }
            }
        }
    }
}
