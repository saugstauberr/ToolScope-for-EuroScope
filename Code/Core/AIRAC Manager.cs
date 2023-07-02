using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolScope_for_EuroScope.Code.Core
{
    public class AIRAC_Manager
    {
        Package_Handler packagehandler = new Package_Handler();
        Notification notification = new Notification();

        public Variables.AIRACUpdate GetAIRACUpdate(Main form, int rows)
        {
            Variables.AIRACUpdate update = new Variables.AIRACUpdate();
            DataGridViewRow row = form.packagesdatagrid.Rows[rows];

            if (row.Cells[6].Value.ToString() == "NOURL")
            {
                update.isUrlFound = false;
                return update;
            }

            update.old_package.country = row.Cells[0].Value.ToString();
            update.old_package.region = row.Cells[1].Value.ToString();
            update.old_package.package = row.Cells[2].Value.ToString();
            update.old_package.airac = row.Cells[3].Value.ToString();
            update.old_package.version = row.Cells[5].Value.ToString();
            update.old_package.released = packagehandler.GetURLInformation(row.Cells[6].Value.ToString()).released;

            Variables.AIRACPackage el = new Variables.AIRACPackage();
            List<string> allurls = new List<string>();

            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = hw.Load("http://files.aero-nav.com/" + update.old_package.country);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (link.Attributes["href"].Value.Contains(".zip"))
                {
                    allurls.Add(link.Attributes["href"].Value);
                }
            }

            foreach (var x in allurls.ToList())
            {
                if (x.Contains(update.old_package.region) != true)
                {
                    allurls.Remove(x);
                }
            }

            foreach (var x in allurls.ToList())
            {
                if (x.Contains(update.old_package.package) != true)
                {
                    allurls.Remove(x);
                }
            }
            var url = string.Join("", allurls.ToList());
            el.airac = packagehandler.GetURLInformation(url).airac;
            DateTime da = DateTime.ParseExact(el.airac, "yyMMdd", new CultureInfo("da-DK"));
            el.airac = da.ToString(@"yy\/MM");
            el.version = packagehandler.GetURLInformation(url).version;
            el.released = packagehandler.GetURLInformation(url).released;
            el.region = packagehandler.GetURLInformation(url).region;
            el.url = url;
            el.country = packagehandler.GetURLInformation(url).country;
            el.package = packagehandler.GetURLInformation(url).package;
            update.new_package = el;


            if (update.old_package.released == update.new_package.released)
            {
                return update;
            }
            else
            {
                update.isUpdateAvailable = true;
                return update;
            }
        }

        public void FeedDataGrid(Main form)
        {
            var packages = new List<Variables.AIRACPackage>();
            Variables.AIRACUpdate update = new Variables.AIRACUpdate();
            string[] packagejsons;
            try
            {
                packagejsons = Directory.GetFiles(form.variables.client_config.general.esdir, "package.json", SearchOption.AllDirectories);
            }
            catch
            {
                return;
            }

            foreach (var pack in packagejsons)
            {
                if (!pack.Contains("ToolScope\\Backup"))
                {
                    try
                    {
                        var package = JsonConvert.DeserializeObject<Variables.AIRACPackage>(File.ReadAllText(pack));
                        if (package.url == null)
                        {
                            package.url = "NOURL";
                        }
                        packages.Add(package);
                    }
                    catch
                    { }
                }
            }
            form.packagesdatagrid.DataSource = packages;

            foreach (DataGridViewRow x in form.packagesdatagrid.Rows)
            {
                update = GetAIRACUpdate(form, x.Index);
                if (update.isUpdateAvailable == true)
                {
                    x.DefaultCellStyle.BackColor = Color.FromArgb(255, 105, 103, 68);
                    x.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 122, 120, 80);
                    x.Cells[5].Value = update.old_package.version + " -> " + "V" + update.new_package.version;
                    x.Cells[3].Value = update.old_package.airac + " -> " + update.new_package.airac;
                    DateTime dr_o = DateTime.ParseExact(update.old_package.released, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
                    update.old_package.released = dr_o.ToString("dd.MM.yy");
                    DateTime dr = DateTime.ParseExact(update.new_package.released, "yyyyMMddHHmms", CultureInfo.InvariantCulture);
                    update.new_package.released = dr.ToString("dd.MM.yy");
                    x.Cells[4].Value = update.old_package.released + " -> " + update.new_package.released;
                    notification.Warning(form, "AIRAC Updates available!", 7000);
                }
                else if (update.isUrlFound == false)
                {
                    x.DefaultCellStyle.BackColor = Color.FromArgb(255, 94, 62, 62);
                    x.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 112, 73, 73);
                    notification.Warning(form, "AIRAC Updates available!", 7000);
                }
            }
        }
    }
}
