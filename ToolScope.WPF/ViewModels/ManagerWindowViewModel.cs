using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using ToolScope.WPF.Models;
using ToolScope.WPF.Models.Web;

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
}