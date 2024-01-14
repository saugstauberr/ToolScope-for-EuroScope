using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope.WPF.Models.Config
{
    class UserConfig
    {
        public string cid = "";
        public string password = "";
        public string callsign = "";

        public string country = "";
        public string region = "";
        public string package = "";

        public UserConfig(string cid, string password, string callsign, string country, string region, string package)
        {
            this.cid = cid;
            this.password = password;
            this.callsign = callsign;
            this.country = country;
            this.region = region;
            this.package = package;
        }
    }
}
