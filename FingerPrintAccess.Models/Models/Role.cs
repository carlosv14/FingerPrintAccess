using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Models.Models
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } 
    }
}
