using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SuperheroManager.Web.ControllerFactories;
using SuperheroManager.Web.Models;
using SuperHeroManager.DataModels.Contexts;
using SuperHeroManager.DataModels.Superheroes;

namespace SuperheroManager.Web
{
    public class ApplicationDbTestInitializer<TContext> : DropCreateDatabaseAlways<TContext> where TContext : ApplicationContextBase
    {
        protected override void Seed(TContext contextBase)
        {
            var stream = new MemoryStream();
            var image = Image.FromFile("G:\\Images\\635820032054432675-314366847_403b8f3f4eeed5389925a9fc5c0b5b2d.jpg");
            image.Save(stream, ImageFormat.Bmp);

            var justiceLeague = new Team
            {
                Name = "Justice League",
            };

            var batman = new Superhero
            {
                Name = "Batman",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "Ninjutsu",
                        Description = "Professional in several martial arts. ",
                        Value = 10
                    },
                    new Skill
                    {
                        Name="Detective",
                        Description = "",
                        Value = 10
                    }
                },
                Teams = new List<Team> { justiceLeague },
                Image = stream.ToArray()
            };

            justiceLeague.SuperHeroes = new List<Superhero> { batman };

            contextBase.Superheroes.Add(batman);

            // saving the changes back into the database
            contextBase.SaveChanges();
        }
    }


    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitializeControllerFactory();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static void InitializeControllerFactory()
        {
            var applicationContext = new ApplicationContext();

            //Database.SetInitializer(new ApplicationDbTestInitializer<ApplicationContext>());

            IApplicationRepository applicationRepository = new StandardApplicationRepository(applicationContext);
            IControllerFactory controllerFactory = new StandardControllerFactory(applicationRepository);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
