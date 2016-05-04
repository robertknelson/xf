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
    public class ContactController : EndpointController
    {
        private const string RoutePattern = @"v{version}/contacts";
        private const string WhitelistPattern = @"";
        private const string Id = "BBDDDCA5-DA77-40C3-AFFE-694227F80E73";
        private const string Name = "Company Contact Endpoint";
        private const string Description = "This endpoint provides REST API functionality for Contacts";

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

        public override string GetRouteTablePattern()
        {
            return RoutePattern;
        }

        public override string GetWhitelistPattern()
        {
            return WhitelistPattern;
        }


        public HttpResponseMessage Get(int version)
        {
            HttpResponseMessage message = null;
            message = Request.CreateResponse(HttpStatusCode.OK, "here is my response");
            return message;
        }
    }
}
