using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACMA.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public JsonResult CreateReport()
        {
            return Json(
                new { report = "reportTAL"});
        }

    }
}
