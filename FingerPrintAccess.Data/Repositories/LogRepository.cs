using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Contexts;

namespace FingerPrintAccess.Data.Repositories
{
    public class LogRepository : AbstractBaseRepository<Log>
    {
        public LogRepository(FingerPrintAccessContext context) : base(context)
        {
        }

        public override IQueryable<Log> All()
        {
            return this.Context.Logs;
        }

        protected override Log MapNewValuesToOld(Log oldEntity, Log newEntity)
        {
            oldEntity.Date = newEntity.Date;
            oldEntity.Id = newEntity.Id;
            oldEntity.Successful = newEntity.Successful;
            oldEntity.UserName = newEntity.UserName;
            oldEntity.RoomName = newEntity.RoomName;
            return oldEntity;
        }
    }
}
