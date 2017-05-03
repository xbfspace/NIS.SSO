using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;
using System.Threading.Tasks;

namespace NIS.SSOServer.CustomerServices
{
    public class CustomerUserService : IUserService
    {
        public Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            return Task.FromResult(0);
        }

        public Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            var username = context.UserName;
            var password = context.Password;
            var message = context.SignInMessage;

            context.AuthenticateResult = null;
            if (username=="xubinfeng" && password=="secret") {
                var claims = new List<System.Security.Claims.Claim>();
                claims.Add(new System.Security.Claims.Claim("role", "admin"));
                context.AuthenticateResult = new AuthenticateResult("1", username, claims);
            }

            //var userValidatorResult = UserManager.UserValidator(username, password);


            //if (userValidatorResult.ResultCode == 1)
            //{
            //    var user = userValidatorResult.Data;
            //    var claims = GetClaimsFromAccount(user);
            //    var signOnId = Guid.NewGuid();
            //    claims.Add(new Claim(iOffice10.SSO.Model.ClaimTypes.SignOnId, signOnId.ToString()));
            //    UserManager.SetSignOnState(user.ID, signOnId);
            //    context.AuthenticateResult = new AuthenticateResult(user.ID.ToString(), user.Name, claims);

            //}
            //else
            //{
            //    if (userValidatorResult.ResultCode == (int)UserValidatorResultCode.DisableUser)
            //    {
            //        context.AuthenticateResult = new AuthenticateResult(userValidatorResult.Message);
            //    }
            //}

            return Task.FromResult(0);
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }

        public Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            return Task.FromResult(0);
        }

        public Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            return Task.FromResult(0);
        }

        public Task SignOutAsync(SignOutContext context)
        {
            return Task.FromResult(0);
        }
    }
}