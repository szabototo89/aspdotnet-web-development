using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroManager.Web.Models;
using SuperheroManager.Web.Utilities;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Controllers
{
    [Authorize]
    public class SuperheroManagerController : Controller
    {
        private readonly IApplicationRepository repository;

        public SuperheroManagerController(IApplicationRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new SuperheroRegistrationViewModel()
            {
                AvailableTeams = repository.GetTeams().Select(team => team.Name).ToList()
            };

            return View("Index", model);
        }

        [HttpGet]
        public ActionResult SuperheroList()
        {
            var model = new SuperheroListViewModel
            {
                Superheroes = repository.GetSuperheroes()
            };

            return View("SuperheroView", model);
        }

        [HttpGet]
        public ActionResult RemoveHero(Int32 id)
        {
            repository.RemoveSuperhero(id);

            return RedirectToAction("SuperheroList");
        }

        private void CreateSuperhero(String name, IEnumerable<String> skills, IEnumerable<String> currentTeams)
        {
            var heroSkills = skills.Select(value => new Skill {Name = value, Value = 10}).ToArray();
            var teams = this.repository.GetTeams().Where(team => currentTeams.Any(value => value == team.Name)).ToArray();

            this.repository.AddSuperhero(name, heroSkills, teams);
        }

        [HttpPost]
        public ActionResult Index(SuperheroRegistrationViewModel model)
        {
            if (String.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("Name", "Name cannot be empty.");
            }

            if (model.Skills.Count > 3)
            {
                ModelState.AddModelError("Skills", "Skills cannot be more than 3.");
            }

            if (!model.CurrentTeams.Any())
            {
                ModelState.AddModelError("CurrentTeams", "Superhero must be assigned to a team.");
            }

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            CreateSuperhero(model.Name, model.Skills, model.CurrentTeams);

            return View("Notification", (Object)"Superhero has been added successfully.");
        }
    }
}