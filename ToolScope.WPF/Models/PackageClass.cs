namespace ToolScope.WPF.Models;

public class PackageClass(
    string country,
    string region,
    string variant = "",
    string airac = "",
    string releaseDate = "",
    string version = "",
    string downloadUrl = "")
{
    // This class represents a package with various properties such as country, region, variant, airac, release date, version, and URL.
    public string Country { get; set; } = country;
    public string Region { get; set; } = region;
    public string Variant { get; set; } = variant;
    public string Airac { get; set; } = airac;
    public string ReleaseDate { get; set; } = releaseDate;
    public string Version { get; set; } = version;
    public string DownloadUrl { get; set; } = downloadUrl;
}