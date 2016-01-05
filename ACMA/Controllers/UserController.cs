using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACMA.Models.User;
using ACMA.Application.Services;

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
            try
            {
                using (var accessService = new AccessService())
                {
                    accessService.RegisterNewUser(RegisterUser.ConvertModelToDomain());
                    return GetSuccessJson("Cadastro de Usuário","O usuário foi cadastrado com sucesso.");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
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
