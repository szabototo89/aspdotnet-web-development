using System;
using System.Web.Mvc;
using System.Web.Routing;
using SuperheroManager.Web.Controllers;
using SuperheroManager.Web.Models;

namespace SuperheroManager.Web.ControllerFactories
{
    public class StandardControllerFactory : DefaultControllerFactory
    {
        private readonly IApplicationRepository repository;

        public StandardControllerFactory(IApplicationRepository repository)
        {
            this.repository = repository;
        }

        private String GetControllerName(String controllerTypeName)
        {
            if (controllerTypeName == null) throw new ArgumentNullException(nameof(controllerTypeName));

            var controllerSuffix = "Controller";
            if (controllerTypeName.EndsWith(controllerSuffix))
            {
                return controllerTypeName.Substring(0, controllerTypeName.IndexOf(controllerSuffix));
            }

            return controllerTypeName;
        }


        public override IController CreateController(RequestContext requestContext, String controllerName)
        {
            if (controllerName == GetControllerName(nameof(SuperheroManagerController)))
            {
                return new SuperheroManagerController(repository);
            }

            if (controllerName == GetControllerName(nameof(HomeController)))
            {
                return new HomeController(repository);
            }

            if (controllerName == GetControllerName(nameof(AccountController)))
            {
                return new AccountController(repository);
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}