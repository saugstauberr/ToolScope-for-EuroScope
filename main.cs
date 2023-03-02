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
using SCRRS_Installer.Functions;

namespace ToolScope_for_EuroScope
{
    public partial class main : Form
    {

        // ##### LINK AUFBAU #####
        // https://files.aero-nav.com/EDMM/Full-Update_20230225100326-230201-2.zip
        // url / SEKTOR / Packagename_YYYYMMDDHHMMSS-AIRAC/xx-Version .zip

        public main()
        {
            InitializeComponent();

            if(File.Exists("config.ini"))
            {
                notifyText("info", "Config has been found!", 5);
            } else
            {
                File.Create("config.ini");
                notifyText("info", "Config has been created!", 5);
            }
            var config = new IniFile("config.ini");
        }

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

        private void airacbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void regionbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
