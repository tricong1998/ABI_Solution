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
    class CompareTextRange
    {
        public IResult Compare(ABIW_Document answer, ABIW_Document submission)
        {
            ABIW_TextRangePro aRange = new ABIW_TextRangePro(answer.Document.Range());
            ABIW_TextRangePro sRange = new ABIW_TextRangePro(submission.Document.Range());

            if (aRange.Compare(sRange).Result == ComparisonResultIndicate.equal)
            {
                return new ComparisonResult(ComparisonResultIndicate.equal);
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
