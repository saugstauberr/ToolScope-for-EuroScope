using System;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ToolScope.WPF.Models.Web;

public class HTTPHandler
{
    public async Task<string[]> GetCountryArrayFromWeb()
    {
        string[] countries = [];
        
        HtmlWeb hw = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com");
        HtmlNode table = doc.DocumentNode.SelectSingleNode("//table[1]");
        foreach (var row in table.SelectNodes("//tr"))
        {
            try
            {
                string countryName = row.SelectSingleNode("td[2]").InnerText.Trim();
                countries = countries.Append(countryName).ToArray();
            } catch (Exception ex)
            {
                // Suppress any exceptions that occur while processing the row
            }
        }
        
        //return countries;
        return countries;
    }
}