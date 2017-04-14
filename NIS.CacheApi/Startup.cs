using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NIS.CacheApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Allow all origins
            app.UseCors(CorsOptions.AllowAll);

            // Wire token validation
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:38493",

                // For access to the introspection endpoint
                ClientId = "cache_api",
                ClientSecret = "secret",

                RequiredScopes = new[] { "cache_api" }//需要有该scope的客户端才可以访问本api
            });

            // Wire Web API
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(httpConfiguration);
        }
    }
}