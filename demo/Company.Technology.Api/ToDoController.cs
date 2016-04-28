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
    public class ToDoController : EndpointController
    {

        #region plugin members

        private const string RoutePattern= @"v{version}/todos";
        private const string WhitelistPattern = @"";
        private const string Id = "CAD93D07-16DF-4465-A800-5FF8C3471E5F";
        private const string Name = "Company ToDo Endpoint";
        private const string Description = "This endpoint provides REST API functionality for ToDo items";

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
            message = Request.CreateResponse(HttpStatusCode.OK, "here is my response");
            return message;
        }
    }
}
