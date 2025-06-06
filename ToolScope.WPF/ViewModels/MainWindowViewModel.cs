using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;
using ToolScope.WPF.Models.Web;

namespace ToolScope.WPF.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler? PropertyChanged;

    protected new virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _currentTab = "0";

    public string CurrentTab
    {
        get => _currentTab;
        set
        {
            _currentTab = value;
            OnPropertyChanged();
        }
    }

    public void ChangeTab(string tabIndex)
    {
        // Logic to change the tab in the main window
        // This could involve updating a property that the view binds to
        // For example, you might have a property called CurrentTab
        // and set it to the name of the tab you want to switch to.
        
        CurrentTab = tabIndex;
        Console.WriteLine($"Tab changed to: {CurrentTab}");
    }
}