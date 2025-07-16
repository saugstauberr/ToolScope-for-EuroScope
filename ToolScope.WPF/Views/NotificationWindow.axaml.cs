using System;
using Avalonia.Controls;
using ToolScope.WPF.ViewModels;

namespace ToolScope.WPF.Views;

public partial class NotificationWindow : Window
{
    public NotificationWindow()
    {
        InitializeComponent();
        DataContext = new NotificationWindowViewModel();

    }
    
    public NotificationWindow(string title, string message)
    {
        InitializeComponent();
        DataContext = new NotificationWindowViewModel();
        this.FindControl<TextBlock>("WindowTitle")!.Text = title;
        this.FindControl<TextBlock>("WindowText")!.Text = message;
    }
}