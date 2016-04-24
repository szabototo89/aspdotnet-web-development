using System;
using SuperheroManager.AdministrationApp.Annotations;
using SuperheroManager.AdministrationApp.Models;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.AdministrationApp.ViewModels
{
    public class DetailedSuperheroViewModel : ViewModelBase
    {
        private readonly SuperheroesViewModel superheroesViewModel;
        private readonly IApplicationRepository repository;
        private readonly Superhero superhero;
        private ActionCommand updateSuperheroCommand;

        public DetailedSuperheroViewModel([NotNull] SuperheroesViewModel superheroesViewModel, IApplicationRepository repository, Superhero superhero)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (superhero == null) throw new ArgumentNullException(nameof(superhero));
            if (superheroesViewModel == null) throw new ArgumentNullException(nameof(superheroesViewModel));

            this.superheroesViewModel = superheroesViewModel;
            this.repository = repository;
            this.superhero = superhero;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            updateSuperheroCommand = new ActionCommand(async () =>
            {
                await this.repository.UpdateSuperheroAsync(superhero.Id, superhero);
                await superheroesViewModel.RefreshViewModelAsync();
            });
        }

        public String Name
        {
            get { return superhero.Name; }
            set { superhero.Name = value; }
        }

        public Boolean IsOnMission
        {
            get { return superhero.IsOnMission; }
            set { superhero.IsOnMission = value; }
        }

        public ActionCommand UpdateSuperheroCommand => updateSuperheroCommand;
    }
}