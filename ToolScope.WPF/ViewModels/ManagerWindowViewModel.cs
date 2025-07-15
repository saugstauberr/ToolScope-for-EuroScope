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
using ToolScope.WPF.Models.Web;
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

    public async void OpenAddPackageWindow()
    {
        if (ConfigHandler.Get("EuroScopeFolder") == "")
        {
            var box = MessageBoxManager
                .GetMessageBoxStandard("Warning", "Please set a folder for new packages first!");
            var result = await box.ShowAsync();
            return;
        }
        
        var window = new Window
        {
            Title = "ToolScope - Adding new package",
            Content = new AddPackageWindow()
        };
        window.Show();
    }
}