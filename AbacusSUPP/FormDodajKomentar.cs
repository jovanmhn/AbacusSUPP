using System;
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

namespace AbacusSUPP
{
    public partial class FormDodajKomentar : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        Task task;
        public FormDodajKomentar(Task _task)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            task = _task;
            //richEditControl1.Document
            
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
            Baza.Komentar.Add(kom);
            Baza.SaveChanges();

            //gridcontrol1.DataSource = Baza.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            //layoutView1.RefreshData();
            //richEditControl1.Document.Delete(richEditControl1.Document.Range);
            this.Close();
        }
    }
}
