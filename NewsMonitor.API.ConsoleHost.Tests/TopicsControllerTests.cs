using System;
using FluentAssertions;
using Microsoft.Owin.Testing;
using Ninject;
using Xunit;
using NewsMonitor.API.ConsoleHost.Models;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Tests
{
    public class TopicsControllerTests
    {
        private readonly TestServer _server;

        public TopicsControllerTests()
        {
            _server = TestServer.Create(app => OwinStartup.CoreConfiguration(app, PrepareContainer));
        }

        private StandardKernel PrepareContainer()
        {
            var kernel = new StandardKernel();

            return kernel;
        }

        [Fact]
        public async void GetCurrentTopic()
        {
            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("topics/1");

                // assert
                response.IsSuccessStatusCode.Should().BeTrue();
                var message = await response.Content.ReadAsStringAsync();

                var jsonTopic =JsonConvert.DeserializeObject<TopicModel>(message);

                jsonTopic.ShouldBeEquivalentTo(new TopicModel
                { 
                    Date = new DateTime(2017, 02, 12),
                    Description = "topic 1.......",
                    Keyword = "key1",
                    Title = "Topic 1"
                });
            }
        }

        [Fact]
        public async void GetOutOfRangeTopic()
        {
            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("topics/2");

                // assert
                response.IsSuccessStatusCode.Should().BeFalse();
            }
        }
    }
}