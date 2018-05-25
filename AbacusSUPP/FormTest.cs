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
        public FormTest()
        {
            InitializeComponent();

            /*System.IO.Stream stream = new System.IO.MemoryStream();
            richEditControl1.SaveDocument(stream, DevExpress.XtraRichEdit.DocumentFormat.WordML);
            stream.Seek(0, System.IO.SeekOrigin.Begin);

            //zip
            */

            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            memoEdit1.Text=richEditControl1.Document.RtfText;
            MessageBox.Show(memoEdit1.Text.Length.ToString());
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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            byte[] r1 = Zip(memoEdit1.Text);
            memoEdit2.Text = Convert.ToBase64String(r1);
            MessageBox.Show(memoEdit2.Text.Length.ToString());
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            byte[] array = Convert.FromBase64String(memoEdit2.Text);
            string rtf = Unzip(array);
            richEditControl1.Document.RtfText = rtf;
            richEditControl1.Refresh();
        }
    }
}
