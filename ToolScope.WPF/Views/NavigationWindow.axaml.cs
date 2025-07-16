using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ToolScope.WPF.ViewModels;

namespace ToolScope.WPF.Views;

public partial class NavigationWindow : UserControl
{
    public NavigationWindow()
    {
        InitializeComponent();
        DataContext = new NavigationWindowViewModel();
    }
}