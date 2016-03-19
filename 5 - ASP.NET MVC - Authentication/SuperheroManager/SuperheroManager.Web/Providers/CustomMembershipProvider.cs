using System;

namespace SuperheroManager.Web.Providers
{
    public class CustomMembershipProvider : CustomMembershipProviderBase
    {
        public override Boolean ValidateUser(String username, String password)
        {
            return true;
        }
    }
}