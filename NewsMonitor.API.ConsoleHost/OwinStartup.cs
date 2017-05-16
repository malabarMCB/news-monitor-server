using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using NewsMonitor.API.ConsoleHost;
using NewsMonitor.API.ConsoleHost.Configurations;
using NewsMonitor.API.ConsoleHost.Controllers.Topics;
using NewsMonitor.API.ConsoleHost.Controllers.Topics.TopicRepository;
using Ninject;
using Ninject.Syntax;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(OwinStartup))]

namespace NewsMonitor.API.ConsoleHost
{
    public class OwinStartup
    {
        public static void Configuration(IAppBuilder app)
        {
            CoreConfiguration(app, CreateKernel);
        }

        public static void CoreConfiguration(IAppBuilder app, Func<IKernel> containerFactory)
        {
            var config = WebApiConfiguration.CreateConfiguration();

            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            app.UseNinjectMiddleware(containerFactory);
            app.UseNinjectWebApi(config);

            config.EnsureInitialized();
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(AssembliesResolver.Instance.GetAssemblies());

            RegisterServices(kernel);

            return kernel;
        }

        private static void RegisterServices(IBindingRoot kernel)
        {
            kernel.Bind<ITopicsRepository>().To<StaticTopicsRepository>();
        }
    }
}