using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Models.Models;
using System.Data.Entity;

namespace FingerPrintAccess.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration(DbModelBuilder modelBuilder)
        {
            ToTable("USERS");
            Property(u => u.Username).IsRequired().HasMaxLength(15);
            Property(u => u.Password).IsRequired().HasMaxLength(15);
            Property(u => u.Name).IsRequired().HasMaxLength(50);

            //modelBuilder.Entity<User>().HasOptional(x => x.Fingerprint);
        }
    }
}
