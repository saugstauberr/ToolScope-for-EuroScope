using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope_for_EuroScope
{
    internal class CountryNames
    {

        private int _id;
        private string _icao;
        private string _name;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Icao
        {
            get { return _icao; }
            set { _icao = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public static IList<CountryNames> InitList1()
        {
            var list = new List<CountryNames>
        {
            new CountryNames { Id = 1, Icao = "ADRIA", Name = "VATSIM Adria" },
            new CountryNames { Id = 2, Icao = "AFRC", Name = "VATSSA Africa Control Centre" },
            new CountryNames { Id = 2, Icao = "AFRX", Name = "Africa UIR/FSS Control Stations" },
            new CountryNames { Id = 2, Icao = "CZEG", Name = "Edmonton FIR" },
            new CountryNames { Id = 2, Icao = "CZQQ", Name = "VATSSA Africa Control Centre" },
            new CountryNames { Id = 2, Icao = "CZUL", Name = "VATSSA Africa Control Centre" },
            new CountryNames { Id = 2, Icao = "CZVR", Name = "VATSSA Africa Control Centre" },
            new CountryNames { Id = 2, Icao = "CZWG", Name = "VATSSA Africa Control Centre" },
            new CountryNames { Id = 2, Icao = "CZYZ", Name = "VATSSA Africa Control Centre" },
            new CountryNames { Id = 2, Icao = "DGAC", Name = "VATSSA Africa Control Centre" }
        };

            return list;
        }

        public string GetCountryDisplayName(string countryCode)
        {
            IList<CountryNames> database = CountryNames.InitList1();
            string countryName = database.Where(c => c.Icao == countryCode).FirstOrDefault()?.Name;

            if (countryName != null)
            {
                return countryName;
            }
            else
            {
                return countryCode;
            }
        }

        public string GetCountryIcao(string countryDisplayName)
        {
            IList<CountryNames> database = CountryNames.InitList1();
            string countryIcao = database.Where(c => c.Name == countryDisplayName).FirstOrDefault()?.Icao;

            if(countryIcao != null)
            {
                return countryIcao;
            } else
            {
                return countryDisplayName;
            }
            
        }
    }
}
