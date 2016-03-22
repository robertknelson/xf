using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Cyclops.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SelectListItemCache.Instance.RegisterProvider("zones", SelectionListUtility.GetZones, true);
            SelectListItemCache.Instance.RegisterProvider("hosting", SelectionListUtility.GetHosting, true);
            SelectListItemCache.Instance.RegisterProvider("operating-systems", SelectionListUtility.GetOperatingSystems, true);
            SelectListItemCache.Instance.RegisterProvider("server-security", SelectionListUtility.GetServerSecurity, true);
            SelectListItemCache.Instance.RegisterProvider("app-types", SelectionListUtility.GetAppTypes, true);
            SelectListItemCache.Instance.RegisterProvider("domains", SelectionListUtility.GetDomains, true);
            SelectListItemCache.Instance.RegisterProvider("scopes", SelectionListUtility.GetScopes, true);
            SelectListItemCache.Instance.RegisterProvider("artifact-type", SelectionListUtility.GetArtifactTypes, true);
            SelectListItemCache.Instance.RegisterProvider("artifact-scope", SelectionListUtility.GetArtifactScopes, true);

        }
    }
}
