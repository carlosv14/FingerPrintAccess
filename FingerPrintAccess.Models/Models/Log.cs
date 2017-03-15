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
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public bool Successful { get; set; }
        public string RoomName { get; set; }

        public Log()
        {
            Date = DateTime.Now;
        }
    }
}
