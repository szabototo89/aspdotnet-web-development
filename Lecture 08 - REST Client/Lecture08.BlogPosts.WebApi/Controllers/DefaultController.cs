using System;
using System.Linq;
using System.Web.Http;
using Lecture08.BlogPosts.EntityFramework.Contexts;
using Lecture08.BlogPosts.EntityFramework.Domain;
using Lecture08.BlogPosts.EntityFramework.Repositories;
using Lecture08.BlogPosts.WebApi.Models;

namespace Lecture08.BlogPosts.WebApi.Controllers
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
            var blogPosts = repository.GetBlogPosts().Select(blogPost => new BlogPostDataTransfer
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                Content = blogPost.Content,
                Authors = blogPost.Authors.Select(author => author.Id)
            });

            return Ok(blogPosts);
        }

        [HttpPut]
        [Route("api/blog-post/{blogPostId}")]
        public IHttpActionResult UpdateBlogPosts([FromUri] Int32 blogPostId, Int32 authorId)
        {
            var actualAuthor = repository.GetAuthors().FirstOrDefault(author => author.Id == authorId);
            repository.EditBlogPost(blogPostId, null, new [] { actualAuthor }, null);
            return Ok();
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
        public IHttpActionResult AddAuthor([FromBody] String fullName)
        {
            repository.AddAuthor(fullName);
            return Ok();
        }

        [HttpPut]
        [Route("api/author/{id}")]
        public IHttpActionResult ChangeAuthor([FromUri(Name = "id")] Int32 id, [FromBody] String fullName)
        {
            repository.ChangeAuthor(id, fullName);
            return Ok();
        }

        [HttpPut]
        [Route("api/author")]
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