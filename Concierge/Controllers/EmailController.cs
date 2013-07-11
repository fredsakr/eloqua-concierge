using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Postal;

namespace Concierge.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Email/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Profile()
        {
            dynamic email = new Email("Profile");
            return View();
        }
    }
}
