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
    
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        

        public FormLogin()
        {
            InitializeComponent();
           
             progressBarControl1.Properties.Step = 1;
             progressBarControl1.Properties.PercentView = true;
             progressBarControl1.Properties.Maximum = 6;
             progressBarControl1.Properties.Minimum = 0;
             progressBarControl1.Properties.EndColor = Color.Green;
             progressBarControl1.Properties.StartColor = Color.Yellow;
             progressBarControl1.ForeColor = Color.Red;

        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                textEdit2.Focus();
            }
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.PerformClick();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var Baza = new AbacusSUPEntities();

            OperaterLogin.operater = Baza.Login.FirstOrDefault(qq => qq.username == textEdit1.Text && qq.pass == textEdit2.Text);
            //OperaterLogin.podesavanja = new Settings();
            if (OperaterLogin.operater != null)
            {
                if (OperaterLogin.operater.Podesavanja == null)
                {
                    Podesavanja pod = new Podesavanja
                    {
                        minimize_notif = false,
                        minimize_tray = true,
                        novitask_notif = true,
                    };
                    Baza.Podesavanja.Add(pod);
                    Baza.SaveChanges();
                    Baza.Login.FirstOrDefault(qq => qq.username == textEdit1.Text && qq.pass == textEdit2.Text).id_podesavanja = pod.id_podesavanja;
                    Baza.SaveChanges();
                }
                FormMain frmmain = Program.MainForm = new FormMain(OperaterLogin.operater, progressBarControl1);
                frmmain.Show();
                this.Hide();
                
                
            }
            else
            {
                MessageBox.Show("Neispravan korisnik ili lozinka!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void textEdit1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) textEdit2.Focus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
