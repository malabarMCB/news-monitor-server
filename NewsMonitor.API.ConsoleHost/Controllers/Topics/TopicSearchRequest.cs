namespace NewsMonitor.API.ConsoleHost.Controllers.Topics
{
    public class TopicSearchRequest
    {
        public string NameSearchPattern { get; set; }
        public PageInfo Page { get; set; }
    }
}