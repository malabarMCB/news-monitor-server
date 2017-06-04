using System;
using Newtonsoft.Json;

namespace NewsMonitor.API.Models.Article
{
    public class ArticleModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public ArticleModel()
        {
            Id = Guid.NewGuid();
        }
    }
}