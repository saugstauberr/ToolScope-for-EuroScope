using System;
using Avalonia.Controls;
using ToolScope.WPF.ViewModels;

namespace ToolScope.WPF.Views;

public partial class MainWindow : Window
{
    public MainWindow(UserControl userControl, string windowTitle = "null")
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

        if (windowTitle == "null")
        {
            this.FindControl<Label>("WindowTitle")!.IsVisible = false;
            this.FindControl<Grid>("WindowGrid")!.RowDefinitions = RowDefinitions.Parse("40, *");
        }
        else
        {
            this.FindControl<Label>("WindowTitle")!.Content = windowTitle;
            this.Title = windowTitle;
        }
        this.FindControl<ContentControl>("Content")!.Content = userControl;
    }
}