using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;
using Tmds.DBus.Protocol;
using ToolScope.WPF.Models;
using ToolScope.WPF.Views;

namespace ToolScope.WPF.ViewModels;

public partial class ManagerWindowViewModel : ViewModelBase
{
    
    [ObservableProperty]
    private ObservableCollection<PackageClass> _installedPackages = PackageHandler.GetInstalled();
    
    private int _selectedPackageIndex = -1;
    
    public int SelectedPackageIndex
    {
        get => _selectedPackageIndex;
        set
        {
            SetProperty(ref _selectedPackageIndex, value);
            IsPackageSelected = (value >= 0);
        }
    }

    [ObservableProperty] private bool _isPackageSelected = false;

    

    public async void OpenAddPackageWindow()
    {
        if (ConfigHandler.Get("EuroScopeFolder") == "")
        {
            MessageBox.Show("Please set a folder for new packages first!", "Warning!");
            return;
        }

        var window = new MainWindow(new AddPackageWindow(), "Install new package");
        await window.ShowDialog((Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow);
        InstalledPackages = PackageHandler.GetInstalled();
    }

    public async void UpdateSelectedPackage()
    {
        PackageHandler.Update(InstalledPackages[SelectedPackageIndex]);
        InstalledPackages = PackageHandler.GetInstalled();
    }
    
    public void RemoveSelectedPackage()
    {
        PackageHandler.Remove(InstalledPackages[SelectedPackageIndex]);
        InstalledPackages = PackageHandler.GetInstalled();
        MessageBox.Show("Package removed successfully!", "Package deleted!");
    }
}