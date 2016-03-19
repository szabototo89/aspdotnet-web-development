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
        IEnumerable<SuperHero> GetSuperheroes();
    }
}
