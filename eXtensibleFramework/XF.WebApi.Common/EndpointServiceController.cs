using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using XF.Common;

namespace XF.WebApi
{
    public abstract class EndpointServiceController : ApiController, IEndpointController
    {

        private IModelRequestService _Service = null;
        protected IModelRequestService Service
        {
            get
            {
                if (_Service == null)
                {
                    _Service = new PassThroughModelRequestService(
                        new DataRequestService(new XF.DataServices.ModelDataGatewayDataService())
                        );
                }
                return _Service;
            }
            set
            {
                _Service = value;
            }
        }

        public abstract string Description { get; }
        public abstract Guid Id { get; }
        public abstract string Name { get; }

        public abstract int Version { get; }

        public abstract string WhitelistPattern { get; }

        public abstract string RouteTablePattern { get; }

        public abstract void Register(HttpConfiguration config);

        string IEndpointController.Description
        {
            get
            {
                return Description;
            }
        }

        Guid IEndpointController.Id
        {
            get
            {
                return Id;
            }
        }

        string IEndpointController.Name
        {
            get
            {
                return Name;
            }
        }

        int IEndpointController.Version
        {
            get
            {
                return Version;
            }
        }

        string IEndpointController.WhitelistPattern
        {
            get
            {
                return WhitelistPattern;
            }
        }

        string IEndpointController.RouteTablePattern
        {
            get
            {
                return RouteTablePattern; ;
            }
        }

        void IEndpointController.Register(HttpConfiguration config)
        {
            Register(config);
        }

    }
}
