﻿#region Using Statements
using AutoUpdaterDotNET;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ToolScope_for_EuroScope.Code.Core;
#endregion

namespace ToolScope_for_EuroScope
{
    public partial class Main : Form
    {
        public string pversion = "1.4.2";

        #region Notes - Link Structure
        /// <summary>
        /// ##### LINK AUFBAU #####
        /// https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        /// url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip
        /// </summary>

        #endregion

        #region Global Objects
        public Objects.ClientRoot publicconfig = new Objects.ClientRoot();
        public Objects.ServerConfig publicsconfig = new Objects.ServerConfig();
        public Variables variables = new Variables();
        Converters converters= new Converters();
        Updater updater = new Updater();
        #endregion

        #region Main
        public Main()
        {
            // TODO: Optimize Main() Function for better readability
            InitializeComponent();
            AutoUpdater.InstalledVersion = new Version(pversion);
            AutoUpdater.Start("https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/update.xml");
            versionlabel.Text = pversion;


            #region Config Loader
            Objects.ClientRoot clientConfig = new Objects.ClientRoot();

            if (File.Exists("config.json") == false)
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(clientConfig, Formatting.Indented));
            }
            else
            {
                publicconfig = JsonConvert.DeserializeObject<Objects.ClientRoot>(File.ReadAllText("config.json"));
            }

            try
            {
                Debug.Write(publicconfig.clientconfig.esdir);
            }
            catch
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(clientConfig, Formatting.Indented));
                MessageBox.Show("JSON file error! Your JSON config file was resetted.");
            }

            var webResponse = "";

            using (WebClient client = new WebClient())
            {
                webResponse = client.DownloadString(variables.uriserverconfig);
            }

            publicsconfig = JsonConvert.DeserializeObject<Objects.ServerConfig>(webResponse);
            UpdateUI("read");
            #endregion

            GetCountries();

            if (publicsconfig.motd != "")
            {
                notifyText("info", publicsconfig.motd, 10);
            }
        }

        private void Main_Shown(Object sender, EventArgs e)
        {
            runpsscript.Checked = publicconfig.clientconfig.runpowershell;
            FeedDataGrid();
        }
        #endregion

        #region HEADER: Navigation Header/Bar

        #region Navigation Sidebar
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

            if (variables.isFirstrun == false)
            {
                System.Windows.Forms.Timer managertimer = new System.Windows.Forms.Timer();
                managertimer.Tick += new EventHandler(OnTimedEvent);
                managertimer.Interval = 50;
                managertimer.Enabled = true;

                void OnTimedEvent(object sendere, EventArgs ee)
                {
                    variables.isFirstrun = true;
                    FeedDataGrid();
                    managertimer.Stop();
                }
            }
        }
        #endregion

        #region Navigation Header
        private void closebtn_Click(object sender, EventArgs e)
        {
            closebtn.Enabled = false;
            Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #endregion

        #region PAGE: AIRAC Manager

        #region Functions

        //TODO: // #TODO: move into own function (AIRAC Manager Functions)
        private void FeedDataGrid()
        {
            publicconfig = JsonConvert.DeserializeObject<Objects.ClientRoot>(File.ReadAllText("config.json"));
            var packages = new List<Objects.AIRACPackage>();
            Objects.AIRACUpdate update = new Objects.AIRACUpdate();
            string[] packagejsons;
            try
            {
                packagejsons = Directory.GetFiles(publicconfig.clientconfig.esdir, "package.json", SearchOption.AllDirectories);
            }
            catch
            {
                return;
            }

            foreach (var pack in packagejsons)
            {
                if (!pack.Contains("ToolScope\\Backup"))
                {
                    try
                    {
                        var package = JsonConvert.DeserializeObject<Objects.AIRACPackage>(File.ReadAllText(pack));
                        if (package.url == null)
                        {
                            package.url = "NOURL";
                        }
                        packages.Add(package);
                    }
                    catch
                    { }
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

        private Objects.AIRACUpdate GetAIRACUpdate(int rows)
        {
            Objects.AIRACUpdate update = new Objects.AIRACUpdate();
            DataGridViewRow row = packagesdatagrid.Rows[rows];

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

            Objects.AIRACPackage el = new Objects.AIRACPackage();
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
                if (x.Contains(update.old_package.package) != true)
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
            el.url = url;
            el.country = GetURLInformation(url).country;
            el.package = GetURLInformation(url).package;
            update.new_package = el;


            if (update.old_package.released == update.new_package.released)
            {
                return update;
            }
            else
            {
                update.update = true;
                return update;
            }
        }

        
        #endregion

        #region Button Events

        #region Additional Settings
        private void insertcredentials_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI("write");
        }

        private void insertatisairport_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI("write");
        }

        private void runpsscript_CheckedChanged(object sender, EventArgs e)
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
            }
            catch
            {

            }
            FeedDataGrid();
        }

        private void packagesdatagrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            airacmanagermenu.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
        }



        private void strip_updatebtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.packagesdatagrid.SelectedRows[0];
            Objects.AIRACUpdate update = GetAIRACUpdate(row.Index);

            uipage.SelectedIndex = 0;

            countrybox.Text = update.old_package.country;
            countrybox_SelectedIndexChanged(null, null);
            regionbox.Text = update.new_package.region;
            regionbox_SelectedIndexChanged(null, null);
            packagebox.Text = update.new_package.package;
            packagebox_SelectedIndexChanged(null, null);
            downloadbtn_Click(null, null);
            variables.isUpdaterun = true;
        }

        private void airacmanagermenu_Opening(object sender, CancelEventArgs e)
        {
            DataGridViewRow row;
            try
            {
                row = this.packagesdatagrid.SelectedRows[0];
            }
            catch
            {
                strip_updatebtn.Visible = false;
                uninstallairac.Visible = false;
                strip_airacupdateinfotext.Text = "- No AIRAC selected or installed -";
                return;
            }


            Objects.AIRACUpdate update = GetAIRACUpdate(row.Index);

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
        #endregion

        #endregion

        #region PAGE: AIRAC Downloader

        #region Button Events
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
            var x = variables.allpackages.FindIndex(s => s.Contains("https://files.aero-nav.com/" + regionbox.Text + "/" + packagebox.Text));
            variables.selectedUrlString = variables.allpackages[x];

            string regionName = GetURLInformation(variables.selectedUrlString).region;

            string release = GetURLInformation(variables.selectedUrlString).released;

            string airac = GetURLInformation(variables.selectedUrlString).airac;

            string version = GetURLInformation(variables.selectedUrlString).version;

            variables.selectedRegionString = regionName;

            versiontxt.Text = "V" + version;
            DateTime da = DateTime.ParseExact(airac, "yyMMdd", new CultureInfo("da-DK"));
            airactxt.Text = da.ToString(@"yy\/MM");
            DateTime dr = DateTime.ParseExact(release, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
            releasetxt.Text = dr.ToString("dd.MM.yyyy");
            downloadbtn.Enabled = true;
        }

        private void downloadbtn_Click(object sender, EventArgs e)
        {
            updater.CreateBackup("", publicconfig);
            downloadbtn.Enabled = false;

            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
                client.Headers.Add(HttpRequestHeader.Referer, "https://files.aero-nav.com/EDXX/");
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(variables.selectedUrlString), publicconfig.clientconfig.esdir + "/ToolScope/data.zip");
            });
            thread.Start();
        }
        #endregion

        #region Download Functions
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                progressbar.Visible = true;
                progressbar.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                progressbar.Visible = false;
                try
                {
                    Directory.Delete(publicconfig.clientconfig.esdir + "/ToolScope/data");
                }
                catch
                {
                }
                updater.ExtractZip(publicconfig);
                updater.CreatePackageJSON(publicconfig.clientconfig.esdir + "/" + variables.selectedRegionString, this);

                // Running selected settings
                if (insertcredentials.Checked == true)
                {
                    updater.ReplaceProfiles(this);
                }

                if (insertsettings.Checked == true)
                {
                    updater.CopySettings(publicconfig, regionbox);
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

                if (variables.isUpdaterun == true)
                {
                    variables.isUpdaterun = false;
                    FeedDataGrid();
                    uipage.SelectedIndex = 1;
                }
            });
        }
        #endregion


        #endregion

        #region PAGE: Settings

        #region File Whitelist

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

        #region Button Events
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
        #endregion

        #endregion


        #region All Functions
        /// <summary>
        /// This only contains functions without any events.
        /// </summary>

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

        #region UI
        private void ChangeUI(string pagename, Bunifu.UI.WinForms.BunifuButton.BunifuButton current)
        {
            UpdateUI("read");
            current.Enabled = false;
            if (variables.lastButton != null)
            {
                variables.lastButton.Enabled = true;
            }

            variables.lastButton = current;
            pagenametxt.Text = pagename;
        }

        private void UpdateUI(string task)
        {
            switch (task)
            {
                case "read":
                    cidbox.Text = publicconfig.clientconfig.cid;
                    passwdbox.Text = converters.ConvertPassword("decrypt", publicconfig.clientconfig.passwd);
                    ratingbox.Text = converters.RatingConvert("read", publicconfig.clientconfig.rating);
                    callsignbox.Text = publicconfig.clientconfig.callsign;
                    namebox.Text = publicconfig.clientconfig.realname;
                    hoppiecodebox.Text = publicconfig.clientconfig.hoppiecode;
                    esfolderbox.Text = publicconfig.clientconfig.esdir;
                    countrybox.Text = publicconfig.clientconfig.country; ;
                    filescopylist.Rows.Clear();
                    if (publicconfig.clientconfig.allowedExtensions != null)
                    {
                        //filescopylist.DataSource = publicconfig.clientconfig.allowedExtensions.ConvertAll(x => new { Value = x });
                        foreach (var ext in publicconfig.clientconfig.allowedExtensions)
                        {
                            filescopylist.Rows.Add(ext);
                        }
                    }
                    else
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
                    publicconfig.clientconfig.passwd = converters.ConvertPassword("encrypt", passwdbox.Text);
                    publicconfig.clientconfig.rating = converters.RatingConvert("write", ratingbox.Text);
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

        #endregion

        #region Package Initalizer
        // TODO: move into own function (package initalizer)
        private void GrabDownloadUrls()
        {
            CountryNames database = new CountryNames();
            variables.allpackages.Clear();

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com/" + database.GetCountryIcao(countrybox.Text));
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (link.Attributes["href"].Value.Contains(".zip"))
                {
                    variables.allpackages.Add(link.Attributes["href"].Value);
                }
            }
        }

        private Objects.AIRACPackage GetURLInformation(string link)
        {
            Objects.AIRACPackage package = new Objects.AIRACPackage();

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
            variables.regions.Clear();

            foreach (string link in variables.allpackages)
            {
                string regionName2 = GetURLInformation(link).region;

                if (!variables.regions.Contains(regionName2))
                {
                    regionbox.Items.Add(GetURLInformation(link).region);
                }

                variables.regions.Add(regionName2);
            }
        }

        private void addPackageItems(string filter)
        {
            packagebox.Items.Clear();

            foreach (string link in variables.allpackages)
            {
                if (link.Contains(filter) == true)
                {
                    packagebox.Items.Add(GetURLInformation(link).package);
                }
            }
        }
        #endregion

        #region PowerShell
        // TODO: move into own function (PowerShell)
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

        #endregion

    }
}