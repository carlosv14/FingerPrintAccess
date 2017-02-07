using System;

namespace FingerPrintAccess.Models.Models
{
    public class Record
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public CheckState Check { get; set; }

        public virtual User User { get; set; }
    }

    public enum CheckState
    {
        In,
        Out
    }
}
