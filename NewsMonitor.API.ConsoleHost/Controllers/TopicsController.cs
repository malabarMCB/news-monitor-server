using System;
using System.Threading.Tasks;
using System.Web.Http;
using NewsMonitor.API.ConsoleHost.Models.TopicRepository;
using NewsMonitor.API.ConsoleHost.Models.Topics.Search;

namespace NewsMonitor.API.ConsoleHost.Controllers
{
    [RoutePrefix("v1/topics")]
    public class TopicsController : ApiController
    {
        private readonly ITopicsRepository _repository;

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
            var topics = await _repository.Search(request.NameSearchPattern,
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
    }
}