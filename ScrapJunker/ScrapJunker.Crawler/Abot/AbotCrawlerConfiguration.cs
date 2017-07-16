using ScrapJunker.Crawler.Abot.Events;
using ScrapJunker.Crawler.Base;
using ScrapJunker.Infrastructure.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Crawler.Abot
{
    public class AbotCrawlerConfiguration : CrawlerConfiguration
    {
        public AbotCrawlerConfiguration(
            IPageCrawlCompletedAsyncEventHandler pageCrawlComplededAsynchEventHandler
            )
        {
            EventHandlers = new List<IEventHandler>
            {
                pageCrawlComplededAsynchEventHandler
            };

            UserAgentString = "ScrapJunker Test Abot Crawler v1";
        }
    }
}
