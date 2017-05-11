using System.Collections.Generic;
using NewsMonitor.API.ConsoleHost.Models;

namespace NewsMonitor.API.ConsoleHost.Controllers.Topics
{
    public class SearchResponse
    {
        public List<TopicModel> Items { get; set; }
        public int TotalItemsCount { get; set; }
    }
}