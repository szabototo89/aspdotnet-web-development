using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SuperheroManager.AdministrationApp.Annotations;
using SuperheroManager.AdministrationApp.Models;
using SuperHeroManager.DataModels.Entities;

namespace SuperheroManager.AdministrationApp.ViewModels
{
    public class DetailedSuperheroViewModel : ViewModelBase
    {
        private readonly SuperheroesViewModel superheroesViewModel;
        private readonly IApplicationRepository repository;
        private readonly Superhero superhero;
        private ActionCommand updateSuperheroCommand;
        private Team selectedTeam;
        private ActionCommand addTeamCommand;
        private ActionCommand removeTeamCommand;
        private String teamName;
        private ObservableCollection<Team> superheroTeams;

        public DetailedSuperheroViewModel([NotNull] SuperheroesViewModel superheroesViewModel, IApplicationRepository repository, Superhero superhero)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (superhero == null) throw new ArgumentNullException(nameof(superhero));
            if (superheroesViewModel == null) throw new ArgumentNullException(nameof(superheroesViewModel));

            this.superheroesViewModel = superheroesViewModel;
            this.repository = repository;
            this.superhero = superhero;
            this.superheroTeams = new ObservableCollection<Team>(superhero.Teams ?? Enumerable.Empty<Team>());

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            updateSuperheroCommand = new ActionCommand(async () =>
            {
                superhero.Teams = Teams.ToList();
                await this.repository.UpdateSuperheroAsync(superhero.Id, superhero);
                await superheroesViewModel.RefreshViewModelAsync();
            });

            addTeamCommand = new ActionCommand(() =>
            {
                Teams.Add(new Team { Name = TeamName });
                TeamName = String.Empty;
            });

            removeTeamCommand = new ActionCommand(() =>
            {
                Teams.Remove(SelectedTeam);
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

        public ObservableCollection<Team> Teams
        {
            get { return superheroTeams; }
        }

        public IEnumerable<Skill> Skills
        {
            get { return superhero.Skills; }
        }

        public ActionCommand AddTeamCommand => addTeamCommand;
        public ActionCommand RemoveTeamCommand => removeTeamCommand;
        public ActionCommand UpdateSuperheroCommand => updateSuperheroCommand;

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                selectedTeam = value;
                OnPropertyChanged(nameof(SelectedTeam));
            }
        }

        public String TeamName
        {
            get { return teamName; }
            set
            {
                teamName = value;
                OnPropertyChanged(nameof(TeamName));
            }
        }

    }
}