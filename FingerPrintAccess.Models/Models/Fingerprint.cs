using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Models.Models
{
    public class Fingerprint
    {
        public long Id { get; set; }
        public int FingerprintId { get; set; }
        public User User { get; set; }
    }
}
