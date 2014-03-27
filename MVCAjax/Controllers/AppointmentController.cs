using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAjax.Models;

namespace MVCAjax.Controllers
{
    public class AppointmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string id)
        {
            return View("Index", (object)id);
        }

        public ActionResult AppointmentData(string id)
        {
            IEnumerable<Appointment> data = new[] { 
                new Appointment {ClientName="Joe", Date=DateTime.Parse("1/1/2012")},
                new Appointment { ClientName = "Joe", Date = DateTime.Parse("3/1/2012")},
                new Appointment { ClientName = "Jane", Date = DateTime.Parse("1/20/2012")},
                new Appointment { ClientName = "Jane", Date = DateTime.Parse("1/22/2012")},
                new Appointment {ClientName = "Bob", Date = DateTime.Parse("2/25/2012")},
                new Appointment {ClientName = "Bob", Date = DateTime.Parse("2/25/2013")}
            };

            System.Threading.Thread.Sleep(1000);//fake data process

            if (!string.IsNullOrEmpty(id) && id != "All") {
                data = data.Where(e => e.ClientName == id);
            }

            if (Request.IsAjaxRequest())
            {
                return Json(data.Select(m => new
                {
                    ClientName = m.ClientName,
                    Date = m.Date.ToShortDateString()
                }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(data);
            }
        }

        //public JsonResult JsonData(string id)
        //{
        //    IEnumerable<Appointment> data = new[] {
        //        new Appointment { ClientName = "Joe", Date = DateTime.Parse("1/1/2012")},
        //        new Appointment { ClientName = "Joe", Date = DateTime.Parse("2/1/2012")},
        //        new Appointment { ClientName = "Joe", Date = DateTime.Parse("3/1/2012")},
        //        new Appointment { ClientName = "Jane", Date = DateTime.Parse("1/20/2012")},
        //        new Appointment { ClientName = "Jane", Date = DateTime.Parse("1/22/2012")},
        //        new Appointment {ClientName = "Bob", Date = DateTime.Parse("2/25/2012")},
        //        new Appointment {ClientName = "Bob", Date = DateTime.Parse("2/25/2013")}
        //        };

        //    if (!string.IsNullOrEmpty(id) && id != "All")
        //    {
        //        data = data.Where(e => e.ClientName == id);
        //    }

        //    var formattedData = data.Select(m => new
        //    {
        //        ClientName = m.ClientName,
        //        Date = m.Date.ToShortDateString()
        //    });

        //    return Json(formattedData, JsonRequestBehavior.AllowGet);
        //}
    }
}
