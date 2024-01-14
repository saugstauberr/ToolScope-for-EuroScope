using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ToolScope.WPF.Models;
using ToolScope.WPF.Models.Config;

namespace ToolScope.WPF;

public partial class MainWindowViewModel : ObservableObject
{

    [ObservableProperty]
    public int width = 935;

    [ObservableProperty]
    public int height = 486;

    [ObservableProperty]
    public int currentTab = 0;

    [ObservableProperty]
    public string packageAIRAC = "";

    [ObservableProperty]
    public string packageReleased = "";

    [ObservableProperty]
    public string packageVersion = "";

    [ObservableProperty]
    public string[] countryList = PackageLister.GetCountriesFromServer();

    [ObservableProperty]
    public string selectedCountry = ConfigManager.GetUserConfig().country;

    [ObservableProperty]
    public string[] regionList = { };

    [ObservableProperty]
    public string selectedRegion = ConfigManager.GetUserConfig().region;

    [ObservableProperty]
    public string[] packageList = { };

    [ObservableProperty]
    public string selectedPackage = ConfigManager.GetUserConfig().package;


    [RelayCommand]
    public void ChangePackage(object package)
    {
        var currentPackage = PackageLister.GetSelectedPackage(selectedCountry, selectedRegion, selectedPackage);
        PackageAIRAC = currentPackage.airac;
        PackageReleased = currentPackage.released;
        PackageVersion = currentPackage.version;
    }

    [RelayCommand]
    public void ChangeCountry(object country)
    {
        RegionList = PackageLister.GetRegions(country.ToString());
    }

    [RelayCommand]
    public void ChangeRegion(object region)
    {
        if (region == null)
        {
            PackageList = new string[] { };
            return;
        }

        PackageList = PackageLister.GetPackages(region.ToString());
    }

    [RelayCommand]
    public void ChangeTab(object tab)
    {
        CurrentTab = int.Parse(tab.ToString()!);
    }

    [RelayCommand]
    public void Install()
    {
        var userConfig = new UserConfig("", "", "", selectedCountry, selectedRegion, selectedPackage);
        ConfigManager.SaveConfig(userConfig);
    }
}
