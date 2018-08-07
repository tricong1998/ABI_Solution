using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.Utils
{
    public class Utils
    {
    }
    // consider to move into Utils class
    public class CompareObject
    {
        public bool compareTwoObject(object o1, object o2)
        {
            if (o1 == null && o2 == null)
            {
                return true;
            }
            else if (o1 != null && o2 != null)
            {
                if (o1.Equals(o2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
