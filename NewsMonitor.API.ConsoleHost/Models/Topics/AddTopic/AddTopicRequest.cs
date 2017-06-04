using NewsMonitor.API.ConsoleHost.Models.Topics.AddTopic;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.AddTopic
{
    public class AddTopicRequest
    {
        [JsonProperty("topic")]
        public Topic Topic { get; set; }
    }
}