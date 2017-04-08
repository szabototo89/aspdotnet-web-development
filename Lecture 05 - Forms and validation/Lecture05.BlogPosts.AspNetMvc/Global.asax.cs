using System.Web.Mvc;
using System.Web.Routing;
using Lecture05.BlogPosts.AspNetMvc.Controllers;
using Lecture05.BlogPosts.AspNetMvc.Repository;

namespace Lecture05.BlogPosts.AspNetMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var blogPostRepository = new MemoryBlogPostRepository();
            ControllerBuilder.Current.SetControllerFactory(new StandardControllerFactory(blogPostRepository));
        }
    }
}
