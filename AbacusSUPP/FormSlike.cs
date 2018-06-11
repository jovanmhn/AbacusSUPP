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
    public partial class FormSlike : DevExpress.XtraEditors.XtraForm
    {
        string[] slike;
        int indikator = 0;
        public FormSlike(string[] _slike)
        {
            InitializeComponent();
            slike = _slike;
            pictureEdit1.LoadAsync(slike[indikator]);
            simpleButton1.Enabled = false;
            if (slike.Count() == 1) simpleButton2.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            indikator--;
            pictureEdit1.LoadAsync(slike[indikator]);
            if (indikator == 0) simpleButton1.Enabled = false;
            simpleButton2.Enabled = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            indikator++;
            pictureEdit1.LoadAsync(slike[indikator]);
            if (indikator == slike.Count()-1) simpleButton2.Enabled = false;
            simpleButton1.Enabled = true;
        }

        private void pictureEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                simpleButton1.PerformClick();
            }
            if (e.KeyCode == Keys.Left)
            {
                simpleButton2.PerformClick();
            }
        }
    }
}
