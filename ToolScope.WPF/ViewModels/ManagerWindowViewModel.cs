using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using ToolScope.WPF.Models;
using ToolScope.WPF.Views;

namespace ToolScope.WPF.ViewModels;

public partial class ManagerWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<PackageClass> _installedPackages;
    

    public ManagerWindowViewModel()
    {
        var people = new List<PackageClass> 
        {
            new PackageClass("EDXX", "EDDM", "Test-Variant")
        };
        InstalledPackages = new ObservableCollection<PackageClass>(people);
    }

    public void OpenAddPackageWindow()
    {
        if (ConfigHandler.Get("EuroScopeFolder") == "")
        {
            MessageBox.Show("Please set a folder for new packages first!", "Warning!");
            return;
        }

        var window = new MainWindow(new AddPackageWindow(), "Install new package");
        window.Show();
    }
}