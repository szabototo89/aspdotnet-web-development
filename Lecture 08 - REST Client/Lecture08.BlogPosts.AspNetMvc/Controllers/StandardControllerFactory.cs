using System;
using System.Web.Mvc;
using System.Web.Routing;
using Lecture08.BlogPosts.EntityFramework.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lecture08.BlogPosts.AspNetMvc.Controllers
{
    public class StandardControllerFactory : DefaultControllerFactory
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly UserManager<IdentityUser> userManager;

        public StandardControllerFactory(IBlogPostRepository blogPostRepository, UserManager<IdentityUser> userManager)
        {
            if (blogPostRepository == null) throw new ArgumentNullException(nameof(blogPostRepository));
            if (userManager == null) throw new ArgumentNullException(nameof(userManager));

            this.blogPostRepository = blogPostRepository;
            this.userManager = userManager;
        }

        public override IController CreateController(RequestContext requestContext, String controllerName)
        {
            if (DoesControllerNameEqual<HomeController>(controllerName))
            {
                return new HomeController(blogPostRepository);
            }

            if (DoesControllerNameEqual<AccountController>(controllerName))
            {
                return new AccountController(userManager);    
            }

            return base.CreateController(requestContext, controllerName);
        }

        private static Boolean DoesControllerNameEqual<TController>(String controllerName) 
            => $"{controllerName}Controller" == typeof(TController).Name;
    }
}