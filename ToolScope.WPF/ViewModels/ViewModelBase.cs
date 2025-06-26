using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using ToolScope.WPF.Models;
using ToolScope.WPF.Models.Web;

namespace ToolScope.WPF.ViewModels;

public class ViewModelBase : ObservableObject
{
    public async Task LoadWebData()
    {
        HTTPHandler httpHandler = new HTTPHandler();
        foreach (var country in await httpHandler.GetCountryArrayFromWeb())
        {
            Console.WriteLine(country);
        }

        Console.WriteLine(ConfigHandler.Get("RealName"));
    }
}