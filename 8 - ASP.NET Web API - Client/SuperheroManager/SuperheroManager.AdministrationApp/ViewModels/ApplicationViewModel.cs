using System;
using SuperheroManager.AdministrationApp.Annotations;
using SuperheroManager.AdministrationApp.Models;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.AdministrationApp.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        private readonly IViewModelFactory viewModelFactory;
        private DetailedSuperheroViewModel detailedSuperheroViewModel;
        private Superhero selectedSuperhero;

        public SuperheroesViewModel SuperheroesViewModel { get; }

        public Superhero SelectedSuperhero
        {
            get { return selectedSuperhero; }
            set
            {
                selectedSuperhero = value;

                if (value != null)
                {
                    DetailedSuperheroViewModel = viewModelFactory.CreateDetailedViewModel(value);
                }

                OnPropertyChanged(nameof(SelectedSuperhero));
            }
        }

        public DetailedSuperheroViewModel DetailedSuperheroViewModel
        {
            get { return detailedSuperheroViewModel; }
            set
            {
                detailedSuperheroViewModel = value;
                OnPropertyChanged(nameof(DetailedSuperheroViewModel));
            }
        }

        public ApplicationViewModel([NotNull] IViewModelFactory viewModelFactory, SuperheroesViewModel superheroesViewModel)
        {
            if (viewModelFactory == null) throw new ArgumentNullException(nameof(viewModelFactory));
            if (superheroesViewModel == null) throw new ArgumentNullException(nameof(superheroesViewModel));

            this.viewModelFactory = viewModelFactory;

            SuperheroesViewModel = superheroesViewModel;
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            SuperheroesViewModel.SelectionChanged += superhero => { this.SelectedSuperhero = superhero; };
        }
    }
}