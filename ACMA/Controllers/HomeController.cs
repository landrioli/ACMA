using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACMA.Models;

namespace ACMA.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        List<MenuItem> menu = new List<MenuItem>();

        public ActionResult Index()
        {
            return View(menu);
        }
    }
}
