using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;

namespace IdentityServer4withRSA.Authentication
{
    //class ProfileService
    //{
    //    private IAuthService _authService;

    //    public ProfileService(IAuthService rep)
    //    {
    //        this._authService = rep;
    //    }

    //    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    //    {
    //        try
    //        {
    //            var claims = new List<Claim>
    //            {
    //                new Claim("Username", context.Client.ClientName),
    //                //add as many claims as you want!new Claim(JwtClaimTypes.Email, user.Email),new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
    //            };

    //            context.IssuedClaims = claims;
    //            return Task.FromResult(0);
    //        }
    //        catch (Exception x)
    //        {
    //            return Task.FromResult(0);
    //        }
    //    }

    //    public Task IsActiveAsync(IsActiveContext context)
    //    {
    //        var user = _authService.GetUserById(context.Subject.GetSubjectId());
    //        context.IsActive = (user != null) && user.Active;
    //        return Task.FromResult(0);
    //    }
    //}
}
