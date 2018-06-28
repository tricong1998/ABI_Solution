// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:56 AM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI
{
    public class ABIW_Paragraph : IComparison
    {
        private Paragraph paragraph;

        public Paragraph Paragraph
        {
            get
            {
                return paragraph;
            }

            set
            {
                paragraph = value;
            }
        }

        /// <summary>
        /// implement algorithm here
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Paragraph otherPara)
            {
                // compare $this vs $otherPara
                // and replace the below exception with a return statement
                throw new NotImplementedException();
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
        }
    }
}
