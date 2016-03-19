using System;
using System.Collections.Generic;
using SuperHeroManager.DataModels.Contexts;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Models
{
    public class StandardApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationContextBase context;

        public StandardApplicationRepository(ApplicationContextBase context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            this.context = context;
        }

        public IEnumerable<Team> GetTeams()
        {
            return context.Teams;
        }

        public IEnumerable<SuperHero> GetSuperheroes()
        {
            return context.Superheroes;
        }
    }
}