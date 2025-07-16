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
}