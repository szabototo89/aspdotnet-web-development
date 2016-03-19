using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SuperheroManager.Web.Providers
{
    public abstract class CustomMembershipProviderBase : MembershipProvider
    {
        public override MembershipUser CreateUser(String username, String password, String email, String passwordQuestion, String passwordAnswer, Boolean isApproved, Object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override Boolean ChangePasswordQuestionAndAnswer(String username, String password, String newPasswordQuestion, String newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override String GetPassword(String username, String answer)
        {
            throw new NotImplementedException();
        }

        public override Boolean ChangePassword(String username, String oldPassword, String newPassword)
        {
            throw new NotImplementedException();
        }

        public override String ResetPassword(String username, String answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override Boolean UnlockUser(String userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(Object providerUserKey, Boolean userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(String username, Boolean userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override String GetUserNameByEmail(String email)
        {
            throw new NotImplementedException();
        }

        public override Boolean DeleteUser(String username, Boolean deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(Int32 pageIndex, Int32 pageSize, out Int32 totalRecords)
        {
            throw new NotImplementedException();
        }

        public override Int32 GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(String usernameToMatch, Int32 pageIndex, Int32 pageSize, out Int32 totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(String emailToMatch, Int32 pageIndex, Int32 pageSize, out Int32 totalRecords)
        {
            throw new NotImplementedException();
        }

        public override Boolean EnablePasswordRetrieval { get; }
        public override Boolean EnablePasswordReset { get; }
        public override Boolean RequiresQuestionAndAnswer { get; }
        public override String ApplicationName { get; set; }
        public override Int32 MaxInvalidPasswordAttempts { get; }
        public override Int32 PasswordAttemptWindow { get; }
        public override Boolean RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override Int32 MinRequiredPasswordLength { get; }
        public override Int32 MinRequiredNonAlphanumericCharacters { get; }
        public override String PasswordStrengthRegularExpression { get; }
    }
}