using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DynamicData;
using ReactiveUI;
using ToolScope.WPF.Models;
using ToolScope.WPF.Models.Web;

namespace ToolScope.WPF.ViewModels;

public partial class SettingsWindowViewModel : ViewModelBase
{
    private string[] _keyNames = ["RealName", "Cid", "CallSign", "Password", "HoppieCode", "EuroScopeFolder"];
    private string[] _inputValues = new string [100];

    public SettingsWindowViewModel()
    {
        // Initialize the input values with existing configuration values
        for (var i = 0; i < _keyNames.Length; i++)
        {
            var key = _keyNames[i];
            InputValues[i] = ConfigHandler.Get(key);
        }
    }
    
    public string[] InputValues
    {
        get => _inputValues;
        set => this.RaiseAndSetIfChanged(ref _inputValues, value);
    }

    public void SaveInput()
    {
        for (var i = 0; i < _keyNames.Length; i++)
        {
            var key = _keyNames[i];
            var value = InputValues[i];

            if (string.IsNullOrEmpty(value))
            {
                continue; // Skip empty values
            }

            // Set the configuration value using the ConfigHandler
            ConfigHandler.Set(key, value);
        }
    }
}