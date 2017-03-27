using System;
using System.Web.Http;

namespace NewsMonitor.API.ConsoleHost.Controllers
{
    [RoutePrefix("v1")]
    public class GreetingController : ApiController
    {
        [HttpGet]
        [Route("greeting")]
        public string Message()
        {
            return $"Hello at {DateTime.Now:HH:mm}";
        }
    }
}