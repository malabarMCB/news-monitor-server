using NewsMonitor.API.ConsoleHost.Models.AddTopic;
using NewsMonitor.API.ConsoleHost.Models.Topics.AddTopic;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.Topics.EditTopic
{
    public class EditTopicRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("topic")]
        public Topic Topic { get; set; }
    }
}