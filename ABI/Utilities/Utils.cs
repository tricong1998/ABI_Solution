// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 12:03 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    /// <summary>
    /// put all static util functions here, which can be used several times
    /// </summary>
    public class Utils
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// copy all files and directories in @strSource folder to @strDestination folder
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="strDestination"></param>
        public static void CopyDirectory(string strSource, string strDestination)
        {
            if (!Directory.Exists(strDestination))
            {
                Directory.CreateDirectory(strDestination);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(strSource);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo tempfile in files)
            {
                tempfile.CopyTo(Path.Combine(strDestination, tempfile.Name));
            }

            DirectoryInfo[] directories = dirInfo.GetDirectories();
            foreach (DirectoryInfo tempdir in directories)
            {
                CopyDirectory(Path.Combine(strSource, tempdir.Name), Path.Combine(strDestination, tempdir.Name));
            }
        }

        public static string ReadFileContent(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="removeIfExist">indicate remove dir if it exists</param>
        /// <returns></returns>
        public static DirectoryInfo CreateDirectory(string dirPath, bool removeIfExist)
        {
            if (Directory.Exists(dirPath))
            {
                if (removeIfExist)
                    Directory.Delete(dirPath, true);
                else
                    return new DirectoryInfo(dirPath);
            }
            return Directory.CreateDirectory(dirPath);
        }

        public static DirectoryInfo CreateDirectoryForFilePath(string filePath)
        {
            return Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        /// <summary>
        /// create temp file and return it's path 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string CreateTempFile(string filePath)
        {
            string fileNameMpExtension = Path.GetFileNameWithoutExtension(filePath);
            string fileExtension = Path.GetExtension(filePath);
            if (fileNameMpExtension == null)
                return null;
            var tempFolder = Path.GetTempPath();
            string newPath = Path.Combine(tempFolder,
                fileNameMpExtension + Guid.NewGuid() + fileExtension);
            File.Copy(filePath, newPath, true);
            return newPath;
        }

        public static string CreateTempFolder(string folderName)
        {
            string re = Path.Combine(Path.GetTempPath(), folderName);
            if (Directory.Exists(re))
                Directory.Delete(re, true);
            Directory.CreateDirectory(re);
            return re;
        }
    }
}
