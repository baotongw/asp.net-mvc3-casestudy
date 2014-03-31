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
    }
}
