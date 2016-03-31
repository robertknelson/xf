﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cyclops.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ServerAppUPload",
                url: "ServerApp/upload",
                defaults: new { controller = "ServerApp", action = "Upload" });
            routes.MapRoute(
                name: "ServerApp",
                url: "ServerApp/{id}",
                defaults: new { controller="ServerApp", action="Index",id=UrlParameter.Optional });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
