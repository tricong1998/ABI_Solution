// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:41 AM 2018/6/27
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.Common
{
    public interface IComparisonResult : IResult
    {
        ComparisonResultIndicate Result { get; set; }
    }
}
