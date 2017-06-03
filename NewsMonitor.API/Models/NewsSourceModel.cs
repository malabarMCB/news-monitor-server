using System;
using System.Collections.Generic;

namespace NewsMonitor.API.Models
{
    public class NewsSourceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<ArticleModel> Articles { get; set; }
    }
}
