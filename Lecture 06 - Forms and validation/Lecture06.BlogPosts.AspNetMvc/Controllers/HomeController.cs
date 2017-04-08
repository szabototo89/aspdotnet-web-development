using System;
using System.Linq;
using System.Web.Mvc;
using Lecture06.BlogPosts.AspNetMvc.Controllers.ViewModels;
using Lecture06.BlogPosts.EntityFramework.Domain;
using Lecture06.BlogPosts.EntityFramework.Repositories;

namespace Lecture06.BlogPosts.AspNetMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBlogPostRepository repository;

        public HomeController(IBlogPostRepository blogPostRepository)
        {
            //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var context = new LocalDatabaseContext(connectionString);
            //repository = new DatabaseBlogPostRepository(context);

            repository = blogPostRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new BlogPostsViewModel
            {
                TopBlogPosts = Enumerable.Empty<BlogPost>(),
                BlogPosts = repository.GetBlogPosts()
            };

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View("About");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("BlogPostDetails", new BlogPostDetailsViewModel(null));
        }


        [HttpPost]
        public ActionResult CreateOrEditBlogPost(Int32? id, String title, String[] authors, String content)
        {
            if (String.IsNullOrEmpty(title))
            {
                ModelState.AddModelError(nameof(title), "Title must have a value.");
            }

            if (String.IsNullOrEmpty(content))
            {
                ModelState.AddModelError(nameof(content), "Content must have a value.");
            }

            if (authors == null || authors.Length == 0)
            {
                ModelState.AddModelError(nameof(authors), "At least one author must be specified.");
            }

            if (!ModelState.IsValid)
            {
                return View("BlogPostDetails", new BlogPostDetailsViewModel(null));
            }

            if (!id.HasValue)
            {
                repository.AddBlogPost(title, authors, content);
            }
            else
            {
                repository.EditBlogPost(id.Value, title, authors, content);
            }
            
            return RedirectToAction("Index");
        }
    }
}