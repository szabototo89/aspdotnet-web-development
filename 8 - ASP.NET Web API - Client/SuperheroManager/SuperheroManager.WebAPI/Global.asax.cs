using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using SuperheroManager.Library.Models;
using SuperheroManager.WebAPI.ControllerFactory;
using SuperHeroManager.DataModels.Contexts;

namespace SuperheroManager.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //IApplicationRepository repository = new AdhocApplicationRepository();

            ApplicationContextBase context = new ApplicationContext();
            IApplicationRepository repository = new StandardApplicationRepository(context);
            var activator = new CustomHttpControllerActivator(repository);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), activator);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
