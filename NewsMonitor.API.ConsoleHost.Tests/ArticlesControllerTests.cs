using System;
using System.Net;
using FluentAssertions;
using Microsoft.Owin.Testing;
using Ninject;
using Xunit;
using NewsMonitor.API.ConsoleHost.Models.ArticleModel;
using NewsMonitor.API.ConsoleHost.Models.ArticleModel.ArticleSearchResult;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Tests
{
    public class ArticlesControllerTests
    {
        private readonly TestServer _server;

        public ArticlesControllerTests()
        {
            _server = TestServer.Create(app => OwinStartup.CoreConfiguration(app, PrepareContainer));
        }

        private StandardKernel PrepareContainer()
        {
            var kernel = new StandardKernel();

            return kernel;
        }

        [Fact]
        public async void GetCurrentArticle()
        {
            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("articles/1");

                //assert
                response.IsSuccessStatusCode.Should().BeTrue();
                var message = await response.Content.ReadAsStringAsync();

                var jsonArticle = JsonConvert.DeserializeObject<ArticleModel>(message);

                jsonArticle.ShouldBeEquivalentTo(new ArticleModel
                {
                    Id = 1,
                    Date = new DateTime(2011, 6, 21),
                    Title = "Title 1",
                    Keyword = "keyword 1",
                    Text = "Another text"
                });
            }
        }

        [Fact]
        public async void GetOutOfRangeArticle()
        {
            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("articles/2");

                // assert
                response.IsSuccessStatusCode.Should().BeFalse();
            }
        }

        [Fact]
        public async void SearchArticles()
        {
            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("articles/search?year=1984&month&day&title&keyword");

                //assert
                response.IsSuccessStatusCode.Should().BeTrue();
                var message = await response.Content.ReadAsStringAsync();

                var jsonSearchResult = JsonConvert.DeserializeObject<ArticleSearchResult>(message);

                jsonSearchResult.TotalCount.Should().Be(1);
            }
        }
    }
}
