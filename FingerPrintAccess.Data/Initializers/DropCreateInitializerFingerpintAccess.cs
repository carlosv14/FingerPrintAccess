using FingerPrintAccess.Data.Contexts;
using FingerPrintAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Data.Initializers
{
    public class DropCreateInitializerFingerpintAccess : DropCreateDatabaseAlways<FingerPrintAccessContext>
    {
        protected override void Seed(FingerPrintAccessContext context)
        {
            var user = new User
            {
                CreationDate = DateTime.Now,
                Fingerprint = new Fingerprint
                {
                    RegistryIdentification = 1
                },
                Name = "Christopher Escalon",
                Password = "123",
                Rooms = new Room[]
                {
                    new Room
                    {
                        Name = "Room 1"
                    }
                },
                Username = "chris"
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
