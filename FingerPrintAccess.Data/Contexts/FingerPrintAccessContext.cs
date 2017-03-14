using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Configuration;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Data.Initializers;
using System.Diagnostics;

namespace FingerPrintAccess.Data.Contexts
{
    public class FingerPrintAccessContext : DbContext
    {
        static FingerPrintAccessContext()
        {
        }

        public FingerPrintAccessContext() 
            : base("FingerPrintAccess")
        {
            this.Database.Log += s => Debug.WriteLine(s);
            Database.SetInitializer(new DropCreateInitializerFingerpintAccess());
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Fingerprint> Fingerprints { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration(modelBuilder));
            modelBuilder.Configurations.Add(new RolesConfiguration());
            modelBuilder.Configurations.Add(new RoomsConfiguration());

            modelBuilder.Entity<User>().HasKey(x => x.Id);

            modelBuilder.Entity<Fingerprint>()
                .HasOptional(s => s.User) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.Fingerprint);
        }
    }
}
