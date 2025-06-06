using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ToolScope.WPF.ViewModels;

namespace ToolScope.WPF.Views;

public partial class SettingsWindow : UserControl
{
    public SettingsWindow()
    {
        InitializeComponent();
        DataContext = new SettingsWindowViewModel();
        
    }
}