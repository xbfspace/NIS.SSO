using IdentityServer3.Core.Configuration;
using IdentityServer3.WsFederation.Configuration;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.WsFederation;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace NIS.SSOServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) {
            var factory = new IdentityServerServiceFactory()
                 .UseInMemoryUsers(Users.Get())
                 .UseInMemoryClients(Clients.Get())
                 .UseInMemoryScopes(Scopes.Get());

           app.UseIdentityServer( new IdentityServerOptions
            {
                RequireSsl =false,
                SiteName = "SSO Server",
                SigningCertificate = LoadCertificate(),
                Factory = factory,
                //添加自定义认证服务到identityserver3中
                PluginConfiguration = ConfigureWsFederation,
                AuthenticationOptions = new AuthenticationOptions {
                    //使用认证服务（可以是外部的认证服务提供商如google、twitter等，或者上面通过PluginConfiguration配置的自定义服务提供商）
                    IdentityProviders = ConfigureIdentityProviders
                }

            });
        }

        private void ConfigureWsFederation(IAppBuilder pluginApp,IdentityServerOptions options) {
            var factory = new WsFederationServiceFactory(options.Factory);
            factory.UseInMemoryRelyingParties(ReplyingParties.Get());
            var wsFedOptions = new WsFederationPluginOptions {
                IdentityServerOptions = options,
                Factory = factory
            };
           
            pluginApp.UseWsFederationPlugin(wsFedOptions);
        }

        private  void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            var google = new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                Caption = "Google",
                SignInAsAuthenticationType = signInAsType,
                ClientId = "...",
                ClientSecret = "..."
            };
            app.UseGoogleAuthentication(google);

            //var fb = new FacebookAuthenticationOptions
            //{
            //    AuthenticationType = "Facebook",
            //    Caption = "Facebook",
            //    SignInAsAuthenticationType = signInAsType,
            //    AppId = "...",
            //    AppSecret = "..."
            //};
            //app.UseFacebookAuthentication(fb);

            //var twitter = new TwitterAuthenticationOptions
            //{
            //    AuthenticationType = "Twitter",
            //    Caption = "Twitter",
            //    SignInAsAuthenticationType = signInAsType,
            //    ConsumerKey = "...",
            //    ConsumerSecret = "..."
            //};
            //app.UseTwitterAuthentication(twitter);
            var ldap = new WsFederationAuthenticationOptions
            {
                AuthenticationType = "ldap",
                Caption = "ldap登录",
                SignInAsAuthenticationType = signInAsType,
                MetadataAddress = "http://localhost:22411/federationmetadata/2007-06/federationmetadata.xml",
                Wtrealm = "urn:idsrv3"
            };
            app.UseWsFederationAuthentication(ldap);
        }
        private static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Config\idsrv3test.pfx"), "idsrv3test");
        }
    }
}