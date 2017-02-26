using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Data.Configuration
{
    public class RoomsConfiguration : EntityTypeConfiguration<Room>
    {
        public RoomsConfiguration()
        {
            ToTable("ROOMS");
            Property(r => r.Name).IsRequired().HasMaxLength(20);
        }
    }
}
