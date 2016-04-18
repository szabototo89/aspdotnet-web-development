using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Controllers
{
    public class SuperheroListViewModel
    {
        public IEnumerable<Superhero> Superheroes { get; set; }
    }
}