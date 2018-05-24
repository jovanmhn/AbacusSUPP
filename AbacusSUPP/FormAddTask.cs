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
    public partial class FormAddTask : DevExpress.XtraEditors.XtraForm
    {
        public Task task { get; set; }
        AbacusSUPEntities Baza { get; set; }
        public FormAddTask(int? id_task /*= null*/ )
        {
            InitializeComponent();

            Baza = new AbacusSUPEntities();
            partneriBindingSource.DataSource = Baza.Partneri.ToList();
            statusBindingSource.DataSource = Baza.Status.ToList();
            prioritetBindingSource.DataSource = Baza.Prioritet.ToList();

            if (id_task == 0)
            {
                task = new Task
                {
                    datum = DateTime.Now,
                    login_id = OperaterLogin.operater.id,
                };
                Baza.Task.Add(task);
            }
            else
            {
                task = Baza.Task.First(it => it.id_task == id_task);
            }

            taskbindingSource.Add(task);

            gridControl1.DataSource = Baza.Login.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Baza.SaveChanges();
            
            this.DialogResult = DialogResult.OK;

            
        }
    }
}
