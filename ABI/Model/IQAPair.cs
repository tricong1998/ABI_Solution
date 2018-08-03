// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:57 PM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public interface IQAPair
    {
        IQuestion Question { get; set; }
        IAnswer Answer { get; set; }

        IAnswer CorrectAnswer { get; set; }

        // store user result of an answer
        IResult Result { get; set; }
    }
}
