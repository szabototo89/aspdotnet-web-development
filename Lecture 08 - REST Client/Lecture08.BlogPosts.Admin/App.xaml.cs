using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Lecture08.BlogPosts.Admin.Models;
using Lecture08.BlogPosts.Admin.ViewModels;
using Lecture08.BlogPosts.EntityFramework.Domain;

namespace Lecture08.BlogPosts.Admin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var repository = new DefaultBlogPostRepository("http://localhost:54162");
            var applicationContext = new ApplicationContext(repository);
            var mainWindow = new MainWindow(applicationContext);
            mainWindow.Show();
        }
    }
}
