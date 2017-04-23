using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lecture05.BlogPosts.AspNetMvc.Controllers.ViewModels;
using Lecture05.BlogPosts.AspNetMvc.Repository;
using Lecture05.BlogPosts.EntityFramework.Contexts;
using Lecture05.BlogPosts.EntityFramework.Domain;
using Lecture05.BlogPosts.EntityFramework.Repositories;

namespace Lecture05.BlogPosts.AspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogPostRepository repository;

        public HomeController(IBlogPostRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var context = new LocalDatabaseContext(connectionString);
            //repository = new DatabaseBlogPostRepository(context);

            this.repository = repository;
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
        public ActionResult AddBlogPost()
        {
            return View("BlogPostDetails", new BlogPost
            {
                Id = 100, 
                Title = "Test 1",
                Content = "Test 2",
                Authors = new List<Author>()
                {
                    new Author { FullName = "John Doe" },
                    new Author { FullName = "Jane Doe" }
                }
            });
        }

        [HttpPost]
        public ActionResult AddBlogPost(String title, String[] author, String content)
        {
            if (String.IsNullOrEmpty(title))
            {
                ModelState.AddModelError("title", "Title cannot be blank.");
            }

            if (String.IsNullOrEmpty(content))
            {
                ModelState.AddModelError("content", "Content cannot be blank.");
            }

            if (author == null || author.Length == 0)
            {
                ModelState.AddModelError("author", "At least one author is required");
            }

            if (!ModelState.IsValid)
            {
                return View("BlogPostDetails");
            }

            repository.AddBlogPost(title, author, content);

            return RedirectToAction("Index");
        }
    }
}