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
using ToolScope_for_EuroScope.Properties;
using System.Windows.Controls;
using static System.Net.WebRequestMethods;

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
                    Directory.Delete(ReadConfig("esdir") + "/ToolScope/data");
                }
                catch
                {
                }
                ExtractZip();

                // Running selected settings
                if(insertcredentials.Checked == true)
                {
                    ReplaceProfiles();
                }

                if(insertsettings.Checked == true)
                {
                    CopySettings();
                }

                if(runpsscript.Checked == true)
                {
                    try
                    {
                        RunPowerShellScript();
                    } catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("PowerShell Script Error! \n" + ex.ToString() + "\n\nThis is not a ToolScope program error!");
                    }
                }
            });
        }
        #endregion

        public void CreateBackup(string pathinesdir)
        {
            var sourcePath = ReadConfig("esdir") + pathinesdir;
            var targetPath = ReadConfig("esdir") + "/ToolScope/Backup/";

            try
            {
                Directory.Delete(ReadConfig("esdir") + "/ToolScope/Backup", true);
            } catch
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

        public void ExtractZip()
        {
            var sourcePath = ReadConfig("esdir") + "/ToolScope/data";
            var targetPath = ReadConfig("esdir");

            try
            {
                Directory.Delete(ReadConfig("esdir") + "/ToolScope/data", true);
            }
            catch
            {

            }

            ZipFile.ExtractToDirectory(ReadConfig("esdir") + "/ToolScope/data.zip", ReadConfig("esdir") + "/ToolScope/data");
            System.IO.File.Delete(ReadConfig("esdir") + "/ToolScope/data.zip");

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

        public void ReplaceProfiles()
        {
            // Inserting the data into the .prf-Files

            var apptext = "\r\nLastSession\tcallsign\t" + ReadConfig("callsign") + "\r\nLastSession\trealname\t" + ReadConfig("realname") +
                    "\r\nLastSession\t" + "certificate\t" + ReadConfig("cid") + "\r\nLastSession\tpassword\t" +
                    ConvertPassword("decrypt", ReadConfig("passwd")) + "\r\nLastSession\trating\t" + ReadConfig("rating") +
                    "\r\nLastSession\t" + "server\t" + ReadConfig("server") + "\r\nLastSession\ttovatsim\t1";
           string[] allProfiles = Directory.GetFiles(ReadConfig("esdir"), "*.prf");

           foreach (string profile in allProfiles)
           {
                    var text = new StringBuilder();

                    text.Append(System.IO.File.ReadAllText(profile) + apptext);
                    text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + ReadConfig("cid"));
                    System.IO.File.WriteAllText(profile, text.ToString());
                    text.Clear();
           }

           try
            {
                foreach (string s in Directory.EnumerateFiles(ReadConfig("esdir") + "/" + selectedregion + "/Plugins/", "TopSkyCPDLChoppieCode.txt", SearchOption.AllDirectories))
                {
                    System.IO.File.WriteAllText(s, ReadConfig("hoppiecode"));
                }
            } catch
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

        public void CopySettings()
        {
            var allowedExtensions = new[] { "Screen.txt", "SCREEN.txt", "General.txt", "GENERAL.txt", "Settings.txt", "SETTINGS.txt", "DepartureList.txt" };

            try
            {
                var files = Directory
                .GetFiles(ReadConfig("esdir") + "/ToolScope/Backup/" + regionbox.Text + "/Settings", "*", SearchOption.AllDirectories).ToList();


                foreach (string file in files)
                {
                    if (allowedExtensions.Contains(Path.GetFileName(file)))
                    {
                        System.IO.File.Copy(file, file.Replace("/ToolScope/Backup/", "/"), true);
                    }
                }

            } catch
            {

            }
        }
    }
}
