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

                gridControl1.DataSource = listataskova;
                gridView1.RefreshData();
            }
        }
    }
}
