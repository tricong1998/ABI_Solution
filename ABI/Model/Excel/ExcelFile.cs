// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:45 PM 2018/6/15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class ExcelFile : ABIFile, IExcelFile
    {
        public ExcelFile(string path) : base(path)
        {
        }
    }
}
