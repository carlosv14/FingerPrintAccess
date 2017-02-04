using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Data.Contexts
{
    public class FingerPrintAccessContext : DbContext
    {
        public FingerPrintAccessContext() 
            : base("FingerPrintAccess")
        {
        }

    }
}
