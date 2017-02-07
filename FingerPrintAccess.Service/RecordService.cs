using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Service
{
    public interface IRecordService
    {
        void Save(Record record);
    }

    public class RecordService : IRecordService
    {
        private readonly AbstractBaseRepository<Record> _recordRepository;

        public RecordService(AbstractBaseRepository<Record> recordRepository)
        {
            this._recordRepository = recordRepository;
        }
        public void Save(Record record)
        {
            this._recordRepository.Create(record);
            this._recordRepository.SaveChangesAsync();
        }
    }
}
