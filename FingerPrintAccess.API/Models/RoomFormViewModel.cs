using System.Collections.Generic;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.API.Models
{
    public class RoomFormViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}