using System;
using System.Collections.Generic;
using SuperHeroManager.DataModels.Entities;

namespace SuperheroManager.Library.Models
{
    public interface IApplicationRepository
    {
        IEnumerable<Team> GetTeams();
        IEnumerable<Superhero> GetSuperheroes();

        void AddTeam(String name);

        Int32 AddSuperhero(String name, IEnumerable<Skill> skills, IEnumerable<Team> teams, Boolean isOnMission);

        void RegisterUser(String userName, String password);

        Boolean IsValidUser(String userName, String password);

        void RemoveTeam(Int32 id);

        void RemoveSuperhero(Int32 id);
    }
}
