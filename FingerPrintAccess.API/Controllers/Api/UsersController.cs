using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;
using AutoMapper;
using FingerPrintAccess.API.Models;
using FingerPrintAccess.API.Security;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service;

namespace FingerPrintAccess.API.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [Route("api/Users/Me")]
        public User Me()
        {
            try
            {
                var id = Convert.ToInt64((HttpContext.Current.User.Identity as ClaimsIdentity)?.FindFirst("Id").Value);
                return _userService.GetUser(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = "Admin")]
        // GET api/<controller>
        public IQueryable<User> Get()
        {
            return this._userService.GetUsers().AsQueryable();
        }

        [HttpGet]
        [Route("api/Users/{id}")]
        [Authorize(Roles = "Admin")]
        // GET api/<controller>/5
        public User Get(long id)
        {
            return this._userService.GetUser(id);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post(UserFormViewModel user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (user != null)
            {
                var newUser = Mapper.Map<UserFormViewModel, User>(user);
                this._userService.CreateUser(newUser);
            }

            try
            {
               await this._userService.SaveChangesAsync();
            }
            catch (DataException)
            {
                throw;
            }

            return this.Ok();
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Users/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Put(long userId, UserFormViewModel user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (userId != user.Id)
            {
                return this.BadRequest();
            }
            
            var userToUpdate = Mapper.Map<UserFormViewModel, User>(user);
            _userService.UpdateUser(userId, userToUpdate);
     
            try
            {
                await this._userService.SaveChangesAsync();
            }
            catch (DataException)
            {
                if (!this._userService.UserExists(userId))
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
        [Route("api/Users/{id}")]
        // DELETE api/<controller>/5
        [Authorize(Roles = "Admin")]
        public async Task<IHttpActionResult> Delete(long id)
        {
            _userService.RemoveUser(id);
            try
            {
                await _userService.SaveChangesAsync();
            }
            catch (DataException)
            {
                if (!this._userService.UserExists(id))
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

    }
}