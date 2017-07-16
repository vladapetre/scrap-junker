using Abot.Crawler;
using System;
using ScrapJunker.Crawler.Core.Interface;
using Abot.Poco;
using ScrapJunker.Infrastructure.Core.Interface;
using System.Threading.Tasks;

namespace ScrapJunker.Crawler.Abot
{
    public class AbotPoliteCrawler : Base.Crawler
    {
        private PoliteWebCrawler _crawler;
        private ICrawlerConfiguration _crawlerConfiguration;
        private readonly ILogger _logger;

        public override ICrawlerConfiguration Configuration => _crawlerConfiguration;

        public AbotPoliteCrawler(ILogger logger, ICrawlerConfiguration crawlerConfiguration)
        {
            _logger = logger;
            _crawlerConfiguration = crawlerConfiguration;
        }
      
        public override void Run(string uri)
        {
            if (_crawlerConfiguration != null)
                InitializeCrawler();

            if (_crawler != null)
                _crawler.Crawl(new Uri(uri));
            else
                _logger.Log("Crawler not configured");
        }

        public override Task RunAsync(string uri)
        {
            return Task.Run(() => Run(uri));
        }

        public override void Configure(ICrawlerConfiguration configuration)
        {
            _crawlerConfiguration = configuration;
        }

        protected void InitializeCrawler()
        {
            var abotCrawlConfiguration = new CrawlConfiguration();
            abotCrawlConfiguration.CrawlTimeoutSeconds = _crawlerConfiguration.CrawlTimeoutSeconds;
            abotCrawlConfiguration.MaxConcurrentThreads = _crawlerConfiguration.MaxConcurrentThreads;
            abotCrawlConfiguration.MaxPagesToCrawl = _crawlerConfiguration.MaxPagesToCrawl;
            abotCrawlConfiguration.UserAgentString = _crawlerConfiguration.UserAgentString;
            //

            _crawler = new PoliteWebCrawler(abotCrawlConfiguration);

            foreach (var eventHandler in _crawlerConfiguration.EventHandlers)
            {
                eventHandler.Register(_crawler);
            }
        }

    }
}
