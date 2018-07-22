using DevExpress.Services;
using DevExpress.Utils;
using DevExpress.XtraRichEdit;
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
        
        public FormTest()
        {
            InitializeComponent();
            
        }

        

    }
    public class CustomRichEditControl : RichEditControl
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            //base.OnMouseWheel(e);
        }
    }
}
