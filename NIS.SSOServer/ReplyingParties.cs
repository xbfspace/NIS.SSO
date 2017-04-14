using IdentityServer3.WsFederation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIS.SSOServer
{
    /// <summary>
    /// 信赖的第三方授权服务 类似client的配置
    /// </summary>
    public class ReplyingParties
    {
        public static List<RelyingParty> Get() {
            return new List<RelyingParty>{
                new RelyingParty {
                  Enabled = true,
                  Name  = "LDAP Provider",
                  Realm ="LdapProvider",
                  ReplyUrl = "http://localhost:22411",
                  PostLogoutRedirectUris = new List<string> {
                      "http://localhost:22411"
                  }
                }
            };
        }
    }
}