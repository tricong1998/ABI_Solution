// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 12:01 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI_DCH.Common;
using Microsoft.Office.Interop.Word;

namespace ABI_Server.Business.Models.Word
{
    public class ABIW_Range : IComparison
    {
        private Range range;

        public ABIW_Range(Range range)
        {
            this.range = range;
        }

        public Range Range
        {
            get
            {
                return range;
            }

            set
            {
                range = value;
            }
        }

        public IComparisonResult Compare(object other)
        {          
            throw new NotImplementedException();
        }        
    }
}
