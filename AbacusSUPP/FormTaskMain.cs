using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Layout;
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
            gridControl1.DataSource = Baza.Komentar.Where(qq => qq.id_task == task.id_task).OrderByDescending(ww => ww.datum).ToList();
            labelControl1.Text = task.id_task.ToString();
            memoEdit2.Text = task.opis;
            labelControl2.Text = "Prioritet: " + task.Prioritet.opis;
            labelControl3.Text = "Task otvorio: " + task.Login.username;
            labelControl4.Text = "Datum:" + task.datum.ToString();
            if (task.status_id == 2)
            {
                labelControl6.Visible = true;
                labelControl6.Text = "Datum zatvaranja"+task.datum_zatv.ToString();
            }
            this.Text = task.naslov;
            labelControl5.Text = task.naslov;
            layoutView1.PanModeSwitch();

            if (task.status_id == 2)
            {
                simpleButton2.Text = "Otvori task";
                simpleButton3.Enabled = false;
            }

            List<VezaLT> listaveza = Baza.VezaLT.Where(qq => qq.id_task == task.id_task).ToList();
            List<Login> listaoperatera = new List<Login>();
            foreach(VezaLT veza in listaveza)
            {
                Login operater = Baza.Login.FirstOrDefault(qq => qq.id == veza.id_login);
                listaoperatera.Add(operater);

            }
            gridControl2.DataSource = listaoperatera;
            gridView1.RefreshData();
            
        }

        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (task.status_id==1)
            {
                Baza.Task.FirstOrDefault(qq => qq.id_task == task.id_task).status_id = Baza.Status.FirstOrDefault(qw => qw.opis == "Zavrseno").id_status;
                Baza.Task.FirstOrDefault(qq => qq.id_task == task.id_task).datum_zatv = DateTime.Now;
                labelControl6.Text = Baza.Task.FirstOrDefault(qq => qq.id_task == task.id_task).datum_zatv.ToString();
                
                List<VezaLT> listaveza = Baza.VezaLT.Where(qq => qq.id_task == task.id_task).ToList();
                foreach (VezaLT veza in listaveza)
                {
                    Baza.VezaLT.FirstOrDefault(qw => qw.id_veza == veza.id_veza).isActive = false;
                }

                Baza.SaveChanges();
                
                this.Close(); 
            }
            if (task.status_id == 2)
            {

                if (XtraMessageBox.Show("Ovaj task je zatvoren. Otvoriti opet?","Provjera",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    Baza.Task.FirstOrDefault(qq => qq.id_task == task.id_task).status_id = Baza.Status.FirstOrDefault(qw => qw.opis == "U toku").id_status;
                    List<VezaLT> listaveza = Baza.VezaLT.Where(qq => qq.id_task == task.id_task).ToList();
                    foreach (VezaLT veza in listaveza)
                    {
                        Baza.VezaLT.FirstOrDefault(qw => qw.id_veza == veza.id_veza).isActive = true;
                    }

                    Baza.SaveChanges();
                    simpleButton3.Enabled = true;
                    
                    this.Close(); 
                }
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
            Baza.Komentar.Add(kom);
            Baza.SaveChanges();
            gridControl1.DataSource = Baza.Komentar.Where(qq => qq.id_task == task.id_task).OrderByDescending(ww => ww.datum).ToList();
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

        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {
            Komentar kom = (Komentar)layoutView1.GetRow(layoutView1.FocusedRowHandle);

            FormKomentarDetalj fkdetalj = new FormKomentarDetalj(kom.sadrzaj);
            fkdetalj.ShowDialog();
        }

        private void layoutView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
            layoutView1.PanModeSwitch();
            }
        }

        private void layoutView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                layoutView1.PanModeSwitch();
            }
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
