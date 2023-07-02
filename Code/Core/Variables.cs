using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope_for_EuroScope.Code.Core
{
    public class Variables
    {
        // Strings
        public string uriToServerConfig = "https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/server.json";
        public string selectedUrlString;
        public string selectedRegionString;


        // Lists
        public List<string> regions = new List<string>();
        public List<string> allpackages = new List<string>();

        // Booleans
        public bool isFirstrun = false;
        public bool isUpdaterun = false;

        // Objects
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton lastButton = null;

        public ClientRoot client_config = new ClientRoot();
        public ServerConfig server_config = new ServerConfig();

        public class AIRACUpdate
        {
            public bool isUpdateAvailable = false;
            public bool isUrlFound = true;
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
            public ClientConfig general = new ClientConfig();
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
            public bool isInsertCredentials = true;
            public bool isInsertAtisAirport = true;
            public bool isInsertPlugins = true;
            public bool isRunPowershell = false;
            public int codezoom = 0;
        }
    }
}
