using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Validation;
using IdentityServer3.Core.ViewModels;
using System.IO;
using System.Threading.Tasks;
using NIS.SSOServer.Common;

namespace NIS.SSOServer.CustomerServices
{
    public class CustomerViewService : IViewService
    {
        private static readonly string VIEW_LOGIN = AppDomain.CurrentDomain.BaseDirectory + @"Resource\Views\login.html";
        private static readonly string SCRIPT_LOGIN = @"http://localhost:38493/Resource/Scripts/login.js";
        private static readonly string VIEW_ERROR = AppDomain.CurrentDomain.BaseDirectory + @"Resource\Views\error.html";
        public Task<Stream> ClientPermissions(ClientPermissionsViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> Consent(ConsentViewModel model, ValidatedAuthorizeRequest authorizeRequest)
        {
            
        }

        public Task<Stream> Error(ErrorViewModel model)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.None);
            var errorHtml = ViewsLoader.Load(VIEW_ERROR);
            errorHtml = errorHtml.Replace("{ErrorViewModel}", json)
                                 .Replace("{ErrorMessage}",model.ErrorMessage);
            return Task.FromResult<Stream>(ViewsLoader.StringToStream(errorHtml));
        }

        public Task<Stream> LoggedOut(LoggedOutViewModel model, SignOutMessage message)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> Login(LoginViewModel model, SignInMessage message)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.None);
            var loginHtml = ViewsLoader.Load(VIEW_LOGIN);
            loginHtml =  loginHtml.Replace("{LoginViewModel}", json)
                                  .Replace("{LoginScript}",SCRIPT_LOGIN);
            return Task.FromResult<Stream>(ViewsLoader.StringToStream(loginHtml));
        }

        public Task<Stream> Logout(LogoutViewModel model, SignOutMessage message)
        {
            throw new NotImplementedException();
        }
    }
}