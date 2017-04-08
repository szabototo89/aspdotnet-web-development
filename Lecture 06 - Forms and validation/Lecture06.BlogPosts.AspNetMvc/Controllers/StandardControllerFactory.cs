using System;
using System.Web.Mvc;
using System.Web.Routing;
using Lecture06.BlogPosts.EntityFramework.Repositories;

namespace Lecture06.BlogPosts.AspNetMvc.Controllers
{
    public class StandardControllerFactory : DefaultControllerFactory
    {
        private readonly IBlogPostRepository blogPostRepository;

        public StandardControllerFactory(IBlogPostRepository blogPostRepository)
        {
            if (blogPostRepository == null) throw new ArgumentNullException(nameof(blogPostRepository));
            this.blogPostRepository = blogPostRepository;
        }

        public override IController CreateController(RequestContext requestContext, String controllerName)
        {
            if ($"{controllerName}Controller" == nameof(HomeController))
            {
                return new HomeController(blogPostRepository);
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}