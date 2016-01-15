using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACMA.Models.User;
using ACMA.Application.Services;
using System.Web.Script.Serialization;
using ACMA.Filters;

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
        public JsonResult RegisterUser(RegisterUserModel RegisterUser)
        {
            try
            {
                using (var accessService = new AccessService())
                {
                    accessService.RegisterNewUser(RegisterUser.ConvertModelToDomain());
                    return GetSuccessJson("Cadastro de Usuário", "O usuário foi cadastrado com sucesso.");
                }
            }
            catch (Exception)
            {
                return GetErrorJson("Cadastro de Usuário", "Não foi possível cadastrar o usuário. Tente novamente mais tarde.");
            }
        }

        public ActionResult SearchUser()
        {
            return View();
        }

        [NoDirectUrlAccess]
        public ActionResult UpdateUser(int id)
        {
            using (var accessService = new AccessService())
            {
                var user = accessService.GetUserById(id);
                return View(UpdateUserModel.ConvertDomainToModel(user));
            }
        }

        [HttpPost]
        public JsonResult UpdateUser(UpdateUserModel updateUserModel)
        {
            try
            {
                using (var accessService = new AccessService())
                {
                    accessService.UpdateUser(UpdateUserModel.ConvertModelToDomain(updateUserModel));
                    return GetSuccessJson("Alteração de dados de Usuário", "Os dados foram alterados com sucesso.");
                }
            }
            catch (Exception)
            {
                return GetErrorJson("Alteração de Usuário", "Não foi possível alterar os dados. Tente novamente mais tarde.");
            }
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            using (var accessService = new AccessService())
            {
                var users = accessService.GetAllUsers();
                var listGridUserModel = new List<GridUserModel>();

                foreach (var user in users)
                {
                    listGridUserModel.Add(GridUserModel.ConvertDomainToModel(user));
                }

                return new JsonResult()
               {
                   Data = SerializeJavaScript(listGridUserModel),
                   JsonRequestBehavior = JsonRequestBehavior.AllowGet
               };
            }
        }

        public ActionResult RemoveUser()
        {
            return View();
        }

        private string SerializeJavaScript(Object obj)
        {
            var jss = new JavaScriptSerializer();
            return jss.Serialize(obj);
        }
    }
}
