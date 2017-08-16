using ScrapJunker.CQRS.Core.Interface;
using ScrapJunker.Umbraco.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace ScrapJunker.Umbraco.Web.CQRS.Commands
{
    public class CreateCrawledPageCommnandHandler : ICommandHandler<CreateCrawledPageCommnand>
    {
        private readonly IUmbContentServiceFactory _umbContentServiceFactory;
        private readonly IUmbAlias _umbAlias;

        public CreateCrawledPageCommnandHandler(IUmbContentServiceFactory umbContentServiceFactory, IUmbAlias umbAlias)
        {
            _umbContentServiceFactory = umbContentServiceFactory;
            _umbAlias = umbAlias;
        }

        public void Handle(CreateCrawledPageCommnand command)
        {
            /*var umbracoContent = */
            var contentService = _umbContentServiceFactory.Create(_umbAlias.DocType_CrawledPage);
            contentService.SaveOrUpdate(command.ContentDTO, _umbAlias.DocType_CrawledPage);
        }

        public void Validate(CreateCrawledPageCommnand command)
        {
            throw new NotImplementedException();
        }
    }
}