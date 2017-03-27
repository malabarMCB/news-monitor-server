using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using NewsMonitor.API.ConsoleHost.Logging;

namespace NewsMonitor.API.ConsoleHost.Configurations
{
    public static class WebApiConfiguration
    {
        public static HttpConfiguration CreateConfiguration()
        {
            var config = new HttpConfiguration
            {
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly,
            };

            // register services
            config.Services.Replace(typeof (IAssembliesResolver), AssembliesResolver.Instance);
            config.Services.Add(typeof (IExceptionLogger), new NLogExceptionLogger());

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            return config;
        }
    }
}