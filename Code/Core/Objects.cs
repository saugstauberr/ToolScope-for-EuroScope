using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope_for_EuroScope.Code.Core
{
    public class Objects
    {
        public class AIRACUpdate
        {
            public bool update = false;
            public bool no_url = false;
            public AIRACPackage old_package = new AIRACPackage();
            public AIRACPackage new_package = new AIRACPackage();
        }
        public class ServerConfig
        {
            public List<string> countries { get; set; }
            public string motd { get; set; }
        }

        public class ClientRoot
        {
            public ClientConfig clientconfig = new ClientConfig();
            public List<ClientPackage> installedpackages = new List<ClientPackage>();
        }

        public class ClientPackage
        {
            public string jsonpath = "";
        }

        public class AIRACPackage
        {
            public string country { get; set; }
            public string region { get; set; }
            public string package { get; set; }
            public string airac { get; set; }
            public string released { get; set; }
            public string version { get; set; }
            public string url { get; set; }
        }

        public class ClientConfig
        {
            public string cid = "";
            public string passwd = "";
            public string callsign = "";
            public string realname = "";
            public string hoppiecode = "";
            public string rating = "";
            public string esdir = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EuroScope");
            public List<string> allowedExtensions { get; set; }


            public string server = "AUTOMATIC";
            public string country = "";
            public bool insertcredentials = true;
            public bool insertatisairport = true;
            public bool insertplugins = true;
            public bool runpowershell = false;
            public int codezoom = 0;
        }
    }
}
