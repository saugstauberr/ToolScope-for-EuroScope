using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using ToolScope.WPF.Models;

namespace ToolScope.WPF.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty] private string _version = "2.0.0-beta.1";
    
}