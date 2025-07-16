using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using Tmds.DBus.Protocol;
using ToolScope.WPF.Models.Web;

namespace ToolScope.WPF.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    
    
    [ObservableProperty]
    private string _currentWindowState = "Normal";
    
    [ObservableProperty]
    private string _currentWindowStateIcon = "Expand";
    
    

    public void MinimizeWindow(object obj)
    {
        if (obj is Window window) { window.WindowState = WindowState.Minimized;}
    }

    public void ToggleWindowState()
    {
        CurrentWindowStateIcon = CurrentWindowStateIcon == "Expand" ? "Compress" : "Expand";
        CurrentWindowState = CurrentWindowState == "Maximized" ? "Normal" : "Maximized";
        
    }
    
    public void CloseWindow(object obj)
    {
        if (obj is Window window) { window.Close();}
    }
}