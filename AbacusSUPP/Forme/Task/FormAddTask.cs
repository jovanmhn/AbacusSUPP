using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP
{
    public partial class FormAddTask : DevExpress.XtraEditors.XtraForm
    {
        public Task task = new Task();
        AbacusSUPEntities Baza { get; set; }
        bool sacuvano = false;
        List<int> idoperatera = new List<int>();
        List<VezaLT> listaveza_old = new List<VezaLT>();
        bool isEdit = false;
        public FormAddTask(Task _task)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();

            partneriBindingSource.DataSource = Baza.Partneri.ToList();
            //statusBindingSource.DataSource = Baza.Status.ToList();
            prioritetBindingSource.DataSource = Baza.Prioritet.ToList();
            labelBindingSource.DataSource = Baza.Label.ToList();
            gridControl1.DataSource = Baza.Login.ToList().OrderBy(qq => qq.id);
            this.DialogResult = DialogResult.Cancel;

            if (_task.id_task == 0)
            {
                task = _task;
            }
            else
            {
                isEdit = true;
                Baza = new AbacusSUPEntities();
                task = Baza.Task.First(qq => qq.id_task == _task.id_task);

                listaveza_old = Baza.VezaLT.Where(qq => qq.id_task == task.id_task).ToList();

                List<Login> datasource = Baza.Login.OrderBy(qq => qq.id).ToList();


                Baza.VezaLT.RemoveRange(listaveza_old);
                Baza.SaveChanges();

                List<VezaLT> listaveza = new List<VezaLT>();
                listaveza.AddRange(listaveza_old);
                foreach (VezaLT veza in listaveza)
                {
                    idoperatera.Add(veza.id_login);
                }
                foreach (int id in idoperatera)
                {

                    //int handle = datasource.IndexOf(datasource.First(qq => qq.id == id));
                    //if(gridView1.IsDataRow(handle))
                    //gridView1.SelectRow(handle);
                    var row = datasource.FirstOrDefault(qq => qq.id == id);
                    var r = gridView1.LocateByValue("username", row.username);
                    gridView1.SelectRow(r);
                }
            }

            taskbindingSource.Add(task);


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            
            //var Baza = new AbacusSUPEntities();
            if (!isEdit) Baza.Task.Add(task);
            else
            {
                foreach (Binding bind in taskbindingSource.CurrencyManager.Bindings)
                bind.WriteValue();
                    
                
            }
            Baza.SaveChanges();
            if (OperaterLogin.operater.Podesavanja.task_github_upload)
            {
                try
                {
                    napravigithubissue(task);
                }
                catch
                {
                    MessageBox.Show("Greska prilikom dodavanja na GitHub issues");
                } 
            }

            int[] handlelista = gridView1.GetSelectedRows();
            foreach (int handle in handlelista)
            {

                if (gridView1.IsDataRow(handle))
                {
                    VezaLT veza = new VezaLT();
                    Login login = (Login)gridView1.GetRow(handle);
                    veza.id_task = task.id_task;
                    veza.id_login = login.id;
                    if (task.status_id == 1) veza.isActive = true;
                    else veza.isActive = false;
                    Baza.VezaLT.Add(veza);
                }
            }
            Baza.SaveChanges();
            sacuvano = true;
            if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public async void napravigithubissue(Task task)
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("AbacusSUPP"));
                var basicAuth = new Credentials("jovanmhn", "jovan123");
                client.Credentials = basicAuth;

                var noviIssue = new NewIssue(task.Partneri.naziv+" - "+task.naslov);
                noviIssue.Body = task.opis;
                noviIssue.Labels.Add("AbacusSUPP");
                switch (task.prioritet_id)
                {
                    case 1: { noviIssue.Labels.Add("low prio"); break; }
                    case 2: { noviIssue.Labels.Add("medium prio"); break; }
                    case 3: { noviIssue.Labels.Add("high prio"); break; }
                    default: { noviIssue.Labels.Add("medium prio"); break; }
                }
                noviIssue.Assignees.Add("jovanmhn");                
                var issue = await client.Issue.Create("jovanmhn", "AbacusSUPP", noviIssue);
                

                //var update = issue.ToUpdate();
                //update.AddLabel("AbacusSUPP");

                var db = new AbacusSUPEntities();
                db.Task.First(qq => qq.id_task == task.id_task).git_id = issue.Number;
                db.SaveChanges();
                
                
            }
            catch (Exception)
            {

                MessageBox.Show("Greska prilikom dodavanja na GitHub issues");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            /*try
            {
                Baza = new AbacusSUPEntities();
                Baza.Task.Remove(Baza.Task.First(qq => qq.id_task == task.id_task));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/
            this.Close();
        }

        private void FormAddTask_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (this.DialogResult != DialogResult.OK)
            {
                /*
                try
                {
                    Baza = new AbacusSUPEntities();
                    Baza.Task.Remove(Baza.Task.First(qq => qq.id_task == task.id_task));
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }*/
            }
            if (!sacuvano)
            {
                try
                {
                    if (listaveza_old.Count > 0)
                    {
                        var Db = new AbacusSUPEntities();
                        Db.VezaLT.AddRange(listaveza_old);
                        Db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
