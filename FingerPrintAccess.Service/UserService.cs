using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Service
{
    interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        User CreateUser(User user);
        int SaveUser();
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
            return _userRepository.All();
        }

        public User GetUser(long id)
        {
            return _userRepository.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User user)
        {
            return _userRepository.Create(user);
        }

        public int SaveUser()
        {
            return _userRepository.SaveChanges();
        }
    }
}
