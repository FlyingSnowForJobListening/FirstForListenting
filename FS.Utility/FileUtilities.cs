using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Utility
{
    public class FileUtilities
    {
        public static bool CreateFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("CreateFolder Exception" + ex.ToString());
            }
        }
        public static string GetNewFileName(params string[] args)
        {
            string result = null;
            try
            {
                result = string.Join("_", args);
                if (string.IsNullOrEmpty(result))
                {
                    result += Guid.NewGuid().ToString("N");
                }
                else
                {
                    result += "_" + Guid.NewGuid().ToString().Substring(24);
                }
            }
            catch (Exception)
            {
                result = Guid.NewGuid().ToString("N");
            }
            return result;
        }
        public static string GetNewFolderName(bool needTimeFolder, params string[] args)
        {
            string result = null;
            try
            {
                result = string.Join("\\", args);
                if (needTimeFolder)
                {
                    result += "\\" + DateTime.Now.ToString("yyyy-MM-dd");
                }
                CreateFolder(result);
            }
            catch (Exception ex)
            {
                throw new Exception("GetNewFolderName Exception : " + ex.ToString());
            }
            return result;
        }

        public static bool FileMove(string sourcePath, string destPath)
        {
            bool success = true;
            try
            {
                File.Move(sourcePath, destPath);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }
        public static bool FileMove(string sourcePath, string fileName, bool needTimeFolder = true, params string[] args)
        {
            bool success = true;
            string destPath = null;
            try
            {
                destPath = string.Join("\\", args);
                if (needTimeFolder)
                {
                    destPath += "\\" + DateTime.Now.ToString("yyyy-MM-dd");
                }
                CreateFolder(destPath);
                File.Move(sourcePath, destPath + "\\" + fileName);
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }
    }
}
