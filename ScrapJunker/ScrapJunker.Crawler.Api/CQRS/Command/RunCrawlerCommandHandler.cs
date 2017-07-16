using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Crawler.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Crawler.Api.CQRS.Command
{
    public class RunCrawlerCommandHandler : ICommandHandler<RunCrawlerCommand>
    {
        private readonly ICrawler _crawler;

        public RunCrawlerCommandHandler(ICrawler crawler)
        {
            _crawler = crawler;
        }

        public void Handle(RunCrawlerCommand command)
        {
            _crawler.Configuration.CrawlTimeoutSeconds = command.RunCrawlerConfigurationDto.CrawlTimeoutSeconds ?? 30;
            _crawler.Configuration.MaxConcurrentThreads = command.RunCrawlerConfigurationDto.MaxConcurrentThreads ?? 1;
            _crawler.Configuration.MaxPagesToCrawl = command.RunCrawlerConfigurationDto.MaxPagesToCrawl ?? 100;

            _crawler.Run(command.RunCrawlerConfigurationDto.Url);
        }
    }
}