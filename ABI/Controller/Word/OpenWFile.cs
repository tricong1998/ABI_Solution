// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 2:40 PM 2018/7/25
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class OpenWFile
    {
        public IResult CheckOpened(string path)
        {
            ABIW_CheckOpen checkOpen = new ABIW_CheckOpen();
            if (checkOpen.CheckOpen(path).Equals(ComparisonResultIndicate.equal))
            {
                return new ComparisonResult(ComparisonResultIndicate.equal);
            }
            else
            {
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
        }
    }
}
