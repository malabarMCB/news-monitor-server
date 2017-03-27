using System;
using Microsoft.Owin;
using NewsMonitor.API.ConsoleHost;
using NewsMonitor.API.ConsoleHost.Configurations;
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

        }
    }
}