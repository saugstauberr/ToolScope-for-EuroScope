using System;
using Tmds.DBus.Protocol;
using ToolScope.WPF.Models.Web;

namespace ToolScope.WPF.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string CurrentTab { get; set; } = "Home";
    
    public void ChangeTab(string tabName)
    {
        // Logic to change the tab in the main window
        // This could involve updating a property that the view binds to
        // For example, you might have a property called CurrentTab
        // and set it to the name of the tab you want to switch to.
        
        Console.WriteLine(tabName);
    }

    public void LoadWebData()
    {
        HTTPHandler httpHandler = new HTTPHandler();
        foreach (var country in httpHandler.GetCountryArrayFromWeb())
        {
            Console.WriteLine(country);
        }
    }
}