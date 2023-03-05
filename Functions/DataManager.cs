using Ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToolScope_for_EuroScope
{
    public partial class Main
    {

        public void WriteConfig(string key, string value)
        {
            var config = new IniFile("config.ini");

            config.Write(key, value, "Settings");
        }

        public string ReadConfig(string key)
        {
            var config = new IniFile("config.ini");

            return config.Read(key, "Settings");
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
                        } catch { }
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
            }
        }

        public string ConvertPassword(string task, string value)
        {
            if (task == "encrypt")
            {
                return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
            } else
            {
                return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(value));
            }
        }

        public string RatingConvert(string task)
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
    }
}
