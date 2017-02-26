using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service.Interfaces;

namespace FingerPrintAccess.Service
{
    public class RoomService : IRoomService
    {
        private readonly AbstractBaseRepository<Room> _roomRepository;
        public RoomService(AbstractBaseRepository<Room> roomRepository )
        {
            this._roomRepository = roomRepository;
        }
        public IEnumerable<Room> GetAll()
        {
            return this._roomRepository.All();
        }

        public Room Get(long id)
        {
           return this._roomRepository.FirstOrDefault(r => r.Id == id);
        }

        public Room Create(Room entity)
        {
            return this._roomRepository.Create(entity);
        }

        public Room Update(long id, Room entity)
        {
           return this._roomRepository.Update(new Room {Id = id}, entity);
        }

        public Room Remove(long id)
        {
            return this._roomRepository.Delete(new Room {Id = id});
        }

        public int SaveChanges()
        {
          return this._roomRepository.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
           return this._roomRepository.SaveChangesAsync();
        }

        public bool RoomExists(long id)
        {
            return this._roomRepository.All().Any(r => r.Id == id);
        }
    }

}
