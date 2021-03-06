﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Models.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Room> Rooms { get; set; }

        public User()
        {
            CreationDate = DateTime.Now;
            Roles = new HashSet<Role>();
            Rooms = new HashSet<Room>();
        }
    }
}
