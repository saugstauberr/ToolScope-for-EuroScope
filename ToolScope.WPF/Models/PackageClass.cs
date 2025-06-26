namespace ToolScope.WPF.Models;

public class PackageClass
{
    // This class represents a package with various properties such as country, region, variant, airac, release date, version, and URL.
    public string Country { get; set; }
    public string Region { get; set; }
    public string Variant { get; set; }
    public string Airac { get; set; }
    public string ReleaseDate { get; set; }
    public string Version { get; set; }
    public string Url { get; set; }
    
    public PackageClass(string country, string region, string variant = "", string airac = "", string releaseDate = "", string version = "", string url = "")
    {
        Country = country;
        Region = region;
        Variant = variant;
        Airac = airac;
        ReleaseDate = releaseDate;
        Version = version;
        Url = url;
    }
}