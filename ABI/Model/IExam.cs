// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:06 AM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    // store all information related an exam
    public interface IExam
    {
        List<IQAPair> QAPairs { get; set; }
    }
}
