using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Owin.Testing;
using NewsMonitor.API.Models;
using Ninject;
using Xunit;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Tests
{
    public class NewsSourcesControllerTests
    {
        private readonly TestServer _server;

        public NewsSourcesControllerTests()
        {
            _server = TestServer.Create(app => OwinStartup.CoreConfiguration(app, PrepareContainer));
        }

        private StandardKernel PrepareContainer()
        {
            var kernel = new StandardKernel();

            return kernel;
        }

        [Fact]
        public async void GetArticlesBySourceName()
        {
            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("news-sources/first/articles");

                //asssert
                response.IsSuccessStatusCode.Should().BeTrue();
                var message = await response.Content.ReadAsStringAsync();

                var jsonArticles = JsonConvert.DeserializeObject<List<ArticleModel>>(message);

                jsonArticles[0].Text.Should().Be("Test");
            }
        }
    }
}
