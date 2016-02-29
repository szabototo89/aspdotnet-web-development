using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroManager.Web.Models;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdhocApplicationRepository repository;

        public HomeController()
        {
            repository = new AdhocApplicationRepository();
        }

        public ActionResult Index()
        {
            var model = new HomeControllerViewModel(repository.GetTeams());

            return View("Index", model);
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult GetTeams(String parameterName, Boolean isDescending)
        {
            var teams = repository.GetTeams().ToArray();
            Func<Team, Object> keySelector = team => team.Name;

            var orderedTeams = !isDescending 
                ? teams.OrderBy(keySelector)
                : teams.OrderByDescending(keySelector);

            return View("Index", new HomeControllerViewModel(orderedTeams, isDescending));
        }
    }
}