using System;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Controllers.Topics.Search
{
    public class SearchTopicModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}