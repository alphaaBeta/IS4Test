using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using System.DirectoryServices.AccountManagement;

namespace IdentityServer4withRSA.Authentication
{
    class AuthService : IAuthService
    {
        private string _domain = Config.ADDomain;
        
        public bool DoesUserExist(string username)
        {
            using (var domainContext = new PrincipalContext(ContextType.Domain, _domain))
            {
                using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, username))
                {
                    return foundUser != null;
                }
            }
        }

        public bool DoesPasswordMatch(string username, string plainTextPassword)
        {
            bool authentic = false;
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://" + _domain,
                    username, plainTextPassword);
                object nativeObject = entry.NativeObject;
                authentic = true;
            }
            catch (DirectoryServicesCOMException) { }
            return authentic;
        }
    }
}
