using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using NewsMonitor.API.ConsoleHost.Models.NewsSources;
using NewsMonitor.API.ConsoleHost.Models.TopicRepository;
using NewsMonitor.API.Models;

namespace NewsMonitor.API.ConsoleHost.Controllers
{
    [RoutePrefix("v1/news-sources")]
    public class NewsSourcesController : ApiController
    {
        private ITopicsRepository _repository;

        public NewsSourcesController(ITopicsRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        [HttpGet]
        [Route("names")]
        public async Task<List<string>>  GetNewsSourceNames()
        {
            return await _repository.GetNewsSourcesNames().ConfigureAwait(false);
        }

        [HttpPost]
        [Route("articles")]
        public async Task<GetArticlesResponse> GetArticles(GetArticlesRequest request)
        {
           var result= await _repository.GetNewsSourceArticles(request.SourceName, 
                request.ItemsPerPage, 
                request.PageNumber)
                .ConfigureAwait(false);

            return new GetArticlesResponse
            {
                Request = request,
                Articles = result.NewsSource,
                TotalArticlesCount = result.TotalArticlesCount
            };
        }
    }
}