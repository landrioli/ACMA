using ACMA.Models;
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
