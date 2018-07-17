// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:01 AM 2018/7/11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class CompareWFileAnswer : AbstractAnswer
    {
        // $file in $AbstractAnswer is user submit

        private IWordFile correctAnswer;

        public IWordFile CorrectAnswer
        {
            get
            {
                return correctAnswer;
            }

            set
            {
                correctAnswer = value;
            }
        }
    }
}
