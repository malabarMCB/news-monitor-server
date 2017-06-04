using System.Collections.Generic;
using NewsMonitor.API.Models;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.Topics.AddTopic
{
    public class Topic
    {
        [JsonProperty("info")]
        public TopicInfo Info { get; set; }

        [JsonProperty("articles")]
        public List<NewsSourceModel> NewsSources { get; set; }
    }
}