using FingerPrintAccess.Models.Models;

namespace FingerPrintAccess.Service.Interfaces
{
    public interface IRoomService : ICrudService<Room>
    {
        bool RoomExists(long id);
    }
}