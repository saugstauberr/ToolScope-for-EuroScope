using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ToolScope.WPF.ViewModels;

namespace ToolScope.WPF.Views;

public partial class AddPackageWindow : UserControl
{
    public AddPackageWindow()
    {
        InitializeComponent();
        DataContext = new AddPackageWindowViewModel();
        
    }
}