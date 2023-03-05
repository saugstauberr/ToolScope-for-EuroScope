using Ini;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolScope_for_EuroScope
{
    public partial class Main
    {
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
                    }
                    else
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
                    }
                    else
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

    }
}
