using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Utility
{
    public class Utilities
    {
        public static DateTime ConvertToDatetime(string date, string format)
        {
            return DateTime.ParseExact(date, format, CultureInfo.CurrentCulture);
        }
    }
}
