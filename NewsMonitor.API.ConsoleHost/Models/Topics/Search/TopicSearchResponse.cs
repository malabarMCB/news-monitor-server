using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.Topics.Search
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