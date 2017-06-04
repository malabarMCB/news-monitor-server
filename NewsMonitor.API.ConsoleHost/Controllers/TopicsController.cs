using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using NewsMonitor.API.ConsoleHost.Models.AddTopic;
using NewsMonitor.API.ConsoleHost.Models.TopicRepository;
using NewsMonitor.API.ConsoleHost.Models.Topics.EditTopic;
using NewsMonitor.API.ConsoleHost.Models.Topics.GetArticles;
using NewsMonitor.API.ConsoleHost.Models.Topics.Search;
using NewsMonitor.API.Models;

namespace NewsMonitor.API.ConsoleHost.Controllers
{
    [RoutePrefix("v1/topics")]
    public class TopicsController : ApiController
    {
        private  ITopicsRepository _repository;

        public TopicsController(ITopicsRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            _repository = repository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetTopic(int id)
        {
            var result = await _repository.Get(id).ConfigureAwait(false);

            return result == null
                ? (IHttpActionResult) NotFound()
                : Ok(result);
        }

        [HttpPost]
        [Route("search")]
        public async Task<TopicSearchResponse> Search(TopicSearchRequest request)
        {
            var topics = await _repository.SearchTopic(request.NameSearchPattern,
                request.Page.ItemsPerPage,
                request.Page.PageNumber)
                .ConfigureAwait(false);

            return new TopicSearchResponse
            {
                Request = request,
                Items = topics.Items,
                TotalItemsCount = topics.TotalItemsCount
            };
        }

        [HttpGet]
        [Route("{id}/info")]
        public async Task<IHttpActionResult> Info(string id)
        {
            var idGuid = Guid.Parse(id);
            var result= await _repository.GetTopicInfo(idGuid).ConfigureAwait(false);

           return result==null
                 ? (IHttpActionResult)NotFound()
                : Ok(result);
        }

        [HttpGet]
        [Route("{id}/articles/count")]
        public async Task<int> CountArticles(string id)
        {
            var idGuid = Guid.Parse(id);

            return await _repository.CountTopicArticles(idGuid).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("{id}/articles")]
        public async Task<List<GetArticlesModel>> GetArticles(string id, PageInfo pageInfo)
        {
            var idGuid = Guid.Parse(id);

            return await _repository.GetTopicArticles(idGuid,
                pageInfo.ItemsPerPage, 
                pageInfo.PageNumber)
                .ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{id}/news-sources/articles")]
        public async Task<List<NewsSourceModel>> GetNewsSources(string id)
        {
            var idGuid = Guid.Parse(id);

            return await _repository.GetTopicNewsSourcesArticles(idGuid).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddTopic(AddTopicRequest request)
        {
             await _repository.AddTopic(request.Topic.Info, request.Topic.NewsSources)
                .ConfigureAwait(false);

            return Ok(0);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IHttpActionResult> EditTopic(EditTopicRequest request)
        {
            await _repository.EditTopic(Guid.Parse(request.Id),
                request.Topic.Info,
                request.Topic.NewsSources);

            return Ok(0);
        }
    }
}