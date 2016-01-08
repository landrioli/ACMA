using ACMA.Application.Services;
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
        public JsonResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                using (var accessService = new AccessService())
                {
                    var canLogin = accessService.Login(login.ConvertModelToDomain());
                    if (canLogin)
                    {
                        System.Web.Security.FormsAuthentication.SetAuthCookie(login.UserName, false);
                        return GetSuccessJson("", "");

                    }
                    return GetErrorJson("Login", "Usuário ou senha inválidos.");
                }
            }
            return GetErrorJson("Login", "Usuário ou senha inválidos.");
        }


        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect("/Authorize/Login");
        }

        [Authorize]
        public ActionResult Logue()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RecoveryPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecoveryPassword(string email)
        {
            try
            {
                using (var accessService = new AccessService())
                {
                    accessService.RecoveryPassword(email);
                    return GetErrorJson("Recuperar Senha", "Foi enviado uma notificação com uma nova senha para o email do usuário cadastrado.");
                }
            }
            catch (Exception)
            {
                return GetErrorJson("Recuperar Senha", "O email informado não existe.");
            }

        }

    }
}
