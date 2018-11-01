using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid;
using DevExpress.XtraRichEdit.API.Native;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraRichEdit.Export;
using Octokit;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Net;

namespace AbacusSUPP //cijela ova forma je govno, treba prepravit
{
    public partial class FormDodajKomentar : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        Task task;
        int count = 0;
        DocumentImageCollection imageCollection;
        GridControl gridControl1;
        LayoutView layoutView1;
        XtraScrollableControl xtraScrollableControl1;
        Komentar kom = new Komentar();
        int tempid;
        public FormDodajKomentar(Task _task, GridControl gridcontrol, LayoutView layoutView, XtraScrollableControl xtraScrollableControl)
        {
            InitializeComponent();
            Baza = new AbacusSUPEntities();
            task = _task;
            imageCollection = richEditControl1.Document.Images;
            gridControl1 = gridcontrol;
            layoutView1 = layoutView;
            xtraScrollableControl1 = xtraScrollableControl;

            #region Da olaksa .rtf! brisanje styleova i sl
            //richEditControl1.Document.BeginUpdate();
            //try
            //{
            //    for (int i = richEditControl1.Document.TableStyles.Count - 1; i >= 1; i--)
            //        richEditControl1.Document.TableStyles.Delete(richEditControl1.Document.TableStyles[i]);

            //    for (int i = richEditControl1.Document.ParagraphStyles.Count - 1; i >= 1; i--)
            //        richEditControl1.Document.ParagraphStyles.Delete(richEditControl1.Document.ParagraphStyles[i]);

            //    for (int i = richEditControl1.Document.CharacterStyles.Count - 1; i >= 1; i--)
            //        richEditControl1.Document.CharacterStyles.Delete(richEditControl1.Document.CharacterStyles[i]);
            //}
            //finally
            //{
            //    richEditControl1.Document.EndUpdate();
            //} 
            #endregion

            kom = new Komentar
            {
                datum = DateTime.Now,
                sadrzaj = null,
                id_login = OperaterLogin.operater.id,
                id_task = task.id_task
            };
            Baza.Komentar.Add(kom);
            Baza.SaveChanges();

            tempid = kom.id;
        }
    

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            byte[] r1 = AbacusSUPP.Helper.Zip(richEditControl1.Document.RtfText);
            string base64 = Convert.ToBase64String(r1);
            var db = new AbacusSUPEntities();

            db.Komentar.First(qq => qq.id == tempid).sadrzaj = base64;
            kom.sadrzaj = base64; //zbog uploada na imgur, moguce je da nije potrebno
            db.SaveChanges();
            int id = 0;
                        
            //var db2 = new AbacusSUPEntities();
            gridControl1.DataSource = db.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            layoutView1.RefreshData();

            LayoutViewInfo info = layoutView1.GetViewInfo() as LayoutViewInfo;
            layoutView1.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            gridControl1.Size = new Size(xtraScrollableControl1.Width - SystemInformation.VerticalScrollBarWidth, info.CalcRealViewHeight(new Rectangle(0, 0, 300, Int32.MaxValue)));

            if (OperaterLogin.operater.Podesavanja.kom_github_upload)
            {
                try
                {
                    //----------------------GitHub-----------------------------------------
                    var client = new GitHubClient(new ProductHeaderValue("AbacusSUPP"));
                    var basicAuth = new Credentials("jovanmhn", "jovan123");
                    client.Credentials = basicAuth;

                    string listal = getSveLinkove(kom);

                    
                    var comment = await client.Issue.Comment.Create("jovanmhn", "AbacusSUPP", task.git_id.Value, vratiPlainText(richEditControl1) + Environment.NewLine + listal); //ovo radi, argumenti su owner/repo/issueNo/komentar 
                    
                    

                    //var issueupitanju = await client.Issue.Get("jovanmhn", "AbacusSUPP", 3);
                    //---------------------------------------------------------------------
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska prilikom uploada komentara na GitHub"+Environment.NewLine + ex.Message);
                } 
            }

            #region Ovo sve je sranje, cijelu formu treba ispraviti, mozda GUID za link za sliku prije nego sto dobije ID...

            //string uri = Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + id.ToString() + "\\";
            //int broj = 0;
            //foreach (DocumentImage image in richEditControl1.Document.Images)
            //{
            //    var a = image.Range;
            //    uri += broj.ToString() + ".bmp";
            //    HyperlinkCollection hypcol = richEditControl1.Document.Hyperlinks;
            //    Hyperlink hyperlink = hypcol.Create(a);
            //    //Hyperlink hyperlink = richEditControl1.Document.CreateHyperlink(a);
            //    hyperlink.NavigateUri = uri;
            //    broj++;
            //}
            //byte[] test = AbacusSUPP.Helper.Zip(richEditControl1.Document.RtfText);
            //string test2 = Convert.ToBase64String(test);
            //var db3 = new AbacusSUPEntities();
            //Komentar testkom = db3.Komentar.Single(qq => qq.id == tempid);
            //testkom.sadrzaj = test2;
            //db3.SaveChanges();
            //gridControl1.DataSource = db3.Komentar.Where(qq => qq.id_task == task.id_task).OrderBy(ww => ww.datum).ToList();
            //layoutView1.RefreshData();
            #endregion




            OperaterLogin.stara_kom_lista.Add(kom);
            this.Close();
            this.DialogResult = DialogResult.OK;
            kraj:;
        }
        public string vratiPlainText(RichEditControl richEditControl1)
        {
            PlainTextDocumentExporterOptions options = new PlainTextDocumentExporterOptions();
            options.ExportBulletsAndNumbering = false;
            string plainText = richEditControl1.Document.GetText(richEditControl1.Document.Range, options);
            return plainText;
        }
        public string getSveLinkove(Komentar komentar)
        {
            if (System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + komentar.id.ToString()))
            {
                DirectoryInfo d = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + komentar.id.ToString());//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles(); //Getting Text files
                List<string> listafajlova = new List<string>();
                List<string> listalinkova = new List<string>();
                string linkovi = String.Empty;
                foreach (FileInfo file in Files)
                {
                    listafajlova.Add(file.Name);
                }
                if (listafajlova.Count != 0)
                {
                    foreach (string str in listafajlova)
                    {
                        //listalinkova.Add(getImgurlink(str));
                        linkovi += String.Format("![image-title]({0})" + Environment.NewLine, getImgurlink(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + komentar.id.ToString() + "\\" + str));
                    }
                    return linkovi;
                }
                else return String.Empty; 
            }
            else return String.Empty;
        }
        public string getImgurlink(string file)
        {
            try
            {
                using (var webclient = new WebClient())
                {
                    string clientID = "0f0d9a1643cbbef";
                    webclient.Headers.Add("Authorization", "Client-ID " + clientID);
                    var values = new NameValueCollection
                    {
                        { "image", Convert.ToBase64String(File.ReadAllBytes(file)) }
                    };

                    byte[] response = webclient.UploadValues("https://api.imgur.com/3/upload", values);
                    var json = Encoding.UTF8.GetString(response);
                    var parsedObject = JObject.Parse(json);
                    var link = parsedObject["data"]["link"].ToString();
                    return link;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Greska prilikom uploada slike na imgur!");
                return "Greska prilikom uploada slike na imgur!";
                
            }
        }
        


    

        private void richEditControl1_ContentChanged(object sender, EventArgs e)
        {
            //DocumentImageCollection imageCollection = richEditControl1.Document.Images;
            if (imageCollection.Count > count)
            {

                DocumentImage image = imageCollection[imageCollection.Count - 1];
                var a = image.Image.NativeImage;
                
                if (!System.IO.Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString()+"\\"+tempid.ToString()))
                {
                    System.IO.Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString()+"\\"+tempid.ToString());
                }
                
                string uri = System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + tempid.ToString() +"\\"+ count.ToString() + ".bmp";
                a.Save(uri);
                DocumentRange b = image.Range;
                richEditControl1.Document.Delete(b);                
                var c = AbacusSUPP.Helper.ResizeImage(a, 350, 350 * a.Height / a.Width);
                imageCollection.Insert(richEditControl1.Document.CaretPosition, c);
                var d = imageCollection[imageCollection.Count - 1];
                b = d.Range;
                Hyperlink hyperlink = richEditControl1.Document.CreateHyperlink(b);
                hyperlink.NavigateUri = uri;

                
                count++;

            }
            if (imageCollection.Count < count) count--;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Fajlovi"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Fajlovi");
                }
                List<string> fajlovi = ofd.FileNames.ToList();
                foreach (string file in fajlovi)
                {
                    string ime = Guid.NewGuid().ToString();
                    string uri = System.Windows.Forms.Application.StartupPath + "\\Fajlovi" + "\\" +ime + Path.GetExtension(file);
                    File.Copy(file, uri);
                    string file1 = Path.GetFileName(file) + System.Environment.NewLine;
                    DocumentRange range = richEditControl1.Document.AppendText(file1);
                    Hyperlink hyperlink = richEditControl1.Document.CreateHyperlink(range);
                    hyperlink.NavigateUri = uri;
                }
            }
        }

        private void FormDodajKomentar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK) //Ako nije save, a forma se zatvorila. Brisati slike...
            {
                var db = new AbacusSUPEntities();
                db.Komentar.Remove(db.Komentar.First(qq => qq.id == tempid));
                db.SaveChanges();


                try                //Directory.Delete(path, true) vjerovatno moze da obrise sve u direktorijumu, ali directory info je korisna klasa za znat
                {
                    System.IO.DirectoryInfo direktorijum = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + tempid.ToString());

                    foreach (FileInfo file in direktorijum.GetFiles())      //sve fajlove
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in direktorijum.GetDirectories()) //sve foldere
                    {
                        dir.Delete(true);
                    }
                    Directory.Delete(System.Windows.Forms.Application.StartupPath + "\\Slike\\" + task.id_task.ToString() + "\\" + tempid.ToString()); //sam direktorijum
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            
        }
    }
}
