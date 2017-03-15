using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("USERS");
            Property(u => u.Username).IsRequired().HasMaxLength(15);
            Property(u => u.Password).IsRequired().HasMaxLength(15);
            Property(u => u.Name).IsRequired().HasMaxLength(50);
            HasMany(u => u.Fingerprints)
                .WithOptional(f => f.User);
        }
    }
}
