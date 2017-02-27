using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Server;
using SuperHeroManager.DataModels.Entities;

namespace SuperheroManager.Web.Controllers
{
    public class HomeControllerViewModel
    {
        public String TeamName { get; set; }

        public IEnumerable<Team> Teams { get; }

        public Boolean? IsDescending { get; }

        public Int32 MaxPages { get; set; }

        public Int32 CurrentPage { get; set; }

        public HomeControllerViewModel(IEnumerable<Team> teams, Boolean? isDescending = null, Int32 currentPage = 0, Int32 maxPages = 1)
        {
            TeamName = String.Empty;
            Teams = teams;
            MaxPages = maxPages;
            IsDescending = isDescending;
            CurrentPage = currentPage;
        }
    }
}