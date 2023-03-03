using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ini;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Globalization;
using System.IO.Compression;
using System.Reflection;
using static System.Net.WebRequestMethods;
using System.Data.SqlTypes;
using WindowsFormsControlLibrary1;
using System.Runtime.Remoting.Lifetime;
using ToolScope_for_EuroScope;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using File = System.IO.File;
using static System.Net.Mime.MediaTypeNames;
using AutoUpdaterDotNET;
using System.Runtime.Remoting.Messaging;

namespace ToolScope_for_EuroScope
{
    public partial class main : Form
    {

        public string packagedir;
        public string esdir;
        public string cid;
        public string passwd;
        public string rating;
        public string server = "AUTOMATIC";
        public string callsign;
        public string realname;
        public string hoppiecode;

        public string selectedurl;
        public string selectedregion;

        public string pversion = "1.0.1";

        private Bunifu.UI.WinForms.BunifuButton.BunifuButton lastButton = null;

        public List<string> regions = new List<string>();

        public List<string> allpackages = new List<string>();

        // ##### LINK AUFBAU #####
        // https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        // url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip

        public main()
        {
            InitializeComponent();
            AutoUpdater.InstalledVersion = new Version(pversion);
            AutoUpdater.Start("https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/update.xml");
            var config = new IniFile("config.ini");

            readAllFromIni();
            var webRequest = WebRequest.Create(@"https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/packages.ini");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
                System.IO.File.WriteAllText("config.ini", strContent);
                saveAllToIni();
            }

            notifyText("info", "Loaded! Version " + pversion, 10);

            if (config.Read("esdir", "Settings") == "")
            {
                config.Write("esdir", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope", "Settings");
                esfolderbox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope";
                notifyText("error", "Remember to change your settings!", 10);
            }

            getRegions();
            addToPackagesList();
            insertInTextBoxes();
        }

        #region FileManager

        private void CreateBackup(string pathinesdir)
        {
            var sourcePath = esdir + "/" + pathinesdir;
            var targetPath = esdir + "/ToolScope/Backup/";


            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                System.IO.File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        public void ReplaceEuroScope()
        {
            var sourcePath = esdir + "/ToolScope/data";
            var targetPath = esdir + "/Scenario";

            try
            {
                Directory.Delete(esdir + "/ToolScope/data", true);
            } catch
            {

            }

            ZipFile.ExtractToDirectory(esdir + "/ToolScope/data.zip", esdir + "/ToolScope/data");
            System.IO.File.Delete(esdir + "/ToolScope/data.zip");

            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                System.IO.File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }

            Directory.Delete(sourcePath, true );

            if (selectedurl.ToString().Contains("EDGG") == true)
            {
                var text = new StringBuilder();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Apron.prf"));
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
                text = text.Append("\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1");

                System.IO.File.WriteAllText(targetPath + "/EDDF Apron.prf", text.ToString());
                System.IO.File.WriteAllText(targetPath + "/EDUU Rhein Radar.prf", text.ToString());
                System.IO.File.WriteAllText(targetPath + "/EDGG Langen Radar.prf", text.ToString());
                System.IO.File.WriteAllText(targetPath + "/Tower Ground.prf", text.ToString());

                text.Clear();
                notifyText("success", "Successfully updated (EDGG)!", 5);
            } 
            else if (selectedurl.Contains("EDMM") == true) {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDMM.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDMM.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDUU.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDUU.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/TWR_REAL.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/TWR_REAL.prf", text.ToString());
                text.Clear();

                notifyText("success", "Successfully updated (EDMM)!", 5);
            }
            else if (selectedurl.Contains("EDWW/DFS") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDBB-CTR-APP.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDBB-CTR-APP.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDBB-TWR.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDBB-TWR.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDUU-CTR.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDUU-CTR.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDWW-CTR-APP.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDWW-CTR-APP.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDWW-TWR.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDWW-TWR.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDYY-CTR.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDYY-CTR.prf", text.ToString());
                text.Clear();

                notifyText("success", "Successfully updated (EDWW-DFS)!", 5);
            }
            else if (selectedurl.Contains("EDWW/EDBB") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDBB_TopSky.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDBB_TopSky.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDBB_TopSky-Tower.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDBB_TopSky-Tower.prf", text.ToString());
                text.Clear();

                notifyText("success", "Successfully updated (EDWW-EDBB)!", 5);
            }
            else if (selectedurl.Contains("EDXX") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/FIS.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/FIS.prf", text.ToString());
                text.Clear();
            }

            foreach (string s in Directory.EnumerateFiles(esdir + "/Scenario/" + selectedregion + "/Plugins/", "TopSkyCPDLChoppieCode.txt", SearchOption.AllDirectories)) {
                System.IO.File.WriteAllText(s, hoppiecode);
            }

            downloadbtn.Enabled = true;
        }

        #endregion

        #region Package Manager
        // 27 Zeichen vor dem EDXX

        private void addToPackagesList()
        {
            var config = new IniFile("config.ini");
            int x = 0;
            int y;

            int.TryParse(config.Read("amount", "Links"), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out y);

            while (x <= y)
            {
                allpackages.Add(config.Read(x.ToString(), "Links"));

                x++;
            }
        }

        private void getRegions()
        {
            string regionName = "0";
            var config = new IniFile("config.ini");
            int x = 0;
            int y;

            int.TryParse(config.Read("amount", "Links"), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out y);

            while (x <= y)
            {

                string regionName2 = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("nav.com/") + 8);
                regionName2 = regionName2.Substring(0, regionName2.IndexOf("/"));

                string release = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("nav.com/") + 8);
                release = release.Substring(0, release.IndexOf("/"));

                string airac = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("nav.com/") + 8);
                airac = airac.Substring(0, airac.IndexOf("/"));

                string version = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("nav.com/") + 8);
                version = version.Substring(0, version.IndexOf("/"));

                if (!regions.Contains(regionName2))
                {
                    regionName = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("nav.com/") + 8);
                    regionName = regionName.Substring(0, regionName.IndexOf("/"));
                    regionbox.Items.Add(regionName);
                }

                regions.Add(regionName2);
                x++;
            }
        }

        private void addPackageItems(string filter)
        {
            var config = new IniFile("config.ini");
            int x = 0;
            int y;

            packagebox.Items.Clear();

            int.TryParse(config.Read("amount", "Links"), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out y);
            while(x <= y)
            {
                if (config.Read(x.ToString(), "Links").Contains(filter) == true) {
                    string packageName = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("nav.com/") + 13);
                    packageName = packageName.Substring(0, packageName.IndexOf("2") - 1);
                    packagebox.Items.Add(packageName);
                }
                x++;
            }
        }
        #endregion

        #region Sonstige Funktionen

        private void ChangeUI(string pagename, Bunifu.UI.WinForms.BunifuButton.BunifuButton current)
        {
            current.OnIdleState.FillColor = Color.FromArgb(255, 92, 82, 37);


            if (lastButton != null)
            {
                lastButton.OnIdleState.FillColor = Color.FromArgb(255, 64, 57, 22);
                lastButton.OnIdleState.BorderColor = Color.FromArgb(255, 207, 160, 6);
            }

            lastButton = current;
            pagenametxt.Text = pagename;
        }

        private void readAllFromIni()
        {
            var config = new IniFile("config.ini");

            packagedir = config.Read("packagedir", "Settings");
            esdir = config.Read("esdir", "Settings");
            cid = config.Read("cid", "Settings");

            if (config.Read("passwd", "Settings") != null)
            {
                passwd = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(config.Read("passwd", "Settings")));
            }
            rating = config.Read("rating", "Settings");
            server = config.Read("server", "Settings"); ;
            callsign = config.Read("callsign", "Settings");
            realname = config.Read("realname", "Settings");
            hoppiecode = config.Read("hoppiecode", "Settings");
        }

        private string ratingConvert(string task, string data2)
        {
            if (task == "write")
            {
                switch (data2)
                {
                    case "S1 - Tower Trainee":
                        return "1";
                    case "S2 - Tower Controller":
                        return "2";
                    case "S3 - Terminal Controller":
                        return "3";
                    case "C1 - Enroute Controller":
                        return "4";
                    case "C3 - Senior Controller":
                        return "5";
                    default:
                        return null;
                }
            }
            else
            {
                switch (data2)
                {
                    case "1":
                        return "S1 - Tower Trainee";
                    case "2":
                        return "S2 - Tower Controller";
                    case "3":
                        return "S3 - Terminal Controller";
                    case "4":
                        return "C1 - Enroute Controller";
                    case "5":
                        return "C3 - Senior Controller";
                    default:
                        return null;
                }
            }
        }

        private void updateVars()
        {
            cid = cidbox.Text;
            passwd = passwdbox.Text;
            rating = ratingConvert("write", ratingbox.Text);
            callsign = callsignbox.Text;
            realname = namebox.Text;
            hoppiecode = hoppiecodebox.Text;
            //packagedir = downloadfolderbox.Text;
            esdir = esfolderbox.Text;
        }

        private void saveAllToIni()
        {
            var password64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(passwdbox.Text));

            var config = new IniFile("config.ini");

            config.Write("packagedir", packagedir, "Settings");
            config.Write("esdir", esdir, "Settings");
            config.Write("cid", cid, "Settings");
            config.Write("passwd", password64, "Settings");
            config.Write("rating", rating, "Settings");
            config.Write("server", server, "Settings");
            config.Write("callsign", callsign, "Settings");
            config.Write("realname", realname, "Settings");
            config.Write("hoppiecode", hoppiecode, "Settings");
        }

        private void insertInTextBoxes()
        {
            cidbox.Text = cid;
            passwdbox.Text = passwd;
            ratingbox.Text = rating = ratingConvert("read", rating); ;
            callsignbox.Text = callsign;
            namebox.Text = realname;
            hoppiecodebox.Text = hoppiecode;
            //downloadfolderbox.Text = packagedir;
            esfolderbox.Text = esdir;
        }

        #endregion

        #region Control Bar

        private void closebtn_Click(object sender, EventArgs e)
        {
            closebtn.Enabled= false;
            Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        #endregion

        #region Notify System

        public void notifyText(string type, string text, int seconds)
        {
            notifytxt.Text = text;
            notifytxt.Visible = true;
            notifytimer.Stop();

            int duration = seconds * 1000;

            switch (type)
            {
                case "success":
                    notifytxt.ForeColor = Color.Green;
                    notifytimer.Interval = duration;
                    notifytimer.Start();
                    break;

                case "error":
                    notifytxt.ForeColor = Color.Red;
                    notifytimer.Interval = duration;
                    notifytimer.Start();
                    break;

                default:
                    notifytxt.ForeColor = Color.Silver;
                    notifytimer.Interval = duration;
                    notifytimer.Start();
                    break;
            }
        }

        private void notifytimer_Tick(object sender, EventArgs e)
        {
            notifytxt.Visible = false;
            notifytimer.Stop();
        }
        #endregion

        #region Downloader
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                progressbar.Visible = true;
                progressbar.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                progressbar.Visible = false;
                try
                {
                    Directory.Delete(esdir + "/ToolScope/data");
                } catch
                {
                }
                ReplaceEuroScope();
            });
        }
        #endregion

        private void regionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addPackageItems(regionbox.Text);
            packagebox.Text = "";
            versiontxt.Text = "None";
            airactxt.Text = "None";
            releasetxt.Text = "None";
        }

        private void packagebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = new IniFile("config.ini");

            var x = allpackages.FindIndex(s => s.Contains("https://files.aero-nav.com/"+ regionbox.Text + "/" + packagebox.Text));

            selectedurl = allpackages[x];

            string regionName = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("nav.com/") + 8);
            regionName = regionName.Substring(0, regionName.IndexOf("/"));

            string release = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("_2") + 1);
            release = release.Substring(0, release.IndexOf(".zip") - 10);

            string airac = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("_2") + 16);
            airac = airac.Substring(0, airac.IndexOf(".zip") - 2);

            string version = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("_2") + 23);
            version = version.Substring(0, version.IndexOf(".zip"));

            selectedregion = regionName;

            versiontxt.Text = "V" + version;
            DateTime da = DateTime.ParseExact(airac, "yyMMdd", new CultureInfo("da-DK"));
            airactxt.Text = da.ToString(@"yy\/MM");
            DateTime dr = DateTime.ParseExact(release, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
            releasetxt.Text = dr.ToString("dd.MM.yyyy");
        }

        private void downloadbtn_Click(object sender, EventArgs e)
        {
            readAllFromIni();
            CreateBackup("Scenario");
            downloadbtn.Enabled = false;

            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
                client.Headers.Add(HttpRequestHeader.Referer, "https://files.aero-nav.com/EDXX/");
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(selectedurl), esdir + "/ToolScope/data.zip");
            });
            thread.Start();
        }

        private void openupdateui_Click(object sender, EventArgs e)
        {
            uipage.SelectedIndex = 0;
            ChangeUI("AIRAC Updater/Downloader", (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender);
        }

        private void opensettingsui_Click(object sender, EventArgs e)
        {
            uipage.SelectedIndex = 1;
            ChangeUI("AIRAC Settings", (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            updateVars();
            saveAllToIni();
            readAllFromIni();
            insertInTextBoxes();
            notifyText("success", "Settings have been saved and loaded!", 5);
        }

        private void esfolderbox_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    esdir = fbd.SelectedPath;
                    esfolderbox.Text = esdir;
                }
            }
        }
    }
}
