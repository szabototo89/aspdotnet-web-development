using System.Web.Mvc;
using System.Web.Routing;
using Lecture06.BlogPosts.AspNetMvc.Controllers;
using Lecture06.BlogPosts.AspNetMvc.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lecture06.BlogPosts.AspNetMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var blogPostRepository = new MemoryBlogPostRepository();
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>())
            {
                PasswordValidator = new MinimumLengthValidator(4)
            };

            ControllerBuilder.Current.SetControllerFactory(new StandardControllerFactory(blogPostRepository));
        }
    }
}
