using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Contexts;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Data
{
    public class FingerPrintAccessSeedData : DropCreateDatabaseIfModelChanges<FingerPrintAccessContext>
    {
        protected override void Seed(FingerPrintAccessContext context)
        {
            GetUsers().ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }

        private static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Name = "admin",
                    Password = "admin",
                    Username = "admin"
                }
            };
        }
    }
}
