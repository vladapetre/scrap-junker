using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Crawler.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Crawler.Api.CQRS.Command
{
    public class RunCrawlerCommand : ICommand
    {
        public RunCrawlerConfigurationDto RunCrawlerConfigurationDto { get; private set; }
        public RunCrawlerCommand(RunCrawlerConfigurationDto runCrawlerConfigurationDto)
        {
            RunCrawlerConfigurationDto = runCrawlerConfigurationDto;
        }
    }
}