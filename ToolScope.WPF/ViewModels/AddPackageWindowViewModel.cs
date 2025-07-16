using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using ToolScope.WPF.Models;

namespace ToolScope.WPF.ViewModels;

public partial class AddPackageWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string[] _countries = HttpHandler.GetCountryArrayFromWeb().Result;

    
    private string _selectedCountry = ConfigHandler.Get("SelectedCountry");

    public string SelectedCountry
    {
        get => _selectedCountry;
        set
        {
            SetProperty(ref _selectedCountry, value);
            ConfigHandler.Set("SelectedCountry", value);
            UpdatePackagesList();
        }
    }

    [ObservableProperty] 
    private ObservableCollection<string> _packagesListBox = [];
    
    private List<PackageClass> _packages = new();

    private int? _selectedPackageIndex;
    public int? SelectedPackageIndex
    {
        get => _selectedPackageIndex;
        set
        {
            SetProperty(ref _selectedPackageIndex, value);
            IsInstallButtonEnabled = (!String.IsNullOrEmpty(value.ToString()));
        }
    }
    
    [ObservableProperty]
    private bool _isInstallButtonEnabled = true;
    
    
    public AddPackageWindowViewModel()
    {
        UpdatePackagesList();
    }
    
    public async void InstallPackage()
    {
        var installPackage = _packages[SelectedPackageIndex!.Value];
        
        MessageBox.Show("Package is being downloaded. Please wait...", "Downloading Package...");
        IsInstallButtonEnabled = false;
        await PackageHandler.Install(installPackage);
        IsInstallButtonEnabled = true;
    }

    private void UpdatePackagesList()
    {
        PackagesListBox.Clear();
        IsInstallButtonEnabled = false;
        
        _packages = HttpHandler.GetPackagesFromCountry(SelectedCountry);

        for (int i = 0; i < _packages.Count; i++)
        {
            if (_packages[i].Variant.Contains("Update"))
            {
                _packages.RemoveAt(i);
            }

            try
            {
                _packages[i].ReleaseDate = DateTime.ParseExact(_packages[i].ReleaseDate, "yyyyMMddHHmms", CultureInfo.InvariantCulture).ToString("dd.MM.yyyy");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        foreach (var package in _packages)
        {
            PackagesListBox.Add(package.Region + " -> " + package.Variant + " -> " +  package.Airac);
        }
        
    }
    
}