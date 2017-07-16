using ScrapJunker.Crawler.Core.Interface;
using System.Collections.Generic;

namespace ScrapJunker.Crawler.Base
{
    public class CrawlerConfiguration : ICrawlerConfiguration
    {
        public int CrawlTimeoutSeconds
        {
            get;set;
        }

        public IList<Infrastructure.Core.Interface.IEventHandler> EventHandlers
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
