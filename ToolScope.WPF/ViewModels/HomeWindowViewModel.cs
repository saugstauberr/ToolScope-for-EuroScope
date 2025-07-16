using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ToolScope.WPF.Models;

namespace ToolScope.WPF.ViewModels;

public partial class HomeWindowViewModel : ViewModelBase
{
    private readonly ObservableCollection<PackageClass> _installedPackagesObj = PackageHandler.GetInstalled();

    public ObservableCollection<string> InstalledPackages => UpdateInstalledPackages();

    private ObservableCollection<string> UpdateInstalledPackages()
    {
        var packageNames = new ObservableCollection<string>();
        foreach (var package in _installedPackagesObj)
        {
            packageNames.Add(package.Country + " - " + package.Region + " - " + package.Variant);
        }
        return packageNames;
    }
}