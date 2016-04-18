using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SuperheroManager.Library.Models;
using SuperHeroManager.DataModels.Contexts;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.WebAPI.Controllers
{
    [RoutePrefix("api/superhero")]
    public class SuperheroController : ApiController
    {
        private readonly IApplicationRepository repository;

        public SuperheroController(IApplicationRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Superhero> GetSuperheroes()
        {
            return repository.GetSuperheroes().ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public Superhero GetSuperhero(Int32 id)
        {
            return repository.GetSuperheroes().FirstOrDefault(superhero => superhero.Id == id);
        }

        [HttpPost]
        public IHttpActionResult AddSuperhero(Superhero superhero)
        {
            if (String.IsNullOrEmpty(superhero.Name))
            {
                return BadRequest("Name is required.");
            }

            this.repository.AddSuperhero(superhero.Name, superhero.Skills, superhero.Teams);
            return Ok();
        }
        
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult RemoveSuperhero(Int32 id)
        {
            this.repository.RemoveSuperhero(id);
            return Ok();
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult UpdateSuperhero([FromUri]Int32 id, [FromBody] Superhero superhero)
        {
            var oldSuperhero = this.repository.GetSuperheroes().FirstOrDefault(hero => hero.Id == id);
            if (oldSuperhero == null) return BadRequest($"Cannot be found hero (id: {id})");

            this.repository.RemoveSuperhero(id);
            this.repository.AddSuperhero(
                superhero.Name ?? oldSuperhero.Name, 
                superhero.Skills ?? oldSuperhero.Skills, 
                superhero.Teams ?? oldSuperhero.Teams
            );

            return Ok();
        }
    } 
}
