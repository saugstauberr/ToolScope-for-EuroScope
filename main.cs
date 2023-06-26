using AutoUpdaterDotNET;
using HtmlAgilityPack;
using Newtonsoft.Json;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static ToolScope_for_EuroScope.Main;

namespace ToolScope_for_EuroScope
{
    public partial class Main : Form
    {
        #region Developer variables
        public string pversion = "1.4.1";
        public string uriserverconfig = "https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/server.json";
        #endregion

        #region Program variables
        public string selectedurl;
        public string selectedregion;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton lastButton = null;
        public List<string> regions = new List<string>();
        public List<string> countries = new List<string>();
        public List<string> allpackages = new List<string>();
        public bool firstrun = false;
        public bool updaterun = false;
        #endregion

        #region Notes
        // ##### LINK AUFBAU #####
        // https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        // url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip
        #endregion

        ClientRoot publicconfig = new ClientRoot();
        ServerConfig publicsconfig = new ServerConfig();

        public Main()
        {
            InitializeComponent();
            AutoUpdater.InstalledVersion = new Version(pversion);
            AutoUpdater.Start("https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/update.xml");
            versionlabel.Text = pversion;


            #region Config Loader
            ClientRoot clientConfig = new ClientRoot();

            if (File.Exists("config.json") == false)
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(clientConfig, Formatting.Indented));
            }
            else
            {
                publicconfig = JsonConvert.DeserializeObject<ClientRoot>(File.ReadAllText("config.json"));
            }

            try
            {
                Debug.Write(publicconfig.clientconfig.esdir);
            } catch
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(clientConfig, Formatting.Indented));
                MessageBox.Show("JSON file error! Your JSON config file was resetted.");
            }

            var webResponse = "";

            using (WebClient client = new WebClient())
            {
                webResponse = client.DownloadString(uriserverconfig);
            }

            publicsconfig = JsonConvert.DeserializeObject<ServerConfig>(webResponse);
            UpdateUI("read");
            #endregion

            GetCountries();

            if(publicsconfig.motd != "")
            {
                notifyText("info", publicsconfig.motd, 10);
            }
            //CreateInstalledLabels();
        }

        private void Main_Shown(Object sender, EventArgs e)
        {
            runpsscript.Checked = publicconfig.clientconfig.runpowershell;
            FeedDataGrid();
        }

        #region AIRAC Manager

        private void uninstallairac_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.packagesdatagrid.SelectedRows[0];
            string region = row.Cells[1].Value.ToString();

            DirectoryInfo d = new DirectoryInfo(publicconfig.clientconfig.esdir);

            try
            {
                Directory.Delete(publicconfig.clientconfig.esdir + "/" + region, true);
                foreach (var file in d.GetFiles())
                {
                    if (file.FullName.Contains(region))
                    {
                        file.Delete();
                    }

                }
            } catch
            {

            }
            FeedDataGrid();
        }

        private void strip_updatebtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.packagesdatagrid.SelectedRows[0];
            AIRACUpdate update = GetAIRACUpdate(row.Index);

            uipage.SelectedIndex = 0;

            countrybox.Text = update.old_package.country;
            countrybox_SelectedIndexChanged(null, null);
            regionbox.Text = update.new_package.region;
            regionbox_SelectedIndexChanged(null, null);
            packagebox.Text = update.new_package.package;
            packagebox_SelectedIndexChanged(null, null);
            downloadbtn_Click(null, null);
            updaterun = true;
        }

        private void airacmanagermenu_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewRow row;
            try
            {
                row = this.packagesdatagrid.SelectedRows[0];
            } catch
            {
                strip_updatebtn.Visible = false;
                uninstallairac.Visible = false;
                strip_airacupdateinfotext.Text = "- No AIRAC selected or installed -";
                return;
            }
            

            AIRACUpdate update = GetAIRACUpdate(row.Index);

            if (update.no_url == true)
            {
                strip_airacupdateinfotext.Text = "- Autoupdater not available, please reinstall package for this feature! -";
                strip_airacrelease.Visible = false;
                strip_airacversion.Visible = false;
                strip_updatebtn.Visible = false;
                uninstallairac.Visible = true;
                return;
            }

            if (update.update == true)
            {
                strip_airacupdateinfotext.Visible = true;
                strip_airacrelease.Visible = true;
                strip_airacversion.Visible = true;
                strip_updatebtn.Visible = true;
                uninstallairac.Visible = true;
                strip_airacupdateinfotext.Text = "- New version found -";

                DateTime dr_o = DateTime.ParseExact(update.old_package.released, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
                update.old_package.released = dr_o.ToString("dd.MM.yyyy");
                DateTime dr = DateTime.ParseExact(update.new_package.released, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
                update.new_package.released = dr.ToString("dd.MM.yyyy");

                strip_airacrelease.Text = update.old_package.released + " -> " + update.new_package.released;
                strip_airacversion.Text = "Version: " + update.old_package.airac + " " + update.old_package.version + " -> " + update.new_package.airac + " V" + update.new_package.version;
            }
            else
            {
                strip_airacrelease.Visible = false;
                strip_airacversion.Visible = false;
                strip_airacupdateinfotext.Text = "- Latest version installed -";
                strip_updatebtn.Visible = false;
                uninstallairac.Visible = true;
            }
        }

        private void FeedDataGrid()
        {
            publicconfig = JsonConvert.DeserializeObject<ClientRoot>(File.ReadAllText("config.json"));
            var packages = new List<AIRACPackage>();
            AIRACUpdate update = new AIRACUpdate();
                string[] packagejsons = Directory.GetFiles(publicconfig.clientconfig.esdir, "package.json", SearchOption.AllDirectories).
                Where(d => !d.Contains("ToolScope")).ToArray(); ;
            foreach (var pack in packagejsons)
            {
                try
                {
                    var package = JsonConvert.DeserializeObject<AIRACPackage>(File.ReadAllText(pack));
                    if (package.url == null)
                    {
                        package.url = "NOURL";
                    }
                    packages.Add(package);
                }
                catch
                {

                }
            }
            packagesdatagrid.DataSource = packages;

            foreach (DataGridViewRow x in packagesdatagrid.Rows)
            {
                update = GetAIRACUpdate(x.Index);
                if (update.update == true)
                {
                    x.DefaultCellStyle.BackColor = Color.FromArgb(255, 105, 103, 68);
                    x.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 122, 120, 80);
                    x.Cells[5].Value = update.old_package.version + " -> " + "V" + update.new_package.version;
                    x.Cells[3].Value = update.old_package.airac + " -> " + update.new_package.airac;
                    DateTime dr_o = DateTime.ParseExact(update.old_package.released, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
                    update.old_package.released = dr_o.ToString("dd.MM.yy");
                    DateTime dr = DateTime.ParseExact(update.new_package.released, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
                    update.new_package.released = dr.ToString("dd.MM.yy");
                    x.Cells[4].Value = update.old_package.released + " -> " + update.new_package.released;
                    notifyText("warning", "AIRAC Updates available!", 7000);
                }
                else if (update.no_url == true)
                {
                    x.DefaultCellStyle.BackColor = Color.FromArgb(255, 94, 62, 62);
                    x.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 112, 73, 73);
                    notifyText("warning", "AIRAC Updates available!", 7000);
                }
            }
        }

        private AIRACUpdate GetAIRACUpdate(int rows)
        {
            AIRACUpdate update = new AIRACUpdate();
            DataGridViewRow row = this.packagesdatagrid.Rows[rows];

            if (row.Cells[6].Value.ToString() == "NOURL")
            {
                update.no_url = true;
                return update;
            }

            update.old_package.country = row.Cells[0].Value.ToString();
            update.old_package.region = row.Cells[1].Value.ToString();
            update.old_package.package = row.Cells[2].Value.ToString();
            update.old_package.airac = row.Cells[3].Value.ToString();
            update.old_package.version = row.Cells[5].Value.ToString();
            update.old_package.released = GetURLInformation(row.Cells[6].Value.ToString()).released;

            AIRACPackage el = new AIRACPackage();
            List<string> allurls = new List<string>();

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com/" + update.old_package.country);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (link.Attributes["href"].Value.Contains(".zip"))
                {
                    allurls.Add(link.Attributes["href"].Value);
                }
            }

            foreach (var x in allurls.ToList())
            {
                if (x.Contains(update.old_package.region) != true)
                {
                    allurls.Remove(x);
                }
            }

            foreach (var x in allurls.ToList())
            {
                if (x.Contains(update.old_package.package) != true )
                {
                    allurls.Remove(x); 
                }
            }
            var url = string.Join("", allurls.ToList());
            el.airac = GetURLInformation(url).airac;
            DateTime da = DateTime.ParseExact(el.airac, "yyMMdd", new CultureInfo("da-DK"));
            el.airac = da.ToString(@"yy\/MM");
            el.version = GetURLInformation(url).version;
            el.released = GetURLInformation(url).released;
            el.region = GetURLInformation(url).region;
            el.url= url;
            el.country = GetURLInformation(url).country;
            el.package = GetURLInformation(url).package;
            update.new_package = el;


            if (update.old_package.released == update.new_package.released)
            {
                return update;
            } else
            {
                update.update = true;
                return update;
            }
        }

        private void CreatePackageJSON(string path)
        {
            
            var root = JsonConvert.DeserializeObject<ClientRoot>(File.ReadAllText("config.json"));
            ClientPackage pack = new ClientPackage();

            AIRACPackage package = new AIRACPackage();

            package.package = packagebox.Text;
            package.country = countrybox.Text;
            package.region = regionbox.Text;

            package.airac = airactxt.Text;
            package.version = versiontxt.Text;
            package.released = releasetxt.Text;
            package.url = selectedurl;

            File.WriteAllText(path + "/package.json", JsonConvert.SerializeObject(package, Formatting.Indented));

            pack.jsonpath = path + "/package.json";

            var fileExists = false;

            for (int i = 0; i < root.installedpackages.Count; i++)
            {
                if (root.installedpackages[i].jsonpath == pack.jsonpath)
                {
                    fileExists = true;
                }
            }

            if (!fileExists)
            {
                root.installedpackages.Add(pack);
            }
        }

        #endregion

        #region Configs

        public class AIRACUpdate
        {
            public bool update = false;
            public bool no_url = false;
            public AIRACPackage old_package = new AIRACPackage();
            public AIRACPackage new_package = new AIRACPackage();
        }
        public class ServerConfig
        {
            public List<string> countries { get; set; }
            public string motd { get; set; }
        }

        public class ClientRoot
        {
            public ClientConfig clientconfig = new ClientConfig();
            public List<ClientPackage> installedpackages = new List<ClientPackage>();
        }

        public class ClientPackage
        {
            public string jsonpath { get; set; }
        }

        public class AIRACPackage
        {
            public string country { get; set; }
            public string region { get; set; }
            public string package { get; set; }
            public string airac { get; set; }
            public string released { get; set; }
            public string version { get; set; }
            public string url { get; set; }
        }

        public class ClientConfig
        {
            public string cid = "";
            public string passwd = "";
            public string callsign = "";
            public string realname = "";
            public string hoppiecode = "";
            public string rating = "";
            public string esdir = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope");
            public List<string> allowedExtensions { get; set; }


            public string server = "AUTOMATIC";
            public string country = "";
            public bool insertcredentials = true;
            public bool insertatisairport = true;
            public bool insertplugins = true;
            public bool runpowershell = false;
            public int codezoom = 0;
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

                case "warning":
                    notifytxt.ForeColor = Color.Orange;
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

        #region File Copier
        private void filescopylist_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            publicconfig.clientconfig.allowedExtensions.Clear();

            foreach (DataGridViewCell cell in filescopylist.SelectedCells)
            {
                cell.Value = null;
            }

            foreach (DataGridViewRow dr in filescopylist.Rows)
            {
                if (dr.Cells.Count >= 0 &&
                    dr.Cells[0].Value != null)
                {
                    publicconfig.clientconfig.allowedExtensions.Add(dr.Cells[0].Value.ToString());
                }
            }
            File.WriteAllText("config.json", JsonConvert.SerializeObject(publicconfig, Formatting.Indented));
            filescopylist.Rows.Clear();
            foreach (var ext in publicconfig.clientconfig.allowedExtensions)
            {
                filescopylist.Rows.Add(ext);
            }
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

        private void UpdateUI(string task)
        {
            switch (task)
            {
                case "read":
                    cidbox.Text = publicconfig.clientconfig.cid;
                    passwdbox.Text = ConvertPassword("decrypt", publicconfig.clientconfig.passwd);
                    ratingbox.Text = RatingConvert("read");
                    callsignbox.Text = publicconfig.clientconfig.callsign;
                    namebox.Text = publicconfig.clientconfig.realname;
                    hoppiecodebox.Text = publicconfig.clientconfig.hoppiecode;
                    esfolderbox.Text = publicconfig.clientconfig.esdir;
                    countrybox.Text = publicconfig.clientconfig.country;;
                    filescopylist.Rows.Clear();
                    if (publicconfig.clientconfig.allowedExtensions != null)
                    {
                        //filescopylist.DataSource = publicconfig.clientconfig.allowedExtensions.ConvertAll(x => new { Value = x });
                        foreach(var ext in publicconfig.clientconfig.allowedExtensions)
                        {
                            filescopylist.Rows.Add(ext);
                        }
                    } else
                    {
                        publicconfig.clientconfig.allowedExtensions = new List<string>() { "Screen.txt", "SCREEN.txt", "General.txt",
                            "GENERAL.txt", "Settings.txt", "SETTINGS.txt", "DepartureList.txt" };
                        File.WriteAllText("config.json", JsonConvert.SerializeObject(publicconfig, Formatting.Indented));
                        foreach (var ext in publicconfig.clientconfig.allowedExtensions)
                        {
                            filescopylist.Rows.Add(ext);
                        }
                    }
                    break;
                case "write":
                    publicconfig.clientconfig.cid = cidbox.Text;
                    publicconfig.clientconfig.passwd = ConvertPassword("encrypt", passwdbox.Text);
                    publicconfig.clientconfig.rating = RatingConvert("write");
                    publicconfig.clientconfig.callsign = callsignbox.Text;
                    publicconfig.clientconfig.realname = namebox.Text;
                    publicconfig.clientconfig.hoppiecode = hoppiecodebox.Text;
                    publicconfig.clientconfig.esdir = esfolderbox.Text;
                    publicconfig.clientconfig.country = countrybox.Text;
                    publicconfig.clientconfig.insertcredentials = insertcredentials.Checked;
                    publicconfig.clientconfig.insertatisairport = insertatisairport.Checked;
                    publicconfig.clientconfig.insertplugins = insertplugins.Checked;
                    publicconfig.clientconfig.runpowershell = runpsscript.Checked;
                    
                    File.WriteAllText("config.json", JsonConvert.SerializeObject(publicconfig, Formatting.Indented));
                    break;
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
                switch (publicconfig.clientconfig.rating)
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

        private AIRACPackage GetURLInformation(string link)
        {
            AIRACPackage package = new AIRACPackage();

            var regionName = link.Substring(link.IndexOf("nav.com/") + 8);
            package.region = regionName.Substring(0, regionName.IndexOf("/"));

            var packageName = regionName.Substring(regionName.IndexOf("/") + 1);
            package.package = packageName.Substring(0, packageName.IndexOf("_2"));

            var release = packageName.Substring(packageName.IndexOf("_2") + 1);
            package.released = release.Substring(0, release.IndexOf("-"));

            var airac = release.Substring(15);
            package.airac = airac.Substring(0, airac.IndexOf("-"));

            var version = airac.Substring(7);
            package.version = version.Substring(0, version.IndexOf(".zip"));
            package.url = "";

            /*switch (type)
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
            }*/
            return package;
        }


        private void GetCountries()
        {
            foreach (string country in publicsconfig.countries)
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
                string regionName2 = GetURLInformation(link).region;

                if (!regions.Contains(regionName2))
                {
                    regionbox.Items.Add(GetURLInformation(link).region);
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
                    packagebox.Items.Add(GetURLInformation(link).package);
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
                    Directory.Delete(publicconfig.clientconfig.esdir + "/ToolScope/data");
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

                CreatePackageJSON(publicconfig.clientconfig.esdir + "/" + selectedregion);

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

                if (updaterun == true)
                {
                    updaterun = false;
                    FeedDataGrid();
                    uipage.SelectedIndex = 1;
                }
            });
        }
        #endregion

        private void CreateBackup(string pathinesdir)
        {
            var sourcePath = publicconfig.clientconfig.esdir + pathinesdir;
            var targetPath = publicconfig.clientconfig.esdir + "/ToolScope/Backup/";

            try
            {
                Directory.Delete(publicconfig.clientconfig.esdir + "/ToolScope/Backup", true);
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
            var sourcePath = publicconfig.clientconfig.esdir + "/ToolScope/data";
            var targetPath = publicconfig.clientconfig.esdir;

            try
            {
                Directory.Delete(publicconfig.clientconfig.esdir + "/ToolScope/data", true);
            }
            catch
            {

            }

            ZipFile.ExtractToDirectory(publicconfig.clientconfig.esdir + "/ToolScope/data.zip", publicconfig.clientconfig.esdir + "/ToolScope/data");
            System.IO.File.Delete(publicconfig.clientconfig.esdir + "/ToolScope/data.zip");

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

            var apptext = "\r\nLastSession\tcallsign\t" + publicconfig.clientconfig.callsign + "\r\nLastSession\trealname\t" + publicconfig.clientconfig.realname +
                    "\r\nLastSession\t" + "certificate\t" + publicconfig.clientconfig.cid + "\r\nLastSession\tpassword\t" +
                    ConvertPassword("decrypt", publicconfig.clientconfig.passwd) + "\r\nLastSession\trating\t" + publicconfig.clientconfig.rating +
                    "\r\nLastSession\t" + "server\t" + publicconfig.clientconfig.server + "\r\nLastSession\ttovatsim\t1";
            string[] allProfiles = Directory.GetFiles(publicconfig.clientconfig.esdir, "*.prf");

            foreach (string profile in allProfiles)
            {
                var text = new StringBuilder();

                text.Append(System.IO.File.ReadAllText(profile) + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + publicconfig.clientconfig.cid);
                System.IO.File.WriteAllText(profile, text.ToString());
                text.Clear();
            }

            try
            {
                foreach (string s in Directory.EnumerateFiles(publicconfig.clientconfig.esdir + "/" + selectedregion + "/Plugins/", "TopSkyCPDLChoppieCode.txt", SearchOption.AllDirectories))
                {
                    System.IO.File.WriteAllText(s, publicconfig.clientconfig.hoppiecode);
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
            var allowedExtensions = publicconfig.clientconfig.allowedExtensions;

            try
            {
                var files = Directory
                .GetFiles(publicconfig.clientconfig.esdir + "/ToolScope/Backup/" + regionbox.Text + "/Settings", "*", SearchOption.AllDirectories).ToList();


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
        #endregion

        #region Button Actions
        #region Save Button Design
        private void cidbox_TextChanged_1(object sender, EventArgs e)
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

        private void ratingbox_SelectedIndexChanged_1(object sender, EventArgs e)
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
            CountryNames country = new CountryNames();

            publicconfig.clientconfig.country = countrybox.Text;
            File.WriteAllText("config.json", JsonConvert.SerializeObject(publicconfig, Formatting.Indented));

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
            var x = allpackages.FindIndex(s => s.Contains("https://files.aero-nav.com/" + regionbox.Text + "/" + packagebox.Text));
            selectedurl = allpackages[x];

            string regionName = GetURLInformation(selectedurl).region;

            string release = GetURLInformation(selectedurl).released;

            string airac = GetURLInformation(selectedurl).airac;

            string version = GetURLInformation(selectedurl).version;

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
            Directory.CreateDirectory(publicconfig.clientconfig.esdir + "/ToolScope");
            Directory.CreateDirectory(publicconfig.clientconfig.esdir + "/ToolScope/Backup");

            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
                client.Headers.Add(HttpRequestHeader.Referer, "https://files.aero-nav.com/EDXX/");
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(selectedurl), publicconfig.clientconfig.esdir + "/ToolScope/data.zip");
            });
            thread.Start();
        }

        private void openupdateui_Click(object sender, EventArgs e)
        {
            uipage.SelectedIndex = 0;
            ChangeUI("AIRAC Installer", (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender);
        }

        private void openpspan_Click(object sender, EventArgs e)
        {
            PSEditor pseditor = new PSEditor();
            //uipage.SelectedIndex = 1;
            //ChangeUI("PowerShell Editor", (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender);
            pseditor.Show();
        }

        private void opensettingsui_Click(object sender, EventArgs e)
        {
            uipage.SelectedIndex = 2;
            ChangeUI("AIRAC Settings", (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender);
        }

        private void airacmanagerbtn_Click(object sender, EventArgs e)
        {
            FeedDataGrid();
            uipage.SelectedIndex = 1;
            ChangeUI("AIRAC Manager", (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender);

            if (firstrun == false)
            {
                System.Windows.Forms.Timer managertimer = new System.Windows.Forms.Timer();
                managertimer.Tick += new EventHandler(OnTimedEvent);
                managertimer.Interval = 50;
                managertimer.Enabled = true;

                void OnTimedEvent(object sendere, EventArgs ee)
                {
                    firstrun = true;
                    FeedDataGrid();
                    managertimer.Stop();
                }
            }
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
                    publicconfig.clientconfig.esdir = fbd.SelectedPath;
                    File.WriteAllText("config.json", JsonConvert.SerializeObject(publicconfig, Formatting.Indented));
                    esfolderbox.Text = publicconfig.clientconfig.esdir;
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
                    System.IO.DirectoryInfo di = new DirectoryInfo(publicconfig.clientconfig.esdir);

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

        private void packagesdatagrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            airacmanagermenu.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
        }

        private void runpsscript_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI("write");
        }
    }
}