using System;
using System.Collections.Generic;
using System.Linq;
using SuperHeroManager.DataModels.Entities;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Library.Models
{
    public class AdhocApplicationRepository : IApplicationRepository
    {
        private readonly List<Superhero> superheroes;
        private readonly List<Team> teams;
        private readonly List<User> users;

        private Int32 idCounter;

        public AdhocApplicationRepository()
        {
            this.superheroes = new List<Superhero>();
            this.teams = new List<Team>();

            idCounter = 0;
        }

        public IEnumerable<Team> GetTeams()
        {
            var random = new Random();

            foreach (var index in Enumerable.Range(0, 100))
            {
                yield return new Team
                {
                    Id = index,
                    Name = $"Superhero {random.Next(100)}",
                    SuperHeroes = new List<Superhero>(
                        Enumerable.Range(0, random.Next(1, 10)).Select(i => new Superhero()
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

        public IEnumerable<Superhero> GetSuperheroes()
        {
            return superheroes;
        }

        public void AddTeam(String name)
        {
            teams.Add(new Team() { Name = name, SuperHeroes = new List<Superhero>() });
        }

        public Int32 AddSuperhero(String name, IEnumerable<Skill> skills, IEnumerable<Team> teams, Boolean isOnMission)
        {
            var superhero = new Superhero
            {
                Id = idCounter,
                Name = name,
                Skills = skills?.ToList(),
                Teams = teams?.ToList(),
                IsOnMission = isOnMission
            };

            this.superheroes.Add(superhero);
            idCounter++;
            return idCounter;
        }

        public void RegisterUser(String userName, String password)
        {
            this.users.Add(new User { Username = userName, Password = password });
        }

        public Boolean IsValidUser(String userName, String password) => users.Any(user => user.Username == userName && user.Password == password);
        public void RemoveTeam(Int32 id)
        {
            var team = teams.FirstOrDefault(t => t.Id == id);

            if (team != null)
            {
                teams.Remove(team);
            }
        }

        public void RemoveSuperhero(Int32 id)
        {
            var superhero = superheroes.FirstOrDefault(hero => hero.Id == id);
            if (superhero != null)
            {
                superheroes.Remove(superhero);
            }
        }
    }
}