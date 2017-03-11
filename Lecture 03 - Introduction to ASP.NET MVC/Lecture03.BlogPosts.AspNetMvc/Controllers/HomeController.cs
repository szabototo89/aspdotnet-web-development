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
            var random = new Random((Int32)DateTime.Now.Ticks);

            return View("Index", new HomeViewModel
            {
                TopBlogPosts = new[]
                {
                    new BlogPost
                    {
                        Content = "Another blog post content",
                        CreatedDate = DateTime.Now.AddDays(-10),
                        Title = "Another blog post title"
                    }
                },
                BlogPosts = Enumerable.Repeat(0, 100)
                    .Select(element => new BlogPost
                    {
                        Content = "Hello World",
                        CreatedDate = DateTime.Now.AddDays(-random.Next(0, 365)),
                        Title = "My first blog post"
                    })
            });
        }
    }
}