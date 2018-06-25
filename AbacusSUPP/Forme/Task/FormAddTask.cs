﻿using System;
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
        public Task task { get; set; }
        AbacusSUPEntities Baza { get; set; }
        bool sacuvano = false;
        List<int> idoperatera = new List<int>();
        List<VezaLT> listaveza_old = new List<VezaLT>();

        public FormAddTask(int? id_task /*= null*/ )
        {
            InitializeComponent();

            Baza = new AbacusSUPEntities();
            partneriBindingSource.DataSource = Baza.Partneri.ToList();
            statusBindingSource.DataSource = Baza.Status.ToList();
            prioritetBindingSource.DataSource = Baza.Prioritet.ToList();
            gridControl1.DataSource = Baza.Login.ToList().OrderBy(qq=>qq.id);
            this.DialogResult = DialogResult.Cancel;
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

                
                listaveza_old = Baza.VezaLT.Where(qq => qq.id_task == id_task).ToList();
                
                List<Login> datasource = Baza.Login.OrderBy(qq => qq.id).ToList();
                

                Baza.VezaLT.RemoveRange(listaveza_old);
                //Baza.SaveChanges();

                List<VezaLT> listaveza = new List<VezaLT>();
                listaveza.AddRange(listaveza_old);
                foreach (VezaLT veza in listaveza)
                {
                    idoperatera.Add(veza.id_login);
                }
                foreach(int id in idoperatera)
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

            //Baza.SaveChanges();


            int[] handlelista = gridView1.GetSelectedRows();
            foreach (int handle in handlelista)
            {

                if (gridView1.IsDataRow(handle))
                {
                    VezaLT veza = new VezaLT();
                    Login login = (Login)gridView1.GetRow(handle);
                    veza.id_task = task.id_task;
                    veza.id_login = login.id;
                    veza.isActive = true;
                    Baza.VezaLT.Add(veza); 
                }
            }
            Baza.SaveChanges();
            sacuvano = true;
            if(!Directory.Exists(Application.StartupPath + "\\Slike\\" + task.id_task.ToString()))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Slike\\" + task.id_task.ToString());
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
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
                        Baza.VezaLT.AddRange(listaveza_old);
                        Baza.SaveChanges();
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
