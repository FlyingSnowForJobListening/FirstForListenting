using System;
using System.Configuration;

namespace FS.Configuration
{
    public class ConfigurationInfo
    {
        public static string DBConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }
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
        public static string PathSend
        {
            get
            {
                return ConfigurationManager.AppSettings["CreatePath"];
            }
        }
        public static string PathReceipt
        {
            get
            {
                return ConfigurationManager.AppSettings["ReceiptPath"];
            }
        }
        public static string PathBackUp
        {
            get
            {
                return ConfigurationManager.AppSettings["BackUpPath"];
            }
        }
        public static string PathBackUpError
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorBackUpPath"];
            }
        }
        public static bool Need501
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["Need501"]);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static string HostEMS
        {
            get
            {
                return ConfigurationManager.AppSettings["HostEMS"];
            }
        }

        public static string HostCPAM
        {
            get
            {
                return ConfigurationManager.AppSettings["HostCPAM"];
            }
        }
        public static string RestPort
        {
            get
            {
                return ConfigurationManager.AppSettings["RestPort"];
            }
        }
    }
}
