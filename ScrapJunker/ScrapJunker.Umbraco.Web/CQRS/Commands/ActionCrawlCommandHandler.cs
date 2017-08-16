using ScrapJunker.CQRS.Core.Interface;
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

        public ActionCrawlCommandHandler(IUmbContentServiceFactory umbContentServiceFactory, IUmbAlias umbAlias)
        {
            _umbContentServiceFactory = umbContentServiceFactory;
            _umbAlias = umbAlias;
        }
        public void Handle(ActionCrawlCommand command)
        {

            Validate(command);

            throw new NotImplementedException("Validation Passed");
        }

        public void Validate(ActionCrawlCommand command)
        {
            var crawledPageContentService = _umbContentServiceFactory.Create(_umbAlias.DocType_CrawledPage);

            var rootCrawledPages = crawledPageContentService.GetByParentId<IContent>(command.RunCrawlerConfigurationDto.Id).Where(page=>page.HasProperty(_umbAlias.Property_IsRoot) && page.GetValue<bool>(_umbAlias.Property_IsRoot));

            if ((rootCrawledPages.Count() >= 2) && rootCrawledPages.All(page=> !page.HasProperty(_umbAlias.Property_AbsoluteUri) || page.GetValue<string>(_umbAlias.Property_AbsoluteUri) != new Uri(command.RunCrawlerConfigurationDto.Url).AbsoluteUri))
            {
                throw new InvalidOperationException($"Cannot crawl anymore, limit reached. Please clean your documents before trying again!");
            }

        }
    }
}