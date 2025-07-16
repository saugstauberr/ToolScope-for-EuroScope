using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ToolScope.WPF.Models;

public static class HttpHandler
{
    private const string baseUrl = "http://files.aero-nav.com/";
    
    public static Task<string[]> GetCountryArrayFromWeb()
    {
        string[] countries = [];
        
        var hw = new HtmlWeb();
        var doc = hw.Load(baseUrl);
        var table = doc.DocumentNode.SelectSingleNode("//table[1]");
        if (table == null) return Task.FromResult(countries);
        foreach (var row in table.SelectNodes("//tr")!)
        {
            try
            {
                string countryName = row.SelectSingleNode("td[2]")!.InnerText.Trim();
                countries = countries.Append(countryName).ToArray();
            }
            catch (Exception ex)
            {
                // Suppress any exceptions that occur while processing the row
            }
        }

        //return countries;
        return Task.FromResult(countries);
    }
    
    private static PackageClass CreatePackageFromString(string country, string value)
    {
        var firstString = value.Substring(value.IndexOf("nav.com/", StringComparison.Ordinal) + 8);
        var regionName = firstString.Substring(0, firstString.IndexOf("/", StringComparison.Ordinal));

        var secondString = firstString.Substring(firstString.IndexOf("/", StringComparison.Ordinal) + 1);
        var packageName = secondString.Substring(0, secondString.IndexOf("_2", StringComparison.Ordinal));
        

        var thirdString = secondString.Substring(secondString.IndexOf("_2", StringComparison.Ordinal) + 1);
        var release = thirdString.Substring(0, thirdString.IndexOf("-", StringComparison.Ordinal));
        
        var fourthString = thirdString.Substring(15);
        var airac = fourthString.Substring(0, fourthString.IndexOf("-", StringComparison.Ordinal));

        var version = fourthString.Substring(7);
        version = version.Substring(0, version.IndexOf(".zip", StringComparison.Ordinal));
        
        var url = value;

        return new PackageClass(
            country: country,
            region: regionName,
            variant: packageName,
            airac: airac,
            releaseDate: release,
            version: version,
            downloadUrl: url);
    }
    
    public static List<PackageClass> GetPackagesFromCountry(string country)
    {
        List<PackageClass> packages = [];
        
        var hw = new HtmlWeb();
        var doc = hw.Load("http://files.aero-nav.com/" + country);
        
        if (doc.DocumentNode.SelectNodes("//a[@href]") == null)
        {
            return packages; // Return empty list if no links found
        }
        try
        {
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]")!)
            {
                if (link.Attributes["href"].Value.Contains(".zip"))
                {
                    packages.Add(CreatePackageFromString(country, link.Attributes["href"].Value));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
        return packages;
    }
}