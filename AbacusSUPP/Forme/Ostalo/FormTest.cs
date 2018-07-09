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
            if (!Directory.Exists(Application.StartupPath + "\\Fajlovi"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Fajlovi");
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                List<string> fajlovi = ofd.FileNames.ToList();
                foreach(string file in fajlovi)
                {
                    string uri = Application.StartupPath + "\\Fajlovi" + "\\" + Path.GetFileName(file);
                    File.Copy(file, uri);
                    string file1 = Path.GetFileName(file) + System.Environment.NewLine;
                    DocumentRange range = richEditControl1.Document.AppendText(file1);

                    //string rec1String = richEditControl1.Text.Replace("\r\n", "\n");
                    //string fileN = file1.Replace("\r\n", "\n");
                    //int rec1Length = rec1String.Length;
                    //int fileNameLength = fileN.Length;
                    
                    Hyperlink hyperlink = richEditControl1.Document.CreateHyperlink(range);
                    hyperlink.NavigateUri = uri;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            richEditControl1.ReadOnly = true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            richEditControl1.ReadOnly = false;
        }
    }
}
