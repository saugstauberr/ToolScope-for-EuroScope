using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace ToolScope.WPF.Models
{
    static class PackageLister
    {
        private static string serverConfig = "https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/server.json";
        private static List<Package> packageList = new List<Package>();

        public static Package GetSelectedPackage(string country, string region, string package)
        {
            foreach (var pack in packageList)
            {
                if (pack.region == region && pack.package == package)
                {
                    return pack;
                }
            }

            return new Package();
        }

        public static string[] GetPackages(string region)
        {
            List<string> packages = new List<string>();

            foreach(var package in packageList)
            {
                if(package.region == region)
                {
                    packages.Add(package.package);
                }
            }

            return packages.ToArray();
        }

        public static string[] GetRegions(string country)
        {
            var packagesRaw = GetPackagesFromWeb(country);
            List<string> regions = new List<string>();

            foreach(var package in packagesRaw)
            {
                Package tempPackage = PackageDecoder.CreatePackageFromURL(package);
                packageList.Add(tempPackage);
                if(!regions.Contains(tempPackage.region))
                {
                    regions.Add(tempPackage.region);
                }
            }

            return regions.ToArray();
        }

        public static string[] GetCountriesFromServer()
        {
            ServerConfig config = new ServerConfig();

            using (HttpClient client = new HttpClient())
            {
                var webResponse = client.GetStringAsync("http://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/server.json").Result;
                config = JsonConvert.DeserializeObject<ServerConfig>(webResponse);
            }


            return config.countries;
        }
        
        public static string[] GetPackagesFromWeb(string country)
        {
            var packages = new List<string>();

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com/" + country);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (link.Attributes["href"].Value.Contains(".zip"))
                {
                    packages.Add(link.Attributes["href"].Value);
                }
            }

            return packages.ToArray();
        }
    }
}
