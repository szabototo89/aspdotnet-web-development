using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lecture05.BlogPosts.EntityFramework.Repositories;

namespace Lecture05.BlogPosts.AspNetMvc.Controllers
{
    public class StandardControllerFactory : DefaultControllerFactory
    {
        private readonly IBlogPostRepository blogPostRepository;

        public StandardControllerFactory(IBlogPostRepository blogPostRepository)
        {
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