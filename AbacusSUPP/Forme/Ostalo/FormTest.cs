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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;
using System.Collections.Specialized;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraEditors;

namespace AbacusSUPP
{
    public partial class FormTest : DevExpress.XtraEditors.XtraForm
    {
        AbacusSUPEntities Baza { get; set; }
        
        public FormTest()
        {
            InitializeComponent();
            
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            //var client = new GitHubClient(new ProductHeaderValue("jovanmhn"));
            //var basicAuth = new Credentials("jovanmhn", "jovan123");
            //client.Credentials = basicAuth;

            //var user = await client.User.Get("jovanmhn");
            ////MessageBox.Show(String.Format("{0} has {1} public repositories - go check out their profile at {2}", user.Name, user.PublicRepos, user.Url));
            //var issuesForOctokit = await client.Issue.GetAllForRepository("jovanmhn", "AbacusSUPP");
            //var createIssue = new NewIssue("this thing doesn't work");
            //var issue = await client.Issue.Create("jovanmhn", "AbacusSUPP", createIssue);


            //var issueupitanju = await client.Issue.Get("jovanmhn", "AbacusSUPP", 3);

            using (var webclient = new WebClient())
            {
                string clientID = "0f0d9a1643cbbef";
                webclient.Headers.Add("Authorization", "Client-ID " + clientID);
                var values = new NameValueCollection
                {
                    { "image", Convert.ToBase64String(File.ReadAllBytes(@"C:\Users\Jovan2\Pictures\test.jpg")) }
                };

                byte[] response = webclient.UploadValues("https://api.imgur.com/3/upload", values);
                var json = Encoding.UTF8.GetString(response);
                var parsedObject = JObject.Parse(json);
                var popupJson = parsedObject["data"]["link"].ToString();

            }





        }


    }
    public class CustomRichTextEdit : RichTextEdit
    {
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            //base.OnMouseWheel(e);
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
