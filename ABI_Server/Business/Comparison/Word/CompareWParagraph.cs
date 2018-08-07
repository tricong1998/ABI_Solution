using ABI_DCH.Common;
using ABI_DCH.Word;
using ABI_Server.Business.Models.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_Server.Business.Comparison
{
    class CompareWParagraph
    {
        public IResult Compare(ABIW_Document answer, ABIW_Document submission)
        {
            int count1 = answer.Document.Range().Paragraphs.Count;
            int count2 = submission.Document.Range().Paragraphs.Count;

            if (count1 == count2)
            {
                for (int i = 1; i <= count1; i++)
                {
                    ABIW_Paragraph answerPara = new ABIW_Paragraph(answer.Document.Range().Paragraphs[i]);
                    ABIW_Paragraph submisPara = new ABIW_Paragraph(submission.Document.Range().Paragraphs[i]);

                    if (answerPara.Compare(submisPara).Result == ComparisonResultIndicate.equal)
                    {
                        continue;
                    }
                    else
                        return new ComparisonResult(ComparisonResultIndicate.not_equal);
                }
                return new ComparisonResult(ComparisonResultIndicate.equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
