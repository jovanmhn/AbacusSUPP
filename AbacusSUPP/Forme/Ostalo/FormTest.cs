using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP
{
    public partial class FormTest : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        System.Drawing.Image img;
        public FormTest()
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            repositoryItemRichTextEdit1.OptionsBehavior.OfficeScrolling = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
            repositoryItemRichTextEdit1.BestFitWidth = -1;
             img = imageCollection1.Images[0];
            richEditControl1.Document.InsertImage(richEditControl1.Document.CaretPosition, img);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<Komentar> list= Baza.Komentar.Where(qq => qq.id_task == 73).ToList();
            gridControl1.DataSource = list;
            layoutView1.RefreshData();
        }

        private void repositoryItemRichTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void layoutView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if(e.Column == UnboundKomentar)
            {
                var row = (Komentar)e.Row;


                if (row != null)
                {
                    byte[] zipovan = Convert.FromBase64String(row.sadrzaj);
                    string rtfraw = AbacusSUPP.Helper.Unzip(zipovan);

                    //rtfpostunzip = rtfraw;
                    
                    repositoryItemRichTextEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
                    e.Value = rtfraw;
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
            h = (int)(slika.Height*w/slika.Width);
            System.Drawing.Bitmap mala_slika = AbacusSUPP.Helper.ResizeImage(slika, w, h);
            //richEditControl1.Document.InsertImage(richEditControl1.Document.CaretPosition, mala_slika);
            collection.Insert(richEditControl1.Document.CaretPosition, mala_slika);

            if (!System.IO.Directory.Exists(Application.StartupPath + "\\Slike" + "\\1"))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Slike" + "\\1");
            }
            slika.Save(Application.StartupPath + "\\Slike" + "\\1"+"\\imeslike.bmp");
            
        }

        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            richEditControl1.Document.InsertImage(richEditControl1.Document.CaretPosition, img);
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
                    }
                
                
            }
            //else e.SuppressKeyPress = true;
        }
    }
}
