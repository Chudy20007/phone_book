using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhoneAPP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "MainPage", id = UrlParameter.Optional }
            );


            routes.MapRoute(
              name: "Manage",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Manage", id = UrlParameter.Optional }
          );
        }
    }
}
