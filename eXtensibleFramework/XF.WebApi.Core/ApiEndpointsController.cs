using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace XF.WebApi.Core
{
    public class ApiEndpointsController : Controller
    {
        public ActionResult Index()
        {
            //WebApiRegistrar.EndpointManager.Endpoints
            return View(WebApiRegistrar.EndpointManager.Endpoints);
        }
    }
}
