using Abot.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrapJunker.Crawler.Core.Interface;
using Abot.Poco;
using ScrapJunker.Infrastructure.Core.Interface;

namespace ScrapJunker.Crawler.Abot
{
    public class AbotPoliteCrawler : Base.Crawler
    {
        private PoliteWebCrawler _crawler;
        private readonly ILogger _logger;

        public AbotPoliteCrawler(ILogger logger)
        {
            _logger = logger;
        }

        public override void Configure(ICrawlerConfiguration configuration)
        {
            var abotCrawlConfiguration = new CrawlConfiguration();
            abotCrawlConfiguration.CrawlTimeoutSeconds = configuration.CrawlTimeoutSeconds;
            abotCrawlConfiguration.MaxConcurrentThreads = configuration.MaxConcurrentThreads;
            abotCrawlConfiguration.MaxPagesToCrawl = configuration.MaxPagesToCrawl;
            abotCrawlConfiguration.UserAgentString = configuration.UserAgentString;
            //

            _crawler = new PoliteWebCrawler(abotCrawlConfiguration);

            foreach (var eventHandler in configuration.EventHandlers)
            {
                eventHandler.Register(_crawler);
            }
        }

        public override void Run(string uri)
        {
            if (_crawler != null)
                _crawler.Crawl(new Uri(uri));
            else
                _logger.Log("Crawler not configured");
        }
    }
}
