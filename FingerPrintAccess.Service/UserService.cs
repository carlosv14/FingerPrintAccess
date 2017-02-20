using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service.Interfaces;

namespace FingerPrintAccess.Service
{
    public class UserService : IUserService
    {
        private readonly AbstractBaseRepository<User> _userRepository;

        public UserService(AbstractBaseRepository<User> userRepository )
        {
            this._userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return this._userRepository.All();
        }

        public User Get(long id)
        {
            return this._userRepository.FirstOrDefault(u => u.Id == id);
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
            return this._userRepository.All().FirstOrDefault(u => u.Username == user && u.Password == password);
        }
    }
}
