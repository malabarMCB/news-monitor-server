using System.Collections.Generic;

namespace NewsMonitor.API.Models.ArticleModel.ArticleSearchResult
{
    public class ArticleSearchResult
    {
        public ArticleSearchRequest Request { get; set; }

        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public List<ArticleModel> PageItems { get; set; }
    }
}
