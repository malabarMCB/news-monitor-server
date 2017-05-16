using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsMonitor.API.ConsoleHost.Controllers.Topics.Search;
using NewsMonitor.API.ConsoleHost.Models;

namespace NewsMonitor.API.ConsoleHost.Controllers.Topics.TopicRepository
{
    public class StaticTopicsRepository : ITopicsRepository
    {
        private readonly List<TopicModel> _topics = new List<TopicModel>
        {
            new TopicModel
            {
                Date = new DateTime(2015, 3, 21),
                Description = "topic 0 bla-bla-bla",
                Keyword = "key0",
                Title = "Topic 0"
            },
            new TopicModel
            {
                Date = new DateTime(2017, 02, 12),
                Description = "topic 1.......",
                Keyword = "key1",
                Title = "Topic 1"
            }
        };

        public Task<TopicModel> Get(int id)
        {
            var result = (id < 0 || id >= _topics.Count)
                ? null
                : _topics[id];

            return Task.FromResult(result);
        }

        public Task<SearchResponse> Search(string nameSearchPattern, int itemsPerPage, int pageNumber)
        {
            var topics = _topics
                .OrderBy(t => t.Title)
                .Where(t => t.Title.Contains(nameSearchPattern))
                .Skip(itemsPerPage * pageNumber)
                .Take(itemsPerPage)
                .Select(t =>new SearchTopicModel
                {
                    Id=t.Id,
                    Title=t.Title
                } )
                .ToList();

            var topicsCount = topics
                .Count(t => t.Title.Contains(nameSearchPattern));

            var result = new SearchResponse
            {
                Items = topics,
                TotalItemsCount = topicsCount
            };

            return Task.FromResult(result);
        }
    }
}