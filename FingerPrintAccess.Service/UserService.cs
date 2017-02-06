using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        User CreateUser(User user);
        User UpdateUser(long id,User user);
        User RemoveUser(long id);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        bool UserExists(long id);
        User GetUser(string user, string password);
    }
    public class UserService : IUserService
    {
        private readonly AbstractBaseRepository<User> _userRepository;

        public UserService(AbstractBaseRepository<User> userRepository )
        {
            this._userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return this._userRepository.All();
        }

        public User GetUser(long id)
        {
            return this._userRepository.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User user)
        {
            return this._userRepository.Create(user);
        }

        public User UpdateUser(long id, User user)
        {
            return this._userRepository.Update(new User {Id = id },user);
        }

        public User RemoveUser(long id)
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

        public User GetUser(string user, string password)
        {
            return this._userRepository.All().FirstOrDefault(u => u.Username == user && u.Password == password);
        }
    }
}
