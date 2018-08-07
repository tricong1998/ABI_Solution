// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 11:50 AM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.Common
{
    public class ComparisonResult : AbstractResult, IComparisonResult
    {
        private ComparisonResultIndicate result;

        public ComparisonResult(ComparisonResultIndicate result)
        {
            this.result = result;
        }

        public ComparisonResultIndicate Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }
    }

    public enum ComparisonResultIndicate
    {
        equal, not_equal
    }
}
