using NewsMonitor.API.Models;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.NewsSources
{
    public class GetArticlesResponse
    {
        [JsonProperty("request")]
        public GetArticlesRequest Request { get; set; }

        [JsonProperty("articleList")]
        public NewsSourceModel Articles { get; set; }

        [JsonProperty("articlesCount")]
        public int TotalArticlesCount { get; set; }
    }
}