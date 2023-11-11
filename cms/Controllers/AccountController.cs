using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace cms.Controllers
{
    public class AccountController : Controller
    {
        private IAdminLoginRepository loginRepository;
        Mycmscontext db=new Mycmscontext();
        public AccountController()
        {
            loginRepository = new loginRepository(db);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login, string ReturnUrl="/")
        {
            if(loginRepository.IsExistUser(login.UserName,login.Password)) 
            {
                FormsAuthentication.SetAuthCookie("UserName", login.RemmeberMe);
                return Redirect(ReturnUrl);
            }
            else
            {
                ModelState.AddModelError("UserName", "کاربری یافت نشد");

            }
            return View(login);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");

        }
    }
}