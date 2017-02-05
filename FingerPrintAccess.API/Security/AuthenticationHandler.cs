using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                var tokens = request.Headers.Authorization.Parameter;
                var context = new FingerPrintAccessContext();
                if (tokens != null)
                {
                    byte[] data = Convert.FromBase64String(tokens);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokensValues = decodedString.Split(':');
                    var username = tokensValues[0];
                    var password = tokensValues[1];
                    User user =
                        context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Username ==  username && u.Password == password);
                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(user.Name), user.Roles.Select(r => r.Name).ToArray());
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
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
                    taskCompletionSource.SetResult(response);
                    return taskCompletionSource.Task;
                }
                return base.SendAsync(request, cancellationToken);
            }
            catch
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
                taskCompletionSource.SetResult(response);
                return taskCompletionSource.Task;
            }
        }
    }
}