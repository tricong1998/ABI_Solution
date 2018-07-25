// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 5:36 PM 2018/7/10
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
        /// </summary>
        /// <returns></returns>
        public List<IQAPair> Load()
        {
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
                    string raw_content = reader[RAW_CONTENT_COLUMN] == null ? null : (string)reader[RAW_CONTENT_COLUMN];
                    string html_content = reader[HTML_CONTENT_COLUMN] == null ? null : (string)reader[HTML_CONTENT_COLUMN];
                    string markdown_content = reader[MARKDOWN_CONTENT_COLUMN] == null ? null : (string)reader[MARKDOWN_CONTENT_COLUMN];
                    string type_l2 = reader[TYPE_L2_COLUMN] == null ? null : (string)reader[TYPE_L2_COLUMN];
                    string question_file = reader[QUESTION_FILE_COLUMN] == null ? null : (string)reader[QUESTION_FILE_COLUMN];
                    string answer_file = reader[ANSWER_FILE_COLUMN] == null ? null : (string)reader[ANSWER_FILE_COLUMN];
                    string description = reader[DESCRIPTION_COLUMN] == null ? null : (string)reader[DESCRIPTION_COLUMN];
                    var pair = Convert(id, raw_content, html_content, markdown_content, type_l2,
                        question_file, answer_file, description, index);
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
            string type_l2, string question_file, string answer_file, string description, int index)
        {
            IQuestion question = null;
            IAnswer answer = null;
            IAnswer correctAnswer = new ABIAnswer();
            List<int> listTypeL2 = type_l2.Split(',').Select(Int32.Parse).ToList();
            // hard code
            // TODO: handle multiple type l2
            int typeL2Int = listTypeL2[0];
            switch (typeL2Int)
            {
                case 1:
                case 2:
                case 3:
                    question = new OpenWFileQuestion();
                    answer = new OpenWFileAnswer();
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
                        ((ABIAnswer)correctAnswer).File = new WordFile(answer_file);
                    break;  
            }
            if (question_file != null)
                question.File = new WordFile(question_file);
            if (question != null)
            {
                question.Index = index;
                question.HtmlContent = html_content;
                question.RawContent = raw_content;
                question.MarkdownContent = markdown_content;
                question.Description = description;
                question.Type_l2 = listTypeL2;
            }
            return new ABIQAPair(question, answer, correctAnswer);
        }
    }
}
