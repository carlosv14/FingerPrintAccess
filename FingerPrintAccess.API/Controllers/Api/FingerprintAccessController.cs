using FingerPrintAccess.API.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace FingerPrintAccess.API.Controllers.Api
{
    using FingerPrintAccess.Data.Repositories;
    using FingerPrintAccess.Data.Repositories.Base;
    using FingerPrintAccess.Models.Models;
    using FingerPrintAccess.Service.Interfaces;

    public class FingerprintAccessController : ApiController
    {
        private readonly IFingerprintAccessService fingerprintAccessService;

        private readonly IRecordFactory recordFactory;

        private readonly AbstractBaseRepository<User> userRepository;

        public FingerprintAccessController(IFingerprintAccessService fingerprintAccessService,
            IRecordFactory recordFactory,
            AbstractBaseRepository<User> userRepository)
        {
            this.fingerprintAccessService = fingerprintAccessService;
            this.recordFactory = recordFactory;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// The authenticate.
        /// </summary>
        /// <param name="fingerprintAccessViewModel">
        /// The fingerprint access view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("api/FingerprintAccess/")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Authenticate(FingerprintAccessViewModel fingerprintAccessViewModel)
        {

            if (fingerprintAccessViewModel.RoomId == null || fingerprintAccessViewModel.FingerprintId == null)
            {
                return this.BadRequest("not valid paramenters");
            }

            var valid = this.fingerprintAccessService.Authenticate(
                fingerprintAccessViewModel.RoomId,
                fingerprintAccessViewModel.FingerprintId);

            if (valid)
            {
                 await this.recordFactory.CreateRecord(
                    this.userRepository.FirstOrDefault(
                        x => x.Fingerprint.RegistryIdentification == fingerprintAccessViewModel.FingerprintId),
                    CheckState.In);
            }

            return
                this.Json(
                    new
                        {
                            opened = valid
                        });
        }
    }
}
