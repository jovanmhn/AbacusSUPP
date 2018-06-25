using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace AbacusSUPP
{
    public static class Helper
    {
        public static void load_settings()
        {
            //NE KORISTI SE VISE
            /*
            string putanja = System.IO.Path.Combine(Application.StartupPath, "Settings.xml");
            //XmlDocument dok = new XmlDocument();
            XmlReader reader = XmlReader.Create(putanja);
            //dok.Load(putanja);


            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Setting"))
                {
                    if (reader.HasAttributes)
                    {

                        
                        var tray = reader.GetAttribute("Tray");
                        OperaterLogin.podesavanja.tray = Convert.ToBoolean(reader.GetAttribute("Tray"));

                        
                        var minnotif = reader.GetAttribute("MinimizeNotif");
                        OperaterLogin.podesavanja.minimizeNotification = Convert.ToBoolean(reader.GetAttribute("MinimizeNotif"));


                    }
                }
            }
            */

        }
        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }

        public static byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    //msi.CopyTo(gs);
                    CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            if (byteArray != null)
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
    }
}
