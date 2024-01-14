using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope.WPF.Models
{
    class ServerConfig
    {
        public string[] countries;
        public string motd;

        public ServerConfig()
        {
            countries = new string[] {  };
            motd = "";
        }
    }
}
