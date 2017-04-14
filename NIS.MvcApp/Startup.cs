using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIS.MvcApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "http://localhost:38493",
                ClientId = "MvcApp",
                //Scope = "openid profile cache_api",
                Scope = "openid profile",
                RedirectUri = "http://localhost:2509",
                //ResponseType = "id_token token",//As soon as a response type of token is requested, IdentityServer stops including the claims in the identity token. This is for optimization purposes, since you now have an access token that allows retrieving the claims from the userinfo endpoint and while keeping the identity token small
                ResponseType = "id_token",
                SignInAsAuthenticationType = "Cookies"
            });
        }
    }
}