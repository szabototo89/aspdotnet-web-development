using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture03.BlogPosts.AspNetMvc.Controllers.ViewModels;
using Lecture03.BlogPosts.EntityFramework.Domain;

namespace Lecture03.BlogPosts.AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // Razor
        public ActionResult Index()
        {
            var model = new BlogPostViewModel
            {
                TopBlogPosts = new[]
                {
                    new BlogPost
                    {
                        Content = "Test Top Blog Post",
                        CreatedDate = DateTime.Now.AddDays(-1),
                        Title = "Top Blog Post"
                    }
                },

                BlogPosts = Enumerable.Repeat(0, 100)
                                      .Select(element => new BlogPost
                                      {
                                          Title = "Test Title",
                                          CreatedDate = DateTime.Now,
                                          Content = "Test Content"
                                      })
            };

            return View("Index", model);
        }
    }
}