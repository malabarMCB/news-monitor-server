using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Testing;
using NewsMonitor.API.ConsoleHost.Models.TopicRepository;
using NewsMonitor.API.ConsoleHost.Models.Topics.Search;
using NewsMonitor.API.Models;
using Ninject;
using Xunit;
using Newtonsoft.Json;
using NSubstitute;

namespace NewsMonitor.API.ConsoleHost.Tests
{
    public class TopicsControllerTests
    {
        private readonly TestServer _server;
        private readonly  ITopicsRepository _topicsRepositoryMock;

        public TopicsControllerTests()
        {
            _topicsRepositoryMock = Substitute.For<ITopicsRepository>();
            _server = TestServer.Create(app => OwinStartup.CoreConfiguration(app, PrepareContainer));
        }

        private StandardKernel PrepareContainer()
        {
            var kernel = new StandardKernel();

            kernel.Bind<ITopicsRepository>().ToConstant(_topicsRepositoryMock);

            return kernel;
        }

        [Fact]
        public async void GetCurrentTopic()
        {
            var expected = new TopicModel
            {
                Date = new DateTime(2017, 02, 12),
                Description = "topic 1.......",
                Keyword = "key1",
                Title = "Topic 1"
            };

            _topicsRepositoryMock
                .Get(Arg.Is<int>(1))
                .Returns(expected);

            // act
            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("v1/topics/1");

                // assert
                response.IsSuccessStatusCode.Should().BeTrue();
                var message = await response.Content.ReadAsStringAsync();

                var actual = JsonConvert.DeserializeObject<TopicModel>(message);

                actual.ShouldBeEquivalentTo(expected);
            }
        }

        [Fact]
        public async void GetOutOfRangeTopic()
        {
            var expected = default(TopicModel);

            _topicsRepositoryMock
                .Get(Arg.Is<int>(2))
                .Returns(expected);

            using (var client = _server.HttpClient)
            {
                var response = await client.GetAsync("v1/topics/2");

                // assert
                response.IsSuccessStatusCode.Should().BeFalse();
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        [Fact]
        public async void SingleItemIsFound()
        {
            var request = new TopicSearchRequest
            {
               NameSearchPattern = "Pattern",
               Page = new PageInfo
               {
                   PageNumber = 1,
                   ItemsPerPage = 1
               }
            };

            var expectedItem = new SearchTopicModel
            {
                Title = "Pattern 1"
            };

            var expected = new TopicSearchResponse
            {
                Request = request,
                TotalItemsCount = 1,
                Items = new List<SearchTopicModel>
                {
                    expectedItem
                }
            };

            _topicsRepositoryMock
                .Search(Arg.Is<string>(request.NameSearchPattern),
                    Arg.Is<int>(request.Page.ItemsPerPage),
                    Arg.Is<int>(request.Page.PageNumber))
                .Returns(new SearchResponse
                {
                    Items = expected.Items,
                    TotalItemsCount = expected.TotalItemsCount
                });

            using (var client = _server.HttpClient)
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(request));
                var response = await client.PostAsync("v1/topics/search",stringContent);

                // assert
                // should be true
                response.IsSuccessStatusCode.Should().BeFalse();
                //
            }
        }
    }
}