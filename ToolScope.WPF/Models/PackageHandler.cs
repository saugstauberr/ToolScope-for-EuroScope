using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToolScope.WPF.Models;

public static class PackageHandler
{
    private const string PackageDescriptionFileName = "package.tslist";

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
    
    public static async Task<bool> Update(PackageClass package, bool keepExisting = false)
    {
        var destinationPath = GetPackagePath(package);
        var availablePackages = HttpHandler.GetPackagesFromCountry(package.Country);
        
        foreach (var availablePackage in availablePackages.ToList())
        {
            if (availablePackage.Region != package.Region)
            {
                availablePackages.Remove(availablePackage);
                continue;
            }
        }

        Console.WriteLine(availablePackages.FirstOrDefault(p => p.Variant.Contains("Update"))?.DownloadUrl);


        /*
         * if (Directory.Exists(destinationPath) && keepExisting)
        {
            return await Install(package);
        }

        Directory.Delete(destinationPath, true);
        return await Install(package);
         */
        
        return true;
    }

    public static void Remove(PackageClass package)
    {
        Directory.Delete(GetPackagePath(package), true);
    }

    public static ObservableCollection<PackageClass> GetInstalled()
    {
        var installedPackages = new ObservableCollection<PackageClass>();
        
        var directories = Directory.GetDirectories(ConfigHandler.Get("EuroScopeFolder") + "/Packages/");
        
        foreach (var directory in directories)
        {
            var packageDescriptionFile = directory + "/" + PackageDescriptionFileName;
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
        var packageDescriptionFile = destinationPath + "/" + PackageDescriptionFileName;
        System.IO.File.Create(packageDescriptionFile).Close();
        System.IO.File.WriteAllText(packageDescriptionFile, packageDescription);
    }
}