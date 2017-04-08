using System.Web.Mvc;
using System.Web.Routing;
using Lecture06.BlogPosts.AspNetMvc.Controllers;
using Lecture06.BlogPosts.AspNetMvc.Repository;

namespace Lecture06.BlogPosts.AspNetMvc
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
