using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        //
        // GET: /Derived/
        public void Index()
        {
            string controller = (string)RouteData.Values["controller"];
            string action = (string)RouteData.Values["action"];
            Response.Write(string.Format("Controller: {0}, Action: {1}", controller, action));
            // ... or ...
            //Response.Redirect("/Some/Other/Url");
        }

        public ActionResult myIndex()
        {
            ViewBag.message = "Hello from the derived controller index method";
            return View("myView");
        }

        public ActionResult Redirect()
        {
            //return new RedirectResult("/Derived/Index");
            //Convenience method for RedirectResult method
            return Redirect("/derived/index");
        }

        public ActionResult RenameProduct()
        {
            // Access various properties from context objects
            string userName = User.Identity.Name;
            string serverName = Server.MachineName;
            string clientIP = Request.UserHostAddress;
            DateTime dateStamp = HttpContext.Timestamp;
            //AuditRequest(userName, serverName, clientIP, dateStamp, "Renaming product");
            // Retrieve posted data from Request.Form
            string oldProductName = Request.Form["OldName"];
            string newProductName = Request.Form["NewName"];
            //bool result = AttemptProductRename(oldProductName, newProductName);
            //ViewData["RenameResult"] = result;
            return View("ProductRenamed");
        }
    }
}
