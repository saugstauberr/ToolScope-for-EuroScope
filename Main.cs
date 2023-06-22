using AutoUpdaterDotNET;
using HtmlAgilityPack;
using Ini;
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

        public string selectedurl;
        public string selectedregion;

        public string pversion = "1.3.4";

        public Bunifu.UI.WinForms.BunifuButton.BunifuButton lastButton = null;

        public List<string> regions = new List<string>();
        
        public List<string> countries = new List<string>();

        public List<string> allpackages = new List<string>();

        public List<string> installedpackages = new List<string>();

        // ##### LINK AUFBAU #####
        // https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        // url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip

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

        public void Debug(string text)
        {
            MessageBox.Show(text);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            closebtn.Enabled= false;
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
                } catch
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

        public static void RunPowerShellScript()
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
            if(runpsscript.Checked == true)
            {
                pscodepanel.Visible = true;
            } else
            {
                pscodepanel.Visible = false;
            }
        }
    }
}
