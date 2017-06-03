using System;

namespace NewsMonitor.API.Models.ArticleModel
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Keyword { get; set; }

        public string Text { get; set; }
    }
}
