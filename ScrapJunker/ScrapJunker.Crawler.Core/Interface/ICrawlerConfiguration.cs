using ScrapJunker.Infrastructure.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Crawler.Core.Interface
{
    public interface ICrawlerConfiguration
    {
        int CrawlTimeoutSeconds { get; set; }
        int MaxConcurrentThreads { get; set; }
        int MaxPagesToCrawl { get; set; }
        string UserAgentString { get; set; }

        IEnumerable<IEventHandler> EventHandlers { get; set; }
    }
}
