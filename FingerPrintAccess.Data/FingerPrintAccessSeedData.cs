using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Contexts;

namespace FingerPrintAccess.Data
{
    public class FingerPrintAccessSeedData : DropCreateDatabaseIfModelChanges<FingerPrintAccessContext>
    {
        protected override void Seed(FingerPrintAccessContext context)
        {
            base.Seed(context);
        }
    }
}
