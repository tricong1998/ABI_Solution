// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 11:43 AM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    /// <summary>
    /// represent for objects which cab be compared with another
    /// </summary>
    public interface IComparison
    {
        IComparisonResult Compare(object other);
    }
}
