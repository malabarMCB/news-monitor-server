using System;
using System.Collections.Generic;
using System.Web.Http;
using NewsMonitor.API.ConsoleHost.Models;

namespace NewsMonitor.API.ConsoleHost.Controllers
{
    [RoutePrefix("topics")]
    public class TopicsController:ApiController
    {
        List<TopicModel> topics =new List<TopicModel>
        {
            new TopicModel {Date=new DateTime(2015,3,21),Description="topic 0 bla-bla-bla",
                Keyword ="key0", Title ="Topic 0"},

            new TopicModel {Date=new DateTime(2017,02,12),Description="topic 1.......",
                Keyword ="key1", Title ="Topic 1"}
        };

        [HttpGet]
        [Route ("{id:int}")]
        public TopicModel GetTopic(int id)
        {
            return topics[id];
        }
    }
}
