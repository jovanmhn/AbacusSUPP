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
                Bitmap slika = new Bitmap(imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("customer_32x32.png")]);
                pictureBox1.Image= AbacusSUPP.Helper.ResizeImage(slika, 50, 50);
                Baza.Login.Add(login);
            }
            else
            {
                login = Baza.Login.First(it => it.id == id);
                if (GetImageFromByteArray(login.avatar) != null)
                    pictureBox1.Image = GetImageFromByteArray(login.avatar);
                else
                {
                    Bitmap slika = new Bitmap(imageCollection1.Images[imageCollection1.Images.Keys.IndexOf("customer_32x32.png")]);
                    pictureBox1.Image = AbacusSUPP.Helper.ResizeImage( slika, 50 , 50);
                }
            }

            bindingSource1.Add(login);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            login.avatar = converterDemo( pictureBox1.Image);
            Baza.SaveChanges();
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ALL FILES (*.*)|*.*|PNG (*.png)|*.png|JPEG (*.jpeg*)|*.jpeg|JPG (*.jpg*)|*.jpg*|BMP (*.bmp*)|*.bmp*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file = ofd.FileName;
                Image image = AbacusSUPP.Helper.ResizeImage( Image.FromFile(file), 50, 50);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }

          
        }
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            if (byteArray!=null)
            {
                ImageConverter _imageConverter = new ImageConverter();
                Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

                if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                                   bm.VerticalResolution != (int)bm.VerticalResolution))
                {
                    // Correct a strange glitch that has been observed in the test program when converting 
                    //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                    //  slightly away from the nominal integer value
                    bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                     (int)(bm.VerticalResolution + 0.5f));
                }

                return bm; 
            }
            return null;
        }

        private void FormDodajOperatera_Load(object sender, EventArgs e)
        {

        }
    }
}
