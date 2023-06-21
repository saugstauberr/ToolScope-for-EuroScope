using HtmlAgilityPack;
using Ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolScope_for_EuroScope
{
    public partial class Main
    {
        private void GrabDownloadUrls()
        {
            CountryNames database = new CountryNames();
            var config = new IniFile("config.ini");
            allpackages.Clear();

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com/" + database.GetCountryIcao(countrybox.Text));
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (link.Attributes["href"].Value.Contains(".zip"))
                {
                    allpackages.Add(link.Attributes["href"].Value);
                }
            }
        }

        public string GetURLInformation(string link, string type)
        {
            string regionName = "0";
            string packageName = "0";
            string release = "0";
            string airac = "0";
            string version = "0";

            regionName = link.Substring(link.IndexOf("nav.com/") + 8);
            string regionName2 = regionName.Substring(0, regionName.IndexOf("/"));

            packageName = regionName.Substring(regionName.IndexOf("/") + 1);
            string packageName2 = packageName.Substring(0, packageName.IndexOf("_2"));

            release = packageName.Substring(packageName.IndexOf("_2") + 1);
            string release2 = release.Substring(0, release.IndexOf("-"));

            airac = release.Substring(15);
            string airac2 = airac.Substring(0, airac.IndexOf("-"));

            version = airac.Substring(7);
            string version2 = version.Substring(0, version.IndexOf(".zip"));

            switch (type)
            {
                case "region":
                    return regionName2;
                case "package":
                    return packageName2;
                case "release":
                    return release2;
                case "airac":
                    return airac2;
                case "version":
                    return version2;
                default:
                    return "ERROR";
            }
        }

        public void GetCountries()
        {
            CountryNames database = new CountryNames();
            var config = new IniFile("config.ini");
            countries = config.Read("countries", "Server").Split(',').ToList();
            var countries2 = config.Read("countries2", "Server").Split(',').ToList();
            countries.AddRange(countries2);
            foreach (string country in countries)
            {
                try
                {
                        countrybox.Items.Add(country);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            GrabDownloadUrls();
            getRegions();
        }

        public void getRegions()
        {
            regionbox.Items.Clear();
            regions.Clear();

            foreach (string link in allpackages)
            {
                string regionName2 = GetURLInformation(link, "region");

                if (!regions.Contains(regionName2))
                {
                    regionbox.Items.Add(GetURLInformation(link, "region"));
                }

                regions.Add(regionName2);
            }
        }

        public void addPackageItems(string filter)
        {
            packagebox.Items.Clear();

            foreach (string link in allpackages)
            {
                if (link.Contains(filter) == true)
                {
                    packagebox.Items.Add(GetURLInformation(link, "package"));
                }
            }
        }
    }
}
