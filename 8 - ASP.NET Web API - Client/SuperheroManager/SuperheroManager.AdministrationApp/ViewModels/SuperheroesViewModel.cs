using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SuperheroManager.AdministrationApp.Annotations;
using SuperheroManager.AdministrationApp.Models;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.AdministrationApp.ViewModels
{
    public class SuperheroesViewModel : ViewModelBase
    {
        private readonly IApplicationRepository repository;
        private Superhero selectedSuperhero;
        private ActionCommand addSuperheroCommand;
        private ActionCommand removeSuperheroCommand;
        private ObservableCollection<Superhero> superheroes;

        public ObservableCollection<Superhero> Superheroes
        {
            get { return superheroes; }
            private set
            {
                superheroes = value;
                OnPropertyChanged(nameof(Superheroes));
            }
        }

        public Superhero SelectedSuperhero
        {
            get { return selectedSuperhero; }
            set
            {
                selectedSuperhero = value;
                OnSelectionChanged(value);
            }
        }

        public ActionCommand AddSuperheroCommand
        {
            get { return addSuperheroCommand; }
        }

        public ActionCommand RemoveSuperheroCommand
        {
            get { return removeSuperheroCommand; }
        }

        public event Action<Superhero> SelectionChanged;

        public SuperheroesViewModel([NotNull] IApplicationRepository repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            this.repository = repository;

            InitializeViewModelAsync();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            addSuperheroCommand = new ActionCommand(async () =>
            {
                var superhero = new Superhero
                {
                    Name = $"[Hero {Superheroes?.Count + 1}]"
                };

                await this.repository.CreateSuperheroAsync(superhero);
                await RefreshViewModelAsync();
            });

            removeSuperheroCommand = new ActionCommand(async () =>
            {
                await this.repository.RemoveSuperheroAsync(this.SelectedSuperhero);
                await RefreshViewModelAsync();
            });
        }

        public async Task RefreshViewModelAsync()
        {
            Superheroes = new ObservableCollection<Superhero>(await this.repository.GetSuperheroesAsync());
            OnPropertyChanged(nameof(Superheroes));
        }

        private async void InitializeViewModelAsync()
        {
            Superheroes = new ObservableCollection<Superhero>(await this.repository.GetSuperheroesAsync());
        }

        protected virtual void OnSelectionChanged(Superhero superhero)
        {
            SelectionChanged?.Invoke(superhero);
        }
    }
}