using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.AdministrationApp.ViewModels
{
    public interface IViewModelFactory
    {
        DetailedSuperheroViewModel CreateDetailedViewModel(Superhero superhero);
    }
}