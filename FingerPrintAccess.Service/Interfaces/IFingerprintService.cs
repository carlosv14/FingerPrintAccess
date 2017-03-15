using FingerPrintAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Service.Interfaces
{
    public interface IFingerprintService : ICrudService<Fingerprint>
    {
        bool FingerprintExists(long id);
        bool IsAllowed(int fingerprintId, int roomId);
    }
}
