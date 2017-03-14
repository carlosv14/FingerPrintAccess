namespace FingerPrintAccess.Service.Interfaces
{
    using System.Threading.Tasks;

    using FingerPrintAccess.Models.Models;

    public interface IRecordFactory
    {
        Task CreateRecord(User user, CheckState check);
    }
}
