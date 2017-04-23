using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture06.BlogPosts.AspNetMvc.Controllers.ViewModels;

namespace Lecture06.BlogPosts.AspNetMvc.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            if (model.Password != model.SecondaryPassword)
            {
                ModelState.AddModelError(nameof(model.Password), "Passwords are not matching.");
            }

            if (!IsPasswordStrong(model))
            {
                ModelState.AddModelError(nameof(model.Password), "Password is not strong enough.");
            }

            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }



            return Redirect("Login");
        }

        private static Boolean IsPasswordStrong(RegisterViewModel model)
        {
            var password = model.Password;

            if (password == null) return false;

            var doesPasswordContainDigit = password.Any(Char.IsDigit);
            var doesPasswordContainLetter = password.Any(Char.IsLetter);
            var isPasswordLongEnough = password.Length >= 4;

            return doesPasswordContainDigit && 
                   doesPasswordContainLetter && 
                   isPasswordLongEnough;
        }
    }
}