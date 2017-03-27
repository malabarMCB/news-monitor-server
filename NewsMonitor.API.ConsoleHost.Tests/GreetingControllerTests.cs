using FluentAssertions;
using Microsoft.Owin.Testing;
using Ninject;
using Xunit;

namespace NewsMonitor.API.ConsoleHost.Tests
{
    public class GreetingControllerTests
    {
        private readonly TestServer _server;

        public GreetingControllerTests()
        {
            _server = TestServer.Create(app => OwinStartup.CoreConfiguration(app, PrepareContainer));
        }

        private StandardKernel PrepareContainer()
        {
            var kernel = new StandardKernel();

            return kernel;
        }

        [Fact]
        public async void MethodName()
        {
            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("v1/greeting");

                // assert
                response.IsSuccessStatusCode.Should().BeTrue();
                var message = await response.Content.ReadAsStringAsync();

                message.Should().Contain("Hello");
            }
        }
    }
}