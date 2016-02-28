using System.Collections.Generic;
using System.Linq;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Models
{
    public class AdhocApplicationRepository : IApplicationRepository
    {
        public IEnumerable<Team> GetTeams()
        {
            foreach (var index in Enumerable.Range(0, 10))
            {
                yield return new Team
                {
                    Id = index,
                    Name = $"Superhero {index}",
                    SuperHeroes = new List<SuperHero>()
                };
            }
        }
    }
}