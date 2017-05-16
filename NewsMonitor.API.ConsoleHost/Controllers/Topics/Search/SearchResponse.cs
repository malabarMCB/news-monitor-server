using System.Collections.Generic;
using NewsMonitor.API.ConsoleHost.Models;

namespace NewsMonitor.API.ConsoleHost.Controllers.Topics.Search
{
    public class SearchResponse
    {
        public List<SearchTopicModel> Items { get; set; }
        public int TotalItemsCount { get; set; }
    }
}