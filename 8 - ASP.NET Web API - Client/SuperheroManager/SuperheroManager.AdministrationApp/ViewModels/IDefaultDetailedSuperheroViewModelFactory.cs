using SuperHeroManager.DataModels.Entities;

namespace SuperheroManager.AdministrationApp.ViewModels
{
    public interface IViewModelFactory
    {
        DetailedSuperheroViewModel CreateDetailedViewModel(Superhero superhero);
    }
}