using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsMonitor.API.ConsoleHost.Models.AddTopic;
using NewsMonitor.API.ConsoleHost.Models.NewsSources;
using NewsMonitor.API.ConsoleHost.Models.Topics.AddTopic;
using NewsMonitor.API.ConsoleHost.Models.Topics.GetArticles;
using NewsMonitor.API.ConsoleHost.Models.Topics.Info;
using NewsMonitor.API.ConsoleHost.Models.Topics.Search;
using NewsMonitor.API.Models;
using NewsMonitor.API.Models.Article;

namespace NewsMonitor.API.ConsoleHost.Models.TopicRepository
{
    //TODO add ctor
    public class StaticTopicsRepository : ITopicsRepository
    {
        private static readonly List<string> _sourcesNames = new List<string>
        {
            "NY Times",
            "Associated Press",
            "Reuters"
        };

        private static List<TopicModel> _topics = new List<TopicModel>
        {
            new TopicModel
            {
                Date = new DateTime(2015, 03, 21),
                Description = "Here we have some sport events",
                Keyword = "Sport",
                Title = "Sport events",
                NewsSources = new List<NewsSourceModel>
                {
                    new NewsSourceModel
                    {
                        Name = "NY Times",
                        Articles = new List<ArticleModel>
                        {
                            new ArticleModel
                            {
                                Date = new DateTime(2017, 02, 03),
                                Title = "Juventus Enters Champions League Final With More Than a Title at Stake",
                                Text =
                                    "Juventus will try to shake past losses in the title game and become the equal of Europe’s superpowers when it faces Real Madrid on Saturday.",
                                Url =
                                    "https://www.nytimes.com/2017/06/02/sports/soccer/juventus-enters-champions-league-final-with-more-than-a-title-at-stake.html?rref=collection%2Fsectioncollection%2Fsports&action=click&contentCollection=sports&region=rank&module=package&version=highlights&contentPlacement=1&pgtype=sectionfront&_r=0"
                            },
                            new ArticleModel
                            {
                                Date = new DateTime(2017, 06, 03),
                                Title = "This Time, Matt Harvey Struggles Against the Pirates",
                                Text =
                                    "After looking sharp against Pittsburgh in his last start, Harvey allowed six runs in five-plus innings as the Mets lost their third straight game.",
                                Url =
                                    "https://www.nytimes.com/2017/06/03/sports/baseball/mets-matt-harvey-pirates.html?rref=collection%2Fsectioncollection%2Fsports&action=click&contentCollection=sports&region=rank&module=package&version=highlights&contentPlacement=2&pgtype=sectionfront"
                            }
                        }
                    },
                    new NewsSourceModel
                    {
                        Name = "Associated Press",
                        Articles = new List<ArticleModel>
                        {
                            new ArticleModel
                            {
                                Date = new DateTime(2017, 05, 17),
                                Title = "AP to publish first all-time college basketball ranking",
                                Text =
                                    "The Associated Press will rank the nation’s all-time top men’s college basketball programs for the first time.",
                                Url = "https://www.ap.org/en-gb/topics/sports#"
                            }
                        }
                    }
                }
            },
            new TopicModel
            {
                Date = new DateTime(2017, 02, 12),
                Description = "Some business news for you",
                Keyword = "Business",
                Title = "Business events",
                NewsSources = new List<NewsSourceModel>
                {
                    new NewsSourceModel
                    {
                        Name = "NY Times",
                        Articles = new List<ArticleModel>
                        {
                            new ArticleModel
                            {
                                Date = new DateTime(2017, 04, 13),
                                Title = "Apple Piles On the Apps, and Users Say, ‘Enough!’",
                                Text =
                                    "The company will show off new features for the iPhone and other products on Monday, but customers are still struggling to get comfortable with the last round of improvements.",
                                Url =
                                    "https://www.nytimes.com/2017/06/02/technology/apple-iphone-developer-conference.html"
                            }
                        }
                    },
                    new NewsSourceModel
                    {
                        Name = "Associated Press",
                        Articles = new List<ArticleModel>
                        {
                            new ArticleModel
                            {
                                Date = new DateTime(2017, 03, 08),
                                Title = "AP receives 4 awards from Deadline Club",
                                Text =
                                    "We were pleased to receive four awards on Monday evening from the Deadline Club, the New York City chapter of the Society of Professional Journalists.",
                                Url = "https://blog.ap.org/announcements/ap-receives-4-awards-from-deadline-club"
                            }
                        }
                    },
                    new NewsSourceModel
                    {
                        Name = "Reuters",
                        Articles = new List<ArticleModel>
                        {
                            new ArticleModel
                            {
                                Date = new DateTime(2017, 05, 21),
                                Title = "Big U.S. companies stay on White House panel despite climate jolt",
                                Text =
                                    "WASHINGTON Several major U.S. companies, including Wal-Mart Stores Inc , JP Morgan Chase & Co and IBM Corp",
                                Url = "http://www.reuters.com/article/us-usa-climatechange-ceos-idUSKBN18T2MC"
                            }
                        }
                    }
                }
            }
        };

        public Task<TopicModel> Get(int id)
        {
            var result = (id < 0 || id >= _topics.Count)
                ? null
                : _topics[id];

            return Task.FromResult(result);
        }

        //items per page <0 throw argexceprion
        // page num -||-
        public Task<SearchResponse> SearchTopic(string nameSearchPattern, int itemsPerPage, int pageNumber)
        {
            var topics = _topics
                .OrderBy(t => t.Title)
                .Where(t => t.Title.Contains(nameSearchPattern))
                .Skip(itemsPerPage * pageNumber)
                .Take(itemsPerPage)
                .Select(t => new SearchTopicModel
                {
                    Id = t.Id,
                    Title = t.Title
                })
                .ToList();

            var topicsCount = topics
                .Count(t => t.Title.Contains(nameSearchPattern));

            var result = new SearchResponse
            {
                Items = topics,
                TotalItemsCount = topicsCount
            };

            return Task.FromResult(result);
        }

        public Task<TopicInfoModel> GetTopicInfo(Guid id)
        {
            var result = _topics
                .Where(t => t.Id == id)
                .Select(t => new TopicInfoModel
                {
                    Id = t.Id,
                    Date = t.Date,
                    Description = t.Description,
                    Keyword = t.Keyword,
                    Title = t.Title
                }).ToList();

            return Task.FromResult(result[0]);
        }

        public Task<int> CountTopicArticles(Guid id)
        {
            var newsSources = _topics
                .Where(t => t.Id == id)
                .Select(t => t.NewsSources);

            int result = 0;
            foreach (var articel in newsSources)
                result += articel.Count;

            return Task.FromResult(result);
        }

        public Task<List<GetArticlesModel>> GetTopicArticles(Guid id, int itemsPerPage, int pageNumber)
        {
            var result = (from t in _topics
                    where t.Id == id
                    from source in t.NewsSources
                    from article in source.Articles
                    select new GetArticlesModel
                    {
                        NewsSourceName = source.Name,
                        Title = article.Title,
                        Url = article.Url
                    })
                .OrderBy(am => am.Title)
                .Skip(itemsPerPage * pageNumber)
                .Take(itemsPerPage)
                .ToList();

            return Task.FromResult(result);
        }

        public Task<List<string>> GetNewsSourcesNames()
        {
            return Task.FromResult(_sourcesNames);
        }

        public Task<GetNSArticles> GetNewsSourceArticles(string sourceName, int itemsPerPage, int pageNumber)
        {
            var articles = (from t in _topics
                from source in t.NewsSources
                where source.Name == sourceName
                from artcl in source.Articles
                orderby artcl.Title
                group artcl by artcl.Id
                into g
                select g.First()
            ).ToList();


            var resultArticles = articles
                .Skip(itemsPerPage * pageNumber)
                .Take(itemsPerPage)
                .ToList();

            var result = new GetNSArticles
            {
                NewsSource = new NewsSourceModel
                {
                    Name = sourceName,
                    Articles = resultArticles
                },
                TotalArticlesCount = articles.Count
            };

            return Task.FromResult(result);
        }

        public Task<List<NewsSourceModel>> GetTopicNewsSourcesArticles(Guid id)
        {
            var result = (from t in _topics
                    where t.Id == id
                    from source in t.NewsSources
                    select source)
                .ToList();

            return Task.FromResult(result);
        }

        public Task AddTopic(TopicInfo info, List<NewsSourceModel> sources)
        {
            _topics.Add(new TopicModel
            {
                Date = info.Date,
                Description = info.Description,
                Keyword = info.Keyword,
                Title = info.Title,
                NewsSources = sources
            });

            return Task.FromResult(0);
        }

        public Task EditTopic(Guid id, TopicInfo info, List<NewsSourceModel> sources)
        {
            var topic = _topics.Find(t => t.Id == id);

            topic.Title = info.Title;
            topic.Description = info.Description;
            topic.Keyword = info.Keyword;
            topic.Date = info.Date;
            topic.NewsSources = sources;

            return Task.FromResult(0);
        }
    }
}