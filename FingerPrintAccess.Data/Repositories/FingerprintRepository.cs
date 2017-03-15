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
    public class FingerprintRepository : AbstractBaseRepository<Fingerprint>
    {
        public FingerprintRepository(FingerPrintAccessContext context) : base(context)
        {
        }

        public override IQueryable<Fingerprint> All()
        {
            return this.Context.Fingerprints;
        }

        protected override Fingerprint MapNewValuesToOld(Fingerprint oldEntity, Fingerprint newEntity)
        {
            oldEntity.FingerprintId = newEntity.FingerprintId;
            oldEntity.User = newEntity.User;
            oldEntity.Id = newEntity.Id;
            return oldEntity;
        }
    }
}
