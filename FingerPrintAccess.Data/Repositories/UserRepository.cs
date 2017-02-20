using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Contexts;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Data.Repositories
{
    public class UserRepository : AbstractBaseRepository<User>
    {
        public UserRepository(FingerPrintAccessContext context) : base(context)
        {
        }

        public override IQueryable<User> All()
        {
            return Context.Users;
        }

        protected override User MapNewValuesToOld(User oldEntity, User newEntity)
        {
            oldEntity.Id = newEntity.Id;
            oldEntity.Name = newEntity.Name;
            oldEntity.Password = newEntity.Password;
            oldEntity.Username = newEntity.Username;
            oldEntity.CreationDate = newEntity.CreationDate;
            oldEntity.Roles = newEntity.Roles;
            oldEntity.Rooms = newEntity.Rooms;
            return oldEntity;
        }
    }
}
