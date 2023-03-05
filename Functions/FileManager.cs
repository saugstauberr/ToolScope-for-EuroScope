using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net;

namespace ToolScope_for_EuroScope
{
    public partial class Main
    {
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
                    Directory.Delete(esdir + "/ToolScope/data");
                }
                catch
                {
                }
                ReplaceEuroScope();
            });
        }
        #endregion

        public void CreateBackup(string pathinesdir)
        {
            var sourcePath = esdir + pathinesdir;
            var targetPath = esdir + "/ToolScope/Backup/";


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

        public void ReplaceEuroScope()
        {
            var sourcePath = esdir + "/ToolScope/data";
            var targetPath = esdir;

            try
            {
                Directory.Delete(esdir + "/ToolScope/data", true);
            }
            catch
            {

            }

            ZipFile.ExtractToDirectory(esdir + "/ToolScope/data.zip", esdir + "/ToolScope/data");
            System.IO.File.Delete(esdir + "/ToolScope/data.zip");

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

            // Inserting the data into the .prf-Files

            if (selectedurl.ToString().Contains("EDGG") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Apron.prf") + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
                System.IO.File.WriteAllText(targetPath + "/EDDF Apron.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Rhein Radar.prf") + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
                System.IO.File.WriteAllText(targetPath + "/EDUU Rhein Radar.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Langen Radar.prf") + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
                System.IO.File.WriteAllText(targetPath + "/EDGG Langen Radar.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDDF Tower Ground.prf") + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + cid);
                System.IO.File.WriteAllText(targetPath + "/Tower Ground.prf", text.ToString());
                text.Clear();

                notifyText("success", "Successfully updated (EDGG)!", 5);
            }
            else if (selectedurl.Contains("EDMM") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDMM.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDMM.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDUU.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDUU.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/TWR_REAL.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/TWR_REAL.prf", text.ToString());
                text.Clear();

                notifyText("success", "Successfully updated (EDMM)!", 5);
            }
            else if (selectedurl.Contains("EDWW/DFS") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDBB-CTR-APP.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDBB-CTR-APP.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDBB-TWR.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDBB-TWR.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDUU-CTR.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDUU-CTR.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDWW-CTR-APP.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDWW-CTR-APP.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDWW-TWR.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDWW-TWR.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDYY-CTR.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDYY-CTR.prf", text.ToString());
                text.Clear();

                notifyText("success", "Successfully updated (EDWW-DFS)!", 5);
            }
            else if (selectedurl.Contains("EDWW/EDBB") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDBB_TopSky.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDBB_TopSky.prf", text.ToString());
                text.Clear();

                text.Append(System.IO.File.ReadAllText(targetPath + "/EDBB_TopSky-Tower.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/EDBB_TopSky-Tower.prf", text.ToString());
                text.Clear();

                notifyText("success", "Successfully updated (EDWW-EDBB)!", 5);
            }
            else if (selectedurl.Contains("EDXX") == true)
            {
                var text = new StringBuilder();
                var apptext = "\r\nLastSession\tcallsign\t" + callsign + "\r\nLastSession\trealname\t" + realname + "\r\nLastSession\t" +
                    "certificate\t" + cid + "\r\nLastSession\tpassword\t" + passwd + "\r\nLastSession\trating\t" + rating + "\r\nLastSession\t" +
                    "server\t" + server + "\r\nLastSession\ttovatsim\t1";

                text.Append(System.IO.File.ReadAllText(targetPath + "/FIS.prf") + apptext);
                System.IO.File.WriteAllText(targetPath + "/FIS.prf", text.ToString());
                text.Clear();

                notifyText("success", "Successfully updated (EDXX)!", 5);
            }
            else
            {

                string[] allProfiles = Directory.GetFiles(esdir, "*.prf");

                foreach (string profile in allProfiles)
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
            }

            foreach (string s in Directory.EnumerateFiles(esdir + "/" + selectedregion + "/Plugins/", "TopSkyCPDLChoppieCode.txt", SearchOption.AllDirectories))
            {
                System.IO.File.WriteAllText(s, hoppiecode);
            }
            //installedpackages.Add(selectedurl);
            UpdateIni("save", "all");
            //CreateInstalledLabels();
            downloadbtn.Enabled = true;
        }
    }
}
