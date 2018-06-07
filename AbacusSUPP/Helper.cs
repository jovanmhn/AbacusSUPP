using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;

namespace AbacusSUPP
{
    public static class Helper
    {
        public static void load_settings()
        {
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
    }
}
