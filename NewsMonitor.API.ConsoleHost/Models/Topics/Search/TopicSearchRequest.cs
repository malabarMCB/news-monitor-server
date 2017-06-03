using NewsMonitor.API.Models;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.Topics.Search
{
    public class TopicSearchRequest
    {
        [JsonProperty("nameSearchPattern")]
        public string NameSearchPattern { get; set; }

        [JsonProperty("page")]
        public PageInfo Page { get; set; }
    }
}