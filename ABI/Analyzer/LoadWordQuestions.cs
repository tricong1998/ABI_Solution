// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 5:36 PM 2018/7/10
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class LoadWordQuestions : LoadQuestions
    {
        public const int ID_COLUMN = 0;
        public const int TITLE_COLUMN = 1;
        public const int RAW_CONTENT_COLUMN = 2;
        public const int HTML_CONTENT_COLUMN = 3;
        public const int MARKDOWN_CONTENT_COLUMN = 4;
        public const int TYPE_L2_COLUMN = 5;
        public const int QUESTION_FILE_COLUMN = 6;
        public const int ANSWER_FILE_COLUMN = 7;
        public const int DESCRIPTION_COLUMN = 8;

        /// <summary>
        /// current load all questions from db, handle later
        /// long task
        /// </summary>
        /// <returns></returns>
        public List<IQAPair> Load(out string workspace)
        {
            workspace = GetWorkSpaceFolder();
            SqlConnection conn = Initialize();
            SqlCommand command = new SqlCommand("SELECT * FROM question", conn);
            List<IQAPair> re = new List<IQAPair>();
            // Create new SqlDataReader object and read data from the command.
            using (SqlDataReader reader = command.ExecuteReader())
            {
                int index = 1;
                while (reader.Read())
                {
                    int id = (int)reader[ID_COLUMN];
                    string raw_content = reader[RAW_CONTENT_COLUMN] as string;
                    string html_content = reader[HTML_CONTENT_COLUMN] as string;
                    string markdown_content = reader[MARKDOWN_CONTENT_COLUMN] as string;
                    int type_l2 = (int)reader[TYPE_L2_COLUMN];
                    string question_file = reader[QUESTION_FILE_COLUMN] as string;
                    string answer_file = reader[ANSWER_FILE_COLUMN] as string;
                    string description = reader[DESCRIPTION_COLUMN] as string;
                    var pair = Convert(id, raw_content, html_content, markdown_content, type_l2,
                        question_file, answer_file, description, index, workspace);
                    index++;
                    re.Add(pair);
                }
            }
            conn.Close();
            return re;
        }

        /// <summary>
        /// @Hoang implement here, consider to define new Question type (extend AbstractQuestion)
        /// maybe need more params, you can add new by yourself
        /// </summary>
        /// <param name="type_l2"></param>
        /// <returns></returns>
        public IQAPair Convert(int id, string raw_content, string html_content, string markdown_content, 
            int type_l2, string question_file, string answer_file, string description, int index, string workspace)
        {
            IQuestion question = null;
            IAnswer answer = null;
            IAnswer correctAnswer = new ABIAnswer();
            switch (type_l2)
            {
                case 1:
                case 2:
                case 3:
                case 22:
                    question = new OpenWFileQuestion();
                    answer = new OpenWFileAnswer();
                    ((OpenWFileQuestion)question).EmptyFilePath = Path.Combine(workspace, "empty.docx");
                    break;
                case 24:
                    question = new CloseWFileQuestion();
                    answer = new CloseWFileAnswer();
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                    question = new CompareWFileQuestion();
                    answer = new CompareWFileAnswer();
                    if (answer_file != null)
                        ((ABIAnswer)correctAnswer).File = new WordFile(Path.Combine(workspace, answer_file));
                    break;
            }
            if (question_file != null)
                question.File = new WordFile(Path.Combine(workspace, question_file));
            if (question != null)
            {
                question.Index = index;
                question.HtmlContent = html_content;
                question.RawContent = raw_content;
                question.MarkdownContent = markdown_content;
                question.Description = description;
                question.Type_l2 = type_l2;

                if (question is OpenWFileQuestion)
                {
                    if (question.HtmlContent != null)
                        ((OpenWFileQuestion)question).HtmlContent += ": <b>" + Path.Combine(workspace, question_file) + "</b>";
                    if (question.MarkdownContent != null)
                        ((OpenWFileQuestion)question).MarkdownContent += ": **" + Path.Combine(workspace, question_file) + "**";
                }
            }
            return new ABIQAPair(question, answer, correctAnswer);
        }

        // change to your 
        public static string WORKSPACE = @"D:\temp\abi\";
        private string GetWorkSpaceFolder()
        {
            var re = WORKSPACE;
            if (!Directory.Exists(re))
            {
                Directory.CreateDirectory(re);
                string path = Path.Combine(re, "my.zip");
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://35.198.229.219/my.zip", path);
                    ZipFile.ExtractToDirectory(path, re);
                }
            }
            return WORKSPACE;
        }
    }
}
