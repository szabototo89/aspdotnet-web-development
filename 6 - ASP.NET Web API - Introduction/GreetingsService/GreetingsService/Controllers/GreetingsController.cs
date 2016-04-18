using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GreetingsService.Models;

namespace GreetingsService.Controllers
{
    [RoutePrefix("api/greetings")]
    public class GreetingsController : ApiController
    {
        [HttpGet]
        [Route("hello")]
        public IHttpActionResult SayHello()
        {
            return Ok("Hello World!");
        }

        [HttpGet]
        [Route("person/random")]
        public IHttpActionResult RandomPerson()
        {
            var person = new Person()
            {
                Name = "Sherlock Homes",
                Address = new Address()
                {
                    City = "London",
                    StreetName = "Baker Street"
                }
            };

            return Ok(person);
        }

        [HttpPost]
        [Route("person")]
        public IHttpActionResult AddPerson([FromBody] Person person)
        {
            return Ok(new { id = 5 });
        }
    }
}
