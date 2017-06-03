using System;
using Newtonsoft.Json;

namespace NewsMonitor.API.Models
{
    public class TopicModel
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public TopicModel()
        {
            Id = Guid.NewGuid();
        }

    }
}
