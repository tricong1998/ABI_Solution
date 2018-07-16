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
        private Columns columns;
        private Rows rows;

        public ABIW_Table(Table table)
        {
            this.table = table;
            this.columns = table.Columns;
            this.rows = table.Rows;
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

        public Columns Columns { get => columns; set => columns = value; }
        public Rows Rows { get => rows; set => rows = value; }

        public IComparisonResult Compare(object other)
        {
            if (other is ABIW_Table otherTable)
            {
                // compare $this vs $otherTable
                // and replace the below exception with a return statement
                if (this.Rows.Count == otherTable.table.Rows.Count
                    && this.Columns.Count == otherTable.table.Columns.Count)
                {
                    for (int i=1; i<=rows.Count; i++)
                    {
                        for (int j=1; j<=columns.Count; j++)
                        {
                            try
                            {
                                Cell cell = this.table.Cell(i, j);
                                Cell otherCell = otherTable.table.Cell(i, j);
                                ABIW_Cell wCell = new ABIW_Cell(cell);
                                ABIW_Cell wOtherCell = new ABIW_Cell(otherCell);
                                if (wCell.Compare(wOtherCell).Result == ComparisonResultIndicate.equal)
                                {
                                    continue;
                                }
                                else
                                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
                            }
                            catch (System.Runtime.InteropServices.COMException ex)
                            {
                                continue;
                            }
                        }
                    }
                    return new ComparisonResult(ComparisonResultIndicate.equal);
                }
                else
                    return new ComparisonResult(ComparisonResultIndicate.not_equal);
                throw new NotImplementedException();
            }
            else
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
            // e.g., use logger
            // logger.Debug("abc");
        }

        
    }
}
