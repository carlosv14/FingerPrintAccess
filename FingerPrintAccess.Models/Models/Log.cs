using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Models.Models
{
    public class Log
    {
        public long Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public bool Successful { get; set; }
        public Room Room { get; set; }

        public Log()
        {
            Date = DateTime.Now;
        }
    }
}
