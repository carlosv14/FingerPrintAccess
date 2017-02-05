using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FingerPrintAccess.API.Models
{
    public class UserFormViewModel
    {
        public UserFormViewModel()
        {
            CreationDate = DateTime.Now;
        }
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; private set; }
    }
}