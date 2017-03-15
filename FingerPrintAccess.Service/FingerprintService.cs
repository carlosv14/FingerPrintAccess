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
        private readonly IRoomService _roomService;

        public FingerprintService(AbstractBaseRepository<Fingerprint>fingerprintRepository, ILogService logService, IRoomService roomService)
        {
            this._fingerprintRepository = fingerprintRepository;
            this._logService = logService;
            this._roomService = roomService;
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
            return this._fingerprintRepository.All().Include(f => f.Room).FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Fingerprint> GetAll()
        {
            return this._fingerprintRepository.All().Include(f => f.Room);
        }

        public bool IsAllowed(int fingerprintId, int roomId)
        {
            try
            {
                var user = this._fingerprintRepository.All()
                    .Include(f => f.User.Rooms)
                    .FirstOrDefault(f => f.FingerprintId == fingerprintId)
                    .User;

                var room = user == null ? null : user.Rooms.FirstOrDefault(r => r.Id == roomId);
                var successful  = room != null;
             
                if (successful)
                {
                    this._logService.Create(new Log { Successful = successful, UserName = user.Name, RoomName = room.Name });
                    this._logService.SaveChanges();
                    return successful;
                }
                var nonSuccessRoom = this._roomService.Get(roomId);
                this._logService.Create(new Log { Successful = successful, UserName = user == null ? "" : user.Username, RoomName = nonSuccessRoom == null?  "" : nonSuccessRoom.Name });
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

        public Fingerprint Create(int fingerprintId, long roomId)
        {
            var room = this._fingerprintRepository.Context.Rooms.Attach(new Room { Id = roomId });
            return this.Create(new Fingerprint { FingerprintId = fingerprintId, Room = room });
        }
    }
}
