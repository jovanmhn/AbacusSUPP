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
        }

        private void richEditControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {

                var a = Clipboard.GetText();
                var b = Clipboard.GetData(DataFormats.FileDrop);
                var c = Clipboard.GetImage();
                e.SuppressKeyPress = false;
                
            }
            //else e.SuppressKeyPress = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            richEditControl1.Document.InsertImage(richEditControl1.Document.CaretPosition, img);
        }
    }
}
