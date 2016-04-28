using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.ComponentModel.Composition;
using System.Net.Http;

namespace XF.WebApi
{
    [InheritedExport(typeof(IEndpointController))]
    public abstract class EndpointController : ApiController, IEndpointController
    {

        public abstract string GetDescription();
        public abstract Guid GetId();
        public abstract string GetName();

        public virtual int GetVersion() {  return 1; }

        public abstract string GetWhitelistPattern();

        public abstract string GetRouteTablePattern();

        public virtual void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                    name: ((IEndpointController)this).Name,
                    routeTemplate: ((IEndpointController)this).RouteTablePattern,
                    defaults: new { controller = ControllerName }
                );
        }

        string IEndpointController.Description
        {
            get
            {
                return GetDescription() ;
            }
        }

        Guid IEndpointController.Id
        {
            get
            {
                return GetId();
            }
        }

        string IEndpointController.Name
        {
            get
            {
                return GetName();
            }
        }

        int IEndpointController.Version
        {
            get
            {
                return GetVersion();
            }
        }

        string IEndpointController.WhitelistPattern
        {
            get
            {
                return GetWhitelistPattern();
            }
        }

        string IEndpointController.RouteTablePattern
        {
            get
            {
                return GetRouteTablePattern();
            }
        }

        void IEndpointController.Register(HttpConfiguration config)
        {
            Register(config);
        }

        protected string ControllerName
        {
            get
            {
                string output = string.Empty;
                string typename = this.GetType().Name;
                if (!String.IsNullOrWhiteSpace(typename) && typename.Contains("Controller"))
                {
                    int len = typename.IndexOf("Controller");
                    output = typename.Substring(0,len);
                }
                return output;
            }
        }
    }
}
