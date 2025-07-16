using System;

namespace ToolScope.WPF.ViewModels;

public partial class NavigationWindowViewModel : ViewModelBase
{
    private string _currentTab = "Home";

    public string CurrentTab
    {
        get => _currentTab;
        set => SetProperty(ref _currentTab,TabIndexToString(value));
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
}