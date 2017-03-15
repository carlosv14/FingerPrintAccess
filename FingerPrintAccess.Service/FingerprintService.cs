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
    public class FingerprintService : IFingerprintService
    {
        private readonly AbstractBaseRepository<Fingerprint> _fingerprintRepository;
        private readonly ILogService _logService;

        public FingerprintService(AbstractBaseRepository<Fingerprint>fingerprintRepository, ILogService logService)
        {
            this._fingerprintRepository = fingerprintRepository;
            this._logService = logService;
        }
        public Fingerprint Create(Fingerprint entity)
        {
            return this._fingerprintRepository.Create(entity);
        }

        public bool FingerprintExists(long id)
        {
            return this._fingerprintRepository.All().Any(f => f.Id == id);
        }

        public Fingerprint Get(long id)
        {
            return this._fingerprintRepository.All().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Fingerprint> GetAll()
        {
            return this._fingerprintRepository.All();
        }

        public bool IsAllowed(int fingerprintId, int roomId)
        {
            try
            {
                var user = this._fingerprintRepository.All()
                    .Include(f => f.User.Rooms)
                    .FirstOrDefault(f => f.FingerprintId == fingerprintId)
                    .User;
                var successful = user.Rooms.Any(r => r.Id == roomId);
                var room = user.Rooms.FirstOrDefault(r => r.Id == roomId);
                this._logService.Create(new Log { Successful = successful, User = user, Room = room });
                this._logService.SaveChanges();
                return successful;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Fingerprint Remove(long id)
        {
            return this._fingerprintRepository.Delete(new Fingerprint {Id = id });
        }

        public int SaveChanges()
        {
            return this._fingerprintRepository.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this._fingerprintRepository.SaveChangesAsync();
        }

        public Fingerprint Update(long id, Fingerprint entity)
        {
            return this._fingerprintRepository.Update(new Fingerprint { Id = id }, entity);
        }
    }
}
