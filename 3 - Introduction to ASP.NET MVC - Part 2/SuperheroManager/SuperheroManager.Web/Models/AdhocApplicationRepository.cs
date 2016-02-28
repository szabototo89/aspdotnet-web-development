using System;
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
                    SuperHeroes = new List<SuperHero>(
                        Enumerable.Range(0, 10).Select(i => new SuperHero()
                        {
                            Id = i,
                            IsOnMission = false,
                            Name = $"Superhero {i + 1}",
                            Skills = new List<Skill>(),
                            Teams = new List<Team>()
                        })
                    )
                };
            }
        }

        public IEnumerable<SuperHero> GetSuperheroes()
        {
            throw new NotImplementedException();
        }
    }
}