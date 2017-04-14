using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace NIS.SSOServer
{
    public static class Users
    {
        public static List<InMemoryUser> Get(){
            return new List<InMemoryUser> {
                 new InMemoryUser {
                     Username = "xubinfeng",
                     Password ="secret",
                     Subject ="1",
                     Claims = new [] {
                         new Claim(Constants.ClaimTypes.GivenName,"binfeng"),
                         new Claim(Constants.ClaimTypes.FamilyName,"xu"),
                         new Claim(Constants.ClaimTypes.Email,"1@qq.com")
                     }
                 }
             };
        }
    }
}