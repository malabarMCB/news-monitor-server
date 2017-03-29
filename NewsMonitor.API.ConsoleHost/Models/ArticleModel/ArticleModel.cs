using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMonitor.API.ConsoleHost.Models.ArticleModel
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
