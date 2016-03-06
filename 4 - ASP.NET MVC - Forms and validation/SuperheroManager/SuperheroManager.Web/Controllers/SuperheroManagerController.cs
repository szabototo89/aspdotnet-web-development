using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroManager.Web.Utilities;

namespace SuperheroManager.Web.Controllers
{
    public class SuperheroViewModel
    {
        public String Name { get; set; }

        public String NewSkill { get; set; }

        public String SelectedSkill { get; set; }

        public String Skills { get; set; }

        public List<String> AvailableTeams { get; set; }

        public List<String> CurrentTeams { get; set; }

        public SuperheroViewModel()
        {
            Skills = String.Empty;
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

    public class SuperheroManagerController : Controller
    {
        public ActionResult Index()
        {
            var model = new SuperheroViewModel();

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(SuperheroViewModel model, String submitType)
        {
            switch (submitType)
            {
                case "Add skill":
                    return AddSkill(model);
                case "Remove selected skill":
                    return RemoveSkill(model);
            }

            return View("View", new SuperheroViewModel());
        }

        [HttpPost]
        public ActionResult AddSkill(SuperheroViewModel previousModel)
        {
            var skills = SkillExtensions.DeserializeSkills(previousModel.Skills);

            var model = new SuperheroViewModel(previousModel)
            {
                NewSkill = String.Empty,
                Skills = String.Join(",", skills.Concat(new [] { previousModel.NewSkill }))
            };

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult RemoveSkill(SuperheroViewModel previousModel)
        {
            var skills = SkillExtensions.DeserializeSkills(previousModel.Skills).ToList();
            skills.Remove(previousModel.SelectedSkill);

            var model = new SuperheroViewModel(previousModel)
            {
                Skills = SkillExtensions.SerializeSkills(skills)
            };

            return View("Index", model);
        }
    }
}