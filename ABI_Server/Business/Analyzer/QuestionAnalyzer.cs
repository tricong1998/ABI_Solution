using ABI_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABI_Server.Business.Analyzer
{
    public class QuestionAnalyzer
    {
        public void Analyze(List<QuestionDTO> questions)
        {
            foreach(var question in questions)
            {
                // set attribute typeClass here
            }
        }
    }
}