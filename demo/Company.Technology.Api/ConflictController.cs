using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Threading.Tasks;
using XF.WebApi;

namespace Company.Technology.Api
{

    public class ConflictController : EndpointController
    {

        #region plugin members

        private const string RoutePattern = @"v{version}/todos";
        private const string WhitelistPattern = @"";
        private const string Id = "2C526773-A6FA-4199-BE1F-8C775BEB98AD";
        private const string Name = "Conflict Endpoint";
        private const string Description = "This endpoint provides REST API functionality for Something";

        public override string GetDescription()
        {
            return Description;
        }

        public override Guid GetId()
        {
            return new Guid(Id);
        }

        public override string GetName()
        {
            return Name;
        }

        public override string GetWhitelistPattern()
        {
            return WhitelistPattern;
        }

        public override string GetRouteTablePattern()
        {
            return RoutePattern;
        }

        #endregion

        public HttpResponseMessage Get(int version)
        {
            HttpResponseMessage message = null;
            message = Request.CreateResponse(HttpStatusCode.OK, "here is my response (ConflictController)");
            return message;
        }
    }
}
