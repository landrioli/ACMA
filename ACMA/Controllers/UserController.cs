using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACMA.Models.User;

namespace ACMA.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(RegisterUserModel RegisterUser)
        {
            return View();
        }

        public ActionResult UpdateUser()
        {
            return View();
        }

        public ActionResult RemoveUser()
        {
            return View();
        }
    }
}
