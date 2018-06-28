// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 5:30 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    public class WordCompareQuestion : AbstractQuestion
    {
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

        public override IResult Submit(IAnswer answer)
        {
            throw new NotImplementedException();
        }
    }
}