using AutoUpdaterDotNET;
using HtmlAgilityPack;
using Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
        public string country;

        public string selectedurl;
        public string selectedregion;

        public string pversion = "1.2.2";

        private Bunifu.UI.WinForms.BunifuButton.BunifuButton lastButton = null;

        public List<string> regions = new List<string>();

        public List<string> countries = new List<string>();

        public List<string> allpackages = new List<string>();

        public List<string> installedpackages = new List<string>();

        // ##### LINK AUFBAU #####
        // https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        // url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip

        public main()
        {
            InitializeComponent();
            AutoUpdater.InstalledVersion = new Version(pversion);
            AutoUpdater.Start("https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/update.xml");
            versionlabel.Text = pversion;
            var config = new IniFile("config.ini");

            UpdateIni("read", "all");
            var webRequest = WebRequest.Create(@"https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/packages.ini");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
                System.IO.File.WriteAllText("config.ini", strContent);
                UpdateIni("save", "all");
            }

            notifyText("info", "Loaded! Version " + pversion, 10);

            if (config.Read("esdir", "Settings") == "")
            {
                config.Write("esdir", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope", "Settings");
                esfolderbox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope";
                notifyText("error", "Remember to change your settings!", 10);
            }

            UpdateIni("read", "all");
            UpdateUI();
            GetCountries();
            //CreateInstalledLabels();
        }

        #region FileManager

        private void CreateBackup(string pathinesdir)
        {
            var sourcePath = esdir + pathinesdir;
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
            var targetPath = esdir;

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

            // Inserting the data into the .prf-Files

            if (selectedurl.ToString().Contains("EDGG") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Apron.prf") + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
                System.IO.File.WriteAllText(targetPath + "/EDDF Apron.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Rhein Radar.prf") + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
                System.IO.File.WriteAllText(targetPath + "/EDUU Rhein Radar.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Langen Radar.prf") + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
                System.IO.File.WriteAllText(targetPath + "/EDGG Langen Radar.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Tower Ground.prf") + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
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

                notifyText("success", "Successfully updated (EDXX)!", 5);
            } else
            {
                
                string[] allProfiles = Directory.GetFiles(esdir, "*.prf");

                foreach (string profile in allProfiles)
                {
                    var text = new StringBuilder();
                    var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                        "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                        "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                    text.Append(System.IO.File.ReadAllText(profile) + apptext);
                    System.IO.File.WriteAllText(profile, text.ToString());
                    text.Clear();
                 }
                notifyText("success", "Successfully updated and data inserted!", 5);

                    /*OpenFileDialog profiles = new OpenFileDialog();
                    profiles.Title = "Select .prf-File/s where your credentials should be inserted into";
                    profiles.Filter = "EuroScope Profiles (multiple possible)|*.prf";
                    profiles.Multiselect = true;
                    profiles.InitialDirectory = esdir;
                    if (profiles.ShowDialog() == DialogResult.OK)
                    {
                        string[] allProfiles = profiles.FileNames;

                        foreach(string profile in allProfiles )
                        {
                            var text = new StringBuilder();
                            var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                                "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                                "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                            text.Append(System.IO.File.ReadAllText(profile) + apptext);
                            System.IO.File.WriteAllText(profile, text.ToString());
                            text.Clear();
                        }
                        notifyText("success", "Successfully updated and data inserted!", 5);
                    }*/
                }

            foreach (string s in Directory.EnumerateFiles(esdir + "/" + selectedregion + "/Plugins/", "TopSkyCPDLChoppieCode.txt", SearchOption.AllDirectories)) {
                System.IO.File.WriteAllText(s, hoppiecode);
            }
            //installedpackages.Add(selectedurl);
            UpdateIni("save", "all");
            //CreateInstalledLabels();
            downloadbtn.Enabled = true;
        }

        #endregion

        #region Download URL Grabber

        private void GrabDownloadUrls()
        {
            CountryNames database = new CountryNames();
            var config = new IniFile("config.ini");
            allpackages.Clear();

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com/" + database.GetCountryIcao(countrybox.Text));
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                if(link.Attributes["href"].Value.Contains(".zip")) {
                    allpackages.Add(link.Attributes["href"].Value);
                }
            }
        }

        #endregion

        #region Package Manager
        // 27 Zeichen vor dem EDXX

        private string GetURLInformation(string link, string type)
        {
            string regionName = "0";
            string packageName = "0";
            string release = "0";
            string airac = "0";
            string version = "0";

            regionName = link.Substring(link.IndexOf("nav.com/") + 8);
            string regionName2 = regionName.Substring(0, regionName.IndexOf("/"));

            packageName = regionName.Substring(regionName.IndexOf("/") + 1);
            string packageName2 = packageName.Substring(0, packageName.IndexOf("_2"));

            release = packageName.Substring(packageName.IndexOf("_2") + 1);
            string release2 = release.Substring(0, release.IndexOf("-"));

            airac = release.Substring(15);
            string airac2 = airac.Substring(0, airac.IndexOf("-"));

            version = airac.Substring(7);
            string version2 = version.Substring(0, version.IndexOf(".zip"));

            switch (type)
            {
                case "region":
                    return regionName2;
                case "package":
                    return packageName2;
                case "release":
                    return release2;
                case "airac":
                    return airac2;
                case "version":
                    return version2;
                default:
                    return "ERROR";
            }
        }

        private void GetCountries()
        {
            CountryNames database = new CountryNames();
            var config = new IniFile("config.ini");
            countries = config.Read("countries", "Server").Split(',').ToList();

            foreach (string country in countries)
            {
                try
                {
                    if (database.GetCountryDisplayName(country) != null)
                    {
                        countrybox.Items.Add(database.GetCountryDisplayName(country));
                    } else
                    {
                        countrybox.Items.Add(country);
                    }
                } catch
                {
                    countrybox.Items.Add(country);
                }
                
            }
            GrabDownloadUrls();
            getRegions();
        }

        private void getRegions()
        {
            regionbox.Items.Clear();
            regions.Clear();

            foreach (string link in allpackages)
            {
                string regionName2 = GetURLInformation(link, "region");

                if (!regions.Contains(regionName2))
                {
                    regionbox.Items.Add(GetURLInformation(link, "region"));
                }

                regions.Add(regionName2);
            }
        }

        private void addPackageItems(string filter)
        {
            packagebox.Items.Clear();

            foreach (string link in allpackages)
            {
                if (link.Contains(filter) == true)
                {
                    packagebox.Items.Add(GetURLInformation(link, "package"));
                }
            }
        }
        #endregion

        #region Sonstige Funktionen
        
        private void CreateInstalledLabels()
        {
            int x = 5;
            int y = 57;

            foreach (string package in installedpackages)
            {
                Label namelabel = new Label();
                namelabel.Location = new Point(x, y);
                namelabel.Text = package;
                namelabel.AutoSize = true;
                namelabel.TextAlign = ContentAlignment.MiddleLeft;
                namelabel.ForeColor = Color.FromArgb(255, 224, 224, 224);
                namelabel.Font = new Font("Microsoft PhagsPa", 9);
                this.Controls.Add(namelabel);
                y += 8;
            }
        }

        private void UpdateIni(string task, string type)
        {
            var config = new IniFile("config.ini");

            switch (type)
            {
                case "installed":
                    if (task == "save")
                    {
                        config.Write("installed", string.Join(",", installedpackages), "Settings");
                    } else
                    {
                        installedpackages = config.Read("installed", "Settings").Split(',').ToList();
                    }
                    break;
                default:
                    if (task == "save")
                    {
                        var password64c = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(passwd));
                        config.Write("packagedir", packagedir, "Settings");
                        config.Write("esdir", esdir, "Settings");
                        config.Write("cid", cid, "Settings");
                        config.Write("passwd", password64c, "Settings");
                        config.Write("rating", rating, "Settings");
                        config.Write("server", "AUTOMATIC", "Settings");
                        config.Write("callsign", callsign, "Settings");
                        config.Write("realname", realname, "Settings");
                        config.Write("hoppiecode", hoppiecode, "Settings");
                        config.Write("country", country, "Settings");
                        config.Write("installed", string.Join(",", installedpackages), "Settings");
                    } else
                    {
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
                        country = config.Read("country", "Settings");
                        installedpackages = config.Read("installed", "Settings").Split(',').ToList();
                    }
                    break;
            }
        }

        private void ChangeUI(string pagename, Bunifu.UI.WinForms.BunifuButton.BunifuButton current)
        {
            UpdateUI();
            current.Enabled = false;

            if (lastButton != null)
            {
                lastButton.Enabled = true;
            }

            lastButton = current;
            pagenametxt.Text = pagename;
        }

        private string ratingConvert(string task)
        {
            var data = ratingbox.Text;

            if (task == "write")
            {
                switch (data)
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
                switch (rating)
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
                        return "Rating not found";
                }
            }
        }

        private void updateVars()
        {
            cid = cidbox.Text;
            passwd = passwdbox.Text;
            rating = ratingConvert("write");
            callsign = callsignbox.Text;
            realname = namebox.Text;
            hoppiecode = hoppiecodebox.Text;
            //packagedir = downloadfolderbox.Text;
            esdir = esfolderbox.Text;
        }

        private void UpdateUI(string attributes = "all")
        {
            switch (attributes)
            {
                case "all":
                    cidbox.Text = cid;
                    passwdbox.Text = passwd;
                    ratingbox.Text = ratingConvert("read");
                    callsignbox.Text = callsign;
                    namebox.Text = realname;
                    hoppiecodebox.Text = hoppiecode;
                    //downloadfolderbox.Text = packagedir;
                    esfolderbox.Text = esdir;
                    savebtn.Enabled = false;
                    countrybox.Text = country;
                    break;
                default:
                    break;
            }
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

        private void countrybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = new IniFile("config.ini");
            CountryNames country = new CountryNames();

            config.Write("country", countrybox.Text, "Settings");
            regionbox.Text = "";
            packagebox.Text = "";
            versiontxt.Text = "None";
            airactxt.Text = "None";
            releasetxt.Text = "None";
            downloadbtn.Enabled = false;

            GrabDownloadUrls();
            getRegions();
        }

        private void regionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addPackageItems(regionbox.Text);
            packagebox.Text = "";
            versiontxt.Text = "None";
            airactxt.Text = "None";
            releasetxt.Text = "None";
            downloadbtn.Enabled = false;
        }

        private void packagebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = new IniFile("config.ini");

            var x = allpackages.FindIndex(s => s.Contains("https://files.aero-nav.com/"+ regionbox.Text + "/" + packagebox.Text));

            selectedurl = allpackages[x];

            string regionName = GetURLInformation(selectedurl, "region");

            string release = GetURLInformation(selectedurl, "release");

            string airac = GetURLInformation(selectedurl, "airac");

            string version = GetURLInformation(selectedurl, "version");

            selectedregion = regionName;

            versiontxt.Text = "V" + version;
            DateTime da = DateTime.ParseExact(airac, "yyMMdd", new CultureInfo("da-DK"));
            airactxt.Text = da.ToString(@"yy\/MM");
            DateTime dr = DateTime.ParseExact(release, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
            releasetxt.Text = dr.ToString("dd.MM.yyyy");
            downloadbtn.Enabled = true;
        }

        private void downloadbtn_Click(object sender, EventArgs e)
        {
            UpdateIni("read", "all");
            CreateBackup("");
            downloadbtn.Enabled = false;
            Directory.CreateDirectory(esdir + "/ToolScope");
            Directory.CreateDirectory(esdir + "/ToolScope/Backup");

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
            UpdateIni("save", "all");
            UpdateIni("read", "all");
            UpdateUI();
            savebtn.Enabled = false;
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

        #region Save Button Design
        private void cidbox_TextChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = true;
        }

        private void passwdbox_TextChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = true;
        }

        private void namebox_TextChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = true;
        }

        private void ratingbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = true;
        }

        private void callsignbox_TextChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = true;
        }

        private void hoppiecodebox_TextChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = true;
        }

        private void esfolderbox_TextChanged(object sender, EventArgs e)
        {
            savebtn.Enabled = true;
        }
        #endregion

        private void clearesfolderbtn_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you really want to delete all downloaded AIRACs? Your settings won't be changed.", "Delete all downloaded AIRACs",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                try
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(esdir);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    notifyText("success", "All AIRACs deleted!", 5);
                } catch
                {
                    notifyText("info", "No AIRACs found!", 5);
                }
                
            }
        }
    }
}
