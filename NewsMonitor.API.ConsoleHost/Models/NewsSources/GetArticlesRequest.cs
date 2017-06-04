using NewsMonitor.API.Models;
using Newtonsoft.Json;

namespace NewsMonitor.API.ConsoleHost.Models.NewsSources
{
    public class GetArticlesRequest
    {
        [JsonProperty("newsSourceName")]
        public string SourceName { get; set; }

        [JsonProperty("itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }
    }
}