using System;
using System.Collections.Generic;
using System.Web.Http;
using NewsMonitor.API.ConsoleHost.Models.ArticleModel;
using NewsMonitor.API.ConsoleHost.Models.ArticleModel.ArticleSearchResult;

namespace NewsMonitor.API.ConsoleHost.Controllers
{
    [RoutePrefix("articles")]
    public class ArticlesController:ApiController
    {
        private List<ArticleModel> articles = new List<ArticleModel>
        {
            new ArticleModel
            {
                Id=0, Date=new DateTime(2010,11,10), Title="Some title 0",
                Keyword="keyword 0", Text="Some text"},

            new ArticleModel
            {
                Id=1, Date=new DateTime(2011,6,21), Title="Title 1",
                Keyword="keyword 1", Text="Another text"}
        };

        [HttpGet]
        [Route("{id:int}")]
        public ArticleModel GetArticle(int id)
        {
            return articles[id];
        }

        [HttpGet]
        [Route("search")]
        public ArticleSearchResult FindArticle(int? year, int? month, int? day,
            string title, string keyword)
        {
            var result = new ArticleSearchResult();
            result.TotalCount = 1;
            return result;
        }
    }
}
