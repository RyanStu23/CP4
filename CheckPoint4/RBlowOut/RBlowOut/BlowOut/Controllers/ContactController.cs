using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.msg = "Please call Support at " + "<u><strong>801-555-1212. </strong></u>" + " Thank you!";
            return View();
        }

        public ActionResult Email(string name, string email)
        {
            ViewBag.msg = "Thank you " + name + ". We will send an email to " + email;
            return View("Index");
        }
    }
}