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
        int count = 0;
        public FormTest()
        {
            InitializeComponent();
            
        }

        

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void richEditControl1_ContentChanged(object sender, EventArgs e)
        {
            DocumentImageCollection imageCollection = richEditControl1.Document.Images;
            if (imageCollection.Count > count)
            {

                DocumentImage image = imageCollection[imageCollection.Count - 1];
                var a = image.Image.NativeImage;
                a.Save(string.Format("C:\\Users\\www.mojweb.me\\Desktop\\{0}.bmp", count));
                
                var b = image.Range;
                richEditControl1.Document.Delete(b);
                //var d = 200 * a.Height / a.Width;
                var c = AbacusSUPP.Helper.ResizeImage(a, 200, 200 * a.Height / a.Width);
                imageCollection.Insert(richEditControl1.Document.CaretPosition, c);

                count++;

            }
            if (imageCollection.Count < count) count--;
        }
    }
}
