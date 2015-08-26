using FS.Utility;
using System.IO;
using System.Security.Permissions;
using System.Threading;

namespace FS.Message.Receiption
{
    public class FileWatcher
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void WatcherStart(string path, int watcherType = 15, string filter = "*.*", bool isIncludeSub = false)
        {
            FileUtilities.CreateFolder(path);
            FileSystemWatcher watcher = new FileSystemWatcher(path, filter);
            if (((WatcherChangeTypes)watcherType & WatcherChangeTypes.Created) == WatcherChangeTypes.Created)
                watcher.Created += new FileSystemEventHandler(OnCreated);
            if (((WatcherChangeTypes)watcherType & WatcherChangeTypes.Deleted) == WatcherChangeTypes.Deleted)
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            if (((WatcherChangeTypes)watcherType & WatcherChangeTypes.Changed) == WatcherChangeTypes.Changed)
                watcher.Changed += new FileSystemEventHandler(OnChanged);
            if (((WatcherChangeTypes)watcherType & WatcherChangeTypes.Renamed) == WatcherChangeTypes.Renamed)
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess
                                   | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            watcher.IncludeSubdirectories = isIncludeSub;
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
        }
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            WaitCallback waitCallBack = new WaitCallback(ReceiptThread.OnProgressReceipt);
            ThreadPool.QueueUserWorkItem(waitCallBack, e.FullPath);
        }
    }
}
