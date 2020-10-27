using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BasicAuth.Controllers
{
    public class CustomersController : ApiController
    {


        [BasicAuthentication]
        public HttpResponseMessage getCustomers()
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;


            return Request.CreateResponse(HttpStatusCode.OK, userName);

        }
    }
}
