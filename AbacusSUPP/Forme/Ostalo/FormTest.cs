using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbacusSUPP
{
    public partial class FormTest : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        int count = 0;
        public FormTest()
        {
            InitializeComponent();
            simpleButton1.BackColor = Color.FromArgb(25, Color.Green);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int a  = Convert.ToInt32(spinEdit1.Value);
            int b = Convert.ToInt32(spinEdit2.Value);
            richEditControl1.Views.SimpleView.BackColor = Color.FromArgb(a, 0, b, 0);
        }

        

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            richEditControl1.ActiveView.BackColor = Color.FromArgb(25, Color.Green);
        }

        private void richEditControl1_CustomDrawActiveView(object sender, DevExpress.XtraRichEdit.RichEditViewCustomDrawEventArgs e)
        {

        }
    }
}
