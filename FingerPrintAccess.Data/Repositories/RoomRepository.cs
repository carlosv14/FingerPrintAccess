using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FingerPrintAccess.Data.Contexts;
using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Data.Repositories
{
    public class RoomRepository : AbstractBaseRepository<Room>
    {
        public RoomRepository(FingerPrintAccessContext context) : base(context)
        {
        }

        public override IQueryable<Room> All()
        {
            return this.Context.Rooms;
        }

        protected override Room MapNewValuesToOld(Room oldEntity, Room newEntity)
        {
            oldEntity.Id = newEntity.Id;
            oldEntity.Name = newEntity.Name;
            oldEntity.Users = newEntity.Users;
            return oldEntity;
        }
    }
}
