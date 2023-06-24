using AutoUpdaterDotNET;
using HtmlAgilityPack;
using Ini;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ToolScope_for_EuroScope
{
    public partial class Main : Form
    {
        #region Developer variables
        public string pversion = "1.3.4";
        public string uriserverconfig = "https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/server.json";
        #endregion

        #region Program variables
        public string selectedurl;
        public string selectedregion;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton lastButton = null;
        public List<string> regions = new List<string>();
        public List<string> countries = new List<string>();
        public List<string> allpackages = new List<string>();
        #endregion

        #region Notes
        // ##### LINK AUFBAU #####
        // https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        // url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip
        #endregion

        public Main()
        {
            InitializeComponent();
            AutoUpdater.InstalledVersion = new Version(pversion);
            AutoUpdater.Start("https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/update.xml");
            versionlabel.Text = pversion;
            var config = new IniFile("config.ini");

            UpdateUI("read");

            var webRequest = WebRequest.Create(@"https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/packages.ini");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
                System.IO.File.WriteAllText("config.ini", strContent);
            }
            GetCountries();

            try
            {
                using (var reader = new StreamReader("custom-ps.ps1"))
                {
                    psscriptbox.Text = reader.ReadToEnd();

                }
            } catch
            {

            }

            UpdateUI("write");

            notifyText("info", "Loaded! Version " + pversion, 10);

            if (config.Read("esdir", "Settings") == "")
            {
                config.Write("esdir", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope", "Settings");
                esfolderbox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope";
                notifyText("error", "Remember to change your settings!", 10);
            }
            //CreateInstalledLabels();
        }

        #region Configs
        public class ServerConfig
        {
            public List<string> countries { get; set; }
        }

        private class ClientConfig
        {

        }

        private void WriteConfig(string key, string value)
        {
            var config = new IniFile("config.ini");

            config.Write(key, value, "Settings");
        }

        private string ReadConfig(string key)
        {
            var config = new IniFile("config.ini");

            return config.Read(key, "Settings");
        }
        #endregion

        #region Notifications
        private void notifyText(string type, string text, int seconds)
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

        #region UI Switcher and Updater
        private void ChangeUI(string pagename, Bunifu.UI.WinForms.BunifuButton.BunifuButton current)
        {
            UpdateUI("read");
            /*current.OnIdleState.FillColor = Color.FromArgb(255, 42, 43, 46);
            current.onHoverState.FillColor = Color.FromArgb(255, 42, 43, 46);
            current.OnPressedState.FillColor = Color.FromArgb(255, 42, 43, 46);*/
            current.Enabled = false;
            if (lastButton != null)
            {
                lastButton.Enabled = true;
                /* lastButton.OnIdleState.FillColor = Color.FromArgb(255, 33, 34, 36);
                 lastButton.onHoverState.FillColor = Color.FromArgb(255, 33, 34, 36);
                 lastButton.OnPressedState.FillColor = Color.FromArgb(255, 33, 34, 36);*/
            }

            lastButton = current;
            pagenametxt.Text = pagename;
        }

        private void UpdateUI(string task, string attributes = "all")
        {
            var config = new IniFile("config.ini");

            if (task == "read")
            {
                switch (attributes)
                {
                    case "all":
                        cidbox.Text = ReadConfig("cid");
                        passwdbox.Text = ConvertPassword("decrypt", ReadConfig("passwd"));
                        ratingbox.Text = RatingConvert("read");
                        callsignbox.Text = ReadConfig("callsign");
                        namebox.Text = ReadConfig("realname");
                        hoppiecodebox.Text = ReadConfig("hoppiecode");
                        //downloadfolderbox.Text = packagedir;
                        esfolderbox.Text = ReadConfig("esdir");
                        countrybox.Text = ReadConfig("country");
                        try
                        {
                            insertcredentials.Checked = bool.Parse(ReadConfig("insertcredentials"));
                            insertatisairport.Checked = bool.Parse(ReadConfig("insertatisairport"));
                            insertplugins.Checked = bool.Parse(ReadConfig("insertplugins"));
                        }
                        catch { }
                        savebtn.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            else if (task == "write")
            {
                WriteConfig("cid", cidbox.Text);
                WriteConfig("passwd", ConvertPassword("encrypt", passwdbox.Text));
                WriteConfig("rating", RatingConvert("write"));
                WriteConfig("callsign", callsignbox.Text);
                WriteConfig("realname", namebox.Text);
                WriteConfig("hoppiecode", hoppiecodebox.Text);
                WriteConfig("esdir", esfolderbox.Text);
                WriteConfig("insertcredentials", insertcredentials.Checked.ToString());
                WriteConfig("insertatisairport", insertatisairport.Checked.ToString());
                WriteConfig("insertplugins", insertplugins.Checked.ToString());
                WriteConfig("server", "AUTOMATIC");
            }
        }

        private string ConvertPassword(string task, string value)
        {
            if (task == "encrypt")
            {
                return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
            }
            else
            {
                return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(value));
            }
        }

        private string RatingConvert(string task)
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
                switch (ReadConfig("rating"))
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
        #endregion

        #region Package Initalizer
        private void GrabDownloadUrls()
        {
            CountryNames database = new CountryNames();
            var config = new IniFile("config.ini");
            allpackages.Clear();

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com/" + database.GetCountryIcao(countrybox.Text));
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (link.Attributes["href"].Value.Contains(".zip"))
                {
                    allpackages.Add(link.Attributes["href"].Value);
                }
            }
        }

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
            var webResponse = "";

            using (WebClient client = new WebClient())
            {
                webResponse = client.DownloadString(uriserverconfig);
            }

            var config = JsonConvert.DeserializeObject<ServerConfig>(webResponse);

            MessageBox.Show(countries.ToString());
            foreach (string country in config.countries)
            {
                try
                {
                    countrybox.Items.Add(country);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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

        #region Updater

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
                    Directory.Delete(ReadConfig("esdir") + "/ToolScope/data");
                }
                catch
                {
                }
                ExtractZip();

                // Running selected settings
                if (insertcredentials.Checked == true)
                {
                    ReplaceProfiles();
                }

                if (insertsettings.Checked == true)
                {
                    CopySettings();
                }

                if (runpsscript.Checked == true)
                {
                    try
                    {
                        RunPowerShellScript();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("PowerShell Script Error! \n" + ex.ToString() + "\n\nThis is not a ToolScope program error!");
                    }
                }
            });
        }
        #endregion

        private void CreateBackup(string pathinesdir)
        {
            var sourcePath = ReadConfig("esdir") + pathinesdir;
            var targetPath = ReadConfig("esdir") + "/ToolScope/Backup/";

            try
            {
                Directory.Delete(ReadConfig("esdir") + "/ToolScope/Backup", true);
            }
            catch
            {

            }

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

        private void ExtractZip()
        {
            var sourcePath = ReadConfig("esdir") + "/ToolScope/data";
            var targetPath = ReadConfig("esdir");

            try
            {
                Directory.Delete(ReadConfig("esdir") + "/ToolScope/data", true);
            }
            catch
            {

            }

            ZipFile.ExtractToDirectory(ReadConfig("esdir") + "/ToolScope/data.zip", ReadConfig("esdir") + "/ToolScope/data");
            System.IO.File.Delete(ReadConfig("esdir") + "/ToolScope/data.zip");

            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                System.IO.File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }

            Directory.Delete(sourcePath, true);
        }

        private void ReplaceProfiles()
        {
            // Inserting the data into the .prf-Files

            var apptext = "\r\nLastSession\tcallsign\t" + ReadConfig("callsign") + "\r\nLastSession\trealname\t" + ReadConfig("realname") +
                    "\r\nLastSession\t" + "certificate\t" + ReadConfig("cid") + "\r\nLastSession\tpassword\t" +
                    ConvertPassword("decrypt", ReadConfig("passwd")) + "\r\nLastSession\trating\t" + ReadConfig("rating") +
                    "\r\nLastSession\t" + "server\t" + ReadConfig("server") + "\r\nLastSession\ttovatsim\t1";
            string[] allProfiles = Directory.GetFiles(ReadConfig("esdir"), "*.prf");

            foreach (string profile in allProfiles)
            {
                var text = new StringBuilder();

                text.Append(System.IO.File.ReadAllText(profile) + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + ReadConfig("cid"));
                System.IO.File.WriteAllText(profile, text.ToString());
                text.Clear();
            }

            try
            {
                foreach (string s in Directory.EnumerateFiles(ReadConfig("esdir") + "/" + selectedregion + "/Plugins/", "TopSkyCPDLChoppieCode.txt", SearchOption.AllDirectories))
                {
                    System.IO.File.WriteAllText(s, ReadConfig("hoppiecode"));
                }
            }
            catch
            {

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

            //installedpackages.Add(selectedurl);
            //CreateInstalledLabels();
            downloadbtn.Enabled = true;
        }

        private void CopySettings()
        {
            var allowedExtensions = new[] { "Screen.txt", "SCREEN.txt", "General.txt", "GENERAL.txt", "Settings.txt", "SETTINGS.txt", "DepartureList.txt" };

            try
            {
                var files = Directory
                .GetFiles(ReadConfig("esdir") + "/ToolScope/Backup/" + regionbox.Text + "/Settings", "*", SearchOption.AllDirectories).ToList();


                foreach (string file in files)
                {
                    if (allowedExtensions.Contains(System.IO.Path.GetFileName(file)))
                    {
                        System.IO.File.Copy(file, file.Replace("/ToolScope/Backup/", "/"), true);
                    }
                }

            }
            catch
            {

            }
        }

        #endregion

        #region PowerShell
        private static void RunPowerShellScript()
        {

            var ps1File = "custom-ps.ps1";

            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{ps1File}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }

        private void psscriptbox_TextChanged(object sender, EventArgs e)
        {
            var ps1File = "custom-ps.ps1";
            var content = psscriptbox.Text;
            System.IO.File.WriteAllText(ps1File, content);
        }

        private void openpseditor_Click(object sender, EventArgs e)
        {
            Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "custom-ps.ps1";
            fileopener.Start();
        }

        private void runpsscript_CheckedChanged(object sender, EventArgs e)
        {
            if (runpsscript.Checked == true)
            {
                pscodepanel.Visible = true;
            }
            else
            {
                pscodepanel.Visible = false;
            }
        }
        #endregion

        #region Button Actions
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

        private void closebtn_Click(object sender, EventArgs e)
        {
            closebtn.Enabled = false;
            Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

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

            var x = allpackages.FindIndex(s => s.Contains("https://files.aero-nav.com/" + regionbox.Text + "/" + packagebox.Text));

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
            CreateBackup("");
            downloadbtn.Enabled = false;
            Directory.CreateDirectory(ReadConfig("esdir") + "/ToolScope");
            Directory.CreateDirectory(ReadConfig("esdir") + "/ToolScope/Backup");

            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
                client.Headers.Add(HttpRequestHeader.Referer, "https://files.aero-nav.com/EDXX/");
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(selectedurl), ReadConfig("esdir") + "/ToolScope/data.zip");
            });
            thread.Start();
        }

        private void openupdateui_Click(object sender, EventArgs e)
        {
            uipage.SelectedIndex = 0;
            ChangeUI("AIRAC Manager", (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender);
        }

        private void opensettingsui_Click(object sender, EventArgs e)
        {
            uipage.SelectedIndex = 1;
            ChangeUI("AIRAC Settings", (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender);
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            UpdateUI("write");
            UpdateUI("read");
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
                    WriteConfig("esdir", fbd.SelectedPath);
                    esfolderbox.Text = ReadConfig("esdir");
                }
            }
        }

        private void clearesfolderbtn_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you really want to delete all downloaded AIRACs? Your settings won't be changed.", "Delete all downloaded AIRACs",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                try
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(ReadConfig("esdir"));

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    notifyText("success", "All AIRACs deleted!", 5);
                }
                catch
                {
                    notifyText("info", "No AIRACs found!", 5);
                }

            }
        }

        private void insertcredentials_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI("write");
        }

        private void insertatisairport_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI("write");
        }

        private void insertplugins_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI("write");
        }

        private void insertsettings_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI("write");
        }
        #endregion
    }
}
