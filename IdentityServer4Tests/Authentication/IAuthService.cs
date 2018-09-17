using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4withRSA.Models;

namespace IdentityServer4withRSA.Authentication
{
    interface IAuthService
    {
        bool DoesUserExist(string username);
        bool DoesPasswordMatch(string username, string plainTextPassword);
    }
}
