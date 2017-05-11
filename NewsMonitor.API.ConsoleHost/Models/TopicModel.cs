using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMonitor.API.ConsoleHost.Models
{
    public class TopicModel
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Keyword { get; set; }

        public string Description { get; set; }

    }
}
