using System;
using SuperheroManager.AdministrationApp.Annotations;
using SuperheroManager.AdministrationApp.Models;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.AdministrationApp.ViewModels
{
    public class DefaultViewModelFactory : IViewModelFactory
    {
        private readonly SuperheroesViewModel superheroesViewModel;
        private readonly IApplicationRepository repository;

        public DefaultViewModelFactory([NotNull] SuperheroesViewModel superheroesViewModel, IApplicationRepository repository)
        {
            if (superheroesViewModel == null) throw new ArgumentNullException(nameof(superheroesViewModel));
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            this.superheroesViewModel = superheroesViewModel;
            this.repository = repository;
        }

        public DetailedSuperheroViewModel CreateDetailedViewModel([NotNull] Superhero superhero)
        {
            if (superhero == null) throw new ArgumentNullException(nameof(superhero));

            return new DetailedSuperheroViewModel(superheroesViewModel, repository, superhero);
        }
    }
}