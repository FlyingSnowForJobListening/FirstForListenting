using System;

namespace FS.Log
{
    public class LogInfo
    {
        #region Properties
        public DateTime dateStamp { get; set; }
        public string typeLevel { get; set; }
        public string productName { get; set; }
        public string datail { get; set; }
        public bool isLog4net { get; set; }
        public string comment1 { get; set; }
        public string comment2 { get; set; }
        public string comment3 { get; set; }
        #endregion
    }
    public enum LogTypeLevel
    {
        Error = 0,
        Warning = 1,
        Information = 2,
        Debug = 3
    };
}
