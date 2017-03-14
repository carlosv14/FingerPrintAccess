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
        private readonly AbstractBaseRepository<User> userRepository;

        public FingerprintAccessService(
            AbstractBaseRepository<Fingerprint> fingerprintRepository,
            AbstractBaseRepository<User> userRepository)
        {
            this.fingerprintRepository = fingerprintRepository;
            this.userRepository = userRepository;
        }

        public bool Authenticate(long roomId, int fingerprintId)
        {
            Room room = this.fingerprintRepository.FirstOrDefault(x => x.RegistryIdentification == fingerprintId)?.User.Rooms.FirstOrDefault(x => x.Id == roomId);

            return room != null;
        }
    }
}
