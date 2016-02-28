using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroManager.Web.Models;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Controllers
{
    public class HomeControllerViewModel
    {
        public IEnumerable<Team> Teams { get; }

        public HomeControllerViewModel(IEnumerable<Team> teams)
        {
            Teams = teams;
        }
    }

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
    }
}