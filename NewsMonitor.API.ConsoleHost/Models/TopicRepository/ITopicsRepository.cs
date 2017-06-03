using System.Threading.Tasks;
using NewsMonitor.API.ConsoleHost.Models.Topics.Search;
using NewsMonitor.API.Models;

namespace NewsMonitor.API.ConsoleHost.Models.TopicRepository
{
    public interface ITopicsRepository
    {
        Task<TopicModel> Get(int id);

        Task<SearchResponse> Search(string nameSearchPattern, int itemsPerPage, int pageNumber);
    }
}