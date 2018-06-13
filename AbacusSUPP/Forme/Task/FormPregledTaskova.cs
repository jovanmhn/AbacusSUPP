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
    public partial class FormPregledTaskova : DevExpress.XtraEditors.XtraForm
    {
        Login login = new Login();
        Partneri partner = new Partneri();
        AbacusSUPEntities Baza { get; set; }

        public FormPregledTaskova(Login _login)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            login = _login;
            
            this.Text = "Taskovi: " + login.username;
            List<Task> listataskova = new List<Task>();
            List<VezaLT> listaveza = Baza.VezaLT.Where(qq => qq.id_login == login.id).ToList();
            foreach (VezaLT veza in listaveza)
            {
                Task task = Baza.Task.First(qq => qq.id_task == veza.id_task);
                listataskova.Add(task);

            }
            gridControl1.DataSource = listataskova.Where(qq=>qq.Status.opis=="U toku");
            gridView1.RefreshData();
            gridControl2.DataSource = listataskova.Where(qq=> qq.Status.opis=="Zavrseno");
            gridView2.RefreshData();
            gridControl3.DataSource = listataskova.Where(qq => qq.Status.opis == "Zavrseno" && qq.login_id_zatv==OperaterLogin.operater.id);
            gridView3.RefreshData();

            Zatvoreni_od.Text += _login.username;

        }
        public FormPregledTaskova(Partneri _partner)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            partner = _partner;

            this.Text = "Taskovi: " + partner.naziv;
            List<Task> listataskova = new List<Task>();
            listataskova = Baza.Task.Where(qq => qq.id_partner == partner.id).ToList();
            gridControl1.DataSource = listataskova.Where(qq => qq.Status.opis == "U toku");
            gridView1.RefreshData();
            gridControl2.DataSource = listataskova.Where(qq => qq.Status.opis == "Zavrseno");
            gridView2.RefreshData();

            Zatvoreni_od.PageVisible = false;
            

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                OperaterLogin.seen_tasks.Add(task.id_task);
                FormTaskMain frmtm = new FormTaskMain(task);
                frmtm.Show();
                
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                OperaterLogin.seen_tasks.Add(task.id_task);
                FormTaskMain frmtm = new FormTaskMain(task);
                frmtm.Show();

            }
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            Task task = (Task)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (task != null)
            {
                OperaterLogin.seen_tasks.Add(task.id_task);
                FormTaskMain frmtm = new FormTaskMain(task);
                frmtm.Show();

            }
        }
    }
}
