using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lecture07.BlogPosts.EntityFramework.Contexts;
using Lecture07.BlogPosts.EntityFramework.Repositories;

namespace Lecture07.BlogPosts.WebAPI.Demo.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly DatabaseBlogPostRepository repository;

        public DefaultController()
        {
            var context = new LocalDatabaseContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BLOGDATABASE_25f1476eeb6f46e5b0cd8c7e02644db2;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            this.repository = new DatabaseBlogPostRepository(context);
        }

        [HttpGet]
        [Route("api/author")]
        public IHttpActionResult GetAuthors()
        {
            var authors = GetAuthorsFromRepository(repository);
            return Ok(authors);
        }

        private IEnumerable<AuthorDTO> GetAuthorsFromRepository(DatabaseBlogPostRepository repository)
        {
            return repository.GetAuthors()
                             .Select(author => new AuthorDTO
                             {
                                 Id = author.Id,
                                 FullName = author.FullName
                             });
        }

        [HttpGet]
        [Route("api/author/{id}")]
        public IHttpActionResult GetAuthor(Int32 id)
        {
            var actualAuthor = GetAuthorsFromRepository(repository)
                .FirstOrDefault(author => author.Id == id);
            return Ok(actualAuthor);
        }

        [HttpDelete]
        [Route("api/author/{id}")]
        public IHttpActionResult DeleteAuthor(Int32 id)
        {
            try
            {
                repository.DeleteAuthor(id);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        [Route("api/author")]
        public IHttpActionResult AddAuthor(String fullName)
        {
            try
            {
                repository.AddAuthor(fullName);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        [Route("api/author/{id}")]
        public IHttpActionResult UpdateAuthor([FromUri] Int32 id, [FromBody] AuthorDTO author)
        {
            try
            {
                if (author == null) throw new ArgumentNullException(nameof(author));
                repository.ChangeAuthor(id, author.FullName);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}