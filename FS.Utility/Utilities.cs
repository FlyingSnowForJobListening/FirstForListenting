using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FS.Utility
{
    public class Utilities
    {
        public static DateTime ConvertToDatetime(string date, string format)
        {
            return DateTime.ParseExact(date, format, CultureInfo.CurrentCulture);
        }
        //Json Decode
        public static T JsonDeserialize<T>(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                jsonSerializer.MaxJsonLength = Int32.MaxValue;
                return jsonSerializer.Deserialize<T>(json);
            }
            else
            {
                return default(T);
            }
        }
        //Json Encode
        public static string JsonSerialize(object obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            jsonSerializer.MaxJsonLength = Int32.MaxValue;
            return jsonSerializer.Serialize(obj);
        }
    }
}
