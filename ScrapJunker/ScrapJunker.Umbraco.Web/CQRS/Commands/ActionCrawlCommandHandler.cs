using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Infrastructure.Core.Interface;
using ScrapJunker.Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace ScrapJunker.Umbraco.Web.CQRS.Commands
{
    public class ActionCrawlCommandHandler : ICommandHandler<ActionCrawlCommand>
    {
        private readonly IUmbContentServiceFactory _umbContentServiceFactory;
        private readonly IUmbAlias _umbAlias;
        private readonly IHttpClientWrapper _httpClientWrapper;

        public ActionCrawlCommandHandler(IUmbContentServiceFactory umbContentServiceFactory, IUmbAlias umbAlias, IHttpClientWrapper httpClientWrapper)
        {
            _umbContentServiceFactory = umbContentServiceFactory;
            _umbAlias = umbAlias;
            _httpClientWrapper = httpClientWrapper;
        }

        public void Handle(ActionCrawlCommand command)
        {
       
            command.RunCrawlerConfigurationDto.CrawlTimeoutSeconds = 30;
            command.RunCrawlerConfigurationDto.MaxConcurrentThreads = 2;
            command.RunCrawlerConfigurationDto.MaxPagesToCrawl = 15;

            _httpClientWrapper.Post(@"http://scrapjunker.crawler.api:8020/run", command.RunCrawlerConfigurationDto);
        }

       
    }
}