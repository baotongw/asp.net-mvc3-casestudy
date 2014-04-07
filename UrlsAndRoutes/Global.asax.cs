using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

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
            #region used for static file route
            //routes.RouteExistingFiles = true;

            //routes.MapRoute("DiskFile", "Content/StaticContent.html",
            //    new { controller = "Account", action = "LogOn" },
            //    new { customConstraint = new UserAgentConstraint("IE") });

            //routes.IgnoreRoute("Content/{filename}.html");

            //routes.MapRoute("DiskFile", "Content/StaticContent.html",
            //new
            //{
            //    controller = "Account",
            //    action = "LogOn",
            //},
            //new
            //{
            //    customConstraint = new UserAgentConstraint("IE")
            //});
            #endregion

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute("NewRoute", "App/Do{action}", new { controller = "Home" });

            //There are two reasons for naming your routes:
            //  • As a reminder of the purpose of the route
            //  • So that you can select a specific route to be used to generate an outgoing URL
            routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //Template default route, optional segments
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add("MyRoute", myRoute);

            //custom segment variables
            //routes.MapRoute("customRoute",
            //    "{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = "DefaultId" },
            //    new[] { "UrlsAndRoutes.Controllers" });//Specify the namespace that route will looking at first priority

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
            //routes.MapRoute("MyRoute",
            //    "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new
            //    {
            //        controller = "^H.*",
            //        action = "^Index$|^About$",
            //        httpmethod = new HttpMethodConstraint(new[] { "GET" }),
            //        customConstraint = new UserAgentConstraint("IE")
            //    },
            //    //the route will match URLs only when the controller variable begins with the letter H and the action variable is Index or About
            //    new[] { "URLsAndRoutes.Controllers" });

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