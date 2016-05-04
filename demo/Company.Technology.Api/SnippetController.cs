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
    public class SnippetController : EndpointController
    {
        private const string RoutePattern = @"v{version}/snippets";
        private const string WhitelistPattern = @"";
        private const string Id = "8E5D5487-E36A-4E51-821A-6806D2474958";
        private const string Name = "Company Snippets Endpoint";
        private const string Description = "This endpoint provides REST API functionality for Snippets";

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
