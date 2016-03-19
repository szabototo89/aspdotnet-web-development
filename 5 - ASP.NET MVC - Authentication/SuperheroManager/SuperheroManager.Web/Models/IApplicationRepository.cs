using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web.Models
{
    public interface IApplicationRepository
    {
        IEnumerable<Team> GetTeams();
        IEnumerable<Superhero> GetSuperheroes();

        void AddTeam(String name);

        void AddSuperhero(String name, IEnumerable<Skill> skills, IEnumerable<Team> teams);

        void RegisterUser(String userName, String password);

        Boolean IsValidUser(String userName, String password);
    }
}
