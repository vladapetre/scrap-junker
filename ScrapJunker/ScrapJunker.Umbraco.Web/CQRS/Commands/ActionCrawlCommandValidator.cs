using ScrapJunker.CQRS.Base;
using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace ScrapJunker.Umbraco.Web.CQRS.Commands
{
    public class ActionCrawlCommandValidator : ICommandValidator<ActionCrawlCommand>
    {
        private readonly IUmbContentServiceFactory _umbContentServiceFactory;
        private readonly IUmbAlias _umbAlias;

        public ActionCrawlCommandValidator(IUmbAlias umbAlias, IUmbContentServiceFactory umbContentServiceFactory)
        {
            _umbContentServiceFactory = umbContentServiceFactory;
            _umbAlias = umbAlias;
        }

        public ICommandResult Validate(ActionCrawlCommand command)
        {
            var result = new CommandResult();

            var crawledPageContentService = _umbContentServiceFactory.Create(_umbAlias.DocType_CrawledPage);

            var rootCrawledPages = crawledPageContentService.GetByParentId<IContent>(command.RunCrawlerConfigurationDto.Id).Where(page => page.HasProperty(_umbAlias.Property_IsRoot) && page.GetValue<bool>(_umbAlias.Property_IsRoot));

            if ((rootCrawledPages.Count() >= 2) && rootCrawledPages.All(page => !page.HasProperty(_umbAlias.Property_AbsoluteUri) || page.GetValue<string>(_umbAlias.Property_AbsoluteUri) != new Uri(command.RunCrawlerConfigurationDto.Url).AbsoluteUri))
            {
                result.Errors.Add($"Cannot crawl anymore, limit reached. Please clean your documents before trying again!");
            }

            return result;
        }
    }
}
