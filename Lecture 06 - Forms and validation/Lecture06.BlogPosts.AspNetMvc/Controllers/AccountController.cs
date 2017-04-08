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

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var isUsernameProvided = !String.IsNullOrEmpty(model.Username);
            var isPasswordProvided = !String.IsNullOrEmpty(model.Password);

            if (!isUsernameProvided)
            {
                ModelState.AddModelError(nameof(model.Username), "User name is required.");
            }

            if (!isPasswordProvided)
            {
                ModelState.AddModelError(nameof(model.Password), "Password is required.");
            }

            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        private static Boolean ArePasswordMatching(RegisterViewModel model)
        {
            return model.Password == model.SecondaryPassword;
        }

        private static Boolean IsUserNameValid(RegisterViewModel model)
        {
            return !String.IsNullOrEmpty(model.Username);
        }

        private static Boolean IsPasswordStrong(RegisterViewModel model)
        {
            var password = model.Password;

            var doesPasswordContainNumber = password.Any(Char.IsNumber);
            var doesPasswordContainLetter = password.Any(Char.IsLetter);
            var isPasswordLongEnough = password.Length >= 4;

            return isPasswordLongEnough && doesPasswordContainNumber && doesPasswordContainLetter;
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (!ArePasswordMatching(model))
            {
                ModelState.AddModelError(nameof(model.Password), "Passwords are not matching.");
            }
            else if (!IsPasswordStrong(model))
            {
                ModelState.AddModelError(nameof(model.Password), "Password must contain at least one letter and one number and must be at least 4 characters long.");
            }

            if (!IsUserNameValid(model))
            {
                ModelState.AddModelError(nameof(model.Username), "User name is required.");
            }

            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }


            return View("Login", new LoginViewModel
            {
                AdditionalMessage = "User has been registered successfully.",
                Username = model.Username
            });
        }
    }
}