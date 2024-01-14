using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace ToolScope.WPF.Models
{
    static class PackageDecoder
    {
        /***
         * New package link format:
         * https://files.aero-nav.com/EDGG/Full_Package_ 2023 12 28 17 11 53-231301-1.zip
         */

        public static Package CreatePackageFromURL(string url)
        {
            Package package = new Package();

            var regionName = url.Substring(url.IndexOf("nav.com/") + 8);
            package.region = regionName.Substring(0, regionName.IndexOf("/"));

            var packageName = regionName.Substring(regionName.IndexOf("/") + 1);
            package.package = packageName.Substring(0, packageName.IndexOf("_2"));

            var release = packageName.Substring(packageName.IndexOf("_2") + 1);
            package.released = release.Substring(0, release.IndexOf("-"));
            package.released = DateTime.ParseExact(package.released, "yyyyMMddHHmms", CultureInfo.InvariantCulture).ToString("yyyy'/'MM'/'dd");

            var airac = release.Substring(15);
            package.airac = airac.Substring(0, airac.IndexOf("-"));
            package.airac = package.airac.Substring(0, 4) + " / " + package.airac.Substring(4, 2);

            var version = airac.Substring(7);
            package.version = version.Substring(0, version.IndexOf(".zip"));
            package.url = url;

            return package;
        }
    }
}
