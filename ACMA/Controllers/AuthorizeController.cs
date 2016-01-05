using ACMA.Models.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACMA.Controllers
{
    public class AuthorizeController : BaseController
    {

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (login.User == "admin" && login.Password == "pass")
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(login.User, false);
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    else return View("/Home/Index");
                }
            }
            return View();
        }


        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        [Authorize]
        public ActionResult Logue() {
            return View();
        }

        [HttpGet]
        public ActionResult RecoveryPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecoveryPassword(string email) {
            return View();
        }

    }
}
