using System.Collections.Generic;
using System.Web.Http;
using NewsMonitor.API.ConsoleHost.Models;
using NewsMonitor.API.ConsoleHost.Models.ArticleModel;

namespace NewsMonitor.API.ConsoleHost.Controllers
{
    [RoutePrefix("news-sources")]
    public class NewsSourcesController:ApiController
    {
        private readonly List<NewsSourceModel> _sources = new List<NewsSourceModel>
        {
            new NewsSourceModel {Name="first"},
            new NewsSourceModel {Name="second" }
        };

        [HttpGet]
        [Route("{name}/articles")]
        public List<ArticleModel> GetArticleFromCurrentNewsSource(string name)
        {
            List<ArticleModel> result=null;

            foreach (var source in _sources)
                if (source.Name == name)
                    result= new List<ArticleModel>
                    {
                        new ArticleModel {Text="Test" }
                    };

            return result;
        }
    }
}
