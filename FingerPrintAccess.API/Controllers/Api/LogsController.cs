using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FingerPrintAccess.API.Controllers.Api
{
    public class LogsController : ApiController
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            this._logService = logService;
        }
        // GET api/<controller>
        public IQueryable<Log> Get()
        {
            return this._logService.GetAll().AsQueryable();
        }
    }
}