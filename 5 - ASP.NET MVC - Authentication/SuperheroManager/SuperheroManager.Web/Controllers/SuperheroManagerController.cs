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
    public class SuperheroViewModel
    {
        public String Name { get; set; }

        public String NewSkill { get; set; }

        public List<String> Skills { get; set; }

        public List<String> AvailableTeams { get; set; }

        public List<String> CurrentTeams { get; set; }

        public SuperheroViewModel()
        {
            Skills = new List<String>();
            AvailableTeams = new List<String>();
            CurrentTeams = new List<String>();
        }

        public SuperheroViewModel(SuperheroViewModel other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            Name = other.Name;
            NewSkill = other.NewSkill;
            Skills = other.Skills;
            AvailableTeams = other.AvailableTeams;
            CurrentTeams = other.CurrentTeams;
        }
    }

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
            var model = new SuperheroViewModel()
            {
                AvailableTeams = repository.GetTeams().Select(team => team.Name).ToList()
            };

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(SuperheroViewModel model)
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

        private void CreateSuperhero(String name, IEnumerable<String> skills, IEnumerable<String> currentTeams)
        {
            var heroSkills = skills.Select(value => new Skill {Name = value, Value = 10}).ToArray();
            var teams = this.repository.GetTeams().Where(team => currentTeams.Any(value => value == team.Name)).ToArray();

            this.repository.AddSuperhero(name, heroSkills, teams);
        }
    }
}