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
            var rooms = new Room[]
                {
                    new Room
                    {
                        Name = "Room 1"
                    }
                };

            context.Rooms.AddRange(rooms);

            var fingerprint = new Fingerprint
            {
                RegistryIdentification = 1
            };

            context.Fingerprints.Add(fingerprint);

            var user = new User
            {
                CreationDate = DateTime.Now,
                Name = "Christopher Escalon",
                Password = "123",
                Username = "chris",
                Fingerprint = fingerprint

            };

            context.Users.Add(user);

            foreach (var room in rooms)
            {
                user.Rooms.Add(room);
            }

            context.SaveChanges();
        }
    }
}
