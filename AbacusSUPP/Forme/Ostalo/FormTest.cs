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
    public partial class FormTest : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        AbacusSUPEntities Baza { get; set; }
        System.Drawing.Image img;
        public FormTest()
        {
            InitializeComponent();
            
        }

        

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
