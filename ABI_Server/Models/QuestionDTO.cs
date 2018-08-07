using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABI_Server.Models
{
    public class QuestionDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string html_content { get; set; }
        public string markdown_content { get; set; }
        public string file_question { get; set; }
        public string file_correct_answer { get; set; }
        public List<int> listTypeL2 { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string typeClass { get; set; }
    }
}