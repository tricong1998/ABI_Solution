// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 4:10 PM 2018/6/26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.Common
{
    /// <summary>
    /// represent for score (e.g., 1-10)
    /// </summary>
    public class ScoreResult : AbstractResult
    {
        private int score = 0;
        private int maxScore = 10; // default = 10

        public ScoreResult(int score)
        {
            this.score = score;
        }
        public ScoreResult(int score, int maxScore) : this(score)
        {
            this.maxScore = maxScore;
        }

        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public int MaxScore
        {
            get
            {
                return maxScore;
            }

            set
            {
                maxScore = value;
            }
        }
    }
}
