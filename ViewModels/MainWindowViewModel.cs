using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToolScope.WPF;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    public int width = 935;

    [ObservableProperty]
    public int height = 486;

    [ObservableProperty]
    public int currentTab = 0;

    [ObservableProperty]
    public string packageAIRAC = "23/06";

    [ObservableProperty]
    public string packageReleased = "16.06.2023";

    [ObservableProperty]
    public string packageVersion = "V1";

    [ObservableProperty]
    public string[] countryList = new string[] { "EDXX", "EHXX" };


    [RelayCommand]
    public void ChangeTab(object tab)
    {
        CurrentTab = int.Parse(tab.ToString()!);
    }
}
