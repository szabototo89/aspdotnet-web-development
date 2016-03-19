using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SuperheroManager.Web.Models;

namespace SuperheroManager.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IApplicationRepository repository;

        public AccountController(IApplicationRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            this.repository = repository;
        }

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

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("Register", new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            if (String.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError(nameof(model.UserName), "User name is required.");
            }

            if (model.Password != model.PasswordAgain)
            {
                ModelState.AddModelError(nameof(model.Password), "Passwords are not matching.");
            }

            if (!ModelState.IsValid)
            {
                return View("Register", new RegisterViewModel());
            }

            repository.RegisterUser(model.UserName, model.Password);

            return RedirectToAction("Index", new LoginViewModel() { UserName = model.UserName, Password = model.Password });
        }
    }
}