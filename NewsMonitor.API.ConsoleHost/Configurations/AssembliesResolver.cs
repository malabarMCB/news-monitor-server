using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace NewsMonitor.API.ConsoleHost.Configurations
{
    public class AssembliesResolver : IAssembliesResolver
    {
        public static readonly AssembliesResolver Instance = new AssembliesResolver();

        private readonly ICollection<Assembly> _assemblies;

        private AssembliesResolver()
        {
            _assemblies = new HashSet<Assembly>(new[]
            {
                typeof(OwinStartup).Assembly,
            });
        }

        public ICollection<Assembly> GetAssemblies()
        {
            return _assemblies;
        }
    }
}