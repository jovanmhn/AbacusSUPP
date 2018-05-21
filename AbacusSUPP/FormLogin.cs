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
        AbacusSUPEntities Baza { get; set; }

        public FormLogin()
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            
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
                simpleButton1.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            
            OperaterLogin.operater = Baza.Login.FirstOrDefault(qq => qq.username == textEdit1.Text && qq.pass == textEdit2.Text);
            if (OperaterLogin.operater != null)
            {
                
                FormMain frmmain = new FormMain(OperaterLogin.operater);
                frmmain.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Neispravan korisnik ili lozinka!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
    
}
