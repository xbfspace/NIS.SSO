using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NIS.CacheApi.Controllers
{
    [Route("UserCache")]
    public class UserCacheController : ApiController
    {
        [HttpGet]
        public IEnumerable<string>  Get()
        {
            return new[] { "xbf","xxx"};
        }
    }
}
