using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewsMonitor.API.ConsoleHost.Models.ArticleModel.ArticleSearchResult
{
    public class ArticleSearchResult
    {
        public ArticleSearchRequest Request { get; set; }

        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public List<ArticleModel> PageItems { get; set; }
    }
}
