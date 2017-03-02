using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using FingerPrintAccess.Data.Contexts;
using FingerPrintAccess.Data.Repositories;
using FingerPrintAccess.Models.Models;
using FingerPrintAccess.Service;
using Ninject;

namespace FingerPrintAccess.API.Security
{
    public class AuthenticationHandler : DelegatingHandler
    { 

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var tokens = request.Headers?.Authorization?.Parameter;
                if (tokens != null)
                {
                    var context = new FingerPrintAccessContext();
                    byte[] data = Convert.FromBase64String(tokens);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokensValues = decodedString.Split(':');
                    var username = tokensValues[0];
                    var password = tokensValues[1];
                    User user =
                        context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Username ==  username && u.Password == password);
                    if (user != null)
                    {
                        GenericIdentity identity = new GenericIdentity(user.Name);
                        identity.AddClaim(new Claim("Id",user.Id.ToString()));
                        IPrincipal principal = new GenericPrincipal(identity, user.Roles.Select(r => r.Name).ToArray());
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                    else
                    {

                        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
                        taskCompletionSource.SetResult(response);
                        return taskCompletionSource.Task;
                    }
                }
                return base.SendAsync(request, cancellationToken);
            }
            catch(Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
                taskCompletionSource.SetResult(response);
                return taskCompletionSource.Task;
            }
        }
    }
}