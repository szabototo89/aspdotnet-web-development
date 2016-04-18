using System;
using SuperheroManager.Library.Models;
using SuperHeroManager.DataModels.Contexts;
using SuperHeroManager.DataModels.Entities;

namespace SuperheroManager.Web.Providers
{
    public class CustomMembershipProvider : CustomMembershipProviderBase
    {
        private readonly IApplicationRepository repository;

        public CustomMembershipProvider()
        {
            this.repository = new StandardApplicationRepository(new ApplicationContext());
        }

        public override Boolean ValidateUser(String username, String password)
        {
            return this.repository.IsValidUser(username, password);
        }
    }
}