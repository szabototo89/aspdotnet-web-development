using System;
using System.Collections.Generic;
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

        public ActionResult ShowWithPagination(IEnumerable<Team> teams, Boolean? isDescending, Int32 page)
        {
            var count = 5;
            var originalTeams = teams.ToArray();

            IEnumerable<Team> currentTeams = originalTeams;

            if (isDescending.HasValue)
            {
                currentTeams = isDescending == false
                    ? currentTeams.OrderBy(team => team.Name)
                    : currentTeams.OrderByDescending(team => team.Name);
            }

            currentTeams = currentTeams.Skip(page * count).Take(count);
            var maxPages = (Int32)Math.Floor(originalTeams.Length / (Double)count);
            var model = new HomeControllerViewModel(currentTeams, isDescending, page, maxPages);

            return View("Index", model);
        }

        public ActionResult Index(Int32 page = 0)
        {
            var originalTeams = repository.GetTeams().ToArray();
            return ShowWithPagination(originalTeams, null, page);
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult GetTeams(Boolean isDescending, Int32 page)
        {
            var teams = repository.GetTeams().ToArray();
            return ShowWithPagination(teams, isDescending, page);
        }
    }
}