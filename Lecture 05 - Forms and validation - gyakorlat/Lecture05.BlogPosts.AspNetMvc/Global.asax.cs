using System.Web.Mvc;
using System.Web.Routing;
using Lecture05.BlogPosts.AspNetMvc.Controllers;
using Lecture05.BlogPosts.AspNetMvc.Repository;
using Lecture05.BlogPosts.EntityFramework.Repositories;

namespace Lecture05.BlogPosts.AspNetMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IBlogPostRepository repository = new MemoryBlogPostRepository();
            var controllerFactory = new StandardControllerFactory(repository);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
