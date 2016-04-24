using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SuperheroManager.AdministrationApp.Annotations;
using SuperheroManager.AdministrationApp.ViewModels;

namespace SuperheroManager.AdministrationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApplicationViewModel applicationViewModel;

        public MainWindow([NotNull] ApplicationViewModel applicationViewModel)
        {
            if (applicationViewModel == null) throw new ArgumentNullException(nameof(applicationViewModel));

            InitializeComponent();
            this.applicationViewModel = applicationViewModel;

            DataContext = applicationViewModel;
        }
    }
}
