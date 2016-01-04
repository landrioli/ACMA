using ACMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACMA.Controllers
{
    public class AccessController : BaseController
    {
        //
        // GET: /Access/

        public ActionResult Index()
        {
            return View();
        }
    }
}
