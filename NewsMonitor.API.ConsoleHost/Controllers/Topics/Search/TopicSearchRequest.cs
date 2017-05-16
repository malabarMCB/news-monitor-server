using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Controllers.Topics
{
    public class TopicSearchRequest
    {
        [JsonProperty("nameSearchPattern")]
        public string NameSearchPattern { get; set; }

        [JsonProperty("page")]
        public PageInfo Page { get; set; }
    }
}