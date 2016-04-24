using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SuperheroManager.AdministrationApp.Models;
using SuperheroManager.AdministrationApp.ViewModels;

namespace SuperheroManager.AdministrationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var repository = new DefaultApplicationRepository("http://localhost:50673/"))
            {
                SuperheroesViewModel superheroesViewModel = new SuperheroesViewModel(repository);
                IViewModelFactory viewModelFactory = new DefaultViewModelFactory(superheroesViewModel, repository);
                ApplicationViewModel applicationViewModel = new ApplicationViewModel(viewModelFactory, superheroesViewModel);

                MainWindow mainWindow = new MainWindow(applicationViewModel);

                mainWindow.ShowDialog();
            }
        }
    }
}
