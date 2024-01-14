using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolScope.WPF.Models.Config;

namespace ToolScope.WPF.Models
{
    static class ConfigManager
    {
        static UserConfig userConfig = ReadConfig();

        private static UserConfig ReadConfig()
        {
            if (File.Exists("config.json"))
            {
                return JsonConvert.DeserializeObject<UserConfig>(File.ReadAllText("config.json"));
            }
            UserConfig config = new UserConfig("","","","","","");
            return config;
        }

        public static void SaveConfig(UserConfig config)
        {
            userConfig = config;
            File.WriteAllText("config.json", JsonConvert.SerializeObject(userConfig, Formatting.Indented));
        }

        public static UserConfig GetUserConfig()
        {
            return userConfig;
        }
    }
}
