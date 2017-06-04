using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsMonitor.API.ConsoleHost.Models.AddTopic;
using NewsMonitor.API.ConsoleHost.Models.NewsSources;
using NewsMonitor.API.ConsoleHost.Models.Topics.AddTopic;
using NewsMonitor.API.ConsoleHost.Models.Topics.GetArticles;
using NewsMonitor.API.ConsoleHost.Models.Topics.Info;
using NewsMonitor.API.ConsoleHost.Models.Topics.Search;
using NewsMonitor.API.Models;

namespace NewsMonitor.API.ConsoleHost.Models.TopicRepository
{
    public interface ITopicsRepository
    {
        Task<TopicModel> Get(int id);

        Task<SearchResponse> SearchTopic(string nameSearchPattern, int itemsPerPage, int pageNumber);

        Task<TopicInfoModel> GetTopicInfo(Guid id);

        Task<int> CountTopicArticles(Guid id);

        Task<List<GetArticlesModel>> GetTopicArticles(Guid id, int itemsPerPage, int pageNumber);

        Task<List<string>> GetNewsSourcesNames();

        Task<GetNSArticles> GetNewsSourceArticles(string sourceName, int itemsPerPage, int pageNumber);

        Task<List<NewsSourceModel>> GetTopicNewsSourcesArticles(Guid id);

        Task AddTopic(TopicInfo info, List<NewsSourceModel> sources);

        Task EditTopic(Guid id, TopicInfo info, List<NewsSourceModel> sources);
    }
}