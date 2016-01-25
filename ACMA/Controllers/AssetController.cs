using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACMA.Controllers
{
    public class AssetController : Controller
    {

        public ActionResult CreateAsset()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAsset()
        {
            return View();
        }

        public ActionResult RemoveAsset()
        {
            return View();
        }

        public ActionResult UpdateAsset()
        {
            return View();
        }

    }
}
