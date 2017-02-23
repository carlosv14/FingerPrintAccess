namespace FingerPrintAccess.Service.Record
{
    using Models.Models;

    public interface IRecordFactory
    {
        Record CreateRecord(User user, CheckState check);
    }
}
