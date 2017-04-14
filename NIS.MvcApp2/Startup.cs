using IdentityServer3.Core;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace NIS.MvcApp2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });
            //以下代码作用详见 https://identityserver.github.io/Documentation/docsv2/overview/mvcGettingStarted.html 
            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "http://localhost:38493",
                ClientId = "MvcApp2",
                Scope = "openid profile cache_api",
                RedirectUri = "http://localhost:51132",
                ResponseType = "id_token token",

                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false//,
                //
                //Notifications = new OpenIdConnectAuthenticationNotifications
                //{
                //    SecurityTokenValidated = n =>
                //    {
                //        n.Reques
                //        var id = n.AuthenticationTicket.Identity;

                //        // we want to keep first name, last name, subject and roles
                //        //var givenName = id.FindFirst(Constants.ClaimTypes.GivenName);
                //        //var familyName = id.FindFirst(Constants.ClaimTypes.FamilyName);
                //        var sub = id.FindFirst(Constants.ClaimTypes.Subject);
                //        //var roles = id.FindAll(Constants.ClaimTypes.Role);

                //        // create new identity and set name and role claim type
                //        //var nid = new ClaimsIdentity(
                //        //    id.AuthenticationType,
                //        //    Constants.ClaimTypes.GivenName,
                //        //    Constants.ClaimTypes.Role);
                //        var nid = new ClaimsIdentity();

                //        //nid.AddClaim(givenName);
                //        //nid.AddClaim(familyName);
                //        nid.AddClaim(sub);
                //        //nid.AddClaims(roles);

                //        // add some other app specific claim
                //        nid.AddClaim(new Claim("app_specific", "some data"));

                //        n.AuthenticationTicket = new AuthenticationTicket(
                //            nid,
                //            n.AuthenticationTicket.Properties);

                //        return Task.FromResult(0);
                //    }
                //}
            });
        }
    }
}