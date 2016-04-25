using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SuperheroManager.Library.Models;

namespace SuperheroManager.WebAPI.Controllers
{
    [RoutePrefix("api/team")]
    public class TeamController : ApiController
    {
        private readonly IApplicationRepository repository;

        public TeamController(IApplicationRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }


        [HttpGet]
        public IHttpActionResult GetTeams()
        {
            return Ok(repository.GetTeams());
        }
    }
}