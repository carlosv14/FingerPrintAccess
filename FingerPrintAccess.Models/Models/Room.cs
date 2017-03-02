using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Models.Models
{
    public class Room
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Room()
        {
            Users = new HashSet<User>();
        }
    }
}
