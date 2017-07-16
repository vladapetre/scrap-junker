using ScrapJunker.Crawler.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Crawler.Base
{
    public class CrawlerConfiguration : ICrawlerConfiguration
    {
        public int CrawlTimeoutSeconds
        {
            get;set;
        }

        public IEnumerable<Infrastructure.Core.Interface.IEventHandler> EventHandlers
        {
            get; set;
        }

        public int MaxConcurrentThreads
        {
            get; set;
        }

        public int MaxPagesToCrawl
        {
            get; set;
        }

        public string UserAgentString
        {
            get; set;
        }
    }
}
