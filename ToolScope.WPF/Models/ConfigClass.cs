namespace ToolScope.WPF.Models;

public class ConfigClass
{
    // This class represents the configuration settings for the application.
    public string? RealName { get; set; }
    public string? Cid { get; set; }
    public string? Password { get; set; }
    public string? CallSign { get; set; }
    public string? HoppieCode { get; set; }
    public string? EuroScopeFolder { get; set; } = "ToolScope";
    public string? SelectedCountry { get; set; }
    public string? SelectedPackage { get; set; }
    public bool? IsFirstRun { get; set; }
}