// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 5:36 PM 2018/7/10
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class LoadWordQuestions : LoadQuestions
    {
        public List<IQuestion> Load()
        {
            SqlConnection conn = Initialize();
            SqlCommand command = new SqlCommand("SELECT * FROM question", conn);
            List<IQuestion> re = new List<IQuestion>();
            // Create new SqlDataReader object and read data from the command.
            using (SqlDataReader reader = command.ExecuteReader())
            {
                int index = 1;
                while (reader.Read())
                {
                    // write the data on to the screen
                    int id = (int)reader[0];
                    //string title = reader[0] as string;
                    string html_content = reader[3] as string;
                    int type_l2 = (int)reader[5];
                    string question_file = reader[6] as string;
                    string answer_file = reader[7] as string;
                    var question = Convert(type_l2);
                    question.Index = index;
                    question.HtmlContent = html_content;
                    index++;
                    re.Add(question);
                }
            }
            return re;
        }

        public IQuestion Convert(int type_l2)
        {
            return new CompareWFileQuestion();
        }
    }
}
