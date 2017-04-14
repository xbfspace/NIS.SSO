using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIS.SSOServer
{
    public static class Clients
    {
        public static IEnumerable<Client> Get() {
            return new[] {
                new Client {
                    Enabled = true,
                    ClientName = "JS App",
                    ClientId = "JSApp",
                    Flow = Flows.Implicit,//它代表一种“隐式”授权方式，即客户端在取得资源拥有者（最终用户）授权的情况下直接获取Access Token，而不是间接地利用获取的Authorization Grant来取得Access Token。换句话说，此种类型的Authorization Grant代表根本不需要Authorization Grant，那么上面介绍的“Three-Legged OAuth”变成了“Two-Legged OAuth”。
                   
                    RedirectUris = new List<string> {
                        "http://localhost:56668/popup.html",
                        // The new page is a valid redirect page after login
                        "http://localhost:56668/silent-renew.html"
                    },
                    // Valid URLs after logging out
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:56668/index.html"
                    },
                    AllowedCorsOrigins = new List<string> {
                        "http://localhost:56668"
                    },
                    AllowAccessToAllScopes = true,
                    //令牌过期时间 70秒
                    AccessTokenLifetime = 70
                },
               new Client {
                   Enabled = true,
                   ClientName = "Mvc App",
                   ClientId = "MvcApp",
                   Flow = Flows.Implicit,
                   RedirectUris = new List<string>() {
                       "http://localhost:2509"
                   },
                   AllowAccessToAllScopes = true,
                   AllowedCorsOrigins = new List<string> {
                       "http://localhost:2509"
                   }
               },
                new Client {
                   Enabled = true,
                   ClientName = "Mvc App2",
                   ClientId = "MvcApp2",
                   Flow = Flows.Implicit,
                   RedirectUris = new List<string>() {
                       "http://localhost:51132"
                   },
                   AllowAccessToAllScopes = true,
                   AllowedCorsOrigins = new List<string> {
                       "http://localhost:51132"
                   }
               },
               new Client {
                   ClientName = "外部第三方应用(带用户名密码访问)",
                   ClientId ="ExternalAppWithUserNameAndPassword",
                   Enabled = true,
                   AccessTokenType = AccessTokenType.Reference,
                   Flow = Flows.ResourceOwner,//带用户名密码访问
                   ClientSecrets = new List<Secret> {
                       new Secret("secret".Sha256())
                   },
                   AllowAccessToAllScopes = true,
                   AllowedCorsOrigins = new List<string> {
                       "http://localhost:56668"
                   }
               },
               new Client {
                   ClientName = "外部第三方应用(仅clientId和clientName访问)",
                   ClientId = "ExternalApp",
                   Enabled = true,
                   AccessTokenType = AccessTokenType.Reference,
                   Flow = Flows.ClientCredentials,
                   ClientSecrets = new List<Secret> {
                       new Secret("secret".Sha256())
                   },
                   AllowAccessToAllScopes = true,
                   AllowedCorsOrigins = new List<string> {
                       "http://localhost:56668"
                   }
               }
            };
        }
    }
}