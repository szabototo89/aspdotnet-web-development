using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SuperheroManager.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", new LoginViewModel { UserName = "", Password = "" });
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            if (String.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError(nameof(model.UserName), "User name has not been passed.");
            }

            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserName, createPersistentCookie: false);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user name or password.");
                }
            }

            return View("Index", new LoginViewModel {UserName = "", Password = ""});
        }

        public ActionResult Register(RegisterViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            if (String.IsNullOrEmpty(model.UserName))
            {
                
            }

            if (model.Password != model.PasswordAgain)
            {
                ModelState.AddModelError(nameof(model.Password), "Passwords are not matching");
            }

            return View("Index");
        }
    }
}