using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }
    }
}
