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
    public partial class FormDodajOperatera : DevExpress.XtraEditors.XtraForm
    {
        int id;
        AbacusSUPEntities Baza { get; set; }
        public Login login { get; set; }

        public FormDodajOperatera(int _id)
        {
            InitializeComponent();
            id = _id;
            Baza = new AbacusSUPEntities();
            sektorBindingSource.DataSource = Baza.Sektor.ToList();
            if (id == 0)
            {
                login = new Login
                {
                    //stvari koje su fiksne
                    
                };
                
                Baza.Login.Add(login);
            }
            else
            {
                login = Baza.Login.First(it => it.id == id);
            }

            bindingSource1.Add(login);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Baza.SaveChanges();
            this.Close();
        }
    }
}
