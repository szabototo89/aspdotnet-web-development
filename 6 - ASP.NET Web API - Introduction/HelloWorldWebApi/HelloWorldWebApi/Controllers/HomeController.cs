using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelloWorldWebApi.Models;

namespace HelloWorldWebApi.Controllers
{
    // localhost:9000/api/home/ GET 
    [RoutePrefix("api/home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("message")]
        // api/home/message
        public IHttpActionResult GetMessage()
        {
            return Ok("Hello World!");
        }

        [HttpGet]
        [Route("person")]
        // api/home/person
        public IHttpActionResult GetPerson()
        {
            return Ok(new
            {
                Name = "John Doe",
                Address = new {City = "Budapest", Street = "Hungaria"}
            });
        }

        [HttpPost]
        [Route("person")]
        public IHttpActionResult PostPerson(Person person)
        {
            return Ok(person);
        }
    }
}
