using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIS.SSOServer
{
    public static class Scopes
    {
        public static List<Scope> Get() {
            var scopes = new List<Scope> {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                new Scope {
                    Name="cache_api",
                    Description="This will grant you access to the API",
                    ScopeSecrets =new List<Secret> {
                        new Secret("secret".Sha256())
                    },
                    Type = ScopeType.Resource
                }
            };
            scopes.AddRange(StandardScopes.All);
            return scopes;
        }
    }
}