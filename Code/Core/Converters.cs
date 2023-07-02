using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolScope_for_EuroScope.Code.Core
{
    internal class Converters
    {
        public string ConvertPassword(string task, string value)
        {
            if (task == "encrypt")
            {
                return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(value));
            }
            else
            {
                return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(value));
            }
        }

        public string RatingConvert(string task, string data)
        {
            if (task == "write")
            {
                switch (data)
                {
                    case "S1 - Tower Trainee":
                        return "1";
                    case "S2 - Tower Controller":
                        return "2";
                    case "S3 - Terminal Controller":
                        return "3";
                    case "C1 - Enroute Controller":
                        return "4";
                    case "C3 - Senior Controller":
                        return "5";
                    default:
                        return null;
                }
            }
            else
            {
                switch (data)
                {
                    case "1":
                        return "S1 - Tower Trainee";
                    case "2":
                        return "S2 - Tower Controller";
                    case "3":
                        return "S3 - Terminal Controller";
                    case "4":
                        return "C1 - Enroute Controller";
                    case "5":
                        return "C3 - Senior Controller";
                    default:
                        return "Rating not found";
                }
            }
        }
    }
}
