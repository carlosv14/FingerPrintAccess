using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Service.Interfaces
{
    public interface IFingerprintAccessService
    {
        bool Authenticate(long roomId, int fingerprintId);
    }
}
