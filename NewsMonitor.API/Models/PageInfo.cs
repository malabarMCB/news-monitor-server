using Newtonsoft.Json;

namespace NewsMonitor.API.Models
{
    public struct PageInfo
    {
        [JsonProperty("itemsPerPage")]
        public int ItemsPerPage { get; set; }

        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }
    }
}