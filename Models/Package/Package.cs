using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope.WPF.Models
{
    class Package
    {
        public string? country { get; set; }
        public string? region { get; set; }
        public string? package { get; set; }
        public string? airac { get; set; }
        public string? released { get; set; }
        public string? version { get; set; }
        public string? url { get; set; }

        public Package()
        {

        }

        public Package(string country, string region, string package, string airac, string released, string version, string url)
        {
            this.country = country;
            this.region = region;
            this.package = package;
            this.airac = airac;
            this.released = released;
            this.version = version;
            this.url = url;
        }
    }
}
