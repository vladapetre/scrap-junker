using ScrapJunker.CQRS.Base;
using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Crawler.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Crawler.Api.CQRS.Commands
{
    public class RunCrawlerCommand : Command
    {
        public RunCrawlerConfigurationDto RunCrawlerConfigurationDto { get; private set; }
        public RunCrawlerCommand(Guid id,int version, RunCrawlerConfigurationDto runCrawlerConfigurationDto) : base(id, version)
        {
            RunCrawlerConfigurationDto = runCrawlerConfigurationDto;
        }
    }
}