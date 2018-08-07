// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:06 PM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_DCH.Common;
using ABI_DCH.Word;
using ABI_Server.Business.Models.Word;
using Microsoft.Office.Interop.Word;

namespace ABI_Server.Business.Comparison
{
    // only check font
    public class CompareWFont
    {
        /// <summary>
        /// several types of question can be treat as compare font
        /// </summary>
        /// <param name="anwser"></param>
        /// <param name="submission"></param>
        /// <returns></returns>
        
        public IResult Compare(ABIW_Document answer, ABIW_Document submission)
        {
            ABIW_Font answerFont = new ABIW_Font(answer.Document.Range().Font);
            ABIW_Font submissFont = new ABIW_Font(submission.Document.Range().Font);

            if (answerFont.Compare(submissFont).Result == ComparisonResultIndicate.equal)
            {
                return new ComparisonResult(ComparisonResultIndicate.equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
