using NewsMonitor.API.Models;

namespace NewsMonitor.API.ConsoleHost.Models.NewsSources
{
    public class GetNSArticles
    {
        public NewsSourceModel NewsSource { get; set; }

        public int TotalArticlesCount { get; set; }
    }
}