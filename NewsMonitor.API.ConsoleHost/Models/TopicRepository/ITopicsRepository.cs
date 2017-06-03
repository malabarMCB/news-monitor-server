using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsMonitor.API.ConsoleHost.Models.Topics.GetArticles;
using NewsMonitor.API.ConsoleHost.Models.Topics.Info;
using NewsMonitor.API.ConsoleHost.Models.Topics.Search;
using NewsMonitor.API.Models;

namespace NewsMonitor.API.ConsoleHost.Models.TopicRepository
{
    public interface ITopicsRepository
    {
        Task<TopicModel> Get(int id);

        Task<SearchResponse> Search(string nameSearchPattern, int itemsPerPage, int pageNumber);

        Task<TopicInfoModel> Info(Guid id);

        Task<int> CountArticles(Guid id);

        Task<List<GetArticlesModel>> GetArticles(Guid id, int itemsPerPage, int pageNumber);
    }
}