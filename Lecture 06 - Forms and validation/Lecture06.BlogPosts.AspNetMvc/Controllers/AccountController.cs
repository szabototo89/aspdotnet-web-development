using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Lecture06.BlogPosts.AspNetMvc.Controllers.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Lecture06.BlogPosts.AspNetMvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
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

            var user = await userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                return View("Login", new LoginViewModel
                {
                    AdditionalMessage = "Wrong user name or password."
                });
            }

            await SignInAsync(user);

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
        public async Task<ActionResult> Register(RegisterViewModel model)
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

            var user = new IdentityUser(model.Username);

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return View("Login", new LoginViewModel
                {
                    AdditionalMessage = "User creation has failed."
                });
            }

            return View("Login", new LoginViewModel
            {
                AdditionalMessage = "User has been registered successfully.",
                Username = model.Username
            });
        }

        private async Task SignInAsync(IdentityUser user)
        {
            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(identity);
        }
    }
}