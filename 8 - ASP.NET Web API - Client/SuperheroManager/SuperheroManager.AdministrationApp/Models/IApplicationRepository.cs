using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.AdministrationApp.Models
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Superhero>> GetSuperheroesAsync();
        Task<Int32> CreateSuperheroAsync(Superhero superhero);
        Task RemoveSuperheroAsync(Superhero selectedSuperhero);
        Task<Superhero> UpdateSuperheroAsync(Int32 id, Superhero value);
    }
}