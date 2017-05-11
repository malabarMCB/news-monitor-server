using System.Threading.Tasks;
using NewsMonitor.API.ConsoleHost.Models;

namespace NewsMonitor.API.ConsoleHost.Controllers.Topics
{
    public interface ITopicsRepository
    {
        Task<TopicModel> Get(int id);

        Task<SearchResponse> Search(string nameSearchPattern, int itemsPerPage, int pageNumber);
    }
}