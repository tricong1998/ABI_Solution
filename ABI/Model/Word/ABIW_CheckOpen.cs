using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI
{
    class ABIW_CheckOpen
    {
        public IResult CheckOpen(string path)
        {
            System.IO.FileStream fileStream = null;
            try
            {
                fileStream = System.IO.File.Open(path,
                System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
                return new ComparisonResult(ComparisonResultIndicate.not_equal);
            }
            catch (System.IO.IOException ex)
            {
                return new ComparisonResult(ComparisonResultIndicate.equal);
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
        }
    }
}
