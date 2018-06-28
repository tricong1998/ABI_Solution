// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:01 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    /// <summary>
    /// all types of questions need to be implemented this interface
    /// </summary>
    public interface IQuestion
    {
        IResult Submit(IAnswer answer);
    }
}
