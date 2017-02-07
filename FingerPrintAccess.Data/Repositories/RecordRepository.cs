using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Contexts;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Data.Repositories
{
    public class RecordRepository : AbstractBaseRepository<Record>
    {
        public RecordRepository(FingerPrintAccessContext context)
            : base(context)
        {
        }

        public override IQueryable<Record> All()
        {
            this.Context.re
        }

        protected override Record MapNewValuesToOld(Record oldEntity, Record newEntity)
        {
            oldEntity.Date = newEntity.Date;
            oldEntity.User = newEntity.User;
            oldEntity.Check = newEntity.Check;
            return oldEntity;
        }
    }
}
