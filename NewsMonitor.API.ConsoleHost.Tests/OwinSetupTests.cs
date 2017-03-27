using Microsoft.Owin.Testing;
using Ninject;
using Xunit;

namespace NewsMonitor.API.ConsoleHost.Tests
{
    public class OwinSetupTests
    {
        [Fact]
        public void TestSetUp()
        {
            var kernel = new StandardKernel();

            TestServer.Create(app => OwinStartup.CoreConfiguration(app, () => kernel));
        }
    }
}