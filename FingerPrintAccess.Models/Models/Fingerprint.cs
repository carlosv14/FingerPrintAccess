using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FingerPrintAccess.Models.Models
{
    public class Fingerprint
    {
        public int Id { get; set; }

        public int RegistryIdentification { get; set; }

        public virtual User User { get; set; }
    }
}
