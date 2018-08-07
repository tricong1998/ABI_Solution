using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABI_Server.Models
{
    public class ListQuestionDTO
    {
        public int exam_id { get; set; }
        public List<QuestionDTO> questions { get; set; }
    }
}