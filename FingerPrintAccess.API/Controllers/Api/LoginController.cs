using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FingerPrintAccess.API.Models;
using FingerPrintAccess.Service;

namespace FingerPrintAccess.API.Controllers.Api
{
    public class LoginController : ApiController
    {
        private UserService userService;

        public LoginController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public IHttpActionResult Login(UserLoginModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            
            var user = this.userService.GetUser(userLogin.User, userLogin.Password);
            if (user != null)
            {
                var userInformation = $"{user.Username}:{user.Password}";
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(userInformation);
                return Ok(new {Token = $"Basic {System.Convert.ToBase64String(plainTextBytes)}"});
            }
            return this.NotFound();
        }
    }
}
