using ScrapJunker.Infrastructure.Core.Interface;
using System.Collections.Generic;

namespace ScrapJunker.Crawler.Core.Interface
{
    public interface ICrawlerConfiguration
    {
        int CrawlTimeoutSeconds { get; set; }
        int MaxConcurrentThreads { get; set; }
        int MaxPagesToCrawl { get; set; }
        string UserAgentString { get; set; }

        IList<IEventHandler> EventHandlers { get; set; }
    }
}
