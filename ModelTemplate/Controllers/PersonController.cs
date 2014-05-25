using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelTemplate.Models;

namespace ModelTemplate.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /Person/

        public ActionResult Index()
        {
            Person person = new Person()
            {
                FirstName = "Wang",
                PersonId = 1000,
                LastName = "baotong",
                BirthDate = new DateTime(1989, 2, 21),
                HomeAddress = new Address() { Line1 = "1", Line2 = "2", City = "beijing", PostalCode = "100081", Country = "China" },
                IsApproved = true,
                Role = Role.Admin
            };

            return View(person);
        }
    }
}
