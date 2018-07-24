// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 12:39 PM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class CompareWFileQuestion : AbstractQuestion
    {
        private int type_l2;

        public int Type_l2 { get => type_l2; set => type_l2 = value; }

        public override IResult Submit(IAnswer answer)
        {
            throw new NotImplementedException();
        }
    }
}
