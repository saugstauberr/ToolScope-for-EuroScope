using HtmlAgilityPack;
using System;
using System.Windows;
using System.Windows.Forms;

namespace ToolScope_for_EuroScope.Code.Core
{
    public class Package_Handler
    {
        public void GrabDownloadUrls(Main form)
        {
            form.variables.allpackages.Clear();

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com/" + form.countrybox.Text);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (link.Attributes["href"].Value.Contains(".zip"))
                {
                    form.variables.allpackages.Add(link.Attributes["href"].Value);
                }
            }
        }

        public Variables.AIRACPackage GetURLInformation(string link)
        {
            Variables.AIRACPackage package = new Variables.AIRACPackage();

            var regionName = link.Substring(link.IndexOf("nav.com/") + 8);
            package.region = regionName.Substring(0, regionName.IndexOf("/"));

            var packageName = regionName.Substring(regionName.IndexOf("/") + 1);
            package.package = packageName.Substring(0, packageName.IndexOf("_2"));

            var release = packageName.Substring(packageName.IndexOf("_2") + 1);
            package.released = release.Substring(0, release.IndexOf("-"));

            var airac = release.Substring(15);
            package.airac = airac.Substring(0, airac.IndexOf("-"));

            var version = airac.Substring(7);
            package.version = version.Substring(0, version.IndexOf(".zip"));
            package.url = "";

            return package;
        }

        public void GetCountries(Main form)
        {
            foreach (string country in form.variables.server_config.countries)
            {
                try
                {
                    form.countrybox.Items.Add(country);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }

            }
            GrabDownloadUrls(form);
            getRegions(form);
        }

        public void getRegions(Main form)
        {
            form.regionbox.Items.Clear();
            form.variables.regions.Clear();

            foreach (string link in form.variables.allpackages)
            {
                string regionName2 = GetURLInformation(link).region;

                if (!form.variables.regions.Contains(regionName2))
                {
                    form.regionbox.Items.Add(GetURLInformation(link).region);
                }

                form.variables.regions.Add(regionName2);
            }
        }

        public void addPackageItems(Main form, string filter)
        {
            form.packagebox.Items.Clear();

            foreach (string link in form.variables.allpackages)
            {
                if (link.Contains(filter) == true)
                {
                    form.packagebox.Items.Add(GetURLInformation(link).package);
                }
            }
        }
    }
}
