using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace IdentityServer4withRSA.Authentication
{
    class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private IAuthService _authService;

        public ResourceOwnerPasswordValidator(IAuthService authService)
        {
            _authService = authService;
        }
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_authService.DoesUserExist(context.UserName))
            {
                if (_authService.DoesPasswordMatch(context.UserName, context.Password))
                {
                    context.Result = new GrantValidationResult(context.UserName, "password", null, "local", null);
                    return Task.FromResult(context.Result);
                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, "The user does not exist", null);
            return Task.FromResult(context.Result);
        }
    }
}
