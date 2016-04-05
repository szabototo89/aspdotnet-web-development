using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Server;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Controllers
{
    public class SuperheroViewModel
    {
        private readonly Superhero superhero;

        public SuperheroViewModel(Superhero superhero)
        {
            this.superhero = superhero;
        }

        public String Id => superhero.Id.ToString();

        public String Name => superhero.Name;

        public String Teams => String.Join(", ", superhero.Teams.Select(team => team.Name));

        public String Skills => String.Join(", ", superhero.Skills.Select(skill => skill.Name));

        public String Image
        {
            get
            {
                var base64String = Convert.ToBase64String(superhero.Image);
                return String.Format("data:image/png;base64,{0}", base64String);
            }
        }
    }
}