using System.Threading.Tasks;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using Tmds.DBus.Protocol;
using ToolScope.WPF.Views;

namespace ToolScope.WPF.Models;

public static class MessageBox
{
    // Custom implementation of MsBox.Avalonia to be the same as in standard WPF
    // Usage: MessageBox.Show() or, if Result is needed, MessageBox.ShowAsync()
    /*public static async Task<ButtonResult> ShowAsync(string text, string title = "ToolScope", ButtonEnum buttonEnum = ButtonEnum.Ok)
    {
        var box = MessageBoxManager
            .GetMessageBoxStandard(title, text, buttonEnum);
        var result = await box.ShowAsync();
        return result;
    }

    public static void Show(string text, string title = "ToolScope", ButtonEnum buttonEnum = ButtonEnum.Ok)
    {
        var box = MessageBoxManager
            .GetMessageBoxStandard(title, text, buttonEnum);
        box.ShowAsync();
    }*/
    public static void Show(string text, string title = "ToolScope", ButtonEnum buttonEnum = ButtonEnum.Ok)
    {
        var box = new NotificationWindow(title, text);
        box.Show();
    }
}