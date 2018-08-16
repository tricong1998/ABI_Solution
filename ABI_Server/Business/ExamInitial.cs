using ABI_Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;

namespace ABI_Server.Business
{
    public class ExamInitial
    {
        /// <summary>
        /// zip all question to @filePath
        /// </summary>
        /// <param name="listQuestion"></param>
        /// <param name="filePath">C:\\my.zip</param>
        public void PackageQuestions(List<QuestionDTO> listQuestion, string filePath)
        {
            using (var archive = ZipFile.Open(filePath, ZipArchiveMode.Create))
            {
                foreach (var questionDto in listQuestion)
                {
                    archive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
                }
            }
        }
            
    }
}