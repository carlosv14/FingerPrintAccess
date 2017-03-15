using AutoMapper;
using FingerPrintAccess.API.Models;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FingerPrintAccess.API.Controllers.Api
{
    public class FingerprintsController : ApiController
    {
        private readonly IFingerprintService _fingerprintService;

        public FingerprintsController(IFingerprintService fingerprintService)
        {
            this._fingerprintService = fingerprintService;
        }

        [HttpGet]
        [Route("api/Fingerprints/Authenticate")]
        public IHttpActionResult Authenticate(int fingerprintId, int roomId)
        {
            return this.Ok(this._fingerprintService.IsAllowed(fingerprintId, roomId));
        }

        [HttpGet]
        [Route("api/Fingerprints")]
        // GET api/<controller>
        public IQueryable<Fingerprint> Get()
        {
            return this._fingerprintService.GetAll().AsQueryable();
        }

        [HttpGet]
        [Route("api/Fingerprints/{id}")]
        // GET api/<controller>/5
        public Fingerprint Get(int id)
        {
            return this._fingerprintService.Get(id);
        }

        [HttpGet]
        [Route("api/Fingerprints/AddFingerprint")]
        // POST api/<controller>
        public async Task<IHttpActionResult> AddFingerprint(int fingerprintId,long roomId)
        {
            this._fingerprintService.Create(fingerprintId, roomId);
            try
            {
                await this._fingerprintService.SaveChangesAsync();
            }
            catch (DataException)
            {
                throw;
            }
            return this.Ok(true);
        }

        [HttpDelete]
        [Route("api/Fingerprints/{id}")]
        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            this._fingerprintService.Remove(id);
            try
            {
                await this._fingerprintService.SaveChangesAsync();
            }
            catch (DataException)
            {
                if (!this._fingerprintService.FingerprintExists(id))
                {
                    return this.NotFound();
                }
                throw;
            }
            return this.Ok();
        }
    }
}