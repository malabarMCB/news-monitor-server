using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.Topics.GetArticles
{
    public class GetArticlesModel
    {
        [JsonProperty("newsSourceName")]
        public string NewsSourceName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}