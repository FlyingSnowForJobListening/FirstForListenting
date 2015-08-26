using System;
using System.Configuration;

namespace FS.Configuration
{
    public class ConfigurationInfo
    {
        public static bool EnableDebugLog
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDebugLog"]);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static string DBConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }
        public static string BackUpPath
        {
            get
            {
                return ConfigurationManager.AppSettings["BackUpPath"];
            }
        }

    }
}
