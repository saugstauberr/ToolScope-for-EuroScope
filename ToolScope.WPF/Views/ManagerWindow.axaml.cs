using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ToolScope.WPF.ViewModels;

namespace ToolScope.WPF.Views;

public partial class ManagerWindow : UserControl
{
    public ManagerWindow()
    {
        InitializeComponent();
        DataContext = new ManagerWindowViewModel();
        
    }
}