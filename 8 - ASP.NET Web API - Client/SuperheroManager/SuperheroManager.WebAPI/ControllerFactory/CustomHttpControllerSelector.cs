using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using SuperheroManager.Library.Models;
using SuperheroManager.WebAPI.Controllers;

namespace SuperheroManager.WebAPI.ControllerFactory
{
    public class CustomHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IApplicationRepository repository;

        public CustomHttpControllerActivator(IApplicationRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == typeof (SuperheroController))
            {
                return new SuperheroController(repository);
            }

            return null;
        }
    }
}