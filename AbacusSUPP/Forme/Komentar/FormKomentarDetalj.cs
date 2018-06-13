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
    public partial class FormKomentarDetalj : Form
    {
        string sadrzaj;
        int count;
        public FormKomentarDetalj(string _sadrzaj)
        {
            InitializeComponent();
            sadrzaj = _sadrzaj;
            //richEditControl1.Document.Unit = DevExpress.Office.DocumentUnit.Centimeter;
            //richEditControl1.Document.Sections[0].Page.Width = 100;
            byte[] zipovan = Convert.FromBase64String(sadrzaj);
            string rtfraw = Unzip(zipovan);
            richEditControl1.Document.RtfText = rtfraw;
            richEditControl1.Refresh();

            
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

        private void richEditControl1_ContentChanged(object sender, EventArgs e)
        {
            DocumentImageCollection collection = richEditControl1.Document.GetImages(richEditControl1.Document.Range);
            if (collection.Count > 0)
            {
                DocumentImage image = collection[collection.Count - 1];
                richEditControl1.Document.Sections[0].Page.Width = image.Size.Width + richEditControl1.Document.Sections[0].Margins.Left + richEditControl1.Document.Sections[0].Margins.Right;
            }
        }
    }
}
