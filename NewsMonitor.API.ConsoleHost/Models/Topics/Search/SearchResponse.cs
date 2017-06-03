using System.Collections.Generic;

namespace NewsMonitor.API.ConsoleHost.Models.Topics.Search
{
    public class SearchResponse
    {
        public List<SearchTopicModel> Items { get; set; }
        public int TotalItemsCount { get; set; }
    }
}