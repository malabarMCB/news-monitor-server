using System;
using System.Collections.Generic;
using NewsMonitor.API.Models.Article;
using Newtonsoft.Json;

namespace NewsMonitor.API.Models
{
    public class NewsSourceModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [JsonProperty("newsSourceName")]
        public string Name { get; set; }

        [JsonProperty("articles")]
        public List<ArticleModel> Articles { get; set; }
    }
}
