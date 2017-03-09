using System;
using System.Linq;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Data.Contexts;

namespace FingerPrintAccess.Data.Repositories
{
    public class FingerprintRepository : AbstractBaseRepository<Fingerprint>
    {
        public FingerprintRepository(FingerPrintAccessContext context)
            : base(context)
        {
        }

        public override IQueryable<Fingerprint> All()
        {
            return this.Context.Fingerprints;
        }

        protected override Fingerprint MapNewValuesToOld(Fingerprint oldEntity, Fingerprint newEntity)
        {
            oldEntity.RegistryIdentification = newEntity.RegistryIdentification;

            return newEntity;
        }
    }
}
