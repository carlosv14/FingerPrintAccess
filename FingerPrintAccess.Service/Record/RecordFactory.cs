namespace FingerPrintAccess.Service.Record
{
    using System;
    using Models.Models;

    public class RecordFactory : IRecordFactory
    {
        public Record CreateRecord(User user, CheckState check)
        {
            return new Record { User = user, Check = check, Date = DateTime.Now };
        }
    }
}
