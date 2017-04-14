using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NIS.OpenApi.Controllers
{
    [Route("tokens")]
    public class TokensController : ApiController
    {
        public TokenResponse Get(string clientId,string clientSecret,string userName,string password) {
            //clientId = "ExternalAppWithUserNameAndPassword";
            //clientSecret = "secret";
            //userName = "xubinfeng";
            //password = "secret";
            var client = new TokenClient(
                "http://localhost:38493/connect/token",
                clientId,
                clientSecret
                );
            string scope = "openid profile cache_api";
            return client.RequestResourceOwnerPasswordAsync(userName, password,scope).Result;
        }

        public TokenResponse Get(string clientId, string clientSecret) {
            //clientId = "ExternalApp";
            //clientSecret = "secret";
            var client = new TokenClient(
                "http://localhost:38493/connect/token",
                clientId,
                clientSecret
                );
            //string scope = "openid profile cache_api";
            string scope = "cache_api";//仅以客户端id加客户端秘钥进行的访问方式不能访问与个人相关的scope如openid profile等
           
            return client.RequestClientCredentialsAsync(scope).Result;
        }
    }
}
