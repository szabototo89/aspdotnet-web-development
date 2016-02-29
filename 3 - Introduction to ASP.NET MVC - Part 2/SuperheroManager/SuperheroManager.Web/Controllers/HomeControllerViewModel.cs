using System;
using System.Collections.Generic;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Controllers
{
    public class HomeControllerViewModel
    {
        public IEnumerable<Team> Teams { get; }

        public Boolean IsDescending { get; }

        public HomeControllerViewModel(IEnumerable<Team> teams, Boolean isDescending = false)
        {
            Teams = teams;
            IsDescending = isDescending;
        }
    }
}