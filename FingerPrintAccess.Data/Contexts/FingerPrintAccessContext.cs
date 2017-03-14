using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Configuration;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Data.Initializers;

namespace FingerPrintAccess.Data.Contexts
{
    public class FingerPrintAccessContext : DbContext
    {
        static FingerPrintAccessContext()
        {
             Database.SetInitializer(new DropCreateInitializerFingerpintAccess());
        }
        public FingerPrintAccessContext() 
            : base("FingerPrintAccess")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Fingerprint> Fingerprints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RolesConfiguration());
            modelBuilder.Configurations.Add(new RoomsConfiguration());
        }
    }
}
