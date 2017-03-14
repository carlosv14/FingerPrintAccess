using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Models.Models
{
    public class User
    {
        public User()
        {
            CreationDate = DateTime.Now;
            Roles = new HashSet<Role>();
            Rooms = new HashSet<Room>();
        }

        public long Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Fingerprint Fingerprint { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Record> Records { get; set; }
    }
}
