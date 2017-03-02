using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using FingerPrintAccess.API.Models;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service.Interfaces;

namespace FingerPrintAccess.API.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class RoomsController : ApiController
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            this._roomService = roomService;
        }

        [Authorize(Roles = "Admin")]
        [Route("api/Rooms")]
        [HttpGet]
        public IQueryable<Room> Get()
        {
            return this._roomService.GetAll().AsQueryable();
        }

        [HttpGet]
        [Route("api/Rooms/{id}")]
        [Authorize(Roles = "Admin")]
        public Room Get(long id)
        {
            return this._roomService.Get(id);
        }

        [Route("api/Rooms/{roomId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Put(long roomId, RoomFormViewModel room)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (roomId != room.Id)
            {
                return this.BadRequest();
            }

            var roomToUpdate = Mapper.Map<RoomFormViewModel, Room>(room);
            this._roomService.Update(roomId, roomToUpdate);

            try
            {
                await this._roomService.SaveChangesAsync();
            }
            catch (DataException)
            {
                if (!this._roomService.RoomExists(roomId))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return this.Ok();
        }

        [HttpDelete]
        [Route("api/Rooms/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Delete(long id)
        {
            this._roomService.Remove(id);
            try
            {
                await this._roomService.SaveChangesAsync();
            }
            catch (DataException)
            {
                if (!this._roomService.RoomExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }
            return this.Ok();
        }

        [HttpPost]
        [Route("api/Rooms")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Post(RoomFormViewModel room)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (room != null)
            {
                var newRoom = Mapper.Map<RoomFormViewModel,Room>(room);
                this._roomService.Create(newRoom);
            }

            try
            {
                await this._roomService.SaveChangesAsync();
            }
            catch (DataException)
            {
                throw;
            }

            return Ok();
        }

    }
}
