using System;
using System.Linq;
using System.Web.Http;
using Lecture07.BlogPosts.EntityFramework.Contexts;
using Lecture07.BlogPosts.EntityFramework.Domain;
using Lecture07.BlogPosts.EntityFramework.Repositories;
using Lecture07.BlogPosts.WebApi.Models;

namespace Lecture07.BlogPosts.WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly DatabaseBlogPostRepository repository;

        public DefaultController()
        {
            var context = new LocalDatabaseContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BLOGDATABASE_25f1476eeb6f46e5b0cd8c7e02644db2;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            repository = new DatabaseBlogPostRepository(context);
        }

        private static AuthorDataTransfer AsSerialized(Author author) => new AuthorDataTransfer
        {
            Id = author.Id,
            FullName = author.FullName
        };

        [HttpGet]
        [Route("api/blog-post")]
        public IHttpActionResult GetBlogPosts()
        {
            var blogPosts = repository.GetBlogPosts();
            return Ok(blogPosts);
        }

        [HttpGet]
        [Route("api/author")]
        public IHttpActionResult GetAuthors()
        {
            var authors = repository.GetAuthors()
                                    .Select(AsSerialized);
            return Ok(authors);
        }

        [HttpGet]
        [Route("api/author/{id}")]
        public IHttpActionResult GetAuthor(Int32 id)
        {
            var foundAuthor = repository.GetAuthors().Select(AsSerialized).FirstOrDefault(author => author.Id == id);
            return Ok(foundAuthor);
        }

        [HttpPost]
        [Route("api/author")]
        public IHttpActionResult AddAuthor(String fullName)
        {
            repository.AddAuthor(fullName);
            return Ok();
        }

        [Route("api/author/{id}")]
        [HttpPut]
        public IHttpActionResult ChangeAuthor([FromUri(Name = "id")] Int32 id, [FromBody] String fullName)
        {
            repository.ChangeAuthor(id, fullName);
            return Ok();
        }

        [Route("api/author")]
        [HttpPut]
        public IHttpActionResult ChangeAuthor([FromBody] AuthorDataTransfer author)
        {
            repository.ChangeAuthor(author.Id, author.FullName);
            return Ok();
        }

        [HttpDelete]
        [Route("api/author/{id}")]
        public IHttpActionResult DeleteAuthor(Int32 id)
        {
            repository.DeleteAuthor(id);
            return Ok();
        }
    }
}