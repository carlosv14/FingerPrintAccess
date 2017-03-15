using FingerPrintAccess.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Data.Repositories.Base;
using System.Data.Entity;

namespace FingerPrintAccess.Service
{
    public class LogService : ILogService
    {
        private readonly AbstractBaseRepository<Log> logRepository;

        public LogService(AbstractBaseRepository<Log> logRepository)
        {
            this.logRepository = logRepository;
        }
        public Log Create(Log entity)
        {
            return this.logRepository.Create(entity);
        }

        public Log Get(long id)
        {
            return this.logRepository.All().Include(l => l.User).FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Log> GetAll()
        {
            return this.logRepository.All().Include(l => l.User);
        }

        public Log Remove(long id)
        {
            return this.logRepository.Delete(new Log { Id = id });
        }

        public int SaveChanges()
        {
            return this.logRepository.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.SaveChangesAsync();
        }

        public Log Update(long id, Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
