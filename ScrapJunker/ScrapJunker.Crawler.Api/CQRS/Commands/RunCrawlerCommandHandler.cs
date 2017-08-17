using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Crawler.Api.Domain;
using ScrapJunker.Crawler.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Crawler.Api.CQRS.Commands
{
    public class RunCrawlerCommandHandler : ICommandHandler<RunCrawlerCommand>
    {
        private readonly ICrawler _crawler;
        private readonly IEventRepository _eventRepository;

        public RunCrawlerCommandHandler(ICrawler crawler, IEventRepository eventRepository)
        {
            _crawler = crawler;
            _eventRepository = eventRepository;

        }

        public void Handle(RunCrawlerCommand command)
        {
            _crawler.Configuration.CrawlTimeoutSeconds = command.RunCrawlerConfigurationDto.CrawlTimeoutSeconds ?? 30;
            _crawler.Configuration.MaxConcurrentThreads = command.RunCrawlerConfigurationDto.MaxConcurrentThreads ?? 1;
            _crawler.Configuration.MaxPagesToCrawl = command.RunCrawlerConfigurationDto.MaxPagesToCrawl ?? 100;

            _crawler.Run(command.RunCrawlerConfigurationDto.Url);

            var aggregate = new TestAggregate(command.Guid, command.RunCrawlerConfigurationDto.Url)
            {
                Version = -1
            };
            _eventRepository.Save<TestAggregate>(aggregate, aggregate.Version);
        }
    }
}