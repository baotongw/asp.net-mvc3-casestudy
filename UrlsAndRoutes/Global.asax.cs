using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Template default route, optional segments
            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);

            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute", myRoute);

            //custom segment variables
            routes.MapRoute("customRoute", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "DefaultId" });

            ////firset segment start with the letter X
            //routes.MapRoute("", "X{controller}/{action}");

            //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action = "About" });

            ////firset segment must Public
            //routes.MapRoute("prefixUrl", "Public/{controller}/{action}", new { controller = "Home", action = "About" });

            ////Replace all request from shop controller to home 
            //routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });

            ////remove the specific request that won't be used anymore and redirect to the home/index page
            //routes.MapRoute("ShopSchema2", "Shop/OldAction", new { controller = "Home", action = "Index" });

            //Addtional segments, There is no upper limit to the number of segments that the URL pattern in this route will match
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",new { controller = "Home", action = "Index", id = UrlParameter.Optional });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}