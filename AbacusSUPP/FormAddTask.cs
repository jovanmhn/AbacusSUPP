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
            gridControl1.DataSource = Baza.Login.ToList().OrderBy(qq=>qq.id);

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

                List<VezaLT> listaveza = new List<VezaLT>();
                listaveza = Baza.VezaLT.Where(qq => qq.id_task == id_task).ToList();
                List<int> idoperatera=new List<int>();
                List<Login> datasource = Baza.Login.OrderBy(qq => qq.id).ToList();
                

                Baza.VezaLT.RemoveRange(listaveza);
                Baza.SaveChanges();

                foreach (VezaLT veza in listaveza)
                {
                    idoperatera.Add(veza.id_login);
                }
                foreach(int id in idoperatera)
                {

                    int handle = datasource.IndexOf(datasource.First(qq => qq.id == id));
                    if(gridView1.IsDataRow(handle))
                    gridView1.SelectRow(handle);
                }
            }

            taskbindingSource.Add(task);

            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Baza.SaveChanges();
            
            this.DialogResult = DialogResult.OK;

            int[] handlelista = gridView1.GetSelectedRows();
            foreach (int handle in handlelista)
            {

                if (gridView1.IsDataRow(handle))
                {
                    VezaLT veza = new VezaLT();
                    Login login = (Login)gridView1.GetRow(handle);
                    veza.id_task = task.id_task;
                    veza.id_login = login.id;
                    Baza.VezaLT.Add(veza); 
                }
            }

            Baza.SaveChanges();

            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
