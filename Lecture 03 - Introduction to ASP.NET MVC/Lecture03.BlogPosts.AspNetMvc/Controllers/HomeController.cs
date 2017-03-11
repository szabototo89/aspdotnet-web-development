using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture03.BlogPosts.AspNetMvc.Controllers.ViewModels;
using Lecture03.BlogPosts.EntityFramework.Domain;

namespace Lecture03.BlogPosts.AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", new HomeViewModel
            {
                BlogPosts = new[]
                {
                    new BlogPost
                    {
                        Content = "Hello World",
                        CreatedDate = DateTime.Now,
                        Title = "My first blog post"
                    }
                }
            });
        }
    }
}