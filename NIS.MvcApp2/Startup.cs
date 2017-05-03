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
            var options = new OpenIdConnectAuthenticationOptions
            {
                Authority = "http://localhost:38493",
                ClientId = "MvcApp2",
                Scope = "openid profile cache_api",
                RedirectUri = "http://localhost:51132",
                ResponseType = "id_token token",

                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false
            };
            //options.ProtocolValidator.RequireNonce = false;
            app.UseOpenIdConnectAuthentication(options);
        }
    }
}