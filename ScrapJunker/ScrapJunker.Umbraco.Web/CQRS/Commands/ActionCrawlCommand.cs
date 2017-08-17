using ScrapJunker.CQRS.Base;
using ScrapJunker.Umbraco.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrapJunker.Umbraco.Web.CQRS.Commands
{
    public class ActionCrawlCommand : Command
    {
        public RunCrawlerConfigurationDto RunCrawlerConfigurationDto { get; private set; }
        public ActionCrawlCommand(Guid id, int version, RunCrawlerConfigurationDto runCrawlerConfigurationDto) : base(id, version)
        {
            RunCrawlerConfigurationDto = runCrawlerConfigurationDto;
        }
    }
}