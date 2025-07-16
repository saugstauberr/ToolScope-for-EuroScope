using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToolScope.WPF.Models;

public static class PackageHandler
{
    private const string packageDescriptionFileName = "package.tslist";

    public static string GetPackagePath(PackageClass package)
    {
        var packagePath = ConfigHandler.Get("EuroScopeFolder") + "/Packages/" + package.Country + "-" +
                              package.Region + "-" + package.Variant + "/";
        return packagePath;
    }
    
    public static async Task<bool> Install(PackageClass package)
    {
        var destinationPath = GetPackagePath(package);
        var installPath = await HttpHandler.DownloadPackage(package.DownloadUrl);
        System.IO.Compression.ZipFile.ExtractToDirectory(installPath, destinationPath);
        System.IO.File.Delete(installPath);
        AddPackageDescription(destinationPath, package);
        return true;
    }

    public static ObservableCollection<PackageClass> GetInstalled()
    {
        var installedPackages = new ObservableCollection<PackageClass>();
        
        var directories = Directory.GetDirectories(ConfigHandler.Get("EuroScopeFolder") + "/Packages/");
        
        foreach (var directory in directories)
        {
            var packageDescriptionFile = directory + "/" + packageDescriptionFileName;
            if (File.Exists(packageDescriptionFile))
            {
                var packageDescription = File.ReadAllText(packageDescriptionFile);
                var package = JsonConvert.DeserializeObject<PackageClass>(packageDescription);
                if (package != null)
                {
                    installedPackages.Add(package);
                }
            }
        }
        
        return installedPackages;
    }

    private static void AddPackageDescription(string destinationPath, PackageClass package)
    {
        var packageDescription = JsonConvert.SerializeObject(package);
        var packageDescriptionFile = destinationPath + "/" + packageDescriptionFileName;
        System.IO.File.Create(packageDescriptionFile).Close();
        System.IO.File.WriteAllText(packageDescriptionFile, packageDescription);
    }
}