﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Configuration;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Data.Contexts
{
    public class FingerPrintAccessContext : DbContext
    {
        public FingerPrintAccessContext() 
            : base("FingerPrintAccess")
        {
            Database.SetInitializer<FingerPrintAccessContext>(new CreateDatabaseIfNotExists<FingerPrintAccessContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Fingerprint> Fingerprints{ get; set; }
        public DbSet<Log> Logs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RolesConfiguration());
            modelBuilder.Configurations.Add(new RoomsConfiguration());
        }
    }
}
