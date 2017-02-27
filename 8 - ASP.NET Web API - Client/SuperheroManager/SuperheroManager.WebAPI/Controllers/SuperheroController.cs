using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SuperheroManager.Library.Models;
using SuperHeroManager.DataModels.Contexts;
using SuperHeroManager.DataModels.Entities;

namespace SuperheroManager.WebAPI.Controllers
{
    [RoutePrefix("api/superhero")]
    public class SuperheroController : ApiController
    {
        private readonly IApplicationRepository repository;
        // GET, POST, PUT, DELETE

        public SuperheroController(IApplicationRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        // [Route("all")]
        [HttpGet]
        public IHttpActionResult GetSuperheroes()
        {
            return Ok(this.repository.GetSuperheroes().ToArray());
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetSuperhero([FromUri] Int32 id)
        {
            var hero = this.repository
                           .GetSuperheroes()
                           .FirstOrDefault(superhero => superhero.Id == id);

            if (hero == null)
            {
                return BadRequest("Superhero is not available.");
            }

            return Ok(hero);
        }

        [HttpPost]
        public IHttpActionResult CreateSuperhero(Superhero superhero)
        {
            var id = this.repository.AddSuperhero(
                superhero.Name, 
                superhero.Skills ?? Enumerable.Empty<Skill>(), 
                superhero.Teams ?? Enumerable.Empty<Team>(),
                isOnMission: false
            );

            return Ok(id);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult RemoveSuperhero([FromUri] Int32 id)
        {
            this.repository.RemoveSuperhero(id);
            return Ok();
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateSuperhero(
            [FromUri] Int32 id, [FromBody]Superhero superhero)
        {
            var hero = this.repository.GetSuperheroes().FirstOrDefault(h => h.Id == id);

            if (hero == null) return BadRequest("Superhero is not found");

            this.repository.RemoveSuperhero(id);
            this.repository.AddSuperhero(
                superhero.Name ?? hero.Name,
                superhero.Skills ?? hero.Skills ?? Enumerable.Empty<Skill>(),
                superhero.Teams ?? hero.Teams ?? Enumerable.Empty<Team>(),
                superhero.IsOnMission
            );

            return Ok();
        }
    } 
}
