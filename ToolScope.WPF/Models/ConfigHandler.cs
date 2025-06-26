using System.IO;
using Newtonsoft.Json;

namespace ToolScope.WPF.Models;

public static class ConfigHandler
{
    private const string ConfigFileFolder = "ToolScope";
    private const string ConfigFileName = ConfigFileFolder + "/" + "config.json";
    private static ConfigClass? _config;

    private static void Initialize()
    {
        // Load the configuration file or settings here
        // Check if the configuration file exists or create it if it doesn't
        if (!Directory.Exists(ConfigFileFolder))
        {
            Directory.CreateDirectory(ConfigFileFolder);
        }
        
        if (!File.Exists(ConfigFileName))
        {
            // Create a new configuration object if the file does not exist
            _config = new ConfigClass();
            Save(); // Save the new config to create the file
        }
        
        _config = JsonConvert.DeserializeObject<ConfigClass>(File.ReadAllText(ConfigFileName)) ?? new ConfigClass();
    }
    
    private static void Save()
    {
        // Save the configuration file or settings to a file
        if (!Directory.Exists(ConfigFileFolder))
        {
            File.Create(ConfigFileFolder).Close();
        }
        File.WriteAllText(ConfigFileName, JsonConvert.SerializeObject(_config, Formatting.Indented));
    }
    
    public static string Get(string key)
    {
        // Get a configuration value by key
        Initialize();

        if (_config == null) return string.Empty;
        
        var property = _config.GetType().GetProperty(key);
        if (property == null) return string.Empty;
        
        var value = property.GetValue(_config);
        return value?.ToString() ?? string.Empty;
    }
    
    public static void Set(string key, string value)
    {
        // First, initialize the configuration
        Initialize();
        
        if (_config == null) return;
        var property = _config.GetType().GetProperty(key);
        if (property == null) return;
        if (property.PropertyType == typeof(string))
        {
            property.SetValue(_config, value);
        }

        // Save the updated configuration
        Save();
    }
}