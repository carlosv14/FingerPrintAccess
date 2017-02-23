using FingerPrintAccess.Data.Repositories.Base;

namespace FingerPrintAccess.Service.Record
{
    public interface IRecordService
    {
        void Save(Models.Models.Record record);
    }

    public class RecordService : IRecordService
    {
        private readonly AbstractBaseRepository<Models.Models.Record> _recordRepository;

        public RecordService(AbstractBaseRepository<Models.Models.Record> recordRepository)
        {
            this._recordRepository = recordRepository;
        }
        public void Save(Models.Models.Record record)
        {
            this._recordRepository.Create(record);
            this._recordRepository.SaveChangesAsync();
        }
    }
}
