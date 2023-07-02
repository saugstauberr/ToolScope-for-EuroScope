using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope_for_EuroScope
{
    internal class CountryNames
    {
        //TODO: useless function "CountryNames Converter"
        private string _icao;
        private string _name;


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
            /*new CountryNames { Icao = "ADRIA", Name = "ADRIA - VATSIM Adria" },
            new CountryNames { Icao = "AFRC", Name = "AFRC - VATSSA Africa Control Centre" },
            new CountryNames { Icao = "AFRX", Name = "AFRX - Africa UIR/FSS Control Stations" },
            new CountryNames { Icao = "CZEG", Name = "CZEG - Edmonton FIR" },
            new CountryNames { Icao = "CZQQ", Name = "CZQQ - Moncton Gander FIR" },
            new CountryNames { Icao = "CZUL", Name = "CZUL - FIR de Montréal" },
            new CountryNames { Icao = "CZVR", Name = "CZVR - Vancouver FIR" },
            new CountryNames { Icao = "CZWG", Name = "CZWG - Winnipeg FIR" },
            new CountryNames { Icao = "CZYZ", Name = "CZYZ - Toronto FIR" },
            new CountryNames { Icao = "DGAC", Name = "DGAC - VATSSA Accra" },
            new CountryNames { Icao = "DNKK", Name = "DNKK - VATSSA Kano" },
            new CountryNames { Icao = "DTTC", Name = "DTTC - Tunis" },
            new CountryNames { Icao = "EBBU", Name = "EBBU - Belux vACC" },
            new CountryNames { Icao = "EDXX", Name = "EDXX - VATSIM Germany" },
            new CountryNames { Icao = "EETT", Name = "EETT - VACC Estonia" },
            new CountryNames { Icao = "EHAA", Name = "EHAA - Dutch VACC" },
            new CountryNames { Icao = "EPWW", Name = "EPWW - Polish VACC" },
            new CountryNames { Icao = "EURO", Name = "EURO - EuroCenter vACC" },
            new CountryNames { Icao = "EVRR", Name = "EVRR - vACC Latvia" },
            new CountryNames { Icao = "EXCXO", Name = "EXCXO - Shanwick & Gander Oceanic" },
            new CountryNames { Icao = "FAXX", Name = "FAXX - VATSSA South Africa" },
            new CountryNames { Icao = "FBGR", Name = "FBGR - VATSSA Gaborone" },
            new CountryNames { Icao = "FCCC", Name = "FCCC - VATSSA Brazzaville" },
            new CountryNames { Icao = "FIMM", Name = "FIMM - VATSSA Mauritius" },
            new CountryNames { Icao = "FLFI", Name = "FLFI - VATSSA Lusaka" },
            new CountryNames { Icao = "FMMM", Name = "FMMM - VATSSA Antananarivo" },
            new CountryNames { Icao = "FNAN", Name = "FNAN - VATSSA Luanda" },
            new CountryNames { Icao = "FQBE", Name = "FQBE - VATSSA Beira" },
            new CountryNames { Icao = "FSSS", Name = "FSSS - VATSSA Seychelles" },
            new CountryNames { Icao = "FTTT", Name = "" },*/
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
