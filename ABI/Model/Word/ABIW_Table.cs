// Copyright (c) 2018 fit.uet.vnu.edu.vn
// author @duongtd
// created on 10:33 AM 2018/6/27
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ABI
{
    /// <summary>
    /// represent for a word table
    /// </summary>
    public class ABIW_Table : IComparison
    {
        public static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Table table;

        public ABIW_Table(Table table)
        {
            this.table = table;
        }

        public Table Table
        {
            get
            {
                return table;
            }

            set
            {
                table = value;
            }
        }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Table otherTable)
            {
                // compare $this vs $otherTable
                // and replace the below exception with a return statement
                throw new NotImplementedException();
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
            // e.g., use logger
            // logger.Debug("abc");
        }
    }
}
