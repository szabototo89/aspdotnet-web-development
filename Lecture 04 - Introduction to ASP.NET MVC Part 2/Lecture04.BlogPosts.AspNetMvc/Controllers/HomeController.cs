using System;
using System.Linq;
using System.Web.Mvc;
using Lecture04.BlogPosts.AspNetMvc.Controllers.ViewModels;
using Lecture04.BlogPosts.AspNetMvc.Repositories;
using Lecture04.BlogPosts.EntityFramework.Contexts;
using Lecture04.BlogPosts.EntityFramework.Domain;
using Lecture04.BlogPosts.EntityFramework.Repositories;

namespace Lecture04.BlogPosts.AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;

        public HomeController()
        {
            var context = new LocalDatabaseContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Lecture02.BlogPosts.EntityFramework.Contexts.LocalDatabaseContext;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            blogPostRepository = new DatabaseBlogPostRepository(context);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new BlogPostViewModel
            {
                TopBlogPosts = Enumerable.Empty<BlogPost>(),
                BlogPosts = blogPostRepository.GetBlogPosts()
            };

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View("About");
        }
    }
}