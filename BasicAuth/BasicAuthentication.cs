using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuth
{
    public class BasicAuthentication :AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string credentials = actionContext.Request.Headers.Authorization.Parameter;

                string decodeCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(credentials));

                //Split UserNAme and Pssword
                string userName = decodeCredentials.Split(':')[0];
                string password = decodeCredentials.Split(':')[1];

                if (CustomerSecurity.Login(userName, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

                }
            }
        }
    }
}