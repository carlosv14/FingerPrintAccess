namespace FingerPrintAccess.Service.Record
{
    using System;
    using Models.Models;

    public class RecordFactory : IRecordFactory
    {
        private readonly Record record;

        public RecordFactory(Record record)
        {
            this.record = record;
        }

        public Record CreateRecord(User user, CheckState check)
        {
            if (user == null)
            {
                throw new ArgumentNullException("the parameter user is null");
            }

            return new Record { User = user, Check = check, Date = DateTime.Now };
        }
    }
}
