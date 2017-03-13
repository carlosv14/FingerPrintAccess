using System.Collections.Generic;
using System.Threading.Tasks;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Service.Interfaces
{
    public interface IUserService : ICrudService<User>
    {
        bool UserExists(long id);
        User Get(string user, string password);
        void AddRoom(long userId, long roomId);
    }
}