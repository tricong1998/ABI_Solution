// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:45 PM 2018/6/15
using ABI_DCH.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.PowerPoint
{
    public class PowerPointFile : ABIFile, IPowerPointFile
    {
        public PowerPointFile(string path) : base(path)
        {
        }
    }
}
