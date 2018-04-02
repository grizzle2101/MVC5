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

            //Task 1 - Create a Custom Route
            //Must Define Routes from MOST Specfic to least,
            //As the most Generic one will ALWAYS be applied.

            //Task 3 - Force Parameter Constraints
            //We want year to be 4 and month to be 2 digits.
            //routes.MapRoute(
            //               name: "MoviesByReleaseDate",
            //               url: "movies/released/{year}/{month}",
            //               defaults: new { controller = "Movies", action = "ByReleaseDate" },
            //               constraints: new { year = @"\d{4}", month = @"\d{2}"}
            //               );

            //Task 4 - Force even more specific Constraints. 
            routes.MapRoute(
               name: "MoviesByReleaseDate",
               url: "movies/released/{year}/{month}",
               defaults: new { controller = "Movies", action = "ByReleaseDate" },
               constraints: new { year = @"2015|2016", month = @"\d{2}" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
