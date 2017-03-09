namespace FingerPrintAccess.Service.Record
{
    using System;
    using System.Threading.Tasks;

    using FingerPrintAccess.Data.Repositories;
    using FingerPrintAccess.Data.Repositories.Base;
    using FingerPrintAccess.Service.Interfaces;

    using Models.Models;

    public class RecordFactory : IRecordFactory
    {
        private readonly Record record;

        private readonly AbstractBaseRepository<Record> recordRepository;

        public RecordFactory(Record record, AbstractBaseRepository<Record> recordRepository)
        {
            this.record = record;
            this.recordRepository = recordRepository;
        }

        public async Task CreateRecord(User user, CheckState check)
        {
            if (user == null)
            {
                throw new ArgumentNullException("the parameter user is null");
            }

            var record = new Record { User = user, Check = check, Date = DateTime.Now };

            this.recordRepository.Create(record);
            this.recordRepository.SaveChangesAsync();
        }
    }
}
