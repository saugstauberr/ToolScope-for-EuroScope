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
        public string uriserverconfig = "https://raw.githubusercontent.com/saugstauberr/ToolScope-for-EuroScope/master/updates/server.json";
        public string selectedUrlString;
        public string selectedRegionString;


        // Lists
        public List<string> regions = new List<string>();
        public List<string> countries = new List<string>();
        public List<string> allpackages = new List<string>();

        // Booleans
        public bool isFirstrun = false;
        public bool isUpdaterun = false;

        // Objects
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton lastButton = null;
    }
}
