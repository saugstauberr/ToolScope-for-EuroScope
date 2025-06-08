using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;
using Tmds.DBus.Protocol;
using ToolScope.WPF.Models.Web;

namespace ToolScope.WPF.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private string _currentTab = "Home";

    public string CurrentTab
    {
        get => _currentTab;
        set => this.RaiseAndSetIfChanged(ref _currentTab, TabIndexToString(value));
    }
    
    private string _currentWindowState = "Normal";
    
    public string CurrentWindowState
    {
        get => _currentWindowState;
        set => this.RaiseAndSetIfChanged(ref _currentWindowState, value);
    }

    private string _currentWindowStateIcon = "Expand";
    
    public string CurrentWindowStateIcon
    {
        get => _currentWindowStateIcon;
        set => this.RaiseAndSetIfChanged(ref _currentWindowStateIcon, value);
    }
    
    private string TabIndexToString(string index)
    {
        return index switch
        {
            "0" => "Home",
            "1" => "Manager",
            "2" => "Settings",
            _ => throw new ArgumentOutOfRangeException(nameof(index), "Invalid tab index")
        };
    }
    
    public void MinimizeWindow(object obj)
    {
        if (obj is Window window) { window.Hide();}
    }
    
    public void ToggleWindowState()
    {
        CurrentWindowStateIcon = CurrentWindowStateIcon == "Expand" ? "Compress" : "Expand";
        CurrentWindowState = CurrentWindowState == "Maximize" ? "Normal" : "Maximize";
        
    }

    public void CloseWindow(object obj)
    {
        if (obj is Window window) { window.Close();}
    }
}