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
    public partial class FormTaskMain : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        Task task { get; set; }

        public string rtfprezip;
        public string rtfpostunzip;

        public FormTaskMain(Task _task)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            task = _task;
            gridControl1.DataSource = Baza.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            labelControl1.Text = task.id_task.ToString();
            memoEdit2.Text = task.opis;
            labelControl2.Text = "Prioritet: " + task.Prioritet.opis;
            labelControl3.Text = "Task otvorio: " + task.Login.username;
            labelControl4.Text = "Datum:" + task.datum.ToString();
            this.Text = task.naslov;
            labelControl5.Text = task.naslov;
            layoutView1.PanModeSwitch();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Komentar kom = new Komentar
            {
                datum = DateTime.Now,
                sadrzaj = memoEdit1.Text,
                id_login = OperaterLogin.operater.id,
                id_task = task.id_task
            };
            Baza.Komentar.Add(kom);
            Baza.SaveChanges();
            gridControl1.DataSource = Baza.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            layoutView1.RefreshData();
            memoEdit1.Text = null;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Baza.Task.FirstOrDefault(qq => qq.id_task == task.id_task).status_id = Baza.Status.FirstOrDefault(qw => qw.opis == "Zavrseno").id_status;
            Baza.SaveChanges();
            this.Close();
            
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
            Baza.Komentar.Add(kom);
            Baza.SaveChanges();
            gridControl1.DataSource = Baza.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            layoutView1.RefreshData();
            richEditControl1.Document.Delete(richEditControl1.Document.Range);
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


                if (row!=null)
                {
                    byte[] zipovan = Convert.FromBase64String(row.sadrzaj);
                    string rtfraw = Unzip(zipovan);

                    rtfpostunzip = rtfraw;

                    repositoryItemRichTextEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
                    e.Value = rtfraw; 
                }
                
                
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
    
    
}
