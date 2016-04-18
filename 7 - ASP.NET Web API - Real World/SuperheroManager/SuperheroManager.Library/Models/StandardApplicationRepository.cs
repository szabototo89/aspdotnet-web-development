using System;
using System.Collections.Generic;
using System.Linq;
using SuperHeroManager.DataModels.Contexts;
using SuperHeroManager.DataModels.Entities;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Library.Models
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

        public IEnumerable<Superhero> GetSuperheroes()
        {
            return context.Superheroes;
        }

        public void AddTeam(String name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            context.Teams.Add(new Team { Name = name, SuperHeroes = new List<Superhero>() });
            context.SaveChanges();
        }

        public void AddSuperhero(String name, IEnumerable<Skill> skills, IEnumerable<Team> teams)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (skills == null) throw new ArgumentNullException(nameof(skills));
            if (teams == null) throw new ArgumentNullException(nameof(teams));

            var superhero = new Superhero
            {
                Name = name,
                Skills = skills.ToList(),
                Teams = teams.ToList()
            };

            context.Superheroes.Add(superhero);

            var allTeams = GetTeams().ToArray();

            foreach (var team in teams)
            {
                var savedTeam = allTeams.FirstOrDefault(element => element.Id == team.Id);

                savedTeam.SuperHeroes.Add(superhero);
            }

            context.SaveChanges();
        }

        public void RegisterUser(String userName, String password)
        {
            context.Users.Add(new User { Username = userName, Password = password });
            context.SaveChanges();
        }

        public Boolean IsValidUser(String userName, String password)
        {
            return context.Users.Any(user => user.Username == userName && user.Password == password);
        }

        public void RemoveTeam(Int32 id)
        {
            var team = context.Teams.FirstOrDefault(t => t.Id == id);
            if (team == null) return;

            context.Teams.Remove(team);
            context.SaveChanges();
        }

        public void RemoveSuperhero(Int32 id)
        {
            var superhero = context.Superheroes.FirstOrDefault(hero => hero.Id == id);
            if (superhero == null) return;

            context.Superheroes.Remove(superhero);
            context.SaveChanges();
        }
    }
}