using FingerPrintAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Data.Configuration
{
    public class FingerprintConfiguration : EntityTypeConfiguration<Fingerprint>
    {
        public FingerprintConfiguration()
        {
            ToTable("FINGERPRINTS");
            Property(f => f.FingerprintId).IsRequired();
            HasKey(f => f.Id);
        }
    }
}
