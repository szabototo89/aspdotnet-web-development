using System.Web.Mvc;
using System.Web.Routing;
using Lecture08.BlogPosts.AspNetMvc.Controllers;
using Lecture08.BlogPosts.AspNetMvc.Repository;
using Lecture08.BlogPosts.EntityFramework.Contexts;
using Lecture08.BlogPosts.EntityFramework.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lecture08.BlogPosts.AspNetMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var context = new LocalDatabaseContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BLOGDATABASE_25f1476eeb6f46e5b0cd8c7e02644db2;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var blogPostRepository = new DatabaseBlogPostRepository(context);
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>())
            {
                PasswordValidator = new MinimumLengthValidator(4)
            };

            ControllerBuilder.Current.SetControllerFactory(new StandardControllerFactory(blogPostRepository, userManager));
        }
    }
}
