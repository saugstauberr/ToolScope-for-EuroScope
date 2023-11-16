using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope.WPF;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    public int width = 935;

    [ObservableProperty]
    public int height = 486;
}
