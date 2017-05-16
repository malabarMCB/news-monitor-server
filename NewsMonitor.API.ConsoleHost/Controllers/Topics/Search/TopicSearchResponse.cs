using System.Collections.Generic;
using NewsMonitor.API.ConsoleHost.Models;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Controllers.Topics.Search
{
    public class TopicSearchResponse
    {
        [JsonProperty("request")]
        public TopicSearchRequest Request { get; set; }

        [JsonProperty("topicsFound")]
        public List<SearchTopicModel> Items { get; set; }

        [JsonProperty("totalFound")]
        public int TotalItemsCount { get; set; }
    }
}