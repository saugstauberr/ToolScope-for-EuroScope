using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using DynamicData;
using ReactiveUI;
using ToolScope.WPF.Models;
using ToolScope.WPF.Models.Web;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ToolScope.WPF.ViewModels;

// should be ViewModelBase and ObservableObject
public partial class SettingsWindowViewModel : ViewModelBase
{
    // Define the keys for the configuration settings
    // These keys correspond to the properties in the ConfigClass
    private string[] _keyNames = ["RealName", "Cid", "CallSign", "Password", "HoppieCode", "EuroScopeFolder"];
    
    // This array will hold the input values for each key
    // When adding a new input value, ensure it corresponds to the keys defined above
    [ObservableProperty]
    private ObservableCollection<string> _inputValues = new ObservableCollection<string>(new string[100]);


    public SettingsWindowViewModel()
    {
        SetInput();
    }

    private void SetInput()
    {
        // Initialize the input values with existing configuration values
        for (var i = 0; i < _keyNames.Length; i++)
        {
            var key = _keyNames[i];
            InputValues[i] = ConfigHandler.Get(key);
        }
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
        MessageBox.Show("Your configuration has been saved successfully!");
    }

    private async Task<IReadOnlyList<IStorageFolder>> OpenFolderPickerAsync(Window window, FolderPickerOpenOptions options)
    {
        if (window?.StorageProvider is { } storageProvider)
        {
            return await storageProvider.OpenFolderPickerAsync(options);
        }
        return [];
    }
    
    public async Task ChoosePathDialogAsync(Window window)
    {
        var options = new FolderPickerOpenOptions
        {
            Title = "Please select desired package folder",
            AllowMultiple = false,
        };

        var folder = await OpenFolderPickerAsync(window, options);
        
        InputValues[5] = folder[0].TryGetLocalPath() ?? string.Empty;
    }
}