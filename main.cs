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
using System.Reflection;
using static System.Net.WebRequestMethods;
using System.Data.SqlTypes;

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

        // ##### LINK AUFBAU #####
        // https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        // url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip

        public main()
        {
            InitializeComponent();
            var config = new IniFile("config.ini");

            readAllFromIni();
            var webRequest = WebRequest.Create(@"https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/packages.ini");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
                System.IO.File.WriteAllText("config.ini", strContent);
                saveAllToIni();
            }
            getRegions();
        }

        #region Package Manager
        // 27 Zeichen vor dem EDXX

        private void getRegions()
        {
            var regions = new List<string>() { };
            var config = new IniFile("config.ini");
            int x = 0;
            int y;

            int.TryParse(config.Read("amount", "Links"), NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out y);
            while (x <= y)
            {
                string regionName2 = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("/") + 21);
                regionName2 = regionName2.Substring(0, regionName2.IndexOf("/"));

                if (!regions.Contains(regionName2))
                {
                    string regionName = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("/") + 21);
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
                    string packageName = config.Read(x.ToString(), "Links").Substring(config.Read(x.ToString(), "Links").IndexOf("/") + 26);
                    packageName = packageName.Substring(0, packageName.IndexOf("2") - 1);
                    packagebox.Items.Add(packageName);
                }
                x++;
            }
        }
        #endregion

        #region Sonstige Functions
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

        private void saveAllToIni()
        {
            var password64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(passwd));

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

        private void airacsettingsbtn_Click(object sender, EventArgs e)
        {
            settings_airac settings_airac = new settings_airac();
            settings_airac.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void regionbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addPackageItems(regionbox.Text);
        }
    }
}
