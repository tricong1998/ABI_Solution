// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:11 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    /// <summary>
    /// represent for pass/fail result
    /// </summary>
    public class BinResult
    {
        private bool state;

        public BinResult(bool state)
        {
            this.state = state;
        }

        public bool State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }
    }
}
