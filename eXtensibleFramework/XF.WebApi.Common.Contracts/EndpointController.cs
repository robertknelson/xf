using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.ComponentModel.Composition;

namespace XF.WebApi
{
    [InheritedExport(typeof(IEndpointController))]
    public abstract class EndpointController : IEndpointController
    {

        public abstract string Description { get; }
        public abstract Guid Id { get; }
        public abstract string Name { get; }

        public abstract void Register(HttpConfiguration config);

        string IEndpointController.Description
        {
            get
            {
                return Description ;
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

        void IEndpointController.Register(HttpConfiguration config)
        {
            Register(config);
        }

    }
}
