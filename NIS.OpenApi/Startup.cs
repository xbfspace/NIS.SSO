using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;

namespace NIS.OpenApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Allow all origins
            app.UseCors(CorsOptions.AllowAll);


            // Wire Web API
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            //对外的开放式api 任何人都可以访问，不做验证
            //httpConfiguration.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(httpConfiguration);
        }
    }
}
