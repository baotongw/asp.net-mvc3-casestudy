using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        //If we define parameters to our action method with names that match the URL
        //pattern variables, the MVC Framework will pass the values obtained from the URL as parameters to the
        //action method

        //We have defined the id parameter as a string, but the MVC Framework will try to convert the URL
        //value to whatever parameter type we define
        public ViewResult CustomVariable(string id)
        {
            //This method obtains the value of the custom variable in the route URL pattern and passes it to the
            //view using the ViewBag
            //ViewBag.CustomVariable = RouteData.Values["id"];
            ViewBag.CustomVariable = id;
            return View();
        }

        public ViewResult MyActionMethod()
        {
            string myActionUrl = Url.Action("Index", new { id = "TestID" });

            string myRouteUrl = Url.RouteUrl(new { });

            return View("Index");
        }

        public ActionResult MyActionRedirect()
        {
            return RedirectToAction("Index");
        }

        public ActionResult MyOtherActionMethod() { 
            //If you want to send a redirect using a URL generated from just object properties, you can use the
            //RedirectToRoute method, as shown in Listing 11-41.
            //Listing 11-41. Redirecting to a URL Generated from Properties in an Anonymous Type

            return RedirectToRoute(new { controller = "Home", action = "Index", id = "MyID" });

            //This method also returns a RedirectToRouteResult object and has exactly the same effect as calling
            //the RedirectToAction method.
        }
    }
}
