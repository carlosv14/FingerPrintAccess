using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Contexts;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service.Interfaces;

namespace FingerPrintAccess.Service
{
    public class UserService : IUserService
    {
        private readonly AbstractBaseRepository<User> _userRepository;

        public UserService(AbstractBaseRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return this._userRepository.All().Include(u => u.Rooms).Include(u => u.Fingerprints);
        }

        public User Get(long id)
        {
            return this._userRepository.All().Include(u => u.Rooms).Include(u => u.Fingerprints).FirstOrDefault(u => u.Id == id);
        }

        public User Create(User entity)
        {
            return this._userRepository.Create(entity);
        }

        public User Update(long id, User entity)
        {
            return this._userRepository.Update(new User {Id = id }, entity);
        }

        public User Remove(long id)
        {
            return this._userRepository.Delete(new User {Id = id});
        }

        public int SaveChanges()
        {
            return this._userRepository.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this._userRepository.SaveChangesAsync();
        }

        public bool UserExists(long id)
        {
            return this._userRepository.All().Any(u => u.Id == id);
        }

        public User Get(string user, string password)
        {
            return this._userRepository.All().Include(u => u.Roles).Include(u => u.Fingerprints).FirstOrDefault(u => u.Username == user && u.Password == password);
        }

        public void AddRoom(long userId, long roomId)
        {
            var room = new Room { Id = roomId };
            this._userRepository.Context.Rooms.Attach(room);
            var user = new User { Id = userId };
            this._userRepository.Context.Users.Attach(user);
            if(user != null)
            {
                user.Rooms.Add(room);   
            }
        }

        public void AddFingerprint(long userId, long fingerprintId)
        {
            var user = this._userRepository.FirstOrDefault(u => u.Id == userId);
            var fingerprint = this._userRepository.Context.Fingerprints.Attach(new Fingerprint { Id = fingerprintId });
            user.Fingerprints.Add(fingerprint);
            this._userRepository.Update(user);
        }
    }
}
