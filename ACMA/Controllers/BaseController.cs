using ACMA.Models;
using ACMA.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACMA.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        List<MenuItem> menuList = new List<MenuItem>();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            loadMenu();
            ViewBag.menuList = menuList;
            base.OnActionExecuting(filterContext);
        }

        protected JsonResult GetErrorJson(string title, Exception exception)
        {
            return GetErrorJson(title, exception.Message);
        }

        protected JsonResult GetErrorJson(string title, string mensagem)
        {
            return new JsonResponse()
                .Success(false)
                .Title(title)
                .Message(mensagem)
                .CreateResponse();
        }

        protected JsonResult GetSuccessJson(string title, string mensagem)
        {
            return GetSuccessJson(title, mensagem, null);
        }

        protected JsonResult GetSuccessJson(string title,string message = null, object data = null)
        {
            return new JsonResponse()
                .Success(true)
                .Title(title)
                .Message(message)
                .Data(data)
                .CreateResponse();
        }

        private void loadMenu()
        {
            menuList.Add(new MenuItem()
            {
                Id = 1,
                ItemName = "Dashboard",
                Key = "Dashboard",
                ParentId = 0,
                ActionName = "Index",
                Controller = "Home",
                Description = "Dashboard",
                HasSubMenu = false
            });
            menuList.Add(new MenuItem()
            {
                Id = 2,
                ItemName = "Assets",
                Key = "Assets",
                ParentId = 0,
                ActionName = "Assets",
                Controller = "Home",
                Description = "Assets",
                HasSubMenu = true
            });
            menuList.Add(new MenuItem()
            {
                Id = 3,
                ItemName = "CreateAssets",
                Key = "Dashboard",
                ParentId = 2,
                ActionName = "CreateAssets",
                Controller = "Home",
                Description = "CreateAssets",
                HasSubMenu = false
            });
            menuList.Add(new MenuItem()
            {
                Id = 4,
                ItemName = "CreateAssets",
                Key = "Dashboard",
                ParentId = 2,
                ActionName = "CreateAssets",
                Controller = "Home",
                Description = "CreateAssets",
                HasSubMenu = false
            });
            menuList.Add(new MenuItem()
            {
                Id = 5,
                ItemName = "Login",
                Key = "Login",
                ParentId = 0,
                ActionName = "Login",
                Controller = "Authorize",
                Description = "Login",
                HasSubMenu = false
            });
            menuList.Add(new MenuItem()
            {
                Id = 6,
                ItemName = "Logue",
                Key = "Logue",
                ParentId = 0,
                ActionName = "Logue",
                Controller = "Authorize",
                Description = "Logue",
                HasSubMenu = false
            });
        }
    }
}
