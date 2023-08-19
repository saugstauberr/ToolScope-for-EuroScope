#region Using Statements
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
        public string pversion = "1.4.4";

        #region Notes - Link Structure
        /// <summary>
        /// ##### LINK AUFBAU #####
        /// https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        /// url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip
        /// </summary>

        #endregion

        #region Global Objects
        public Variables variables = new Variables();
        Converters converters= new Converters();
        Updater updater = new Updater();
        PowerShell powershell = new PowerShell();
        AIRAC_Manager airacmanager = new AIRAC_Manager();
        Package_Handler packagehandler = new Package_Handler();
        Notification notification= new Notification();
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
            Variables.ClientRoot clientConfig = new Variables.ClientRoot();

            if (File.Exists("config.json") == false)
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(clientConfig, Formatting.Indented));
            }
            else
            {
                if(File.ReadAllText("config.json").Contains("clientconfig"))
                {
                    var fileContent = File.ReadAllText("config.json");
                    fileContent = fileContent.Replace("clientconfig", "general");
                    MessageBox.Show(fileContent);
                    File.WriteAllText("config.json", fileContent);
                }
                variables.client_config = JsonConvert.DeserializeObject<Variables.ClientRoot>(File.ReadAllText("config.json"));
            }

            try
            {
                Debug.Write(variables.client_config.general.esdir);
            }
            catch
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(clientConfig, Formatting.Indented));
                MessageBox.Show("JSON file error! Your JSON config file was resetted.");
            }

            var webResponse = "";

            using (WebClient client = new WebClient())
            {
                webResponse = client.DownloadString(variables.uriToServerConfig);
            }

            variables.server_config = JsonConvert.DeserializeObject<Variables.ServerConfig>(webResponse);
            UpdateUI("read");
            #endregion

            packagehandler.GetCountries(this);

            if (variables.server_config.motd != "")
            {
                notification.Information(this, variables.server_config.motd, 10);
            }

            runpsscript.Checked = variables.client_config.general.isRunPowershell;
            airacmanager.FeedDataGrid(this);
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
            airacmanager.FeedDataGrid(this);
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
                    airacmanager.FeedDataGrid(this);
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
        //Only Button Events here

        #region Button Events
        private void clearesfolderbtn_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Do you really want to delete all downloaded AIRACs? Your settings won't be changed.", "Delete all downloaded AIRACs",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                try
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(variables.client_config.general.esdir);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    notification.Success(this, "All AIRACs deleted!", 5);
                }
                catch
                {
                    notification.Information(this, "No AIRACs found!", 5);
                }

            }
        }

        private void uninstallairac_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.packagesdatagrid.SelectedRows[0];
            string region = row.Cells[1].Value.ToString();
            string package = row.Cells[2].Value.ToString();

            DirectoryInfo d = new DirectoryInfo(variables.client_config.general.esdir);

            try
            {
                Directory.Delete(variables.client_config.general.esdir + "/" + region + " " + package, true);
            }
            catch
            {

            }
            airacmanager.FeedDataGrid(this);
        }

        private void packagesdatagrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            airacmanagermenu.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
        }



        private void strip_updatebtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.packagesdatagrid.SelectedRows[0];
            Variables.AIRACUpdate update = airacmanager.GetAIRACUpdate(this, row.Index);

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


            Variables.AIRACUpdate update = airacmanager.GetAIRACUpdate(this, row.Index);

            if (update.isUrlFound == false)
            {
                strip_airacupdateinfotext.Text = "- Autoupdater not available, please reinstall package for this feature! -";
                strip_airacrelease.Visible = false;
                strip_airacversion.Visible = false;
                strip_updatebtn.Visible = false;
                uninstallairac.Visible = true;
                return;
            }

            if (update.isUpdateAvailable == true)
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
        // Only button events here except of Download Functions

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

        #region Button Events
        private void countrybox_SelectedIndexChanged(object sender, EventArgs e)
        {
            variables.client_config.general.country = countrybox.Text;
            File.WriteAllText("config.json", JsonConvert.SerializeObject(variables.client_config, Formatting.Indented));

            regionbox.Text = "";
            packagebox.Text = "";
            versiontxt.Text = "None";
            airactxt.Text = "None";
            releasetxt.Text = "None";
            downloadbtn.Enabled = false;

            packagehandler.GrabDownloadUrls(this);
            packagehandler.getRegions(this);
        }

        private void regionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            packagehandler.addPackageItems(this, regionbox.Text);
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

            string regionName = packagehandler.GetURLInformation(variables.selectedUrlString).region;

            string release = packagehandler.GetURLInformation(variables.selectedUrlString).released;

            string airac = packagehandler.GetURLInformation(variables.selectedUrlString).airac;

            string version = packagehandler.GetURLInformation(variables.selectedUrlString).version;

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
            updater.CreateBackup("", variables.client_config);
            downloadbtn.Enabled = false;

            Thread thread = new Thread(() =>
            {
                WebClient client = new WebClient();
                client.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
                client.Headers.Add(HttpRequestHeader.Referer, "https://files.aero-nav.com/EDXX/");
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(variables.selectedUrlString), variables.client_config.general.esdir + "/ToolScope/data.zip");
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
                    Directory.Delete(variables.client_config.general.esdir + "/ToolScope/data");
                }
                catch
                {
                }
                updater.ExtractZip(variables.client_config, variables.client_config.general.esdir + "/" + regionbox.Text + " " + packagebox.Text);

                // TODO: Folder structure, if selected advanced then to below, else do without packagebox.Text
                updater.CreatePackageJSON(variables.client_config.general.esdir + "/" + regionbox.Text + " " + packagebox.Text + "/" + variables.selectedRegionString, this);

                notification.Success(this, "Packages successfully installed/updated!", 10);

                // Running selected settings
                if (insertcredentials.Checked == true)
                {
                    updater.ReplaceProfiles(this);
                }

                if (insertsettings.Checked == true)
                {
                    updater.CopySettings(variables.client_config, regionbox);
                }

                if (runpsscript.Checked == true)
                {
                    try
                    {
                        powershell.RunPowerShellScript();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("PowerShell Script Error! \n" + ex.ToString() + "\n\nThis is not a ToolScope program error!");
                    }
                }

                if (variables.isUpdaterun == true)
                {
                    variables.isUpdaterun = false;
                    airacmanager.FeedDataGrid(this);
                    uipage.SelectedIndex = 1;
                }
            });
        }
        #endregion


        #endregion

        #region PAGE: Settings
        // Only Button Events here

        #region File Whitelist

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            variables.client_config.general.allowedExtensions.Clear();

            foreach (DataGridViewCell cell in filescopylist.SelectedCells)
            {
                cell.Value = null;
            }

            foreach (DataGridViewRow dr in filescopylist.Rows)
            {
                if (dr.Cells.Count >= 0 &&
                    dr.Cells[0].Value != null)
                {
                    variables.client_config.general.allowedExtensions.Add(dr.Cells[0].Value.ToString());
                }
            }
            File.WriteAllText("config.json", JsonConvert.SerializeObject(variables.client_config, Formatting.Indented));
            filescopylist.Rows.Clear();
            foreach (var ext in variables.client_config.general.allowedExtensions)
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
            notification.Success(this, "Settings have been saved and loaded!", 5);
        }

        private void esfolderbox_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    variables.client_config.general.esdir = fbd.SelectedPath;
                    File.WriteAllText("config.json", JsonConvert.SerializeObject(variables.client_config, Formatting.Indented));
                    esfolderbox.Text = variables.client_config.general.esdir;
                }
            }
        }
        #endregion

        #endregion

        #region All Functions
        // This only contains functions without any events.

        #region Notifications

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
                    cidbox.Text = variables.client_config.general.cid;
                    passwdbox.Text = converters.ConvertPassword("decrypt", variables.client_config.general.passwd);
                    ratingbox.Text = converters.RatingConvert("read", variables.client_config.general.rating);
                    callsignbox.Text = variables.client_config.general.callsign;
                    namebox.Text = variables.client_config.general.realname;
                    hoppiecodebox.Text = variables.client_config.general.hoppiecode;
                    esfolderbox.Text = variables.client_config.general.esdir;
                    countrybox.Text = variables.client_config.general.country; ;
                    filescopylist.Rows.Clear();
                    if (variables.client_config.general.allowedExtensions != null)
                    {
                        foreach (var ext in variables.client_config.general.allowedExtensions)
                        {
                            filescopylist.Rows.Add(ext);
                        }
                    }
                    else
                    {
                        variables.client_config.general.allowedExtensions = new List<string>() { "Screen.txt", "SCREEN.txt", "General.txt",
                            "GENERAL.txt", "Settings.txt", "SETTINGS.txt", "DepartureList.txt" };
                        File.WriteAllText("config.json", JsonConvert.SerializeObject(variables.client_config, Formatting.Indented));
                        foreach (var ext in variables.client_config.general.allowedExtensions)
                        {
                            filescopylist.Rows.Add(ext);
                        }
                    }
                    break;
                case "write":
                    variables.client_config.general.cid = cidbox.Text;
                    variables.client_config.general.passwd = converters.ConvertPassword("encrypt", passwdbox.Text);
                    variables.client_config.general.rating = converters.RatingConvert("write", ratingbox.Text);
                    variables.client_config.general.callsign = callsignbox.Text;
                    variables.client_config.general.realname = namebox.Text;
                    variables.client_config.general.hoppiecode = hoppiecodebox.Text;
                    variables.client_config.general.esdir = esfolderbox.Text;
                    variables.client_config.general.country = countrybox.Text;
                    variables.client_config.general.isInsertCredentials = insertcredentials.Checked;
                    variables.client_config.general.isInsertAtisAirport = insertatisairport.Checked;
                    variables.client_config.general.isInsertPlugins = insertplugins.Checked;
                    variables.client_config.general.isRunPowershell = runpsscript.Checked;
                    File.WriteAllText("config.json", JsonConvert.SerializeObject(variables.client_config, Formatting.Indented));
                    break;
            }
        }

        #endregion

        #endregion

        private void SaveFileWhitelist(object sender, DataGridViewCellEventArgs e)
        {
            variables.client_config.general.allowedExtensions.Clear();

            foreach (DataGridViewRow ext in filescopylist.Rows)
            {
                
                if(ext.Cells[0].Value != null)
                {
                    variables.client_config.general.allowedExtensions.Add(ext.Cells[0].Value.ToString());
                }
                UpdateUI("write");
            }
        }
    }
}