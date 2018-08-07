using ABI_DCH.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABI_DCH.Word
{
    public class OpenWFileQuestion : AbstractQuestion
    {
        string emptyFilePath;

        public string EmptyFilePath
        {
            get
            {
                return emptyFilePath;
            }

            set
            {
                emptyFilePath = value;
            }
        }

        public bool OpenedAnFile
        {
            get
            {
                return openedAnFile;
            }

            set
            {
                openedAnFile = value;
            }
        }

        protected bool openedAnFile = false;

        public override IResult Submit(IAnswer answer)
        {
            throw new NotImplementedException();
        }
    }
}
