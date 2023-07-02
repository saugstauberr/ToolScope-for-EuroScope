using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace ToolScope_for_EuroScope.Code.Core
{
    internal class Updater
    {
        public bool CreateBackup(string pathinesdir, Variables.ClientRoot config)
        {
            var sourcePath = config.general.esdir + pathinesdir;
            var targetPath = config.general.esdir + "/ToolScope/Backup/";

            Directory.CreateDirectory(config.general.esdir + "/ToolScope");
            Directory.CreateDirectory(config.general.esdir + "/ToolScope/Backup");

            try
            {
                Directory.Delete(config.general.esdir + "/ToolScope/Backup", true);
            }
            catch
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
            return true;
        }

        public bool ExtractZip(Variables.ClientRoot config)
        {
            var sourcePath = config.general.esdir + "/ToolScope/data";
            var targetPath = config.general.esdir;

            try
            {
                Directory.Delete(config.general.esdir + "/ToolScope/data", true);
            }
            catch
            {

            }
                
            ZipFile.ExtractToDirectory(config.general.esdir + "/ToolScope/data.zip", config.general.esdir + "/ToolScope/data");
            System.IO.File.Delete(config.general.esdir + "/ToolScope/data.zip");

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
            return true;
        }

        public bool ReplaceProfiles(Main form)
        {
            // Inserting the data into the .prf-Files

            Variables.ClientConfig config = form.variables.client_config.general;

            Converters converters= new Converters();

            var apptext = "\r\nLastSession\tcallsign\t" + config.callsign + "\r\nLastSession\trealname\t" + config.realname +
                    "\r\nLastSession\t" + "certificate\t" + config.cid + "\r\nLastSession\tpassword\t" +
                    converters.ConvertPassword("decrypt", config.passwd) + "\r\nLastSession\trating\t" + config.rating +
                    "\r\nLastSession\t" + "server\t" + config.server + "\r\nLastSession\ttovatsim\t1";
            string[] allProfiles = Directory.GetFiles(config.esdir, "*.prf");

            foreach (string profile in allProfiles)
            {
                var text = new StringBuilder();

                text.Append(System.IO.File.ReadAllText(profile) + apptext);
                text = text.Replace("TeamSpeakVccs\tTs3NickName\tYOUR ID", "TeamSpeakVccs\tTs3NickName\t" + config.cid);
                System.IO.File.WriteAllText(profile, text.ToString());
                text.Clear();
            }

            try
            {
                foreach (string s in Directory.EnumerateFiles(config.esdir + "/" + form.variables.selectedRegionString + "/Plugins/", "TopSkyCPDLChoppieCode.txt", SearchOption.AllDirectories))
                {
                    System.IO.File.WriteAllText(s, config.hoppiecode);
                }
            }
            catch
            {

            }

            return true;
        }

        public void CopySettings(Variables.ClientRoot config, Bunifu.UI.WinForms.BunifuDropdown region_object)
        {
            var allowedExtensions = config.general.allowedExtensions;

            try
            {
                var files = Directory
                .GetFiles(config.general.esdir + "/ToolScope/Backup/" + region_object.Text + "/Settings", "*", SearchOption.AllDirectories).ToList();


                foreach (string file in files)
                {
                    if (allowedExtensions.Contains(System.IO.Path.GetFileName(file)))
                    {
                        System.IO.File.Copy(file, file.Replace("/ToolScope/Backup/", "/"), true);
                    }
                }

            }
            catch
            {

            }
        }

        public void CreatePackageJSON(string path, Main el)
        {
            Variables.ClientPackage pack = new Variables.ClientPackage();

            Variables.AIRACPackage package = new Variables.AIRACPackage();

            package.package = el.packagebox.Text;
            package.country = el.countrybox.Text;
            package.region = el.regionbox.Text;

            package.airac = el.airactxt.Text;
            package.version = el.versiontxt.Text;
            package.released = el.releasetxt.Text;
            package.url = el.variables.selectedUrlString;

            File.WriteAllText(path + "/package.json", JsonConvert.SerializeObject(package, Formatting.Indented));

            pack.jsonpath = path + "/package.json";
        }
    }
}
