﻿using FingerPrintAccess.Data.Repositories.Base;

namespace FingerPrintAccess.Service.Record
{
    using FingerPrintAccess.Service.Interfaces;

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