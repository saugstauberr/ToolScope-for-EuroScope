using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using IniParser;
using IniParser.Model;

namespace ToolScope_for_EuroScope
{
    public partial class settings_airac : Form
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

        public settings_airac()
        {
            InitializeComponent();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");

            readAllFromIni();

            if(data["Settings"]["packagedir"] == null)
            {
                
                data["Settings"]["packagedir"] = System.IO.Path.GetTempPath() + "toolscope_download";
                parser.WriteFile("config.ini", data);
            }

            if(data["Settings"]["esdir"] == null)
            {
                data["Settings"]["esdir"] = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope";
                parser.WriteFile("config.ini", data);
            }

            insertInTextBoxes();
        }

        #region Insert data in Textboxed

        private void readAllFromIni()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");

            packagedir = data["Settings"]["packagedir"];
            esdir = data["Settings"]["esdir"];
            cid = data["Settings"]["cid"];

            if (data["Settings"]["passwd"] != null)
            {
                passwd = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(data["Settings"]["passwd"]));
            }
            rating = data["Settings"]["rating"];
            server = data["Settings"]["server"];
            callsign = data["Settings"]["callsign"];
            realname = data["Settings"]["realname"];
            hoppiecode = data["Settings"]["hoppiecode"];
        }

        private string ratingConvert(string task, string data2)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");

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
            } else {
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
            packagedir = downloadfolderbox.Text;
            esdir = esfolderbox.Text;
        }

        private void saveAllToIni()
        {
            var password64 = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(passwdbox.Text));

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");

            data["Settings"]["packagedir"] = packagedir;
            parser.WriteFile("config.ini", data);

            data["Settings"]["esdir"] = esdir;
            parser.WriteFile("config.ini", data);

            data["Settings"]["cid"] = cid;
            parser.WriteFile("config.ini", data);

            data["Settings"]["passwd"] = password64;
            parser.WriteFile("config.ini", data);

            data["Settings"]["rating"] = rating;
            parser.WriteFile("config.ini", data);

            data["Settings"]["server"] = server;
            parser.WriteFile("config.ini", data);

            data["Settings"]["callsign"] = callsign;
            parser.WriteFile("config.ini", data);

            data["Settings"]["realname"] = realname;
            parser.WriteFile("config.ini", data);

            data["Settings"]["hoppiecode"] = hoppiecode;
            parser.WriteFile("config.ini", data);
        }

        private void insertInTextBoxes()
        {
            cidbox.Text = cid;
            passwdbox.Text = passwd;
            ratingbox.Text = rating = ratingConvert("read", rating); ;
            callsignbox.Text = callsign;
            namebox.Text = realname;
            hoppiecodebox.Text = hoppiecode;
            downloadfolderbox.Text = packagedir;
            esfolderbox.Text = esdir;
        }

        #endregion

        private void settings_airac_Load(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            main main = new main();
            updateVars();
            saveAllToIni();
            main.notifyText("success", "Settings have been saved!", 5);
            Hide();
        }

        private void downloadfolderbox_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    packagedir = fbd.SelectedPath;
                    downloadfolderbox.Text = packagedir;
                }
            }
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
