using FingerPrintAccess.Data.Repositories.Base;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintAccess.Service
{
    public class FingerprintAccessService : IFingerprintAccessService
    {
        private readonly AbstractBaseRepository<Fingerprint> fingerprintRepository;

        public FingerprintAccessService(AbstractBaseRepository<Fingerprint> fingerprintRepository)
        {
            this.fingerprintRepository = fingerprintRepository;
        }

        public bool Authenticate(long roomId, int fingerprintId)
        {
            var room = this.fingerprintRepository.FirstOrDefault(x => x.RegistryIdentification == fingerprintId)?.User.Rooms.FirstOrDefault(x => x.Id == roomId);

            return room != null;
        }
    }
}
