using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "ByReleaseDate",
            //    url: "movies/released/{year}/{month}",
            //    defaults: new
            //    {
            //        controller = "Movies", action = "ByReleaseDate", year = 2020, month = 01
            //    },
                
            //    new {year = @"\d{4}", month=@"\d{1,2}"}
            //    ); 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
